using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLicence.Application.Helpers
{
    public class CNPJHelper
    {
        public static bool IsValid(string cnpj)
        {
            cnpj = cnpj?.Replace(".", "").Replace("/", "").Replace("-", "");

            if (cnpj is null || cnpj?.Length < 14)
                return false;

            return DigOneCalculus(cnpj) && DigTwoCalculus(cnpj);
        }

        private static bool DigOneCalculus(string cnpj)
        {
            var calculus = new List<int> { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int result = calculus.Select((num, index) => num * Int32.Parse(cnpj.Substring(index, 1))).Sum();

            return (result % 11 < 2 ? 0 : 11 - result % 11) == Int32.Parse(cnpj.Substring(cnpj.Length - 2, 1));
        }

        private static bool DigTwoCalculus(string cnpj)
        {
            var calculus = new List<int> { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int result = calculus.Select((num, index) => num * Int32.Parse(cnpj.Substring(index, 1))).Sum();

            return (result % 11 < 2 ? 0 : 11 - result % 11) == Int32.Parse(cnpj.Substring(cnpj.Length - 1, 1));
        }
    }
}