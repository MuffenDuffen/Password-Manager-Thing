using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace PasswordManger.RomanNumberStuff
{
    internal static class RomanNumeralCalculator
    {
        public static string ConvertToRomanNumeral(string word)
        {
            var intArrayWithCharsInNumberForm = new int[word.Length];
            var indexInArray = 0;

            foreach (var c in word)
            {
                intArrayWithCharsInNumberForm[indexInArray] = Convert.ToInt32(c);
                indexInArray++;
            }

            var finalString = intArrayWithCharsInNumberForm.Aggregate("", (current, c) => current + (CalculateRomanNumeral(c) + " , "));

            finalString = finalString[..^3];
            return finalString;
        }

        public static string ReverseConvertToRomanNumeral(string numeralWord)
        {
            var numbers = numeralWord.Split(new[] {" , "}, StringSplitOptions.None);

            for (var indexInNumbersArray = 0; indexInNumbersArray < numbers.Length; indexInNumbersArray++)
            {
                for (var indexInWord = 0; indexInWord < numbers[indexInNumbersArray].Length; indexInWord++)
                {
                    if (indexInWord == numbers[indexInNumbersArray].Length - 1 && numbers[indexInNumbersArray][indexInWord] == ',')
                    {
                        numbers[indexInNumbersArray] = numbers[indexInNumbersArray][..^1];
                    }
                }
            }


            return numbers.Aggregate("", (current, number) => current + (char) ReverseCalculateRomanNumeral(number));
        }

        private static ulong ReverseCalculateRomanNumeral(string numberInRomanNumeralsString)
        {
            var backToArabicNumberals = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},

                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},

                {"M", 1000},
                {"MV`", 4000},
                {"V`", 5000},
                {"MX`", 9000},

                {"X`", 10000},
                {"LX`", 40000},
                {"L`", 50000},
                {"XC`", 90000},

                {"C`", 100000},
                {"CD`", 400000},
                {"D`", 500000},
                {"CM`", 900000},
                {"M`", 1000000}
            };
            var numberInRomanNumeralsStringArray = numberInRomanNumeralsString.Split(',');
            var finalInt = new int[numberInRomanNumeralsString.Length];

            for (var i = 0; i < numberInRomanNumeralsStringArray.Length; i++)
            {
                finalInt[i] = backToArabicNumberals[numberInRomanNumeralsStringArray[i]];
            }

            return (ulong) finalInt.Sum();
        }

        private static readonly OrderedDictionary RomanNumerals = new OrderedDictionary()
        {
            {"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}, {"V`", 5000}, {"X`", 10000}, {"L`", 50000}, {"C`", 100000}, {"D`", 500000}, {"M`", 1000000}
        };

        private static string CalculateRomanNumeral(int currentInput)
        {
            var answer = "";

            if (!InputValidator.IsInputValid(currentInput)) return answer;

            if (IsInputEqualToOneOfTheRomanNumerals(currentInput))
            {
                var romanNumeral = GetRomanNumeralFromValue(currentInput);
                return romanNumeral;
            }

            int nextInput;
            if (IsInputLargerThanLargestRomanNumeralValue(currentInput))
            {
                var largestRomanNumeralValue = GetLargestRomanNumeralValue();
                var largestRomanNumeral = GetRomanNumeralFromValue(largestRomanNumeralValue);
                answer += largestRomanNumeral + ",";
                nextInput = currentInput - largestRomanNumeralValue;
            }
            else
            {
                var lowerRomanNumeralValue = GetLowerRomanNumeralValue(currentInput);
                var upperRomanNumeralValue = GetUpperRomanNumeralValue(lowerRomanNumeralValue);
                var upperRomanNumeralValueMinusInput = upperRomanNumeralValue - currentInput;
                var lowerPowerOfTenRomanNumeralValue = GetLowerPowerOfTenRomanNumeralValue(lowerRomanNumeralValue, upperRomanNumeralValue);

                if (CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(upperRomanNumeralValueMinusInput, lowerPowerOfTenRomanNumeralValue))
                {
                    var lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral = ConcatenateRomanNumeralsFromValues(lowerPowerOfTenRomanNumeralValue, upperRomanNumeralValue);
                    var lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue = upperRomanNumeralValue - lowerPowerOfTenRomanNumeralValue;
                    answer += lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral + ",";
                    nextInput = currentInput - lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue;
                }
                else
                {
                    answer += GetRomanNumeralFromValue(lowerRomanNumeralValue) + ",";
                    nextInput = currentInput - lowerRomanNumeralValue;
                }
            }

            answer += CalculateRomanNumeral(nextInput);


            return answer;
        }

        private static bool CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(int upperRomanNumeralValueMinusInput, int lowerPowerOfTenRomanNumeralValue)
        {
            return upperRomanNumeralValueMinusInput <= lowerPowerOfTenRomanNumeralValue;
        }

        private static bool IsInputEqualToOneOfTheRomanNumerals(int currentInput)
        {
            return RomanNumerals.ContainsValue(currentInput);
        }

        private static bool IsInputLargerThanLargestRomanNumeralValue(int input)
        {
            return input > GetLargestRomanNumeralValue();
        }

        private static int GetLargestRomanNumeralValue()
        {
            return GetRomanNumeralValueAtIndex(RomanNumerals.Count - 1);
        }

        private static int GetLowerPowerOfTenRomanNumeralValue(int lowerRomanNumeralValue, int upperRomanNumeralValue)
        {
            var lowerPowerOfTenRomanNumeralValue = lowerRomanNumeralValue;

            if (MathCalculator.IsValuePowerOfTen(upperRomanNumeralValue))
            {
                lowerPowerOfTenRomanNumeralValue = GetNextLowerPowerOfTenRomanNumeral(lowerRomanNumeralValue);
            }

            return lowerPowerOfTenRomanNumeralValue;
        }

        private static string ConcatenateRomanNumeralsFromValues(int beforeRomanNumeralValue, int afterRomanNumeralValue)
        {
            var lowerRomanNumeralPowerOfTen = GetRomanNumeralFromValue(beforeRomanNumeralValue);
            var upperRomanNumeral = GetRomanNumeralFromValue(afterRomanNumeralValue);
            return lowerRomanNumeralPowerOfTen + upperRomanNumeral;
        }

        private static int GetNextLowerPowerOfTenRomanNumeral(int currentValue)
        {
            var lowerPowerOfTenRomanNumeralValue = 0;
            if (MathCalculator.IsValuePowerOfTen(currentValue))
            {
                lowerPowerOfTenRomanNumeralValue = currentValue;
            }
            else
            {
                var lowerRomanNumeralIndex = RomanNumerals.IndexOfValue(currentValue);
                for (var i = lowerRomanNumeralIndex; i >= 0; i--)
                {
                    var currentRomanNumeralValue = GetRomanNumeralValueAtIndex(i);
                    if (!MathCalculator.IsValuePowerOfTen(currentRomanNumeralValue)) continue;

                    lowerPowerOfTenRomanNumeralValue = currentRomanNumeralValue;
                    break;
                }
            }

            return lowerPowerOfTenRomanNumeralValue;
        }

        private static int GetUpperRomanNumeralValue(int lowerRomanNumeralValue)
        {
            var indexOfLowerRomanNumeral = RomanNumerals.IndexOfValue(lowerRomanNumeralValue);
            var upperRomanNumeralValue = GetRomanNumeralValueAtIndex(indexOfLowerRomanNumeral + 1);
            return upperRomanNumeralValue;
        }

        private static int GetLowerRomanNumeralValue(int input)
        {
            for (var i = RomanNumerals.Count - 1; i >= 0; i--)
            {
                var romanNumeralValue = GetRomanNumeralValueAtIndex(i);

                if (romanNumeralValue <= input)
                {
                    return romanNumeralValue;
                }
            }

            throw new Exception(global::RomanNumerals.Strings.Strings.LowerRomanNumeralNotFound);
        }

        private static int GetRomanNumeralValueAtIndex(int index)
        {
            return (int)RomanNumerals[index];
        }

        private static string GetRomanNumeralFromValue(int value)
        {
            return (string) RomanNumerals.GetKeyFromFirstElementWithValue(value);
        }
    }
}