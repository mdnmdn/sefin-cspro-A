using System;
using System.Collections.Generic;

namespace Sefin.CsProA.GenericsPlay
{
    public class ExtensionPlay
    {
        public void Intro() {
            var txt = "wow!";

            

            StringExtender.Truncate(txt, 12);

            txt.Truncate(12);

            var fileName = StringExtender.RemoveChars(txt, "è");

            fileName = txt.RemoveChars("à")
                           .RemoveChars("è")
                           .RemoveChars("ò")
                           .Truncate(20);

            StringExtender.Truncate(
                StringExtender.RemoveChars(
                    StringExtender.RemoveChars(
                        StringExtender.RemoveChars(txt, "è"), "à"), "ò"), 20);                    

            if (txt.IsEmpty()) {

            }
        }


    }

    public static class StringExtender {

        public static bool IsEmpty(this object obj)
        {
            return obj == null;
        }

        public static bool IsEmpty(this string txt) {
            return String.IsNullOrEmpty(txt);
        }

        public static bool HasValue(this string txt)
        {
            return !String.IsNullOrEmpty(txt);
        }

        public static string RemoveChars(this string text, string charsTorRemove) {
            return text.Replace(charsTorRemove, " ");
        }

        public static string Truncate(this string txt, int maxLen, string ellipsis = "...") {
            if (txt != null && txt.Length > maxLen) {
                return txt.Substring(0, maxLen) + ellipsis;
            }
            return txt;
        }
    }
}
