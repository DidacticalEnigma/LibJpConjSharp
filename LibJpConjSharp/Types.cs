// 2018, milleniumbug
// This file is a part of a LibJpConjSharp library
// which is a port of a LibJpConj C++ library, which is a part of the
// JapKatsuyou project.
// See below for the original copyright notice
/*
    This file is part of JapKatsuyou project; an application that provide
    Japanese verb conjugation
    Copyright (C) 2013  DzCoding group (JapKatsuyou team)
    Authors:
            Abdelkrime Aries <kariminfo0@gmail.com>
  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at
      http://www.apache.org/licenses/LICENSE-2.0
  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibJpConjSharp.Tests")]

namespace LibJpConjSharp
{
    // Characters which can be the ending of a verb in  dictionary form
    internal static class Constants
    {
        public static readonly string EndChars = "うくぐすつぬぶむるふ";
    }

    public static class EdictTypeUtils
    {
        public static bool IsGodan(EdictType type)
        {
            switch (type)
            {
                case EdictType.v5:
                case EdictType.v5aru:
                case EdictType.v5b:
                case EdictType.v5g:
                case EdictType.v5k:
                case EdictType.v5k_s:
                case EdictType.v5m:
                case EdictType.v5n:
                case EdictType.v5r:
                case EdictType.v5r_i:
                case EdictType.v5s:
                case EdictType.v5t:
                case EdictType.v5u:
                case EdictType.v5u_s:
                case EdictType.v5uru:
                case EdictType.v5z:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsIchidan(EdictType type)
        {
            switch (type)
            {
                case EdictType.v1:
                case EdictType.v1_s:
                    return true;
            }

            return false;
        }

        public static bool IsSuru(EdictType type)
        {
            switch (type)
            {
                case EdictType.vs:
                case EdictType.vs_c:
                case EdictType.vs_i:
                case EdictType.vs_s:
                    return true;
            }

            return false;
        }
        
        public static EdictType FromDescription(string description)
        {
            return mapping[description];
        }

        public static EdictType? FromDescriptionOrNull(string description)
        {
            if (mapping.TryGetValue(description, out var value))
            {
                return value;
            }

            return null;
        }

        public static string ToLongString(EdictType type)
        {
            if (inverseMapping.TryGetValue(type, out var value))
            {
                return value;
            }

            return type.ToString();
        }

        // https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if(attributes != null &&
               attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        private static readonly Dictionary<string, EdictType> mapping = Enum.GetValues(typeof(EdictType))
            .Cast<EdictType>()
            .ToDictionary(e => GetEnumDescription(e), e => e);

        private static readonly Dictionary<EdictType, string> inverseMapping =
            mapping.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
    }

    public enum EdictType
    {
        [Description("This means no type at all, it is used to return the radical as it is")]
        v0 = 0,

        [Description("Ichidan verb")]
        v1 = 1,

        [Description("Nidan verb with 'u' ending (archaic)")]
        v2a_s = 2,

        [Description("Yodan verb with `hu/fu' ending (archaic)")]
        v4h = 3,

        [Description("Yodan verb with `ru' ending (archaic)")]
        v4r = 4,

        [Description("Godan verb (not completely classified)")]
        v5 = 5,

        [Description("Godan verb - -aru special class")]
        v5aru = 6,

        [Description("Godan verb with `bu' ending")]
        v5b = 7,

        [Description("Godan verb with `gu' ending")]
        v5g = 8,

        [Description("Godan verb with `ku' ending")]
        v5k = 9,

        [Description("Godan verb - Iku/Yuku special class")]
        v5k_s = 10,

        [Description("Godan verb with `mu' ending")]
        v5m = 11,

        [Description("Godan verb with `nu' ending")]
        v5n = 12,

        [Description("Godan verb with `ru' ending")]
        v5r = 13,

        [Description("Godan verb with `ru' ending (irregular verb)")]
        v5r_i = 14,

        [Description("Godan verb with `su' ending")]
        v5s = 15,

        [Description("Godan verb with `tsu' ending")]
        v5t = 16,

        [Description("Godan verb with `u' ending")]
        v5u = 17,

        [Description("Godan verb with `u' ending (special class)")]
        v5u_s = 18,

        [Description("Godan verb - uru old class verb (old form of Eru)")]
        v5uru = 19,

        [Description("Godan verb with `zu' ending")]
        v5z = 20,

        [Description("Ichidan verb - zuru verb - (alternative form of -jiru verbs)")]
        vz = 21,

        [Description("Kuru verb - special class")]
        vk = 22,

        [Description("irregular nu verb")]
        vn = 23,

        [Description("noun or participle which takes the aux. verb suru")]
        vs = 24,

        [Description("su verb - precursor to the modern suru")]
        vs_c = 25,

        [Description("suru verb - irregular")]
        vs_i = 26,

        [Description("suru verb - special class")]
        vs_s = 27,

        [Description("Ichidan verb - kureru special class")]
        v1_s = 28
    }

    /*
     * \brief The CForm enum (Conjugation Form) contains the verb's complex forms.
     *
     * Conjugation Form: contains the verb's complex forms.
     * These forms are created from basic forms (a, e, t, u, i, o)-stems by adding suffixes.
     */
    public enum CForm
    {
        /* This is the te-form of the verb, it has no polite form */
        TeForm = 1,

        /* Present tense of the verb; plain (u-form + る), polite (i-form + ます)*/
        Present = 2,

        /* Past tense of the verb; plain (t-form + た), polite (i-form + ました) */
        Past = 3,

        /* Provision form (condition); plain (e-form + ば), polite (i-form + ますれば) */
        Provision = 4,

        /* Condiction form (past condition); plain (t-form + たら), polite (i-form + ましたら)*/
        Condition = 5,

        /* Imperative form; plain (eImp-form), polite (t-form + て下さい) */
        Imperative = 6,

        /* Volitional form (lets ...); plain (o-form + う), polite (i-form + ましょう) */
        Volitional = 7,

        /* Present continuous form; plain (t-form + ている), polite (t-form + ています) */
        PresentContinuous = 8,

        /* Past continuous form; plain (t-form + ていた), polite (t-form + ていました)*/
        PastContinuous = 9,

        /* Passive form; plain (a-form + れる), polite (a-form + れます) */
        Passive = 10,

        /* Causative form */
        Causative = 11,// a＋せる a＋させる
        CausativePassive = 12,// a＋せられる a＋させられる
        Potential = 13// e＋る e＋られる
        //Desire             = 14; // i + たい
        //WhileDoing         = 15; // ながら
        //WayOfDoing         = 16; // かた・方
    }

    /*
     * \brief The Polarity enum Gives the polartity of sentence: affirmative or negative
     */
    public enum Polarity
    {
        /* This is the negative conjugation of the verb. eg. don't go (polite present)*/
        Negative = 0,

        /* This is the affirnative conjugation of the verb. eg. 行きます: go (polite present)*/
        Affirmative = 1,
    }

    /*
     * \brief The Politeness enum Specifies if the verb is in plain form (used between friends),
     * or polite form (official talking)
     */
    public enum Politeness
    {
        /* Plain form of a verb. eg. 行く: go (plain present)*/
        Plain = 0,

        /* Polite form of a verb. eg. 行きます: go (polite present)*/
        Polite = 1
    };


    /*
     * \brief The KForm enum (Conjugation Form) contains the verb's basic forms.
     *
     * Katsuyou Form: contains the verb's basic forms.
     * These forms are thought in Japanese schools, and are origin of complex forms by adding suffixes.
     */
    public enum KForm
    {
        /* Imperfective (general), in Japanese: 未然形*/
        ImperfectiveA = 1,

        /* Imperfective (volutional), in Japanese also: 未然形*/
        ImperfectiveO = 2,

        /* Conjunctive (-i), in Japanese: 連用形*/
        ConjunctiveI = 3,

        /* Conjunctive (other), in Japanese also: 連用形*/
        ConjunctiveT = 4,

        /* Attributive, in Japanese: 終止形*/
        TerminalU = 5,

        /* Attributive, in Japanese: 連体形*/
        AttributiveU = 6,

        /* Hypothetical, in Japanese: 仮定形*/
        HypotheticalE = 7,

        /* Imperative, in Japanese: 命令形*/
        ImperativeE = 8
    }

    class VerbInfo
    {
        public string Verb { get; }

        public CForm Form { get; }

        public Polarity polarity { get; }

        public Politeness politeness { get; }

        public VerbInfo(string verb, CForm form, Polarity polarity = Polarity.Affirmative, Politeness politeness = Politeness.Plain)
        {
            Verb = verb ?? throw new ArgumentNullException(nameof(verb));
            Form = form;
            this.polarity = polarity;
            this.politeness = politeness;
        }
    };
}
