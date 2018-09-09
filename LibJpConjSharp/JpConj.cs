using System;
using System.Collections.Generic;
using System.Text;

namespace LibJpConjSharp
{
    public class JpConj
    {
        public static string Conjugate(string verb, EdictType type, CForm form, Politeness polite = Politeness.Plain, Polarity affirmative = Polarity.Affirmative)
        {
            return Inflection.Conjugate(verb, type, form, polite, affirmative);
        }

        public static string Katsuyou(string verb, EdictType type, KForm form)
        {
            return Inflection.Katsuyou(verb, type, form);
        }
    }
}
