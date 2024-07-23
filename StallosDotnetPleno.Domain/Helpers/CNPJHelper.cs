namespace StallosDotnetPleno.Domain.Helpers
{
    public static class CNPJHelper
    {
        public static bool IsValidCNPJ(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
            {
                return false;
            }

            if (new string(cnpj[0], cnpj.Length) == cnpj)
            {
                return false;
            }

            var mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCnpj = cnpj[..12];
            var sum = 0;

            for (var i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * mult1[i];
            }

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            tempCnpj += digit;

            sum = 0;
            for (var i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * mult2[i];
            }

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();
            return cnpj.EndsWith(digit);
        }
    }
}