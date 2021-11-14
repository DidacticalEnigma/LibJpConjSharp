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
using System.ComponentModel;
using System.Reflection;

namespace LibJpConjSharp
{
    internal static class Utils
    {
        public static string Right(string input, int n)
        {
            if (n >= input.Length || n < 0)
                return input;
            return input.Substring(input.Length - n);
        }

        public static string Chop(string input, int n)
        {
            if (n < 0)
                return Chop(input, 0);
            if (n >= input.Length)
                return "";
            return input.Remove(input.Length - n);
        }

        public static string RemoveLastCharacter(string input)
        {
            return input.Substring(0, input.Length - 1);
        }

        // https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if(attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
