namespace DesafioPorter.Helpers
{
    public static class IntegerExtensions
    {
        public static string ToWords(this long number)
        {
            // It could be implemented for bigger numbers, but I chosse this limit
            if (number > 9999999999999)
            {
                return "valor ultrapassou o limite";
            }

            if (number == 0)
                return "zero";            
            
            if (number == 100)
                return "cem";

            if (number < 0)
                return "menos " + Math.Abs(number).ToWords();

            string words = "";

            long tri = 1000000000000;
            long bi = 1000000000;
            long mi = 1000000;
            long mil = 1000;

            if ((number / tri) > 0)
            {
                var plural = number / tri > 1 ? "trilhões" : "trilhão";
                words += (number / tri).ToWords() + $" {plural} ";
                number %= tri;
            }

            if ((number / bi) > 0)
            {
                var plural = number / bi > 1 ? "bilhões" : "bilhão";
                words += (number / bi).ToWords() + $" {plural} ";
                number %= bi;
            }

            if ((number / mi) > 0)
            {
                var plural = number / mi > 1 ? "milhões" : "milhão";
                words += (number / mi).ToWords() + $" {plural} ";
                number %= mi;
            }

            if ((number / mil) > 0)
            {
                words += (number / mil).ToWords() + " mil ";
                number %= mil;
            }

            if ((number / 100) > 0)
            {
                string[] hundredsMap = {
                    "cem", "cento ", "duzentos ", "trezentos ", "quatrocentos ", "quinhentos ", "seiscentos ", "setecentos ", "oitocentos ", "novecentos "
                };
                words += hundredsMap[number / 100];
                number %= 100;
            }

            string[] unitsMap = {
                "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove",
                "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove"
            };

            string[] tensMap = {
                "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"
            };

            if (number > 0)
            {
                if (words != "")
                {
                    words += "e ";
                }

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else 
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += " e " + unitsMap[number % 10];
                    }
                }
            }

            return words;
        }
    }
}
