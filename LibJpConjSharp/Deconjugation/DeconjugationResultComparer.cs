using System;
using System.Collections.Generic;
using System.Globalization;

namespace LibJpConjSharp.Deconjugation
{
    internal partial class DeconjugationResultComparer : IComparer<DeconjugationResult>
    {
        public int Compare(DeconjugationResult x, DeconjugationResult y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            
            // First try comparing the words as-is based on their frequency.
            var strictCompare = CompareFrequency(x.Base, y.Base);
            if (strictCompare != 0)
            {
                return strictCompare;
            }

            var suruVerbCompare = CompareFrequency(TryGetSuruVerb(x.Base), TryGetSuruVerb(y.Base));
            if (suruVerbCompare != 0)
            {
                return suruVerbCompare;
            }

            return Comparer<int>.Default.Compare(x.Base.Length, y.Base.Length);
        }

        public string TryGetSuruVerb(string x)
        {
            if (x.EndsWith("する"))
            {
                return x.Substring(0, x.Length - 2);
            }

            return x;
        }

        public int CompareFrequency(string x, string y)
        {
            var xFrequencyIsKnown = WordFrequency.TryGetValue(x, out var xFrequency);
            var yFrequencyIsKnown = WordFrequency.TryGetValue(y, out var yFrequency);

            if (xFrequencyIsKnown && yFrequencyIsKnown)
            {
                return Comparer<int>.Default.Compare(xFrequency, yFrequency);
            }
            else if(xFrequencyIsKnown)
            {
                return -1;
            }
            else if (yFrequencyIsKnown)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static IReadOnlyDictionary<string, int> WordFrequency { get; } = CreateWordFrequencyDictionary();

        private static IReadOnlyDictionary<string,int> CreateWordFrequencyDictionary()
        {
            var dict = new Dictionary<string, int>();
            var split = wordFrequency.Split('|');
            for (int i = 0; i < split.Length; i += 2)
            {
                dict.Add(split[i], int.Parse(split[i+1], CultureInfo.InvariantCulture));
            }

            return dict;
        }
    }
}