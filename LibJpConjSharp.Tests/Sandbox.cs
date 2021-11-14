using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using LibJpConjSharp.Deconjugation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LibJpConjSharp.Tests
{
    public class Sandbox
    {
        [Test]
        [Explicit]
        public void SandboxTest()
        {
            foreach (var result in JpConj.Deconjugate("されたくない"))
            {
                Console.WriteLine($"------ {result.Base} ------");
                var derivations = Enumerable.Zip(
                    result.DerivationPath,
                    result.CurrentDerivationSequence,
                    (derivation, word) => new { derivation, word });
                foreach (var derivation in derivations)
                {
                    Console.WriteLine($"{derivation.word}: {derivation.derivation.ToLongString()}");
                }
            }
        }
    }
}