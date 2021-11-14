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
        private const string Verb = "verb";
        public const string Adjective = "adjective";

        private static readonly IReadOnlyList<DerivationAttribute> SingleSilent = Array.AsReadOnly(new[] { DerivationAttribute.Silent });

        public static readonly IReadOnlyList<DerivationRule> DerivationRules = new []
        {
            // Negative
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "わない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "かない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "がない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "さない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "たない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "なない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ばない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "まない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "らない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ない", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.NegativeNaiVerb),

            // Desu
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るです", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るです", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.PoliteDesuVerb),

            // Past form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "った", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "いた", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "いだ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "した", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "った", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "んだ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "んだ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "んだ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "った", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "た", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.PlainPast),

            // Te form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "って", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "いて", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "いで", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "して", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "って", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "んで", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "んで", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "んで", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "って", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "て", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.TeForm),

            // Ba form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "えば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "けば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "げば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "せば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "てば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ねば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "べば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "めば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "れば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "れば", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.BaForm),

            // Potentional form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "える", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "ける", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "げる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "せる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential, cannotFollow: new[] { new[] {WordType.ShortenedCausative, WordType.GodanVerb} }),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "てる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ねる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "べる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "める", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "れる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "れる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Potential),

            // Potential koto ga dekiru
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることができる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることができる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Potential),

            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることできる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Potential),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることできる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Potential),

            // Occasional occurance koto ga aru
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることがある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることがある", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),

            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることある", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることある", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.OccasionalOccuranceAru),

            // Ambiguous potential/passive
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "られる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.PotentialPassive),

            // Passive form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "われる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "かれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "がれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "される", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "たれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "なれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ばれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "まれる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),

            // Imperative form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "え", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "け", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "げ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "せ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "て", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ね", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "べ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "め", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "れ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ろ", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Imperative),

            // Volitional form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "おう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "こう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ごう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "そう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "とう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "のう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぼう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "もう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "よう", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Volitional),

            // Masu stem form
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.MasuStem, cannotFollow: new[] { new[] {WordType.ShortIru, WordType.IchidanVerb} }),
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "い", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "き", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぎ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "し", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "ち", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "に", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "び", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "み", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "り", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),

            // Causative form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "わせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "かせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "がせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "させる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "たせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "なせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ばせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "ませる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "らせる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "させる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Causative),

            // Tara form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "ったら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "いたら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "いだら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "したら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "ったら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "んだら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "んだら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "んだら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ったら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "たら", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Tara),

            // Tari form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "ったり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "いたり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "いだり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "したり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "ったり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "んだり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "んだり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "んだり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ったり", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tari),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "たり", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Tari),

            // Zu form
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "わず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "かず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "がず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "さず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "たず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "なず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ばず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "まず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "らず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ず", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Zu),

            // Beki
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るべき", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Beki),

            // SURU
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "せず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Zu),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "し", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "して", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "した", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "しない", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "しよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "させる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "される", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Passive),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "しろ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "せよ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "すれば", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "したら", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "する", conjugatedEnding: "すべき", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beki),

            // Hearsay
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るそう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るそう", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Hearsay),

            // Na command
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るな", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NaCommand),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るな", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.NaCommand),

            // Negative volitional
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るまい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.NegativeVolitional),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るまい", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.NegativeVolitional),

            // Koto ni suru
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることにする", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることにする", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.KotoNiSuru),

            // Koto ni naru
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むことになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることになる", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ることになる", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.KotoNiNaru),

            // Koto nominalizer
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むこと", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ること", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "ること", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.KotoNominalizer),

            // Koto nominalizer
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "う前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "く前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐ前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "す前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つ前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬ前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶ前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "む前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る前", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mae),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る前", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Mae),

            // Darou
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るだろう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るだろう", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Darou),

            // Ga hayai ka
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るが早いか", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.GaHayaiKa),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るが早いか", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.GaHayaiKa),

            // Mitai
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るみたい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るみたい", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Mitai),

            // Rashii
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るらしい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るらしい", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Rashii),

            // Rashii
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るほうがいい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るほうがいい", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.HouGaIi),

            // YOU
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るよう", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るよう", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.You),

            // HAZU
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るはず", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るはず", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Hazu),

            // BEKU
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "うべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "すべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "むべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るべく", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Beku),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "るべく", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.Beku),

            // KURU
            new DerivationRule(unconjugatedEnding: "来る", conjugatedEnding: "来い", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.Imperative),

            // NASARU
            new DerivationRule(unconjugatedEnding: "なさる", conjugatedEnding: "なさい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "為さる", conjugatedEnding: "為さい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),

            // Irrassharu and ossharu
            new DerivationRule(unconjugatedEnding: "いらっしゃる", conjugatedEnding: "いらっしゃい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "居らっしゃる", conjugatedEnding: "居らっしゃい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "おっしゃる", conjugatedEnding: "おっしゃい", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),
            new DerivationRule(unconjugatedEnding: "仰る", conjugatedEnding: "仰い", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.MasuStem),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "う", conjugatedEnding: "う", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "く", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ぐ", conjugatedEnding: "ぐ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "す", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "つ", conjugatedEnding: "つ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ぶ", conjugatedEnding: "ぶ", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "む", conjugatedEnding: "む", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る", unconjugatedWordType: WordType.GodanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る", unconjugatedWordType: WordType.IchidanVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Advjective rules
            */
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "かった", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "くない", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "くはない", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "くて", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "く", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Adverb),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "ければ", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.BaForm),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "かったら", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いそう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いです", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いことがある", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いことある", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いこと", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "かろう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いべき", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Beki),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いそう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "そう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Appearance),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いだろう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いことがある", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いことある", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.OccasionalOccuranceAru),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いことにする", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いこと", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "い", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いみたい", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いらしい", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Rashii),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いよう", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "い", conjugatedEnding: "いはず", unconjugatedWordType: WordType.Adjective, conjugatedWordType: WordType.Hazu),

            /*
            * Plain past form rules
            */
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たそう", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだそう", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Hearsay),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たあげく", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Ageku),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだあげく", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Ageku),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "た挙句", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Ageku),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだ挙句", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Ageku),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たこと", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだこと", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たことになる", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだことになる", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たみたい", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだみたい", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たばかり", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.TaBakari),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだばかり", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.TaBakari),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たほうがいい", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだほうがいい", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.HouGaIi),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "た", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだ", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たよう", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだよう", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.You),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たはず", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだはず", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.Hazu),
            new DerivationRule(unconjugatedEnding: "た", conjugatedEnding: "たばっか", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.TaBakari),
            new DerivationRule(unconjugatedEnding: "んだ", conjugatedEnding: "んだばっか", unconjugatedWordType: WordType.PlainPast, conjugatedWordType: WordType.TaBakari),

            /*
            * Masu stem rules
            */
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ます", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.PoliteMasu),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ません", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.PoliteMasen),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "そう", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Appearance),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "たい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Tai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "なさい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Nasai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "な", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Nasai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "はしない", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.MasuStemWaShinai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ながら", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Nagara),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "がち", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Gachi),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "かた", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Kata),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "方", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Kata),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "やすい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Yasui),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "にくい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Nikui),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "すぎる", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Sugiru),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "過ぎる", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Sugiru),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "すぎ", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Sugi),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "過ぎ", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Sugi),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "に", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.MasuStemNi),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "つつある", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.TsutsuAru),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "がたい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Gatai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "難い", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Gatai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "次第", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Shidai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "しだい", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Shidai),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "やがる", unconjugatedWordType: WordType.MasuStem, conjugatedWordType: WordType.Yagaru),

            /*
            *  Te form rules
            */
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てください", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Kudasai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でください", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Kudasai),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.NegativeAruOrIru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.NegativeAruOrIru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ている", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Iru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でいる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Iru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.ShortIru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.ShortIru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てある", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Aru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "である", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Aru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ておる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でおる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "とる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "どる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ておく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oku),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "とく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oku),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でおく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oku),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "どく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Oku),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てもらう", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Morau),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でもらう", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Morau),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てくれる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Kureru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でくれる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Kureru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てあげる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Ageru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "であげる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Ageru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ては", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.WaAfterTe),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "では", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.WaAfterTe),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ても", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.MoAfterTe),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でも", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.MoAfterTe),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ていい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でいい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ていけない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でいけない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てはいけない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "ではいけない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てならない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でならない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てはならない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "ではならない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てだめ", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でだめ", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てはだめ", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "ではだめ", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "て駄目", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "で駄目", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ては駄目", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "では駄目", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeDame),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てしまう", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Shimau),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でしまう", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Shimau),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てみる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Miru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でみる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Miru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てほしい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Hoshii),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でほしい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Hoshii),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "て欲しい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Hoshii),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "で欲しい", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Hoshii),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てから", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeKara),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でから", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeKara),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てくる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeKuru),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でくる", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeKuru),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "ていく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIku),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でいく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIku),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIku),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "でく", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.TeIku),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "てすまない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Sumanai),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "ですまない", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.Sumanai),

            /*
            * Kudasai rules
            */
            new DerivationRule(unconjugatedEnding: "ください", conjugatedEnding: "ください", unconjugatedWordType: WordType.Kudasai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Negative aru or iru rules
            */
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "ない", unconjugatedWordType: WordType.NegativeAruOrIru, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Beku rules
            */
            new DerivationRule(unconjugatedEnding: "べく", conjugatedEnding: "べく", unconjugatedWordType: WordType.Beku, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Yagaru
            */
            new DerivationRule(unconjugatedEnding: "やがる", conjugatedEnding: "やがる", unconjugatedWordType: WordType.Yagaru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Shidai rules
            */
            new DerivationRule(unconjugatedEnding: "次第", conjugatedEnding: "次第だ", unconjugatedWordType: WordType.Shidai, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "しだい", conjugatedEnding: "しだいだ", unconjugatedWordType: WordType.Shidai, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "次第", conjugatedEnding: "次第", unconjugatedWordType: WordType.Shidai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "しだい", conjugatedEnding: "しだい", unconjugatedWordType: WordType.Shidai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Gatai rules
            */
            new DerivationRule(unconjugatedEnding: "がたい", conjugatedEnding: "がたい", unconjugatedWordType: WordType.Gatai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "難い", conjugatedEnding: "難い", unconjugatedWordType: WordType.Gatai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Tsutsu aru rules
            */
            new DerivationRule(unconjugatedEnding: "つつある", conjugatedEnding: "つつある", unconjugatedWordType: WordType.TsutsuAru, conjugatedWordType: WordType.Aru, attributes: SingleSilent),

            /*
            * Adverb rules
            */
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "く", unconjugatedWordType: WordType.Adverb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "くなる", unconjugatedWordType: WordType.Adverb, conjugatedWordType: WordType.Naru),

            /*
            * Naru rules
            */
            new DerivationRule(unconjugatedEnding: "なる", conjugatedEnding: "なる", unconjugatedWordType: WordType.Naru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Hazu rules
            */
            new DerivationRule(unconjugatedEnding: "はず", conjugatedEnding: "はず", unconjugatedWordType: WordType.Hazu, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "はず", conjugatedEnding: "はずだ", unconjugatedWordType: WordType.Hazu, conjugatedWordType: WordType.Da),

            /*
            * You rules
            */
            new DerivationRule(unconjugatedEnding: "よう", conjugatedEnding: "よう", unconjugatedWordType: WordType.You, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "よう", conjugatedEnding: "ようだ", unconjugatedWordType: WordType.You, conjugatedWordType: WordType.Da),

            /*
            * Kamau rules
            */
            new DerivationRule(unconjugatedEnding: "かまう", conjugatedEnding: "かまう", unconjugatedWordType: WordType.Kamau, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Te iku rules
            */
            new DerivationRule(unconjugatedEnding: "いく", conjugatedEnding: "いった", unconjugatedWordType: WordType.TeIku, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "いく", conjugatedEnding: "いく", unconjugatedWordType: WordType.TeIku, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "く", unconjugatedWordType: WordType.TeIku, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Te kuru rules
            */
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "きた", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "きたら", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.Tara),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こい", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こない", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こよう", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こられる", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.PotentialPassive),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こさせる", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.Causative),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "こよう", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.Volitional),
            new DerivationRule(unconjugatedEnding: "くる", conjugatedEnding: "き", unconjugatedWordType: WordType.TeKuru, conjugatedWordType: WordType.MasuStem),

            /*
            * Te kara rules
            */
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からだ", unconjugatedWordType: WordType.TeKara, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "から", unconjugatedWordType: WordType.TeKara, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Hoshii rules
            */
            new DerivationRule(unconjugatedEnding: "欲しい", conjugatedEnding: "欲しい", unconjugatedWordType: WordType.Hoshii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ほしい", conjugatedEnding: "ほしい", unconjugatedWordType: WordType.Hoshii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Miru rules
            */
            new DerivationRule(unconjugatedEnding: "みる", conjugatedEnding: "みる", unconjugatedWordType: WordType.Miru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Shimau rules
            */
            new DerivationRule(unconjugatedEnding: "てしまう", conjugatedEnding: "ちゃう", unconjugatedWordType: WordType.Shimau, conjugatedWordType: WordType.Chau),
            new DerivationRule(unconjugatedEnding: "でしまう", conjugatedEnding: "じゃう", unconjugatedWordType: WordType.Shimau, conjugatedWordType: WordType.Jau),
            new DerivationRule(unconjugatedEnding: "てしまう", conjugatedEnding: "ちまう", unconjugatedWordType: WordType.Shimau, conjugatedWordType: WordType.Chimau),
            new DerivationRule(unconjugatedEnding: "でしまう", conjugatedEnding: "じまう", unconjugatedWordType: WordType.Shimau, conjugatedWordType: WordType.Jimau),
            new DerivationRule(unconjugatedEnding: "しまう", conjugatedEnding: "しまう", unconjugatedWordType: WordType.Shimau, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Chau rules
            */
            new DerivationRule(unconjugatedEnding: "ちゃう", conjugatedEnding: "ちゃう", unconjugatedWordType: WordType.Chau, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Jau rules
            */
            new DerivationRule(unconjugatedEnding: "じゃう", conjugatedEnding: "じゃう", unconjugatedWordType: WordType.Jau, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Chimau rules
            */
            new DerivationRule(unconjugatedEnding: "ちまう", conjugatedEnding: "ちまう", unconjugatedWordType: WordType.Chimau, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Jimau rules
            */
            new DerivationRule(unconjugatedEnding: "じまう", conjugatedEnding: "じまう", unconjugatedWordType: WordType.Jimau, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Imperative rules
            */
            new DerivationRule(unconjugatedEnding: "え", conjugatedEnding: "え", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "け", conjugatedEnding: "け", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "げ", conjugatedEnding: "げ", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "せ", conjugatedEnding: "せ", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "て", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "ね", conjugatedEnding: "ね", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "べ", conjugatedEnding: "べ", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "め", conjugatedEnding: "め", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "れ", conjugatedEnding: "れ", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),
            new DerivationRule(unconjugatedEnding: "ろ", conjugatedEnding: "ろ", unconjugatedWordType: WordType.Imperative, conjugatedWordType: WordType.SentenceEndingParticles, attributes:SingleSilent),

            /*
            * Masu stem ni rules
            */
            new DerivationRule(unconjugatedEnding: "に", conjugatedEnding: "に", unconjugatedWordType: WordType.MasuStemNi, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Na command rules
            */
            new DerivationRule(unconjugatedEnding: "な", conjugatedEnding: "な", unconjugatedWordType: WordType.NaCommand, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Nasai rules
            */
            new DerivationRule(unconjugatedEnding: "なさい", conjugatedEnding: "なさい", unconjugatedWordType: WordType.Nasai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "な", conjugatedEnding: "な", unconjugatedWordType: WordType.Nasai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Yasui rules
            */
            new DerivationRule(unconjugatedEnding: "やすい", conjugatedEnding: "やすい", unconjugatedWordType: WordType.Yasui, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Nikui rules
            */
            new DerivationRule(unconjugatedEnding: "にくい", conjugatedEnding: "にくい", unconjugatedWordType: WordType.Nikui, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Sugiru rules
            */
            new DerivationRule(unconjugatedEnding: "すぎる", conjugatedEnding: "すぎる", unconjugatedWordType: WordType.Sugiru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "過ぎる", conjugatedEnding: "過ぎる", unconjugatedWordType: WordType.Sugiru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Sugiru rules
            */
            new DerivationRule(unconjugatedEnding: "すぎ", conjugatedEnding: "すぎだ", unconjugatedWordType: WordType.Sugi, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "過ぎ", conjugatedEnding: "過ぎだ", unconjugatedWordType: WordType.Sugi, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "すぎ", conjugatedEnding: "すぎ", unconjugatedWordType: WordType.Sugi, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "過ぎ", conjugatedEnding: "過ぎ", unconjugatedWordType: WordType.Sugi, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Kata rules
            */
            new DerivationRule(unconjugatedEnding: "かた", conjugatedEnding: "かただ", unconjugatedWordType: WordType.Kata, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "方", conjugatedEnding: "方だ", unconjugatedWordType: WordType.Kata, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "かた", conjugatedEnding: "かた", unconjugatedWordType: WordType.Kata, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "方", conjugatedEnding: "方", unconjugatedWordType: WordType.Kata, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Gachi rules
            */
            new DerivationRule(unconjugatedEnding: "がち", conjugatedEnding: "がち", unconjugatedWordType: WordType.Gachi, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "がち", conjugatedEnding: "がちだ", unconjugatedWordType: WordType.Gachi, conjugatedWordType: WordType.Da),

            /*
            * Wa shinai rules
            */
            new DerivationRule(unconjugatedEnding: "はしない", conjugatedEnding: "はしない", unconjugatedWordType: WordType.MasuStemWaShinai, conjugatedWordType: WordType.NegativeNaiVerb, attributes: SingleSilent),

            /*
            * Garu rules
            */
            new DerivationRule(unconjugatedEnding: "がる", conjugatedEnding: "がる", unconjugatedWordType: WordType.Garu, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Rashii rules
            */
            new DerivationRule(unconjugatedEnding: "らしい", conjugatedEnding: "らしい", unconjugatedWordType: WordType.Rashii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Mitai rules
            */
            new DerivationRule(unconjugatedEnding: "みたい", conjugatedEnding: "みたいだ", unconjugatedWordType: WordType.Mitai, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "みたい", conjugatedEnding: "みたい", unconjugatedWordType: WordType.Mitai, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Ga hayai ka rules
            */
            new DerivationRule(unconjugatedEnding: "が早いか", conjugatedEnding: "がはやいか", unconjugatedWordType: WordType.GaHayaiKa, conjugatedWordType: WordType.GaHayaiKa),

            /*
            * Mae rules
            */
            new DerivationRule(unconjugatedEnding: "前", conjugatedEnding: "まえだ", unconjugatedWordType: WordType.Mae, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "前", conjugatedEnding: "前だ", unconjugatedWordType: WordType.Mae, conjugatedWordType: WordType.Da),

            /*
            * Occasional occurance aru rules
            */
            new DerivationRule(unconjugatedEnding: "ある", conjugatedEnding: "ある", unconjugatedWordType: WordType.OccasionalOccuranceAru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Nai negative form rules
            */
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "ぬ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Nu),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なきゃ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Nakya),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくちゃ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Nakucha),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "ないで", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Naide),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なさそう", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Appearance),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくていけない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくてならない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくてはいけない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくてはならない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なければいけない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なければならない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくてだめ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくてはだめ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なければだめ", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくて駄目", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なくては駄目", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "なければ駄目", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.NakuteNakerebaDame),
            new DerivationRule(unconjugatedEnding: "ない", conjugatedEnding: "ない", unconjugatedWordType: WordType.NegativeNaiVerb, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Te dame rules
            */
            new DerivationRule(unconjugatedEnding: "だめ", conjugatedEnding: "だめだ", unconjugatedWordType: WordType.NakuteNakerebaDame, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "駄目", conjugatedEnding: "駄目だ", unconjugatedWordType: WordType.NakuteNakerebaDame, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "だめ", conjugatedEnding: "だめ", unconjugatedWordType: WordType.NakuteNakerebaDame, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "駄目", conjugatedEnding: "駄目", unconjugatedWordType: WordType.NakuteNakerebaDame, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Nakute nakereba ikenai naranai rules
            */
            new DerivationRule(unconjugatedEnding: "ならない", conjugatedEnding: "ならない", unconjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "いけない", conjugatedEnding: "いけない", unconjugatedWordType: WordType.NakuteNakerebaIkenaiNaranai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Nu rules
            */
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことにする", unconjugatedWordType: WordType.Nu, conjugatedWordType: WordType.KotoNiSuru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬことになる", unconjugatedWordType: WordType.Nu, conjugatedWordType: WordType.KotoNiNaru),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬこと", unconjugatedWordType: WordType.Nu, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬみたい", unconjugatedWordType: WordType.Nu, conjugatedWordType: WordType.Mitai),
            new DerivationRule(unconjugatedEnding: "ぬ", conjugatedEnding: "ぬ", unconjugatedWordType: WordType.Nu, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Hou ga ii rules
            */
            new DerivationRule(unconjugatedEnding: "ほうがいい", conjugatedEnding: "方がいい", unconjugatedWordType: WordType.HouGaIi, conjugatedWordType: WordType.Ii, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ほうがいい", conjugatedEnding: "ほうが良い", unconjugatedWordType: WordType.HouGaIi, conjugatedWordType: WordType.Ii, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ほうがいい", conjugatedEnding: "方が良い", unconjugatedWordType: WordType.HouGaIi, conjugatedWordType: WordType.Ii, attributes: SingleSilent),

            /*
            * Ta bakari rules
            */
            new DerivationRule(unconjugatedEnding: "ばかり", conjugatedEnding: "ばかりだ", unconjugatedWordType: WordType.TaBakari, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "ばかり", conjugatedEnding: "ばかり", unconjugatedWordType: WordType.TaBakari, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "て", conjugatedEnding: "て", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "で", conjugatedEnding: "で", unconjugatedWordType: WordType.TeForm, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),


            /*
            * Sumanai rules
            */
            new DerivationRule(unconjugatedEnding: "すまない", conjugatedEnding: "すみません", unconjugatedWordType: WordType.Sumanai, conjugatedWordType: WordType.Sumimasen),

            /*
            * Sumimasen rules
            */
            new DerivationRule(unconjugatedEnding: "すみません", conjugatedEnding: "すみません", unconjugatedWordType: WordType.Sumimasen, conjugatedWordType: WordType.PoliteMasen, attributes: SingleSilent),

            /*
            * Te dame rules
            */
            new DerivationRule(unconjugatedEnding: "だめ", conjugatedEnding: "だめだ", unconjugatedWordType: WordType.TeDame, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "駄目", conjugatedEnding: "駄目だ", unconjugatedWordType: WordType.TeDame, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "だめ", conjugatedEnding: "だめ", unconjugatedWordType: WordType.TeDame, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "駄目", conjugatedEnding: "駄目", unconjugatedWordType: WordType.TeDame, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Te ikenai naranai rules
            */
            new DerivationRule(unconjugatedEnding: "いけない", conjugatedEnding: "いけない", unconjugatedWordType: WordType.TeIkenaiNaranai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "ならない", conjugatedEnding: "ならない", unconjugatedWordType: WordType.TeIkenaiNaranai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Wa after te rules
            */
            new DerivationRule(unconjugatedEnding: "は", conjugatedEnding: "はいい", unconjugatedWordType: WordType.WaAfterTe, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "は", conjugatedEnding: "はない", unconjugatedWordType: WordType.WaAfterTe, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "は", conjugatedEnding: "はいる", unconjugatedWordType: WordType.WaAfterTe, conjugatedWordType: WordType.Iru),
            new DerivationRule(unconjugatedEnding: "は", conjugatedEnding: "はある", unconjugatedWordType: WordType.WaAfterTe, conjugatedWordType: WordType.Aru),

            /*
            * Mo after te rules
            */
            new DerivationRule(unconjugatedEnding: "も", conjugatedEnding: "もいい", unconjugatedWordType: WordType.MoAfterTe, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "も", conjugatedEnding: "もかまう", unconjugatedWordType: WordType.MoAfterTe, conjugatedWordType: WordType.Kamau),

            /*
            * Ba form rules
            */
            new DerivationRule(unconjugatedEnding: "ば", conjugatedEnding: "ばいい", unconjugatedWordType: WordType.BaForm, conjugatedWordType: WordType.Ii),

            /*
            * Potential form rules
            */
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る", unconjugatedWordType: WordType.Potential, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Potential/passive form rules
            */
            new DerivationRule(unconjugatedEnding: "られる", conjugatedEnding: "られる", unconjugatedWordType: WordType.PotentialPassive, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Passive form rules
            */
            new DerivationRule(unconjugatedEnding: "れる", conjugatedEnding: "れる", unconjugatedWordType: WordType.Passive, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Causative form rules
            */
            new DerivationRule(unconjugatedEnding: "せる", conjugatedEnding: "せる", unconjugatedWordType: WordType.Causative, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "せる", conjugatedEnding: "す", unconjugatedWordType: WordType.Causative, conjugatedWordType: WordType.ShortenedCausative),

            /*
            * Shorted causative form rules
            */
            new DerivationRule(unconjugatedEnding: "す", conjugatedEnding: "す", unconjugatedWordType: WordType.ShortenedCausative, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * ii rules
            */
            new DerivationRule(unconjugatedEnding: "いい", conjugatedEnding: "よい", unconjugatedWordType: WordType.Ii, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "いい", conjugatedEnding: "良い", unconjugatedWordType: WordType.Ii, conjugatedWordType: WordType.Ii),
            new DerivationRule(unconjugatedEnding: "よい", conjugatedEnding: "よい", unconjugatedWordType: WordType.Ii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "良い", conjugatedEnding: "良い", unconjugatedWordType: WordType.Ii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "いい", conjugatedEnding: "いい", unconjugatedWordType: WordType.Ii, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),

            /*
            * Tai form rules
            */
            new DerivationRule(unconjugatedEnding: "たい", conjugatedEnding: "たい", unconjugatedWordType: WordType.Tai, conjugatedWordType: WordType.Adjective, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "たい", conjugatedEnding: "たがる", unconjugatedWordType: WordType.Tai, conjugatedWordType: WordType.Garu),

            /*
            * Tara rules
            */
            new DerivationRule(unconjugatedEnding: "たら", conjugatedEnding: "たらいい", unconjugatedWordType: WordType.Tara, conjugatedWordType: WordType.Ii),

            /*
            * Tari rules
            */
            new DerivationRule(unconjugatedEnding: "たり", conjugatedEnding: "たりする", unconjugatedWordType: WordType.Tari, conjugatedWordType: WordType.GodanVerb, attributes:SingleSilent),

            /*
            * Ba rules
            */
            new DerivationRule(unconjugatedEnding: "ば", conjugatedEnding: "ばいい", unconjugatedWordType: WordType.BaForm, conjugatedWordType: WordType.Ii),

            /*
            * Nakya rules
            */
            new DerivationRule(unconjugatedEnding: "なきゃ", conjugatedEnding: "なきゃいい", unconjugatedWordType: WordType.Nakya, conjugatedWordType: WordType.Ii),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "なきゃ", conjugatedEnding: "なきゃ", unconjugatedWordType: WordType.Nakya, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Nakucha rules
            */
            new DerivationRule(unconjugatedEnding: "なくちゃ", conjugatedEnding: "なくちゃいい", unconjugatedWordType: WordType.Nakucha, conjugatedWordType: WordType.Ii),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "なくちゃ", conjugatedEnding: "なくちゃ", unconjugatedWordType: WordType.Nakucha, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Da rules
            */
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "です", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.PoliteDesuVerb),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "じゃない", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "ではない", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "だろう", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.Darou),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "なの", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.ExplanatoryNoParticle),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "だった", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.PlainPast),
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "である", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.DeAru),

            /*
            * De aru rules
            */
            new DerivationRule(unconjugatedEnding: "である", conjugatedEnding: "である", unconjugatedWordType: WordType.DeAru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "だ", conjugatedEnding: "だ", unconjugatedWordType: WordType.Da, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Polite desu rules
            */

            // Special transformation to sentence end
            new DerivationRule(conjugatedEnding: "です", unconjugatedEnding: "です", unconjugatedWordType: WordType.PoliteDesuVerb, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Beki rules
            */
            new DerivationRule(unconjugatedEnding: "べき", conjugatedEnding: "べきだ", unconjugatedWordType: WordType.Beki, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "べき", conjugatedEnding: "べきこと", unconjugatedWordType: WordType.Beki, conjugatedWordType: WordType.KotoNominalizer),
            new DerivationRule(unconjugatedEnding: "べき", conjugatedEnding: "べきことになる", unconjugatedWordType: WordType.Beki, conjugatedWordType: WordType.KotoNiNaru),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "べき", conjugatedEnding: "べき", unconjugatedWordType: WordType.Beki, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Hearsay rules
            */
            new DerivationRule(unconjugatedEnding: "そう", conjugatedEnding: "そうだ", unconjugatedWordType: WordType.Hearsay, conjugatedWordType: WordType.Da),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "そう", conjugatedEnding: "そう", unconjugatedWordType: WordType.Hearsay, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Appearance rules
            */
            new DerivationRule(unconjugatedEnding: "そう", conjugatedEnding: "そうだ", unconjugatedWordType: WordType.Appearance, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "そう", conjugatedEnding: "そうなこと", unconjugatedWordType: WordType.Appearance, conjugatedWordType: WordType.KotoNominalizer),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "そう", conjugatedEnding: "そう", unconjugatedWordType: WordType.Appearance, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Polite masu rules
            */
            new DerivationRule(unconjugatedEnding: "ます", conjugatedEnding: "ました", unconjugatedWordType: WordType.PoliteMasu, conjugatedWordType: WordType.PoliteMashita),
            new DerivationRule(unconjugatedEnding: "ます", conjugatedEnding: "まして", unconjugatedWordType: WordType.PoliteMasu, conjugatedWordType: WordType.TeForm),
            new DerivationRule(unconjugatedEnding: "ます", conjugatedEnding: "ましょう", unconjugatedWordType: WordType.PoliteMasu, conjugatedWordType: WordType.PoliteMashou),
            new DerivationRule(unconjugatedEnding: "ます", conjugatedEnding: "ましたら", unconjugatedWordType: WordType.PoliteMasu, conjugatedWordType: WordType.Tara),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "ます", conjugatedEnding: "ます", unconjugatedWordType: WordType.PoliteMasu, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Polite masen rules
            */
            new DerivationRule(unconjugatedEnding: "ません", conjugatedEnding: "ませんでした", unconjugatedWordType: WordType.PoliteMasen, conjugatedWordType: WordType.PoliteMasenDeshita),
            new DerivationRule(unconjugatedEnding: "ません", conjugatedEnding: "ませんでしたら", unconjugatedWordType: WordType.PoliteMasen, conjugatedWordType: WordType.Tara),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "ません", conjugatedEnding: "ません", unconjugatedWordType: WordType.PoliteMasen, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Aru rules
            */
            new DerivationRule(unconjugatedEnding: "ある", conjugatedEnding: "ない", unconjugatedWordType: WordType.Aru, conjugatedWordType: WordType.NegativeNaiVerb),
            new DerivationRule(unconjugatedEnding: "ある", conjugatedEnding: "ある", unconjugatedWordType: WordType.Aru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Iru rules
            */
            new DerivationRule(unconjugatedEnding: "いる", conjugatedEnding: "いる", unconjugatedWordType: WordType.Iru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "る", conjugatedEnding: "る", unconjugatedWordType: WordType.ShortIru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Darou rules
            */
            new DerivationRule(unconjugatedEnding: "だろう", conjugatedEnding: "でしょう", unconjugatedWordType: WordType.Darou, conjugatedWordType: WordType.PoliteDeshou),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "だろう", conjugatedEnding: "だろう", unconjugatedWordType: WordType.Darou, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Deshou rules
            */

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "でしょう", conjugatedEnding: "でしょう", unconjugatedWordType: WordType.PoliteDeshou, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Morau rules
            */
            new DerivationRule(unconjugatedEnding: "もらう", conjugatedEnding: "いただく", unconjugatedWordType: WordType.Morau, conjugatedWordType: WordType.PoliteItadaku),
            new DerivationRule(unconjugatedEnding: "もらう", conjugatedEnding: "もらう", unconjugatedWordType: WordType.Morau, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),
            new DerivationRule(unconjugatedEnding: "いただく", conjugatedEnding: "いただく", unconjugatedWordType: WordType.PoliteItadaku, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Kureru rules
            */
            new DerivationRule(unconjugatedEnding: "くれる", conjugatedEnding: "くれ", unconjugatedWordType: WordType.Kureru, conjugatedWordType: WordType.Imperative),
            new DerivationRule(unconjugatedEnding: "くれる", conjugatedEnding: "くれる", unconjugatedWordType: WordType.Kureru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Ageru rules
            */
            new DerivationRule(unconjugatedEnding: "あげる", conjugatedEnding: "あげる", unconjugatedWordType: WordType.Ageru, conjugatedWordType: WordType.IchidanVerb, attributes: SingleSilent),

            /*
            * Oku rules
            */
            new DerivationRule(unconjugatedEnding: "おく", conjugatedEnding: "置く", unconjugatedWordType: WordType.Oku, conjugatedWordType: WordType.Oku),
            new DerivationRule(unconjugatedEnding: "く", conjugatedEnding: "く", unconjugatedWordType: WordType.Oku, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Koto nominalizer rules
            */
            new DerivationRule(unconjugatedEnding: "こと", conjugatedEnding: "ことだ", unconjugatedWordType: WordType.KotoNominalizer, conjugatedWordType: WordType.Da),

            // Special transformation to sentence end
            new DerivationRule(unconjugatedEnding: "こと", conjugatedEnding: "こと", unconjugatedWordType: WordType.KotoNominalizer, conjugatedWordType: WordType.SentenceEndingParticles, attributes: SingleSilent),

            /*
            * Koto ni suru rules
            */
            new DerivationRule(unconjugatedEnding: "ことにする", conjugatedEnding: "ことにする", unconjugatedWordType: WordType.KotoNiSuru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Koto ni naru rules
            */
            new DerivationRule(unconjugatedEnding: "ことになる", conjugatedEnding: "ことになる", unconjugatedWordType: WordType.KotoNiNaru, conjugatedWordType: WordType.GodanVerb, attributes: SingleSilent),

            /*
            * Sentence ending particles rules
            */
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "わ", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.FeminineWaParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "の", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.ExplanatoryNoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ん", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.ExplanatoryNoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "よ", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ね", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "な", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.NaParticle, cannotFollow: new[] { new[] {WordType.Imperative, WordType.SentenceEndingParticles} }),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ぞ", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.ZoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "ぜ", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.ZeParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "か", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.KaParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "が", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.GaParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "さ", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.SaParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "けど", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.KedoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "けれど", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.KedoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "けれども", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.KedoParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "のに", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.NoniParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "まで", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.MadeParticle),
            new DerivationRule(unconjugatedEnding: "", conjugatedEnding: "から", unconjugatedWordType: WordType.SentenceEndingParticles, conjugatedWordType: WordType.KaraParticle, cannotFollow: new[] { new[] {WordType.TeForm, WordType.SentenceEndingParticles} }),

            /*
            * No particle rules
            */
            new DerivationRule(unconjugatedEnding: "の", conjugatedEnding: "のよ", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "の", conjugatedEnding: "のね", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "の", conjugatedEnding: "のか", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.KaParticle),
            new DerivationRule(unconjugatedEnding: "の", conjugatedEnding: "のさ", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.SaParticle),
            new DerivationRule(unconjugatedEnding: "の", conjugatedEnding: "のだ", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.Da),
            new DerivationRule(unconjugatedEnding: "ん", conjugatedEnding: "んだ", unconjugatedWordType: WordType.ExplanatoryNoParticle, conjugatedWordType: WordType.Da),

            /*
            * Made particle rules
            */
            new DerivationRule(unconjugatedEnding: "まで", conjugatedEnding: "までわ", unconjugatedWordType: WordType.MadeParticle, conjugatedWordType: WordType.FeminineWaParticle),
            new DerivationRule(unconjugatedEnding: "まで", conjugatedEnding: "までよ", unconjugatedWordType: WordType.MadeParticle, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "まで", conjugatedEnding: "までね", unconjugatedWordType: WordType.MadeParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "まで", conjugatedEnding: "までさ", unconjugatedWordType: WordType.MadeParticle, conjugatedWordType: WordType.SaParticle),
            new DerivationRule(unconjugatedEnding: "まで", conjugatedEnding: "までだ", unconjugatedWordType: WordType.MadeParticle, conjugatedWordType: WordType.Da),

            /*
            * Kara particle rules
            */
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からわ", unconjugatedWordType: WordType.KaraParticle, conjugatedWordType: WordType.FeminineWaParticle),
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からよ", unconjugatedWordType: WordType.KaraParticle, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からね", unconjugatedWordType: WordType.KaraParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からさ", unconjugatedWordType: WordType.KaraParticle, conjugatedWordType: WordType.SaParticle),
            new DerivationRule(unconjugatedEnding: "から", conjugatedEnding: "からだ", unconjugatedWordType: WordType.KaraParticle, conjugatedWordType: WordType.Da),


            /*
            * Feminine wa particle rules
            */
            new DerivationRule(unconjugatedEnding: "わ", conjugatedEnding: "わよ", unconjugatedWordType: WordType.FeminineWaParticle, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "わ", conjugatedEnding: "わね", unconjugatedWordType: WordType.FeminineWaParticle, conjugatedWordType: WordType.NeParticle),

            /*
            * Yo particle rules
            */
            new DerivationRule(unconjugatedEnding: "よ", conjugatedEnding: "よね", unconjugatedWordType: WordType.YoParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "よ", conjugatedEnding: "よな", unconjugatedWordType: WordType.YoParticle, conjugatedWordType: WordType.NaParticle),

            /*
            * Ka particle rules
            */
            new DerivationRule(unconjugatedEnding: "か", conjugatedEnding: "かよ", unconjugatedWordType: WordType.KaParticle, conjugatedWordType: WordType.YoParticle),
            new DerivationRule(unconjugatedEnding: "か", conjugatedEnding: "かな", unconjugatedWordType: WordType.KaParticle, conjugatedWordType: WordType.NaParticle),
            new DerivationRule(unconjugatedEnding: "か", conjugatedEnding: "かね", unconjugatedWordType: WordType.KaParticle, conjugatedWordType: WordType.NeParticle),

            /*
            * Kedo particle rules
            */
            new DerivationRule(unconjugatedEnding: "けど", conjugatedEnding: "けどね", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "けれど", conjugatedEnding: "けれどね", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "けれども", conjugatedEnding: "けれども", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "けど", conjugatedEnding: "けどな", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NaParticle),
            new DerivationRule(unconjugatedEnding: "けれど", conjugatedEnding: "けれどな", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NaParticle),
            new DerivationRule(unconjugatedEnding: "けれども", conjugatedEnding: "けれどもな", unconjugatedWordType: WordType.KedoParticle, conjugatedWordType: WordType.NaParticle),

            /*
            * Noni particle rules
            */
            new DerivationRule(unconjugatedEnding: "のに", conjugatedEnding: "のにね", unconjugatedWordType: WordType.NoniParticle, conjugatedWordType: WordType.NeParticle),
            new DerivationRule(unconjugatedEnding: "のに", conjugatedEnding: "のにな", unconjugatedWordType: WordType.NoniParticle, conjugatedWordType: WordType.NaParticle),
        };
        
        private static readonly IReadOnlyDictionary<WordType, IReadOnlyList<DerivationRule>> DerivationRulesForConjugatedWordType;

        static Deconjugation()
        {
            DerivationRulesForConjugatedWordType = DerivationRules
                .GroupBy(rule => rule.ConjugatedWordType)
                .ToDictionary(grouping => grouping.Key, grouping => (IReadOnlyList<DerivationRule>)grouping.ToList());
        }
    }
}