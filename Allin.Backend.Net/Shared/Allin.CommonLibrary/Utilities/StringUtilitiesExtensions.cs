using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Allin.Common.Utilities
{
   public static class StringUtilitiesExtensions
    {

        public static string? ToTitleCase(
            this string text)
        {

            if (text == null)
            {
                return null;
            }
            return Regex.Replace(text, @"\b\w", (Match match) => match.ToString().ToUpper());
        }
        public static string? ToCamelCase(
            this string text)
        {

            if (text == null)
            {
                return null;
            }
            return Regex.Replace(text, @"\b\w", (Match match) => match.ToString().ToLower());
        }

        public static string ConcatenateIgnoringNullEmpty(this string separator, params string?[] values)
        {
            return string.Join(separator, values.Where(value => !string.IsNullOrEmpty(value)));
        }
        public static string? ComplexModelQueryStringRemoveExtraChars(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return Regex.Replace(text.ToTitleCase()!, "\\[|\\]|{|}|\"", string.Empty);
            //return text.ToTitleCase()!.Replace("[", String.Empty).Replace("]", String.Empty).Replace("\"", String.Empty).Replace("{", String.Empty).Replace("}", String.Empty);
        }
        public static string? ComplexListModelQueryStringRemoveExtraChars(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return Regex.Replace(text.ToTitleCase()!, "\\[|\\]|\"", string.Empty);
            // return text.ToTitleCase()!.Replace("[", String.Empty).Replace("]", String.Empty).Replace("\"", String.Empty);
        }

        public static string SplitPascalCase(this string text)
        {
            //return Regex.Replace(text, @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
            return Regex.Replace(text, @"(\B[a-z](?=[A-Z])|\B[A-Z](?=[A-Z][^A-Z]))", "$1 ");
        }

        public static string ToPascalCase(this string? x)
        {
            if (string.IsNullOrEmpty(x) || x.Length <= 1)
                return x;
            return x[0].ToString().ToUpper() + x.Substring(1);
        }
        public static string EndSubstring(this string term, int length)
        {
            if (string.IsNullOrEmpty(term)) return term;
            var result =
                term.Length < length ? term :
                term.Substring(term.Length - length);
            return result;
        }

        public static string CleanedPhoneNumber9EndsChars(this string phoneNumber)
        {
            return CleanedPhoneNumber(phoneNumber).EndSubstring(9);
        }
        public static string CleanedPhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return phoneNumber;
            var result = phoneNumber.Trim().Replace(" ", string.Empty)
                .Replace("+", string.Empty)
                .Replace("0", " ")
                .TrimStart()
                .Replace(" ", "0")
                .Replace("-", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace(".", string.Empty)
                ;
            return result;
        }

        public static string Encode(this string input, string key)
        {
            byte[] keyByte = ToByteArray(key);
            HMACSHA1 hMacSha1 = new HMACSHA1(keyByte);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return hMacSha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s).ToUpper();
        }
        private static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        const string encryptKey = "mysyall2ey12345A129876@13456e8a0";
        public static string EncryptString(string text)
        {
            var key = Encoding.UTF8.GetBytes(encryptKey);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }



        public static string DecryptString(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(encryptKey);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

    }
}
