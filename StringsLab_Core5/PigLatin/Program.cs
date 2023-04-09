using System;
using System.Linq;

namespace PigLatin
{
    class Program
    {
        /*  1.==============================================================================================
		Design and implement a program that processes a string entered from the keyboard.  The application will
		- convert the string to upper and lowercase
		- reverse the string
		- count the number punctuation characters in the string
		- find the index of the first vowel in the string
		- divide the string up into "words"
		
		2.==============================================================================================
		Design and implement a program that converts a sentence entered by the user into pig latin.
		- version 1 - 	moves the first character to the end and adds ay
		- version 2 - 	words that start with vowels - add way to the end
						words that start with consonants - same as version 1
						
        */
        public static void Main()
        {
            Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
            string input = Console.ReadLine();

            // uppercase and lowercase
            string lower = input.ToLower();
            Console.WriteLine("Converted to lowercase: " + lower);
            string upper = input.ToUpper();
            Console.WriteLine("Converted to uppercase: " + upper);

            // iterate through a string with a foreach loop
            string reverse = "";
            foreach (char c in input)
                reverse = c + reverse;
            Console.WriteLine("In reverse: " + reverse);

            // use Char method.  Note that most of the Char methods are static - they get called on a CLASS
            // Math.pow is a static method.  gen.Next(..) gets called on a random OBJECT and is NOT static
            int pCount = 0;
            foreach (char c in input)
                if (Char.IsPunctuation(c))
                    pCount++;
            Console.WriteLine("Puncutation count: " + pCount);

            // find the index of the first vowel in a string
            // see the method IsVowel below
            int vIndex = -1;
            // a string has a Length property  - just like an array
            for (int i = 0; i < input.Length && vIndex == -1; i++)
            {
                char c = input[i];
                if (IsVowel(c))
                    vIndex = i;
            }
            Console.WriteLine("The index of the first vowel is: " + vIndex);

            // create an array of strings from a string.  Default delimiter is white space.
            string[] words = input.Split();
            foreach (string word in words)
                Console.WriteLine(word);
            if (input.Length > 0)
            {
                /*string pig1 = PigLatin1(words[0]);
                Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig1);

                string pig2 = PigLatin2(words[0]);
                Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig2);

                string pig3 = PigLatin3(words[0]);
                Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig3);

                string pig4 = PigLatin4(words[0]);
                Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig4);*/

                string pig5 = PigLatin5(words[0]);
                Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig5);

                string pig6 = PigLatin6(words);
                Console.WriteLine("The phrase {0} in pig latin is: {1}", input, pig6);
            }

            char b = 'b';
            Console.WriteLine("Here's a character: " + b);
            int asciiOFb = (int)b;
            Console.WriteLine("Here's its ascii value: " + asciiOFb);
            char bPlus1 = (char)(asciiOFb + 1);
            Console.WriteLine("Here's the character after adding 10 to it's ascii value: " + bPlus1);
            char z = 'z';
            Console.WriteLine("Here's a character: " + z);
            int asciiOFz = (int)z;
            Console.WriteLine("Here's its ascii value: " + asciiOFz);
            char zPlus1 = (char)(asciiOFz + 1);
            Console.WriteLine("Here's the character after adding 1 to it's ascii value: " + zPlus1);
            Console.WriteLine("Darn!  z should be translated to a");
        }

        static bool IsVowel(char c)
        {
            Char[] vowels = { 'A', 'E', 'I', 'O', 'U' };//Uppercase character array because I'm feeling extra silly today.
            return vowels.Contains(Char.ToUpper(c));
        }

        static int IndexOfFirstVowel(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (IsVowel(s[i]))
                { 
                    return i; 
                }
            }
            return -1;
        }

        static int IndexOfFirstLetter(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        static string PigLatin1(string s)
        {
            if (s.Length != 1)
            {
                string pig = s.Substring(1) + s[0] + "ay";
                return pig;
            }
            else
            {
                return s;
            }
        }

        static string PigLatin2(string s)
        {
            if (s.Length != 1)
            {
                string pig;
                if (IndexOfFirstVowel(s) == 0)
                {
                    pig = s + "way";
                }
                else
                {
                    pig = s.Substring(1) + s[0] + "ay";
                }
                return pig;
            }
            else
            {
                return s;
            }
        }
        static string PigLatin3(string s)
        {
            if (s.Length != 1)
            {
                string pig;
                if (IndexOfFirstVowel(s) == 0)
                {
                    pig = s + "way";
                }
                else
                {
                    /*Char[] pigCon = new Char[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!(IsVowel(s[i])))
                        {
                            pigCon[i] = s[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    pig = s.Substring(IndexOfFirstVowel(s)) + string.Concat(pigCon) + "ay";*/
                    pig = s.Substring(IndexOfFirstVowel(s)) + s.Substring(0, IndexOfFirstVowel(s)) + "ay";//This is much easier than whatever I just did.
                }
                return pig;
            }
            else
            {
                return s;
            }
        }
        static string PigLatin4(string s)
        {
            if (s.Length != 1)
            {
                string pig;
                if (IndexOfFirstVowel(s) == 0)
                {
                    pig = s + "way";
                }
                else
                {
                    if (Char.IsUpper(s[0]))
                    {
                        s = s.ToLower();
                        pig = Char.ToUpper(s[IndexOfFirstVowel(s)]) + s.Substring(IndexOfFirstVowel(s) + 1) + s.Substring(0, IndexOfFirstVowel(s)) + "ay";
                    }
                    else
                    {
                        pig = s.Substring(IndexOfFirstVowel(s)) + s.Substring(0, IndexOfFirstVowel(s)) + "ay";
                    }
                }
                return pig;
            }
            else
            {
                return s;
            } 
        }

        static string PigLatin5(string s)//Works for punctuation at the beginning, too.  Try quotes.  "Hello!"
        {
            if (IndexOfFirstLetter(s) != -1)//Has at least one letter.
            {
                string pig;//Return string.
                string exR = "";//Last punctuation in string reverse.
                string ex = "";//Last punctuation in string.
                for (int i = s.Length -1; i >= 0; i--)
                {
                    if (Char.IsPunctuation(s[i]) || !(Char.IsLetterOrDigit(s[i])))
                    {
                        exR += s[i];
                    }
                    else
                    {
                        break;
                    }
                }
                foreach (char c in exR)
                {
                    ex = c + ex;
                }
                if (s.Substring(IndexOfFirstLetter(s), (s.Length - IndexOfFirstLetter(s) - ex.Length)).Length > 1)//More than one letter.
                {
                    if (IndexOfFirstVowel(s) == IndexOfFirstLetter(s))//Starts with vowel.
                    {
                        pig = s.Substring(0, (s.Length - ex.Length)) + "way" + ex;
                    }
                    else if (IndexOfFirstVowel(s) == -1)//No vowel edge case.
                    {
                        pig = s.Substring(0, (s.Length - ex.Length)) + "ay" + ex;
                    }
                    else
                    {
                        if (Char.IsUpper(s[IndexOfFirstLetter(s)]))//Uppercase.
                        {
                            s = s.ToLower();
                            pig = s.Substring(0, (IndexOfFirstLetter(s))) + Char.ToUpper(s[IndexOfFirstVowel(s)]) + s.Substring(IndexOfFirstVowel(s) + 1, s.Length - 1 - (s.Substring(IndexOfFirstLetter(s), IndexOfFirstVowel(s)).Length) - ex.Length) + s.Substring(IndexOfFirstLetter(s), IndexOfFirstVowel(s) - (s.Substring(0, IndexOfFirstLetter(s)).Length)) + "ay" + ex;
                            //Beginning punctuation + first vowel uppercase + (string after vowel - number of punctuation marks) + first consonants + "ay" + punctuation.
                        }
                        else
                        {
                            pig = s.Substring(0, (IndexOfFirstLetter(s))) + s[IndexOfFirstVowel(s)] + s.Substring(IndexOfFirstVowel(s) + 1, s.Length - 1 - (s.Substring(IndexOfFirstLetter(s), IndexOfFirstVowel(s)).Length) - ex.Length) + s.Substring(IndexOfFirstLetter(s), IndexOfFirstVowel(s) - (s.Substring(0, IndexOfFirstLetter(s)).Length)) + "ay" + ex;
                        }
                    }
                }
                else
                {
                    pig = s.Substring(0, (s.Length - ex.Length)) + "ay" + ex;
                }
                return pig;
            }
            else
            {
                return s;
            }
        }

        static string PigLatin6(string[] s)
        {
            string pigLatin = "";
            foreach (string word in s)
                pigLatin += PigLatin5(word) + " ";
            return pigLatin;
        }
    }
}
