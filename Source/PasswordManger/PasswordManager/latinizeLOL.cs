using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class LatinizeLol
    {
        internal static string ReverseConvertStringToLatinNumber(string numberInStrings)
        {
            var numbers = numberInStrings.Split(new[] {" , "}, StringSplitOptions.None);

            return numbers.Select(ReversePrintNumberInLatin).Aggregate("", (current, numberBackFromLatin) => current + ((char) numberBackFromLatin));
        }

        internal static string ConvertStringToLatinNumber(string numberInString)
        {
            var intArrayWithCharsInNumberForm = new int[numberInString.Length];
            var indexInArray = 0;

            foreach (var c in numberInString)
            {
                intArrayWithCharsInNumberForm[indexInArray] = Convert.ToInt32(c);
                indexInArray++;
            }

            var finalString = intArrayWithCharsInNumberForm.Select(number => PrintLatinNumber(number.ToString())).Aggregate("", (current, numberInLatin) => current + (numberInLatin + " , "));

            finalString = finalString[..^3];
            return finalString;
        }

        private static string PrintLatinNumber(string numberString)
        {
            var numbersInLatin = new Dictionary<string, string>
            {
                {"1s", "Unos"},
                {"2s", "Duo"},
                {"3s", "Tres"},
                {"4s", "Quattuor"},
                {"5s", "Quinque"},
                {"6s", "Sex"},
                {"7s", "Septem"},
                {"8s", "Octo"},
                {"9s", "Novem"},

                {"1tenth", "Decem"},
                {"2tenth", "Viginti"},
                {"3tenth", "Triginta"},
                {"4tenth", "Quadraginta"},
                {"5tenth", "Quinquaginta"},
                {"6tenth", "Sexaginta"},
                {"7tenth", "Septuaginta"},
                {"8tenth", "Octoginta"},
                {"9tenth", "Nonaginta"},

                {"1hundredth", "Centum"},
                {"2hundredth", "Ducenti"},
                {"3hundredth", "Trecenti"},
                {"4hundredth", "Quadrigenti"},
                {"5hundredth", "Quingenti"},
                {"6hundredth", "Sescenti"},
                {"7hundredth", "Septingenti"},
                {"8hundredth", "Octingenti"},
                {"9hundredth", "Nongenti"},

                {"1thousandth", "Mille"},
                {"2thousandth", "Duo Mille"},
                {"3thousandth", "Tres Mille"},
                {"4thousandth", "Quattuor Mille"},
                {"5thousandth", "Quinque Milia"},
                {"6thousandth", "Sex Milia"},
                {"7thousandth", "Septem Milia"},
                {"8thousandth", "Octo Milia"},
                {"9thousandth", "Novem Milia"},

                {"1tenthousandth", "Decem Milia"},
                {"2tenthousandth", "Viginti Milia"},
                {"3tenthousandth", "triginta Milia"},
                {"4tenthousandth", "Quadraginta Milia"},
                {"5tenthousandth", "Quinquaginta Milia"},
                {"6tenthousandth", "Sexaginta Milia"},
                {"7tenthousandth", "Septuaginta Milia"},
                {"8tenthousandth", "Octoginta Milia"},
                {"9tenthousandth", "Nonaginta Milia"},

                {"1hundredthousandth", "Centum Milia"},
                {"2hundredthousandth", "Ducenti Milia"},
                {"3hundredthousandth", "Trecenta Millia"},
                {"4hundredthousandth", "Quadrigenti Milia"},
                {"5hundredthousandth", "Quingenta Milia"},
                {"6hundredthousandth", "Sescenti Milia"},
                {"7hundredthousandth", "Septigenti Milia"},
                {"8hundredthousandth", "Octingenti Milia"},
                {"9hundredthousandth", "Nongenti Milia"},

                {"1million", "Deciec centena milia"}
            };

            var indexInNumber = numberString.Length;

            var stringOfNumberInLatin = "";

            if (indexInNumber == 1 && numberString[0] == '0')
            {
                return "Nihil";
            }

            foreach (var cc in numberString)
            {
                var alteredNumberString = "";

                if (cc == '0')
                {
                    indexInNumber--;
                    continue;
                }

                switch (indexInNumber)
                {
                    case 1:
                    {
                        alteredNumberString += cc.ToString() + "s";
                        break;
                    }
                    case 2:
                    {
                        alteredNumberString += cc.ToString() + "tenth";
                        break;
                    }
                    case 3:
                    {
                        alteredNumberString += cc.ToString() + "hundredth";
                        break;
                    }
                    case 4:
                    {
                        alteredNumberString += cc.ToString() + "thousandth";
                        break;
                    }
                    case 5:
                    {
                        alteredNumberString += cc.ToString() + "tenthousandth";
                        break;
                    }
                    case 6:
                    {
                        alteredNumberString += cc.ToString() + "hundredthousandth";
                        break;
                    }
                    case 7 when cc == '1':
                        alteredNumberString += cc.ToString() + "million";
                        break;
                    case 7 when cc != '1':
                        return "Error 1: To high of a number, cant exceed 1999999";
                }

                stringOfNumberInLatin += numbersInLatin[alteredNumberString] + ",";

                indexInNumber--;
            }

            stringOfNumberInLatin = stringOfNumberInLatin[..^1];

            return stringOfNumberInLatin;
        }

        private static ulong ReversePrintNumberInLatin(string stringOfNumberInLatin)
        {
            var reverseNumbersInLatin = new Dictionary<string, int>
            {
                {"Unos", 1},
                {"Duo", 2},
                {"Tres", 3},
                {"Quattuor", 4},
                {"Quinque", 5},
                {"Sex", 6},
                {"Septem", 7},
                {"Octo", 8},
                {"Novem", 9},

                {"Decem", 10},
                {"Viginti", 20},
                {"Triginta", 30},
                {"Quadraginta", 40},
                {"Quinquaginta", 50},
                {"Sexaginta", 60},
                {"Septuaginta", 70},
                {"Octoginta", 80},
                {"Nonaginta", 90},

                {"Centum", 100},
                {"Ducenti", 200},
                {"Trecenti", 300},
                {"Quadrigenti", 400},
                {"Quingenti", 500},
                {"Sescenti", 600},
                {"Septingenti", 700},
                {"Octingenti", 800},
                {"Nongenti", 900},

                {"Mille", 1000},
                {"Duo Mille", 2000},
                {"Tres Mille", 3000},
                {"Quattuor Mille", 4000},
                {"Quinque Milia", 5000},
                {"Sex Milia", 6000},
                {"Septem Milia", 7000},
                {"Octo Milia", 8000},
                {"Novem Milia", 9000},

                {"Decem Milia", 10000},
                {"Viginti Milia", 20000},
                {"triginta Milia", 30000},
                {"Quadraginta Milia", 40000},
                {"Quinquaginta Milia", 50000},
                {"Sexaginta Milia", 60000},
                {"Septuaginta Milia", 70000},
                {"Octoginta Milia", 80000},
                {"Nonaginta Milia", 90000},

                {"Centum Milia", 100000},
                {"Ducenti Milia", 200000},
                {"Trecenta Millia", 300000},
                {"Quadrigenti Milia", 400000},
                {"Quingenta Milia", 500000},
                {"Sescenti Milia", 600000},
                {"Septigenti Milia", 700000},
                {"Octingenti Milia", 800000},
                {"Nongenti Milia", 900000},

                {"Deciec centena milia", 1000000}
            };


            var backToNumberFromLatin = stringOfNumberInLatin.Split(',');

            for (var i = 0; i < backToNumberFromLatin.Length; i++)
            {
                backToNumberFromLatin[i] = reverseNumbersInLatin[backToNumberFromLatin[i]].ToString();
            }

            return backToNumberFromLatin.Aggregate<string, ulong>(0, (current, t) => current + (ulong) Convert.ToInt64(t));
        }
    }
}
