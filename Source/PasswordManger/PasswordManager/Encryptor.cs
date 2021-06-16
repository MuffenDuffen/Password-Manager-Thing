using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordManger
{
    internal abstract class Encryptor
    {
        public static string EncryptCredential(Credential credential, int[] key, ulong shift, string passPhrase)
        {
            var encrypted = EncryptString(credential.AppName, key, shift, passPhrase).Length + "," +
                            EncryptString(credential.Email, key, shift, passPhrase).Length + "," +
                            EncryptString(credential.Password, key, shift, passPhrase).Length + " " +
                            EncryptString(credential.AppName, key, shift, passPhrase) +
                            EncryptString(credential.Email, key, shift, passPhrase) +
                            EncryptString(credential.Password, key, shift, passPhrase);

            return encrypted;
        }

        public static string EncryptString(string encrypt, int[] key, ulong encryptShift, string passPhrase) //ToDo mek function us key
        {
            var text = new List<string>();

            var result = encrypt;
            foreach (var i in key)
            {
                result = i switch
                {
                    0 => NextChar(result),
                    1 => InvertBits(result),
                    2 => LatinizeLol.ConvertStringToLatinNumber(result),
                    3 => Caesarion(result, encryptShift),
                    4 => RomanNumberStuff.RomanNumeralCalculator.ConvertToRomanNumeral(result),
                    //5 => HexStuff.wordToHex(result),
                    6 => CharAdder(result, passPhrase),
                    7 => PythagoranTheorem.PTheoremWWords(result),
                    8 => reverseString(result),
                    9 => StringLolifierlol.LOLIFIERLOL(result),
                    10 => CircumferenceStuff.GetCircumferenceOfCharWithEntireText(result),
                    11 => BitReverserOfDoom.ReverseBitOrder(result),
                    _ => result
                };
            }

            return result;
        }

        //Gets next char and replaces old one

            //encryptions, replacecharwithnextchar, toandinvertbinary,
            
            private static string Caesarion(string encrypt, ulong shift)
            {
                var encryptArray = encrypt.ToCharArray();

                encryptArray = encryptArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar + shift)).ToArray();

                return new string(encryptArray);
            }

            private static string CharAdder(string input, string passPhrase)
            {
                var inputArray = input.ToCharArray();

                foreach (var passChar in passPhrase)
                {
                    for (var i = 0; i < inputArray.Length; i++)
                    {
                        inputArray[i] = (char) (Convert.ToInt64(inputArray[i]) + Convert.ToInt64(passChar));
                    }
                }

                return new string(inputArray);
            }

            public static string reverseString(string word)
            {
                var wordCharArray = word.ToCharArray();
                Array.Reverse(wordCharArray);

                return new string(wordCharArray);
            }

            private static string NextChar(string stringToNextChar) // adds one to the UTF-8 value
            {
                var stringToNextCharArray = stringToNextChar.ToCharArray();

                stringToNextCharArray = stringToNextCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar + 1)).ToArray();

                return stringToNextCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
            }

            public static string InvertBits(string stringToInvert) // converts each characters UTF-8 value into bits and inverts it, then converts back to chars. China warning
            {
                var inverted = stringToInvert.ToCharArray();
                for (var i = 0; i < inverted.Length; i++)
                {
                    inverted[i] = (char) ~Convert.ToInt64(inverted[i]);
                }

                return new string(inverted);
            }
    }
}