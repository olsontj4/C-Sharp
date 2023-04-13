using System;
using System.Reflection.Metadata.Ecma335;

namespace ShiftCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a word or phrase:");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split();
            Console.WriteLine("Type a number to shift to:");
            int shift = int.Parse(Console.ReadLine());
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(ShiftCypher(words[i], shift) + " ");
            }
        }
        static string ShiftCypher(string sentence, int shift)
        {
            string encrypted = "";
            foreach (char c in sentence)
            {
                if (Char.IsUpper(c))
                {
                    if (((int)(Char.ToLower(c)) + shift) > 122)//Shift out of range positive.
                    {
                        encrypted += Char.ToUpper((Char)((int)(Char.ToLower(c)) - 122 + 96 + shift));
                    }
                    else if (((int)(Char.ToLower(c)) + shift) < 97)//Shift out of range negative.
                    {
                        encrypted += Char.ToUpper((Char)((int)(Char.ToLower(c)) + 123 - 97 + shift));
                    }
                    else
                    {
                        encrypted += Char.ToUpper((Char)((int)(Char.ToLower(c)) + shift));
                    }
                }
                else
                {
                    if (((int)(c) < 97 || ((int)(c)) > 122))//Special characters.
                    {
                        encrypted += c;
                    }
                    else if (((int)(c) + shift) > 122)//Shift out of range positive.
                    {
                        encrypted += (Char)((int)(c) - 122 + 96 + shift);
                    }
                    else if (((int)(c) + shift) < 97)//Shift out of range negative.
                    {
                        encrypted += (Char)((int)(c) + 123 - 97 + shift);
                    }
                    else
                    {
                        encrypted += (Char)((int)(c) + shift);
                    }
                }
            }
            return encrypted;
        }
    }
}