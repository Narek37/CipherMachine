using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CipherMachine
{
    class Cipher
    {

            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string revalphabet = "zyxwvutsrqponmlkjihgfedcba";
            const string RevAlphabet = "ZYXWVUTSRQPONMLKJIHGFEDCBA";


            ///////returns MD5 hash
    public string MD5(string text)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                byte[] result = md5.Hash;
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    str.Append(result[i].ToString("x2"));
                }

                return str.ToString();
            }
            //////returns SHA1 hash
            public string SHA1(string text)
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                byte[] result = sha1.Hash;
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    str.Append(result[i].ToString("x2"));
                }

                return str.ToString();
            }

            ////Caesar cipher///Method gets text and key then returns cipher////////////
            public string CaesarCipher(string text, int key)
            {
                char[] cipher = text.ToCharArray();

                for (int i = 0; i < cipher.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (cipher[i] == alphabet[j])
                        {
                            if (j + key > alphabet.Length - 1)
                            {
                                cipher[i] = alphabet[j + key - alphabet.Length];
                                break;
                            }
                            else
                            {
                                cipher[i] = alphabet[j + key];
                                break;
                            }
                        }
                        else

                        if (cipher[i] == Alphabet[j])
                        {
                            if (j + key > Alphabet.Length - 1)
                            {
                                cipher[i] = Alphabet[j + key - Alphabet.Length];
                                break;
                            }
                            else
                            {
                                cipher[i] = Alphabet[j + key];
                                break;
                            }
                        }

                    }
                }

                text = new string(cipher);
                return text;
            }

            ////Caesar cipher decoder///Method gets cipher and key then returns text////////////
            public string CaesarCipherDecode(string text, int key)
            {
                char[] cipher = text.ToCharArray();

                for (int i = 0; i < cipher.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (cipher[i] == alphabet[j])
                        {
                            if (j - key < 0)
                            {
                                cipher[i] = alphabet[alphabet.Length - key + j];
                                break;
                            }
                            else
                            {
                                cipher[i] = alphabet[j - key];
                                break;
                            }
                        }
                        else if (cipher[i] == Alphabet[j])
                        {
                            if (j - key < 0)
                            {
                                cipher[i] = Alphabet[Alphabet.Length - key + j];
                                break;
                            }
                            else
                            {
                                cipher[i] = Alphabet[j - key];
                                break;
                            }
                        }




                    }
                }

                text = new string(cipher);
                return text;
            }

            //////Reverse alphabet/////////////////////////////////
            public string ReverseAlphabet(string text)
            {
                char[] cipher = text.ToCharArray();


                for (int i = 0; i < cipher.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (cipher[i] == alphabet[j])
                        {
                            cipher[i] = revalphabet[j];
                            break;
                        }
                        else
                            if (cipher[i] == Alphabet[j])
                        {
                            cipher[i] = RevAlphabet[j];
                            break;
                        }
                    }
                }


                text = new string(cipher);
                return text;
            }


        
    }
}
