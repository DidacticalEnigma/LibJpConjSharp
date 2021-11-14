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
using System.Collections.Immutable;
using System.Linq;

namespace LibJpConjSharp.Deconjugation
{
    internal class DerivationSequence
    {
        public ImmutableList<DerivationRule> AllDerivationsTaken { get; }
        
        public ImmutableList<DerivationRule> NonSilentDerivationsTaken { get; }
        
        public ImmutableList<string> NonSilentWordFormProgression { get; }

        public DerivationSequence(
            ImmutableList<DerivationRule> allDerivationsTaken,
            ImmutableList<DerivationRule> nonSilentDerivationsTaken,
            ImmutableList<string> nonSilentWordFormProgression)
        {
            AllDerivationsTaken = allDerivationsTaken ??
                throw new ArgumentNullException(nameof(allDerivationsTaken));
            NonSilentDerivationsTaken = nonSilentDerivationsTaken ??
                throw new ArgumentNullException(nameof(nonSilentDerivationsTaken));
            NonSilentWordFormProgression = nonSilentWordFormProgression ??
                throw new ArgumentNullException(nameof(nonSilentWordFormProgression));
        }

        public DerivationSequence()
        {
            NonSilentDerivationsTaken = ImmutableList<DerivationRule>.Empty;
            NonSilentWordFormProgression = ImmutableList<string>.Empty;
            AllDerivationsTaken = ImmutableList<DerivationRule>.Empty;
        }

        public DerivationSequence With(
            ImmutableList<DerivationRule> allDerivationsTaken = null,
            ImmutableList<DerivationRule> nonSilentDerivationsTaken = null,
            ImmutableList<string> nonSilentWordFormProgression = null)
        {
            return new DerivationSequence(
                allDerivationsTaken ?? this.AllDerivationsTaken,
                nonSilentDerivationsTaken ?? this.NonSilentDerivationsTaken,
                nonSilentWordFormProgression ?? this.NonSilentWordFormProgression);
        }

        public DerivationSequence AddDerivation(DerivationRule derivationRule, string derivedWord)
        {
            bool derivationIsSilent = derivationRule.Attributes.Contains(DerivationAttribute.Silent);
            
            return With(
                allDerivationsTaken: AllDerivationsTaken.Add(derivationRule),
                nonSilentDerivationsTaken: !derivationIsSilent ? NonSilentDerivationsTaken.Add(derivationRule) : null,
                nonSilentWordFormProgression: !derivationIsSilent ? NonSilentWordFormProgression.Add(derivedWord) : null);
        }

        public bool IsInvalidDerivation()
        {
            /*
             * Check if any derivation in the sequence follows a sequence of derivations
             * that it's not allowed to follow.
             */
            for (int i = 0; i < AllDerivationsTaken.Count; i++)
            {
                var derivation = AllDerivationsTaken[i];

                foreach (var forbiddenPredecessorSequence in derivation.CannotFollow)
                {
                    int nextDerivationOffset = 1;
                    
                    /*
                     * The forbidden predecessor sequences are expressed in forward-order in derivations.js,
                     * because they are easier to think about that way. But the conjugation code works in
                     * reverse order, so we have to consider the forbidden predecessor sequences in reverse
                     * order also. So start at the back of the sequence.
                     */

                    for (int g = forbiddenPredecessorSequence.Count - 1; g >= 0; --g, ++nextDerivationOffset)
                    {
                        var nextDerivation = AllDerivationsTaken.ElementAtOrDefault(i + nextDerivationOffset);
                        if (nextDerivation == null ||
                            nextDerivation.ConjugatedWordType != forbiddenPredecessorSequence[g])
                        {
                            break;  // A forbidden predecessor sequence was matched. Return true.
                        }

                        if (g == 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false; // No forbidden predecessor sequence was matched.
        }
    }
}