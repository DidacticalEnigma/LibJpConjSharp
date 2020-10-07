
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

        [TestCase("いらっしゃ|っ|て", CForm.TeForm)]
        [TestCase("いらっしゃ|る|", CForm.Present)]
        [TestCase("いらっしゃ|っ|た", CForm.Past)]
        [TestCase("いらっしゃ|れ|ば", CForm.Provision)]
        [TestCase("いらっしゃ|っ|たら", CForm.Condition)]
        [TestCase("いらっしゃ|い|", CForm.Imperative)]
        [TestCase("いらっしゃ|ろ|う", CForm.Volitional)]
        [TestCase("いらっしゃ|っ|ている", CForm.PresentContinuous)]
        [TestCase("いらっしゃ|っ|ていた", CForm.PastContinuous)]
        [TestCase("いらっしゃ|ら|れる", CForm.Passive)]
        [TestCase("いらっしゃ|ら|せる", CForm.Causative)]
        [TestCase("いらっしゃ|ら|せられる", CForm.CausativePassive)]
        [TestCase("いらっしゃ|れ|る", CForm.Potential)]
        [TestCase("いらっしゃ|い|ます", CForm.Present, Politeness.Polite, Polarity.Affirmative)]
        public void GodanAru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "いらっしゃる"; 
            var wordClass = EdictType.v5aru;
            
            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("運|ん|で", CForm.TeForm)]
        [TestCase("運|ぶ|", CForm.Present)]
        [TestCase("運|ん|だ", CForm.Past)]
        [TestCase("運|べ|ば", CForm.Provision)]
        [TestCase("運|ん|だら", CForm.Condition)]
        [TestCase("運|べ|", CForm.Imperative)]
        [TestCase("運|ぼ|う", CForm.Volitional)]
        [TestCase("運|ん|でいる", CForm.PresentContinuous)]
        [TestCase("運|ん|でいた", CForm.PastContinuous)]
        [TestCase("運|ば|れる", CForm.Passive)]
        [TestCase("運|ば|せる", CForm.Causative)]
        [TestCase("運|ば|せられる", CForm.CausativePassive)]
        [TestCase("運|べ|る", CForm.Potential)]
        public void GodanBu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "運ぶ";
            var wordClass = EdictType.v5b;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("游|い|で", CForm.TeForm)]
        [TestCase("游|ぐ|", CForm.Present)]
        [TestCase("游|い|だ", CForm.Past)]
        [TestCase("游|げ|ば", CForm.Provision)]
        [TestCase("游|い|だら", CForm.Condition)]
        [TestCase("游|げ|", CForm.Imperative)]
        [TestCase("游|ご|う", CForm.Volitional)]
        [TestCase("游|い|でいる", CForm.PresentContinuous)]
        [TestCase("游|い|でいた", CForm.PastContinuous)]
        [TestCase("游|が|れる", CForm.Passive)]
        [TestCase("游|が|せる", CForm.Causative)]
        [TestCase("游|が|せられる", CForm.CausativePassive)]
        [TestCase("游|げ|る", CForm.Potential)]
        public void GodanGu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "游ぐ";
            var wordClass = EdictType.v5g;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("艶め|い|て", CForm.TeForm)]
        [TestCase("艶め|く|", CForm.Present)]
        [TestCase("艶め|い|た", CForm.Past)]
        [TestCase("艶め|け|ば", CForm.Provision)]
        [TestCase("艶め|い|たら", CForm.Condition)]
        [TestCase("艶め|け|", CForm.Imperative)]
        [TestCase("艶め|こ|う", CForm.Volitional)]
        [TestCase("艶め|い|ている", CForm.PresentContinuous)]
        [TestCase("艶め|い|ていた", CForm.PastContinuous)]
        [TestCase("艶め|か|れる", CForm.Passive)]
        [TestCase("艶め|か|せる", CForm.Causative)]
        [TestCase("艶め|か|せられる", CForm.CausativePassive)]
        [TestCase("艶め|け|る", CForm.Potential)]
        public void GodanKu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "艶めく";
            var wordClass = EdictType.v5k;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("合点がい|っ|て", CForm.TeForm)]
        [TestCase("合点がい|く|", CForm.Present)]
        [TestCase("合点がい|っ|た", CForm.Past)]
        [TestCase("合点がい|け|ば", CForm.Provision)]
        [TestCase("合点がい|っ|たら", CForm.Condition)]
        [TestCase("合点がい|け|", CForm.Imperative)]
        [TestCase("合点がい|こ|う", CForm.Volitional)]
        [TestCase("合点がい|っ|ている", CForm.PresentContinuous)]
        [TestCase("合点がい|っ|ていた", CForm.PastContinuous)]
        [TestCase("合点がい|か|れる", CForm.Passive)]
        [TestCase("合点がい|か|せる", CForm.Causative)]
        [TestCase("合点がい|か|せられる", CForm.CausativePassive)]
        [TestCase("合点がい|け|る", CForm.Potential)]
        public void GodanIkuYuku(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "合点がいく"; // also 冴え行く
            var wordClass = EdictType.v5k_s;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }
        
        [TestCase("刷り込|ん|で", CForm.TeForm)]
        [TestCase("刷り込|む|", CForm.Present)]
        [TestCase("刷り込|ん|だ", CForm.Past)]
        [TestCase("刷り込|め|ば", CForm.Provision)]
        [TestCase("刷り込|ん|だら", CForm.Condition)]
        [TestCase("刷り込|め|", CForm.Imperative)]
        [TestCase("刷り込|も|う", CForm.Volitional)]
        [TestCase("刷り込|ん|でいる", CForm.PresentContinuous)]
        [TestCase("刷り込|ん|でいた", CForm.PastContinuous)]
        [TestCase("刷り込|ま|れる", CForm.Passive)]
        [TestCase("刷り込|ま|せる", CForm.Causative)]
        [TestCase("刷り込|ま|せられる", CForm.CausativePassive)]
        [TestCase("刷り込|め|る", CForm.Potential)]
        public void GodanMu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "刷り込む";
            var wordClass = EdictType.v5m;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("死|ん|で", CForm.TeForm)]
        [TestCase("死|ぬ|", CForm.Present)]
        [TestCase("死|ん|だ", CForm.Past)]
        [TestCase("死|ね|ば", CForm.Provision)]
        [TestCase("死|ん|だら", CForm.Condition)]
        [TestCase("死|ね|", CForm.Imperative)]
        [TestCase("死|の|う", CForm.Volitional)]
        [TestCase("死|ん|でいる", CForm.PresentContinuous)]
        [TestCase("死|ん|でいた", CForm.PastContinuous)]
        [TestCase("死|な|れる", CForm.Passive)]
        [TestCase("死|な|せる", CForm.Causative)]
        [TestCase("死|な|せられる", CForm.CausativePassive)]
        [TestCase("死|ね|る", CForm.Potential)]
        public void GodanNu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "死ぬ";
            var wordClass = EdictType.v5n;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("あやま|っ|て", CForm.TeForm)]
        [TestCase("あやま|る|", CForm.Present)]
        [TestCase("あやま|っ|た", CForm.Past)]
        [TestCase("あやま|れ|ば", CForm.Provision)]
        [TestCase("あやま|っ|たら", CForm.Condition)]
        [TestCase("あやま|れ|", CForm.Imperative)]
        [TestCase("あやま|ろ|う", CForm.Volitional)]
        [TestCase("あやま|っ|ている", CForm.PresentContinuous)]
        [TestCase("あやま|っ|ていた", CForm.PastContinuous)]
        [TestCase("あやま|ら|れる", CForm.Passive)]
        [TestCase("あやま|ら|せる", CForm.Causative)]
        [TestCase("あやま|ら|せられる", CForm.CausativePassive)]
        [TestCase("あやま|れ|る", CForm.Potential)]
        public void GodanRu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "あやまる";
            var wordClass = EdictType.v5r;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("|あっ|て", CForm.TeForm)]
        [TestCase("|ある|", CForm.Present)]
        [TestCase("|あっ|た", CForm.Past)]
        [TestCase("|あれ|ば", CForm.Provision)]
        [TestCase("|あっ|たら", CForm.Condition)]
        [TestCase("|あれ|", CForm.Imperative)]
        [TestCase("|あ|ろう", CForm.Volitional)]
        [TestCase("|あっ|ている", CForm.PresentContinuous)]
        [TestCase("|あっ|ていた", CForm.PastContinuous)]
        [TestCase("|あら|れる", CForm.Passive)]
        [TestCase("|あら|せる", CForm.Causative)]
        [TestCase("|あら|せられる", CForm.CausativePassive)]
        [TestCase("|あれ|る", CForm.Potential)]
        [TestCase("||ない", CForm.Present, Politeness.Plain, Polarity.Negative)]
        public void GodanRuIrregular(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "ある";
            var wordClass = EdictType.v5r_i;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }
        
        [TestCase("螫|し|て", CForm.TeForm)]
        [TestCase("螫|す|", CForm.Present)]
        [TestCase("螫|し|た", CForm.Past)]
        [TestCase("螫|せ|ば", CForm.Provision)]
        [TestCase("螫|し|たら", CForm.Condition)]
        [TestCase("螫|そ|う", CForm.Volitional)]
        [TestCase("螫|し|ている", CForm.PresentContinuous)]
        [TestCase("螫|し|ていた", CForm.PastContinuous)]
        [TestCase("螫|さ|れる", CForm.Passive)]
        [TestCase("螫|さ|せる", CForm.Causative)]
        [TestCase("螫|さ|せられる", CForm.CausativePassive)]
        [TestCase("螫|せ|る", CForm.Potential)]
        public void GodanSu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "螫す";
            var wordClass = EdictType.v5s;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("持|っ|て", CForm.TeForm)]
        [TestCase("持|つ|", CForm.Present)]
        [TestCase("持|っ|た", CForm.Past)]
        [TestCase("持|て|ば", CForm.Provision)]
        [TestCase("持|っ|たら", CForm.Condition)]
        [TestCase("持|と|う", CForm.Volitional)]
        [TestCase("持|っ|ている", CForm.PresentContinuous)]
        [TestCase("持|っ|ていた", CForm.PastContinuous)]
        [TestCase("持|た|れる", CForm.Passive)]
        [TestCase("持|た|せる", CForm.Causative)]
        [TestCase("持|た|せられる", CForm.CausativePassive)]
        [TestCase("持|て|る", CForm.Potential)]
        public void GodanTsu(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "持つ";
            var wordClass = EdictType.v5t;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }
        
        [TestCase("行|っ|て", CForm.TeForm)]
        [TestCase("行|う|", CForm.Present)]
        [TestCase("行|っ|た", CForm.Past)]
        [TestCase("行|え|ば", CForm.Provision)]
        [TestCase("行|っ|たら", CForm.Condition)]
        [TestCase("行|お|う", CForm.Volitional)]
        [TestCase("行|っ|ている", CForm.PresentContinuous)]
        [TestCase("行|っ|ていた", CForm.PastContinuous)]
        [TestCase("行|わ|れる", CForm.Passive)]
        [TestCase("行|わ|せる", CForm.Causative)]
        [TestCase("行|わ|せられる", CForm.CausativePassive)]
        [TestCase("行|え|る", CForm.Potential)]
        public void GodanU(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "行う";
            var wordClass = EdictType.v5u;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
        }

        [TestCase("信を問|う|", CForm.Present)]
        [TestCase("信を問|う|た", CForm.Past)]
        [TestCase("信を問|え|ば", CForm.Provision)]
        [TestCase("信を問|う|たら", CForm.Condition)]
        [TestCase("信を問|お|う", CForm.Volitional)]
        [TestCase("信を問|う|ている", CForm.PresentContinuous)]
        [TestCase("信を問|う|ていた", CForm.PastContinuous)]
        [TestCase("信を問|わ|れる", CForm.Passive)]
        [TestCase("信を問|わ|せる", CForm.Causative)]
        [TestCase("信を問|わ|せられる", CForm.CausativePassive)]
        [TestCase("信を問|え|る", CForm.Potential)]
        public void GodanUSpecialClass(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "信を問う";
            var wordClass = EdictType.v5u_s;
            
            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
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
        public void KuruKanji(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "来る";
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
        public void NounSuru(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "勉強";
            var wordClass = EdictType.vs;
            
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
        public void Su(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "熟す";
            var wordClass = EdictType.vs_c;
            
            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
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

        [TestCase("愛|し|て", CForm.TeForm)]
        [TestCase("愛|する|", CForm.Present)]
        [TestCase("愛|し|た", CForm.Past)]
        [TestCase("愛|すれ|ば", CForm.Provision)]
        [TestCase("愛|し|たら", CForm.Condition)]
        [TestCase("愛|(しろ/せよ)|", CForm.Imperative)]
        [TestCase("愛|し|よう", CForm.Volitional)]
        [TestCase("愛|し|ている", CForm.PresentContinuous)]
        [TestCase("愛|し|ていた", CForm.PastContinuous)]
        //[TestCase("愛||される", CForm.Passive)]
        //[TestCase("愛||させる", CForm.Causative)]
        //[TestCase("愛||させられる", CForm.CausativePassive)]
        [TestCase("愛||せる", CForm.Potential)]
        [TestCase("愛||さない", CForm.Present, Politeness.Plain, Polarity.Negative)]
        public void SuruSpecial(string conjugatedWord, CForm form, Politeness politeness = Politeness.Plain, Polarity polarity = Polarity.Affirmative)
        {
            var word = "愛する";
            var wordClass = EdictType.vs_s;

            Assert.AreEqual(conjugatedWord, JpConj.Conjugate(word, wordClass, form, politeness, polarity));
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
