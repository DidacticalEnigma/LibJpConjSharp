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
    internal class DerivationRule
    {
        public string UnconjugatedEnding { get; }
        
        public string ConjugatedEnding { get; }
        
        public WordType UnconjugatedWordType { get; }
        
        public WordType ConjugatedWordType { get; }
        
        public IReadOnlyList<DerivationAttribute> Attributes { get; }
        
        public IReadOnlyList<IReadOnlyList<WordType>> CannotFollow { get; }

        public DerivationRule(
            string unconjugatedEnding,
            string conjugatedEnding,
            WordType unconjugatedWordType,
            WordType conjugatedWordType,
            IReadOnlyList<IReadOnlyList<WordType>> cannotFollow = null,
            IReadOnlyList<DerivationAttribute> attributes = null)
        {
            UnconjugatedEnding = unconjugatedEnding
                ?? throw new ArgumentNullException(nameof(unconjugatedEnding));
            ConjugatedEnding = conjugatedEnding
                ?? throw new ArgumentNullException(nameof(conjugatedEnding));
            UnconjugatedWordType = unconjugatedWordType;
            ConjugatedWordType = conjugatedWordType;
            CannotFollow = cannotFollow
                ?? Array.Empty<IReadOnlyList<WordType>>();
            Attributes = attributes
                ?? Array.Empty<DerivationAttribute>();
        }
    }
}