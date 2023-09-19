using System;

namespace Palindrome
{
    class Program
    {
        static bool IsPalindrome(string sentence)
        {
            int length = sentence.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (sentence[i] != sentence[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine().ToLower().Replace(" ", string.Empty);
            if (IsPalindrome(sentence))
            {
                Console.WriteLine("The given sentence is a palindrome.");
            }
            else
            {
                Console.WriteLine("The given sentence is not a palindrome.");
            }
        }
    }
}