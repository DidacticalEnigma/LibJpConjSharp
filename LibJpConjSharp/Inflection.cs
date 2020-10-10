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

namespace LibJpConjSharp
{
    internal class Inflection
    {
        /*!
         * \brief Inflection::tEnd Used to get te or ta forms
         *
         * There are verbs which take de (da) in the end, in te (ta) forms,
         * those verbs are ending with ぬ, む, ぶ, and ぐ
         * \param end give the end of the verb in dictionary form (u-form)
         * \param te when it is True (te-form), when False (ta-form)
         * \return te, ta, de, da
         */
        private static string tEnd(string end, bool te)
        {

            if ("ぬむぶぐ".Contains(end))
            {
                if (te)
                    return "|で";
                return "|だ";
            }

            if (te)
                return "|て";
            return "|た";
        }

        public static string Conjugate(string verb, EdictType type, CForm form, Politeness polite, Polarity affirmative)
        {
            if (verb.Length < 2)
                return verb;

            string radical = verb;
            string end = Utils.Right(verb, 1);
            radical = Utils.Chop(radical, 1);

            string bar = "|";

            switch (form)
            {

                case CForm.TeForm:
                    if (affirmative != 0)
                        return VerbStem.tForm(radical, type) + tEnd(end, true);
                    if (type == EdictType.v5r_i)
                    {
                        var aru = Utils.Chop(radical, 1);
                        return aru + "||なくて";
                    }
                    
                    return VerbStem.aForm(radical, type) + "|なくて";

                case CForm.Present:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.iForm(radical, type) + "|ます";
                        return VerbStem.iForm(radical, type) + "|ません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.uForm(radical, type) + "|";
                    if (type == EdictType.v5r_i)
                    {
                        var aru = Utils.Chop(radical, 1);
                        return aru + "||ない";
                    }
                    
                    return VerbStem.aForm(radical, type) + "|ない";

                case CForm.Past:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.iForm(radical, type) + "|ました";
                        return VerbStem.iForm(radical, type) + "|ませんでした";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.tForm(radical, type) + tEnd(end, false);
                    return VerbStem.aForm(radical, type) + "|なかった";

                case CForm.Provision:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.iForm(radical, type) + "|ますれば";
                        return VerbStem.iForm(radical, type) + "|ませんならば";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.eForm(radical, type) + "|ば";
                    return VerbStem.aForm(radical, type) + "|なければ";

                case CForm.Condition:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.iForm(radical, type) + "|ましたら";
                        return VerbStem.iForm(radical, type) + "|ませんでしたら";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.tForm(radical, type) + tEnd(end, false) + "ら";
                    return VerbStem.aForm(radical, type) + "|なかったら";

                case CForm.Imperative:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.tForm(radical, type) + tEnd(end, true) + "下さい";
                        return VerbStem.aForm(radical, type) + "|ないで下さい";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.eImpForm(radical, type) + "|";
                    return VerbStem.uForm(radical, type) + "|な";

                case CForm.Volitional:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.iForm(radical, type) + "|ましょう";
                        return VerbStem.uForm(radical, type) + "|のをやめましょう";
                    }
                    //plain
                    if (affirmative != 0)
                    {
                        if (type == EdictType.v5r_i)
                        {
                            return "|" + radical + "|ろう";
                        }

                        if (!EdictTypeUtils.IsGodan(type) && type != EdictType.vn)
                        {
                            return VerbStem.oForm(radical, type) + "|よう";
                        }

                        return VerbStem.oForm(radical, type) + "|う";
                    }

                    return VerbStem.uForm(radical, type) + "|のをやめよう";

                case CForm.PresentContinuous:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.tForm(radical, type) + tEnd(end, true) + "います";
                        return VerbStem.tForm(radical, type) + tEnd(end, true) + "いません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.tForm(radical, type) + tEnd(end, true) + "いる";
                    return VerbStem.tForm(radical, type) + tEnd(end, true) + "いない";

                case CForm.PastContinuous:
                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.tForm(radical, type) + tEnd(end, true) + "いました";
                        return VerbStem.tForm(radical, type) + tEnd(end, true) + "いませんでした";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.tForm(radical, type) + tEnd(end, true) + "いた";
                    return VerbStem.tForm(radical, type) + tEnd(end, true) + "いなかった";

                case CForm.Potential:

                    if (type == EdictType.v1)
                    {
                        radical += "||られ"; // radical + られ
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if (type == EdictType.vs_s)
                    {
                        
                    }
                    else if (type >= EdictType.vs)
                    { //suru verbs numbers are 27 26 25 24
                        if (type != EdictType.vs_c) // suru verb number 25 ends with su,  no need to chop it
                            radical = Utils.Chop(radical, 1);
                        radical += "||でき";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if (type == EdictType.vk)
                    {
                        if (radical.EndsWith("く"))
                        {
                            radical = Utils.Chop(radical, 1) + "こ";
                        }
                        radical += "||られ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }

                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.eForm(radical, type) + bar + "ます";
                        return VerbStem.eForm(radical, type) + bar + "ません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.eForm(radical, type) + bar + "る";
                    return VerbStem.eForm(radical, type) + bar + "ない";

                case CForm.Passive:
                    if (type == EdictType.v1)
                    {
                        radical += "||ら";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if (type >= EdictType.vs)
                    { //suru verbs numbers are 27 26 25 24
                        if (type != EdictType.vs_c) // suru verb number 27 ends with su,  no need to chop it
                            radical = Utils.Chop(radical, 1);
                        radical += "||さ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if(type == EdictType.vk || type == EdictType.vz)
                    {
                        bar = "|ら";
                    }

                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.aForm(radical, type) + bar + "れます";
                        return VerbStem.aForm(radical, type) + bar + "れません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.aForm(radical, type) + bar + "れる";
                    return VerbStem.aForm(radical, type) + bar + "れない";

                case CForm.Causative:
                    if (type == EdictType.v1)
                    {
                        radical += "||さ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if (type >= EdictType.vs)
                    { //suru verbs numbers are 27 26 25 24
                        if (type != EdictType.vs_c) // suru verb number 27 ends with su,  no need to chop it
                            radical = Utils.Chop(radical, 1);
                        radical += "||さ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if(type == EdictType.vk || type == EdictType.vz)
                    {
                        bar = "|さ";
                    }

                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.aForm(radical, type) + bar + "せます";
                        return VerbStem.aForm(radical, type) + bar + "せません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.aForm(radical, type) + bar + "せる";
                    return VerbStem.aForm(radical, type) + bar + "せない";

                case CForm.CausativePassive:
                    if (type == EdictType.v1)
                    {
                        radical += "||さ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if (type >= EdictType.vs)
                    { //suru verbs numbers are 27 26 25 24
                        if (type != EdictType.vs_c) // suru verb number 27 ends with su,  no need to chop it
                            radical = Utils.Chop(radical, 1);
                        radical += "||さ";
                        type = EdictType.v0; //to prevent changing the radical when using eForm
                        bar = "";
                    }
                    else if(type == EdictType.vk || type == EdictType.vz)
                    {
                        bar = "|さ";
                    }

                    if (polite != 0)
                    {
                        if (affirmative != 0)
                            return VerbStem.aForm(radical, type) + bar + "せられます";
                        return VerbStem.aForm(radical, type) + bar + "せられません";
                    }
                    //plain
                    if (affirmative != 0)
                        return VerbStem.aForm(radical, type) + bar + "せられる";
                    return VerbStem.aForm(radical, type) + bar + "せられない";
            }

            return verb;
        }


        public static string Katsuyou(string verb, EdictType type, KForm form)
        {
            if (verb.Length < 2)
                return verb;

            string radical = verb;
            radical = Utils.Chop(radical, 1);


            switch (form)
            {
                case KForm.ImperfectiveA:
                    return VerbStem.aForm(radical, type);

                case KForm.ImperfectiveO:
                    return VerbStem.oForm(radical, type);

                case KForm.ConjunctiveI:
                    return VerbStem.iForm(radical, type);

                case KForm.ConjunctiveT:
                    return VerbStem.tForm(radical, type);

                case KForm.TerminalU:
                    return VerbStem.uForm(radical, type);

                case KForm.AttributiveU:
                    return VerbStem.uForm(radical, type);

                case KForm.HypotheticalE:
                    return VerbStem.eForm(radical, type);

                case KForm.ImperativeE:
                    return VerbStem.eImpForm(radical, type);

                default:
                    break;
            }

            return verb;
        }
    }
}
