using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.EndPoint.Api.Helpers
{
    public class ShortUrlHelper
    {
        private const string Alphabet = "{C7CE719D-A14F-41E7-9850-1A4CD4A95DA3}";
        private static readonly int Base = Alphabet.Length;

        public static string Encode(int num)
        {
            var sb = new StringBuilder();
            while (num > 0)
            {
                sb.Insert(0, Alphabet.ElementAt(num % Base));
                num = num / Base;
            }
            return sb.ToString();
        }

        public static int Decode(string str)
        {
            var num = 0;
            for (var i = 0; i < str.Length; i++)
            {
                num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
            }
            return num;
        }
    }
}
