using System;

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
            return "a";
        }
    }
}
