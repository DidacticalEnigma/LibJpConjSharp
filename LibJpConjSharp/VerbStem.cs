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
    internal class VerbStem
    {
        /*!
         * \class Verbstem
         * It is used to get the verb's six forms which are a, e, u, i, o, and t -forms.
         */

        //TODO: check suru types


        /*! \~english
         * @brief  aForm  Gives the a-form (stem) of a verb
         *
         *  The function take a \e radical \e of a verb and gives its a-form by changing the last character's sound
         * from \b u \b (dictionary form) to \b a \b \n
         * eg. 飲む -> 飲ま
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the a-form of the verb
         */
        public static string aForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical;

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical; //TODO: check

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "ら";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "ば";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "が";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "か";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                return radical + "か";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "ま";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "な";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "ら";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 1);
                return "|" + radical + "ら";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "さ";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "た";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "わ";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "わ";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical; //TODO: check

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical; //TODO: check

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 2);
                return radical + "|じ";

                case EdictType.vk://kuru verb - special class
                if(radical.EndsWith("く|"))
                {
                    radical = Utils.Chop(radical, 2);
                    radical += "こ|";
                }
                return radical;

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "な";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_c://su verb - precursor to the modern suru
                                    //radical = Utils.Chop(radical, 1);
                return radical + "せ";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|さ";
            }

            return radical;
        }



        /*! \~english
         * @brief  eForm  Gives the e-form (stem) of a verb
         *
         * In case of GODAN verbs, The function take a \e radical \e of a verb and gives its e-form by changing the last character's sound
         * from \b u \b (dictionary form) to \b e \b \n
         * eg. 飲む -> 飲め
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the e-form of the verb
         */
        public static string eForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical + "れ";

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical; //TODO: check

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "れ";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "べ";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "げ";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "け";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                return radical + "け";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "め";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "ね";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "れ";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 2);
                return radical + "|あれ";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "せ";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "て";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "え";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "え";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical; //TODO: check

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical; //TODO: check

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 2);
                return radical + "|(じ/ず)れ";

                case EdictType.vk://kuru verb - special class
                return radical + "れ";

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "ね";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|すれ";

                case EdictType.vs_c://su verb - precursor to the modern suru
                                    //radical = Utils.Chop(radical, 1);
                return radical + "すれ";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|すれ";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|せ";
            }

            return radical;
        }



        /*! \~english
         * @brief  eImpForm  Gives the e-imperative form (stem) of a verb
         *
         * It is the same as eImpForm, but in case of suru and kuru, ichidan, and zuru it's different
         * eg. する -> しろ
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the e-imperative form of the verb
         */
        public static string eImpForm(string radical, EdictType type)
        {
            switch(type)
            {

                case EdictType.v0: //just the radical
                return radical;

                case EdictType.v1:  //Ichidan verb
                return radical + "|(ろ/よ)";
                
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical + "|";

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "|い";

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 1);
                return radical + "|(じろ/じよ/ぜよ)";

                case EdictType.vk://kuru verb - special class
                if(radical.EndsWith("く"))
                {
                    radical = Utils.Chop(radical, 1);
                    radical += "こ";
                }
                return radical + "|い";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 1);
                return radical + "|(しろ/せよ)";

                case EdictType.vs_c://su verb - precursor to the modern suru
                return radical + "|せよ";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 1);
                return radical + "|(しろ/せよ)";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 1);
                return radical + "|(しろ/せよ)";
            }

            //if not included in special cases, the form is same as eForm
            return eForm(radical, type);
        }



        /*! \~english
         * @brief  tForm  Gives the t-form (stem) of a verb
         *
         * In case of GODAN verbs, The function take a \e radical \e of a verb and gives its t-form by changing the last character's sound
         * - u  to t 買う -> 買っ
         * - ku to i　歩く -> 歩い
         * - gu to i　泳ぐ -> 泳い
         * - su to shi 出す -> 出し
         * - tsu to t 立つ -> 立っ
         * - nu to n 死ぬ -> 死ん
         * - bu to n 遊ぶ -> 遊ん
         * - mu to n 飲む -> 飲ん
         * - ru to t eg. 取る -> 取っ
         *
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the t-form of the verb
         */
        public static string tForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical;

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical; //TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical; //TODO: check

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class くださる　なさる　etc.
                return radical + "っ";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "ん";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "い";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "い";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                if(radical.EndsWith("ゆ"))
                {
                    radical = Utils.Chop(radical, 1);
                    radical += "い";
                }
                return radical + "っ";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "ん";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "ん";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "っ";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 2);
                return radical + "|あっ";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "し";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "っ";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "っ";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "う";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical; //TODO: check

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical; //TODO: check

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 2);
                return radical + "|じ";

                case EdictType.vk://kuru verb - special class
                if(radical.EndsWith("く|"))
                {
                    radical = Utils.Chop(radical, 2);
                    radical += "き|";
                }
                return radical;

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "ん";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_c://su verb - precursor to the modern suru
                return radical + "し";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|し";
            }

            return radical;

        }



        /*! \~english
         * @brief  uForm  Gives the u-form (stem) of a verb
         *
         * Gives the dictionary form of a verb
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string dictionary form of the verb
         */
        public static string uForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical + "る";

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical + "う";

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical + "ふ";

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical + "る";

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "る";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "ぶ";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "ぐ";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "く";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                return radical + "く";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "む";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "ぬ";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "る";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 2);
                return radical + "|ある";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "す";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "つ";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "う";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "う";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical + "る";

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical + "ず";

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                return radical + "る";

                case EdictType.vk://kuru verb - special class
                return radical + "る";

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "ぬ";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|する";

                case EdictType.vs_c://su verb - precursor to the modern suru
                return radical + "する";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|する";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|する";
                
            }

            return radical;
        }



        /*! \~english
         * @brief  iForm  Gives the i-form (stem) of a verb
         *
         * In case of GODAN verbs, The function take a \e radical \e of a verb and gives its i-form by changing the last character's sound
         * from \b u \b (dictionary form) to \b i \b \n
         * eg. 飲む -> 飲み
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the i-form of the verb
         */
        public static string iForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical;

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical;//TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical;//TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical;//TODO: check

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "い";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "び";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "ぎ";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "き";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                return radical + "き";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "み";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "に";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "り";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 2);
                return radical + "|あり";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "し";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "ち";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "い";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "い";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical + "る";

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical + "ず";

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 2);
                return radical + "|じ";

                case EdictType.vk://kuru verb - special class
                if(radical.EndsWith("く|"))
                {
                    radical = Utils.Chop(radical, 2);
                    return radical + "き|";
                }
                return radical;

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "に";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_c://su verb - precursor to the modern suru
                return radical + "し";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|し";
            }

            return radical;

        }


        /*! \~english
         * @brief  oForm  Gives the o-form (stem) of a verb
         *
         *  The function take a \e radical \e of a verb and gives its o-form by changing the last character's sound
         * from \b u \b (dictionary form) to \b o \b \n
         * eg. 飲む -> 飲も
         * @param radical It is the part which never get changed during conjugation,
         * we can get it dictionary form (u-form) minus the last character (eg. 飲む -> 飲)
         * @param type type of the verb: v1, v5u, etc. (See EdictType)
         * @return string the o-form of the verb
         */
        public static string oForm(string radical, EdictType type)
        {
            radical += "|";

            switch(type)
            {

                case EdictType.v0: //just the radical
                radical = Utils.Chop(radical, 1);
                return radical;

                case EdictType.v1:  //Ichidan verb
                case EdictType.v1_s:  //Ichidan verb - kureru special class
                return radical;

                case EdictType.v2a_s:   //Nidan verb with 'u' ending (archaic)
                return radical;//TODO: check

                case EdictType.v4h:     //Yondan verb with 'hu/fu' ending (archaic)
                return radical;//TODO: check

                case EdictType.v4r: //Yondan verb with 'ru' ending (archaic)
                return radical;//TODO: check

                case EdictType.v5://Godan verb (not completely classified)
                return radical; //TODO: check

                case EdictType.v5aru: //Godan verb - -aru special class
                return radical + "ろ";

                case EdictType.v5b://Godan verb with 'bu' ending
                return radical + "ぼ";

                case EdictType.v5g://Godan verb with 'gu' ending
                return radical + "ご";

                case EdictType.v5k://Godan verb with 'ku' ending
                return radical + "こ";

                case EdictType.v5k_s://Godan verb - iku/yuku special class
                return radical + "こ";

                case EdictType.v5m://Godan verb with 'mu' ending
                return radical + "も";

                case EdictType.v5n://Godan verb with 'nu' ending
                return radical + "の";

                case EdictType.v5r://Godan verb with 'ru' ending
                return radical + "ろ";

                case EdictType.v5r_i://Godan verb with 'ru' ending (irregular verb) ある
                radical = Utils.Chop(radical, 2);
                return radical + "|あり";

                case EdictType.v5s://Godan verb with 'su' ending
                return radical + "そ";

                case EdictType.v5t://Godan verb with 'tsu' ending
                return radical + "と";

                case EdictType.v5u://Godan verb with 'u' ending
                return radical + "お";

                case EdictType.v5u_s: //Godan verb with 'u' ending (special class) こう　とう
                return radical + "お";

                case EdictType.v5uru://Godan verb - uru old class verb (old form of Eru)
                return radical + "ろ";

                case EdictType.v5z://Godan verb with 'zu' ending
                return radical + "ず";

                case EdictType.vz://Ichidan verb - zuru verb - (alternative form of -jiru verbs)
                radical = Utils.Chop(radical, 2);
                return radical + "|じ";

                case EdictType.vk://kuru verb - special class
                if(radical.EndsWith("く|"))
                {
                    radical = Utils.Chop(radical, 2);
                    return radical + "こ|";
                }
                return radical;

                case EdictType.vn://irregular nu verb 死ぬ
                return radical + "の";

                case EdictType.vs://noun or participle which takes the aux. verb suru
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_c://su verb - precursor to the modern suru
                return radical + "し";

                case EdictType.vs_i://suru verb - irregular
                radical = Utils.Chop(radical, 2);
                return radical + "|し";

                case EdictType.vs_s: //suru verb - special class
                radical = Utils.Chop(radical, 2);
                return radical + "|し";
            }

            return radical;

        }
    }
}
