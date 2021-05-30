using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    public class latinizeLOL
    {
        public static string PrintLatinNumber(string numberString)
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
                {"7hundredth", "Septigenti"},
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
            
            int indexInNumber = numberString.Length;

            var stringOfNumberInLatin = "";
            
            if (indexInNumber == 1 && numberString[0] == '0')
            {
                return "Nihil";
            }

            foreach (char cc in numberString)
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
                }

                if (indexInNumber == 7 && cc == '1')
                {
                    alteredNumberString += cc.ToString() + "million";
                }
                else if (indexInNumber == 7 && cc != '1')
                {
                    return "Error 1: To high of a number, cant exceed 1999999";
                }

                stringOfNumberInLatin += numbersInLatin[alteredNumberString] + ",";

                indexInNumber--;
            }
            
            stringOfNumberInLatin = stringOfNumberInLatin[..^1];

            return stringOfNumberInLatin;
        }

        internal static ulong ReversePrintNumberInLatin(string stringOfNumberInLatin)
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
                {"Septigenti", 700},
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
            
            
            string[] backToNumberFromLatin = stringOfNumberInLatin.Split(',');

            for (var i = 0; i < backToNumberFromLatin.Length; i++)
            {
                backToNumberFromLatin[i] = reverseNumbersInLatin[backToNumberFromLatin[i]].ToString();
            }

            return backToNumberFromLatin.Aggregate<string, ulong>(0, (current, t) => current + (ulong) Convert.ToInt64(t));
        }

        public static string ToRoman(int number)
        {
            if (number is < 0 or > 1999999) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");

            if (number < 1) return string.Empty;
            if (number >= 1000000) return "M(|)" + "," + ToRoman(number - 1000000);
            if (number >= 900000) return "CM(|)" + "," + ToRoman(number - 900000); 
            if (number >= 500000) return "D(|)" + "," + ToRoman(number - 500000);
            if (number >= 400000) return "CD(|)" + "," + ToRoman(number - 400000);
            if (number >= 100000) return "C(|)" + "," + ToRoman(number - 100000);
        
            if (number >= 90000) return "XC" + "," + ToRoman(number - 90000);
            if (number >= 50000) return "L" + "," + ToRoman(number - 50000);
            if (number >= 40000) return "XL" + "," + ToRoman(number - 40000);
            if (number >= 10000) return "X" + "," + ToRoman(number - 10000);
            if (number >= 9000) return "IX" + "," + ToRoman(number - 9000);
            if (number >= 5000) return "V" + "," + ToRoman(number - 5000);
            if (number >= 4000) return "IV" + "," + ToRoman(number - 4000);
        
            if (number >= 1000) return "M" + "," + ToRoman(number - 1000);
            if (number >= 900) return "CM" + "," + ToRoman(number - 900); 
            if (number >= 500) return "D" + "," + ToRoman(number - 500);
            if (number >= 400) return "CD" + "," + ToRoman(number - 400);
            if (number >= 100) return "C" + "," + ToRoman(number - 100);            
            if (number >= 90) return "XC" + "," + ToRoman(number - 90);
            if (number >= 50) return "L" + "," + ToRoman(number - 50);
            if (number >= 40) return "XL" + "," + ToRoman(number - 40);
            if (number >= 10) return "X" + "," + ToRoman(number - 10);
            if (number >= 9) return "IX" + "," + ToRoman(number - 9);
            if (number >= 5) return "V" + "," + ToRoman(number - 5);
            if (number >= 4) return "IV" + "," + ToRoman(number - 4);
            if (number >= 1) return "I" + "," + ToRoman(number - 1);

            throw new ArgumentOutOfRangeException("Something bad happened");
        }
    }
}