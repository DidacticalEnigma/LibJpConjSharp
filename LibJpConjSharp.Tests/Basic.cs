
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
        public void Ichidan()
        {
            var word = "あわせる";
            var wordClass = EdictType.v1;
            Assert.AreEqual("あわせ||ない", JpConj.Conjugate(word, wordClass, CForm.Present, Politeness.Plain, Polarity.Negative));
            Assert.AreEqual("あわせ||て", JpConj.Conjugate(word, wordClass, CForm.TeForm, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("あわせ||た", JpConj.Conjugate(word, wordClass, CForm.Past, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("あわせ||ます", JpConj.Conjugate(word, wordClass, CForm.Present, Politeness.Polite));
        }

        [Test]
        [Ignore("archaic verbs not supported yet")]
        public void NidanU()
        {
            var word = "得";
            var wordClass = EdictType.v2a_s;
        }

        [Test]
        [Ignore("archaic verbs not supported yet")]
        public void YodanHuFu()
        {
            var word = "相語らふ";
            var wordClass = EdictType.v4h;
        }

        [Test]
        [Ignore("archaic verbs not supported yet")]
        public void YodanRu()
        {
            var word = "離る";
            var wordClass = EdictType.v4r;
        }

        [Test]
        [Ignore("this one does not exist in JMdict so far, so we can't make a test case for now")]
        public void GodanNotClassified()
        {
            var word = "";
            var wordClass = EdictType.v5;
        }

        [Test]
        public void GodanAru()
        {
            var word = "いらっしゃる";
            var wordClass = EdictType.v5aru;
        }

        [Test]
        public void GodanBu()
        {
            var word = "運ぶ";
            var wordClass = EdictType.v5b;
        }

        [Test]
        public void GodanGu()
        {
            var word = "游ぐ";
            var wordClass = EdictType.v5g;
        }

        [Test]
        public void GodanKu()
        {
            var word = "艶めく";
            var wordClass = EdictType.v5k;
        }

        [Test]
        public void GodanIkuYuku()
        {
            var word = "合点がいく"; // also 冴え行く
            var wordClass = EdictType.v5k_s;
        }

        [Test]
        public void GodanMu()
        {
            var word = "刷り込む";
            var wordClass = EdictType.v5m;
        }

        [Test]
        public void GodanNu()
        {
            var word = "死ぬ";
            var wordClass = EdictType.v5n;
        }

        [Test]
        public void GodanRu()
        {
            var word = "あやまる";
            var wordClass = EdictType.v5r;
        }

        [Test]
        public void GodanRuIrregular()
        {
            var word = "脚がある";
            var wordClass = EdictType.v5r_i;
        }

        [Test]
        public void GodanSu()
        {
            var word = "螫す";
            var wordClass = EdictType.v5s;
        }

        [Test]
        public void GodanTsu()
        {
            var word = "持つ";
            var wordClass = EdictType.v5t;
        }

        [Test]
        public void GodanU()
        {
            var word = "行う";
            var wordClass = EdictType.v5u;
        }

        [Test]
        public void GodanUSpecialClass()
        {
            var word = "信を問う";
            var wordClass = EdictType.v5u_s;
        }

        [Test]
        [Ignore("this one does not exist in JMdict so far, so we can't make a test case for now")]
        public void GodanUru()
        {
            var word = "";
            var wordClass = EdictType.v5uru;
        }

        [Test]
        [Ignore("this one does not exist in JMdict so far, so we can't make a test case for now")]
        public void GodanZu()
        {
            var word = "";
            var wordClass = EdictType.v5z;
        }

        [Test]
        public void IchidanZuru()
        {
            var word = "観ずる";
            var wordClass = EdictType.vz;
        }

        [Test]
        public void Kuru()
        {
            var word = "くる";
            var wordClass = EdictType.vk;

            Assert.AreEqual("き||た", JpConj.Conjugate(word, wordClass, CForm.Past, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("き||て", JpConj.Conjugate(word, wordClass, CForm.TeForm, Politeness.Plain, Polarity.Affirmative));
        }

        [Test]
        public void IrregularNu()
        {
            var word = "死ぬ";
            var wordClass = EdictType.vn;
        }

        [Test]
        public void NounSuru()
        {
            var word = "勉強";
            var wordClass = EdictType.vs;
        }

        [Test]
        public void Su()
        {
            var word = "熟す";
            var wordClass = EdictType.vs_c;
        }

        [Test]
        public void SuruIrregular()
        {
            var word = "する";
            var wordClass = EdictType.vs_i;

            Assert.AreEqual("|し|よう", JpConj.Conjugate(word, wordClass, CForm.Volitional, Politeness.Plain, Polarity.Affirmative));
            Assert.AreEqual("|し|て", JpConj.Conjugate(word, wordClass, CForm.TeForm, Politeness.Plain, Polarity.Affirmative));
        }

        [Test]
        public void SuruSpecial()
        {
            var word = "則する";
            var wordClass = EdictType.vs_s;
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
