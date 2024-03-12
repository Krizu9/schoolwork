using System;

namespace Task32
{
    class Program
    {
        delegate string StringTransformer(string input);

        static void Main(string[] args)
        {
            Console.Write("Enter the string to process: ");
            string input = Console.ReadLine();

            StringTransformer transformer = null;
            while (true)
            {
                Console.WriteLine("\nChoose the treatment you want, you can give several treatments at once");
                Console.WriteLine("as one string, e.g. '123'");
                Console.WriteLine("1: to capital letters");
                Console.WriteLine("2: lowercase");
                Console.WriteLine("3: as a title");
                Console.WriteLine("4: as a palindrome");
                Console.WriteLine("0: termination\n");

                Console.Write("Selection: ");
                string selection = Console.ReadLine();
                Console.WriteLine();

                if (selection.Contains("0"))
                {
                    Console.WriteLine("Terminating...");
                    break;
                }

                if (selection.Contains("1"))
                {
                    transformer += ToUpperCase;
                    string transformedString = transformer(input);
                    Console.WriteLine($"{input} changed to {transformedString}");
                }

                if (selection.Contains("2"))
                {
                    transformer += ToLowerCase;
                    string transformedString = transformer(input);
                    Console.WriteLine($"{input} changed to {transformedString}");
                }

                if (selection.Contains("3"))
                {
                    transformer += ToTitleCase;
                    string transformedString = transformer(input);
                    Console.WriteLine($"{input} changed to {transformedString}");
                }

                if (selection.Contains("4"))
                {
                    transformer += ToPalindrome;
                    string transformedString = transformer(input);
                    Console.WriteLine($"{input} changed to {transformedString}");
                }

                transformer = null;
            }
        }

        static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        static string ToLowerCase(string input)
        {
            return input.ToLower();
        }

        static string ToTitleCase(string input)
        {
            return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
        }

        static string ToPalindrome(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
