
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LibJpConjSharp.Tests
{
    public class Basic
    {
        [Test]
        public void Awaseru()
        {
            var word = "あわせる";
            var wordClass = EdictType.v1;
            Assert.AreEqual("あわせ||ない", JpConj.Conjugate(word, wordClass, CForm.Present, Politeness.Plain, Polarity.Negative));
            Assert.AreEqual("あわせ||て", JpConj.Conjugate(word, wordClass, CForm.TeForm, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("あわせ||た", JpConj.Conjugate(word, wordClass, CForm.Past, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("あわせ||ます", JpConj.Conjugate(word, wordClass, CForm.Present, Politeness.Polite));
        }

        [Test]
        public void Suru()
        {
            var word = "する";
            var wordClass = EdictType.vs_i;
            
            Assert.AreEqual("|し|て", JpConj.Conjugate(word, wordClass, CForm.TeForm, Politeness.Plain, Polarity.Affirmative));

        }

        [Test]
        public void StringMethodsTest()
        {
            Assert.AreEqual("a", Utils.Right("aaa", 1));
            Assert.AreEqual("aaa", Utils.Right("aaa", 5));
            Assert.AreEqual("", Utils.Right("aaa", 0));
            Assert.AreEqual("aaa", Utils.Right("aaa", -1));
        }
    }
}
