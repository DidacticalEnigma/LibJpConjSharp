// The following file is a part of the port of the project jp-verb-deconjugator to C# 
// https://github.com/mistval/jp-verb-deconjugator
// the following is the license and the copyright notice of the original software
/*
MIT License

Copyright (c) 2017 mistval

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LibJpConjSharp.Deconjugation
{
    internal partial class Deconjugation
    {
        public static IEnumerable<DerivationRule> GetCandidateDerivations(string word, WordType? wordType)
        {
            var candidateDerivations = wordType != null
                ? DerivationRulesForConjugatedWordType[wordType.Value]
                : DerivationRules;

            return candidateDerivations.Where(derivation => word.EndsWith(derivation.ConjugatedEnding));
        }

        public static string UnconjugateWord(string word, DerivationRule derivation)
        {
            return word.Substring(0, word.Length - derivation.ConjugatedEnding.Length) + derivation.UnconjugatedEnding;
        }

        public static IEnumerable<DeconjugationResult> Unconjugate(string word, bool fuzzy, int recursionDepthLimit)
        {
            var results = UnconjugateRecursive(word, (WordType?)null, new DerivationSequence(), 0, recursionDepthLimit);

            if (fuzzy && results.Count == 0)
            {
                var truncatedWord = Utils.RemoveLastCharacter(word);
                while (truncatedWord.Length != 0 && results.Count == 0)
                {
                    results = UnconjugateRecursive(word, null, new DerivationSequence(), 0, recursionDepthLimit);
                    truncatedWord = Utils.RemoveLastCharacter(word);
                }
            }

            return results.OrderBy(x => x, new DeconjugationResultComparer());
        }

        private static IReadOnlyCollection<DeconjugationResult> UnconjugateRecursive(string word, WordType? wordType, DerivationSequence derivationSequence, int level, int levelLimit)
        {
            if (derivationSequence.IsInvalidDerivation())
            {
                return Array.Empty<DeconjugationResult>();
            }

            if (level > levelLimit)
            {
                /*
                 * Recursion is going too deep, abort.
                 *
                 * There should not be any potential for infinite recursion,
                 * however it is difficult to verify with certainty that
                 * there is none. Therefore, a way to break out of the
                 * recursion is provided for safety (relying on running out of space
                 * on the stack and throwing might take too ling)
                 */
                return Array.Empty<DeconjugationResult>();
            }

            var results = new List<DeconjugationResult>();
            var isDictionaryForm =
                wordType == null || wordType == WordType.GodanVerb || wordType == WordType.IchidanVerb;

            // Check if we have reached a potentially valid result, and if so, add it to the results.
            if (isDictionaryForm)
            {
                results.Add(new DeconjugationResult(
                    baseWord: word,
                    derivationPath: derivationSequence.NonSilentDerivationsTaken.Reverse().Select(derivation => derivation.ConjugatedWordType).ToList(),
                    currentDerivationSequence: derivationSequence.NonSilentWordFormProgression.Reverse().ToList()));
            }

            foreach (var candidateDerivation in GetCandidateDerivations(word, wordType))
            {
                var nextDerivationSequence = derivationSequence.AddDerivation(candidateDerivation, word);
                var unconjugatedWord = UnconjugateWord(word, candidateDerivation);
                results.AddRange(UnconjugateRecursive(unconjugatedWord, candidateDerivation.UnconjugatedWordType, nextDerivationSequence, level+1, levelLimit));
            }

            return results;
        }
    }
}