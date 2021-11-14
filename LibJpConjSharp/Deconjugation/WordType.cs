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
using System.ComponentModel;
using System.Linq;

namespace LibJpConjSharp.Deconjugation
{
    public enum WordType
    {
        [Description("ます Polite")]
        PoliteMasu,
        [Description("です Polite")]
        PoliteDesuVerb,
        [Description("ません Polite Negative")]
        PoliteMasen,
        [Description("ませんでした Polite Negative Past")]
        PoliteMasenDeshita,
        [Description("ました Polite past")]
        PoliteMashita,
        [Description("ましょう Polite Volitional")]
        PoliteMashou,
        [Description("ない Negative")]
        NegativeNaiVerb,
        [Description("Plain Past")]
        PlainPast,
        [Description("て・で Form")]
        TeForm,
        [Description("Potential Form")]
        Potential,
        [Description("Potential Or Passive Form")]
        PotentialPassive,
        [Description("Passive Form")]
        Passive,
        [Description("ば Conditional Form")]
        BaForm,
        [Description("Imperative Form")]
        Imperative,
        [Description("Volitional Form")]
        Volitional,
        [Description("ます Stem")]
        MasuStem,
        [Description("そう Hearsay Form")]
        Hearsay,
        [Description("Causative Form")]
        Causative,
        [Description("Shortened Causative Form")]
        ShortenedCausative,
        [Description("たら Conditional Form")]
        Tara,
        [Description("なきゃ Casual \"Must Do\"")]
        Nakya,
        [Description("なくちゃ Casual \"Must Do\"")]
        Nakucha,
        [Description("あげく・挙句 After Great Trouble")]
        Ageku,
        [Description("たい Want To Do")]
        Tai,
        [Description("そう Appearance Form")]
        Appearance,
        [Description("ないで Without Doing")]
        Naide,
        [Description("な Negative Command (Do Not Do)")]
        NaCommand,
        [Description("まい Negative Volitional")]
        NegativeVolitional,
        [Description("なさい Polite But Firm Command")]
        Nasai,
        [Description("ず Without Doing")]
        Zu,
        [Description("く Adverbification")]
        Adverb,
        [Description("は Particle")]
        WaParticle,
        [Description("ている・でいる Continuing State/Result")]
        Iru,
        [Description("てある・である Form")]
        Aru,
        [Description("ておる・でおる Form")]
        Oru,
        [Description("ください Polite Request")]
        Kudasai,
        [Description("ぬ Archaic Negative")]
        Nu,
        [Description("わ Feminine Emphasis Particle")]
        FeminineWaParticle,
        [Description("よ Emphasis Particle")]
        YoParticle,
        [Description("ね Agreement Seeking Particle")]
        NeParticle,
        [Description("な Masculine Emphasis Particle")]
        NaParticle,
        [Description("ぞ Rough/Casual Emphasis Particle")]
        ZoParticle,
        [Description("ぜ Rough/Casual Emphasis Particle")]
        ZeParticle,
        [Description("か Question Particle")]
        KaParticle,
        [Description("が But")]
        GaParticle,
        [Description("さ Emphasis/Filler Particle")]
        SaParticle,
        [Description("まで Until")]
        MadeParticle,
        [Description("から Since, From")]
        KaraParticle,
        [Description("けど・けれど・けれども But")]
        KedoParticle,
        [Description("のに Even Though, Despite")]
        NoniParticle,
        [Description("でしょう Polite \"Probably\"")]
        PoliteDeshou,
        [Description("だろう Probably")]
        Darou,
        [Description("いただく Polite/Humble Receive Favor")]
        PoliteItadaku,
        [Description("もらう Casual Receive Favor")]
        Morau,
        [Description("べき Must Do")]
        Beki,
        [Description("ておく・でおく To Do Something In Preparation")]
        Oku,
        [Description("くれる To Give (Toward Speaker)")]
        Kureru,
        [Description("あげる To Give (Away From Speaker)")]
        Ageru,
        [Description("は Particle")]
        WaAfterTe,
        [Description("も Particle (Even, Even If)")]
        MoAfterTe,
        [Description("いい Good, Okay")]
        Ii,
        [Description("だ Copula")]
        Da,
        [Description("ことがある Occasional Occurance ・ It Happens Sometimes")]
        OccasionalOccuranceAru,
        [Description("の Explanatory Particle")]
        ExplanatoryNoParticle,
        [Description("こと Nominalizer")]
        KotoNominalizer,
        [Description("ことにする Decide To Do ・ Settle On Doing")]
        KotoNiSuru,
        [Description("ことになる Has Been Decided ・ Has Become The Case")]
        KotoNiNaru,
        [Description("前・まえ Before Doing")]
        Mae,
        [Description("が早いか As Soon As")]
        GaHayaiKa,
        [Description("みたい Looks Like ・ Seems Like")]
        Mitai,
        [Description("らしい Looks Like ・ Seems Like")]
        Rashii,
        [Description("がる Appearing To Want")]
        Garu,
        [Description("ます Stem しない Strong Emphasis On Not Doing")]
        MasuStemWaShinai,
        [Description("ながら While")]
        Nagara,
        [Description("がち Prone To ・ Unfortunate Tendency")]
        Gachi,
        [Description("方・かた Way Of Doing")]
        Kata,
        [Description("にくい Difficult To Do")]
        Nikui,
        [Description("やすい Easy To Do")]
        Yasui,
        [Description("過ぎ・すぎ Overdoing")]
        Sugi,
        [Description("過ぎる・すぎる Overdoing")]
        Sugiru,
        [Description("ます Stem に Going To Do")]
        MasuStemNi,
        [Description("なくて・なければ + いけない・ならない Must Do")]
        NakuteNakerebaIkenaiNaranai,
        [Description("ていけない・てならない Must Not Do")]
        TeIkenaiNaranai,
        [Description("だめ・駄目 Bad ・ Should Not")]
        TeDame,
        [Description("なくて・なければ + だめ・駄目 Must Do")]
        NakuteNakerebaDame,
        [Description("しまう To Do Unfortunately ・ To Do Completely")]
        Shimau,
        [Description("ちゃう Casual Contraction Of てしまう")]
        Chau,
        [Description("みる To Try To Do")]
        Miru,
        [Description("ほしい・欲しい To Want Someone To Do Something")]
        Hoshii,
        [Description("から Since, After")]
        TeKara,
        [Description("てくる・でくる Gradual Change (Toward Speaker)")]
        TeKuru,
        [Description("ていく・でいく Gradual Change (Away From Speaker)")]
        TeIku,
        [Description("かまう To Mind ・ To Care")]
        Kamau,
        [Description("すまない Sorry!")]
        Sumanai,
        [Description("すみません Polite Sorry")]
        Sumimasen,
        [Description("じまう Casual Contraction Of でしまう")]
        Jimau,
        [Description("ちまう Casual Contraction Of てしまう")]
        Chimau,
        [Description("じゃう Casual Contraction Of でしまう")]
        Jau,
        [Description("たり Et Cetera")]
        Tari,
        [Description("たばかり・だばかり To Have Just Done")]
        TaBakari,
        [Description("ほうがいい Better ・ Preferable")]
        HouGaIi,
        [Description("よう Appearance ・ It Seems That Way")]
        You,
        [Description("はず Expectation")]
        Hazu,
        [Description("なる To Become")]
        Naru,
        [Description("である Formal ・ Literary Copula")]
        DeAru,
        [Description("つつある In The Process Of")]
        TsutsuAru,
        [Description("がたい Difficult To Do (Due To Emotional Reasons)")]
        Gatai,
        [Description("次第・しだい Immediately After")]
        Shidai,
        [Description("やがる Shows Contempt For The Action Being Done")]
        Yagaru,
        [Description("べく In Order To")]
        Beku,
        [Description("godan verb")]
        GodanVerb,
        [Description("ichidan verb")]
        IchidanVerb,
        [Description("adjective")]
        Adjective,
        [Description("sentence ending particles (silent)")]
        SentenceEndingParticles,
        [Description("Negative ある or いる")]
        NegativeAruOrIru,
        [Description("てる・でる Continuing State/Result")]
        ShortIru,
    }

    public static class WordTypeUtils
    {
        public static string ToLongString(this WordType type)
        {
            if (mapping.TryGetValue(type, out var value))
            {
                return value;
            }

            return type.ToString();
        }
        
        private static readonly Dictionary<WordType, string> mapping = Enum.GetValues(typeof(WordType))
            .Cast<WordType>()
            .ToDictionary(e => e, e => Utils.GetEnumDescription(e));
    }
}