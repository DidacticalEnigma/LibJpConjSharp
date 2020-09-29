
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

        [TestCase("あわせ||て", CForm.TeForm)]
        [TestCase("あわせ|る|", CForm.Present)]
        [TestCase("あわせ||た", CForm.Past)]
        [TestCase("あわせ|れ|ば", CForm.Provision)]
        [TestCase("あわせ||たら", CForm.Condition)]
        [TestCase("あわせ|(ろ/よ)|", CForm.Imperative)]
        [TestCase("あわせ||よう", CForm.Volitional)]
        [TestCase("あわせ||ている", CForm.PresentContinuous)]
        [TestCase("あわせ||ていた", CForm.PastContinuous)]
        [TestCase("あわせ||られる", CForm.Passive)]
        [TestCase("あわせ||させる", CForm.Causative)]
        [TestCase("あわせ||させられる", CForm.CausativePassive)]
        [TestCase("あわせ||られる", CForm.Potential)]
        [TestCase("あわせ||ない", CForm.Present, Politeness.Plain, Polarity.Negative)]
        [TestCase("あわせ||ます", CForm.Present, Politeness.Polite, Polarity.Affirmative)]
        public void Ichidan(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "あわせる";
            var wordClass = EdictType.v1;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
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

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("いらっしゃ|ろ|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        [TestCase("いらっしゃ|い|ます", CForm.Present, Politeness.Polite, Polarity.Affirmative)]
        public void GodanAru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "いらっしゃる"; 
            var wordClass = EdictType.v5aru;
            
            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("運|ぼ|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanBu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "運ぶ";
            var wordClass = EdictType.v5b;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("游|ご|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanGu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "游ぐ";
            var wordClass = EdictType.v5g;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("艶め|こ|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanKu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "艶めく";
            var wordClass = EdictType.v5k;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanIkuYuku(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "合点がいく"; // also 冴え行く
            var wordClass = EdictType.v5k_s;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("刷り込|も|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanMu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "刷り込む";
            var wordClass = EdictType.v5m;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("死|の|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanNu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "死ぬ";
            var wordClass = EdictType.v5n;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("あやま|ろ|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanRu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "あやまる";
            var wordClass = EdictType.v5r;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("あ||ろう", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanRuIrregular(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "ある";
            var wordClass = EdictType.v5r_i;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("螫|そ|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanSu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "螫す";
            var wordClass = EdictType.v5s;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("持|と|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanTsu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "持つ";
            var wordClass = EdictType.v5t;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("行|お|う", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanU(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "行う";
            var wordClass = EdictType.v5u;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void GodanUSpecialClass(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
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

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void IchidanZuru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "観ずる";
            var wordClass = EdictType.vz;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("き||て", CForm.TeForm)]
        [TestCase("く|る|", CForm.Present)]
        [TestCase("き||た", CForm.Past)]
        [TestCase("く|れ|ば", CForm.Provision)]
        [TestCase("き||たら", CForm.Condition)]
        [TestCase("こ|い|", CForm.Imperative)]
        [TestCase("こ|よ|う", CForm.Volitional)]
        [TestCase("き||ている", CForm.PresentContinuous)]
        [TestCase("き||ていた", CForm.PastContinuous)]
        [TestCase("こ||られる", CForm.Passive)]
        [TestCase("こ||させる", CForm.Causative)]
        [TestCase("こ||させられる", CForm.CausativePassive)]
        [TestCase("こ||られる", CForm.Potential)]
        public void Kuru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "くる";
            var wordClass = EdictType.vk;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void IrregularNu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "死ぬ";
            var wordClass = EdictType.vn;
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void NounSuru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "勉強";
            var wordClass = EdictType.vs;
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void Su(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "熟す";
            var wordClass = EdictType.vs_c;
        }

        [TestCase("|し|て", CForm.TeForm)]
        [TestCase("|する|", CForm.Present)]
        [TestCase("|し|た", CForm.Past)]
        [TestCase("|すれ|ば", CForm.Provision)]
        [TestCase("|し|たら", CForm.Condition)]
        [TestCase("|(しろ/せよ)|", CForm.Imperative)]
        [TestCase("|し|よう", CForm.Volitional)]
        [TestCase("|し|ている", CForm.PresentContinuous)]
        [TestCase("|し|ていた", CForm.PastContinuous)]
        [TestCase("||される", CForm.Passive)]
        [TestCase("||させる", CForm.Causative)]
        [TestCase("||させられる", CForm.CausativePassive)]
        [TestCase("||できる", CForm.Potential)]
        public void SuruIrregular(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "する";
            var wordClass = EdictType.vs_i;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("", CForm.TeForm)]
        [TestCase("", CForm.Present)]
        [TestCase("", CForm.Past)]
        [TestCase("", CForm.Provision)]
        [TestCase("", CForm.Condition)]
        [TestCase("", CForm.Imperative)]
        [TestCase("則|し|よう", CForm.Volitional)]
        [TestCase("", CForm.PresentContinuous)]
        [TestCase("", CForm.PastContinuous)]
        [TestCase("", CForm.Passive)]
        [TestCase("", CForm.Causative)]
        [TestCase("", CForm.CausativePassive)]
        [TestCase("", CForm.Potential)]
        public void SuruSpecial(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
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
