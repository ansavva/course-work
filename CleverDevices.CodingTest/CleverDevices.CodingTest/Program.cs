using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CleverDevices.CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("One morning [I, shot] [An elephant in my pajamas]."));
            Console.WriteLine(ReverseString("One morning [I, shot] [An elephant in my pajamas]!"));
            Console.WriteLine(ReverseString("Help!"));
            Console.WriteLine(ReverseString("help!"));
            Console.WriteLine(CharIntersect("These are characters", "These are characters"));
            Console.WriteLine(CharIntersect("!Apple.", "ple.!"));
            Console.WriteLine(CharIntersect("!Apple.", null));
            Console.WriteLine(CharIntersect(null, "!Apple."));
            Console.WriteLine(CharIntersect("!Apple.", ""));
            Console.WriteLine(CharIntersect("", "!Apple."));
            Console.WriteLine(CharIntersect(null, null));
            Console.WriteLine(CharIntersect("", ""));
            Console.WriteLine(CharIntersect(" ", " "));

            Stack<string> stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Pop();
            foreach(var item in stack.Get())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(stack.Size().ToString());
            Console.WriteLine(stack.IsEmpty().ToString());
            
            Console.ReadKey();
        }

        public class Stack<T>
        {
            private static List<T> list;

            public Stack()
            {
                list = new List<T>();
            }

            /// <summary>
            /// Returns all elements in the stack as a generic list.
            /// </summary>
            public List<T> Get()
            {
                return list;
            }

            /// <summary>
            /// Add an element to the front of the stack.
            /// </summary>
            /// <param name="item"></param>
            public void Push(T item)
            {
                list.Insert(0, item);
            }

            /// <summary>
            /// Removes an element from the front of the stack.
            /// </summary>
            public void Pop()
            {
                list.RemoveAt(0);
            }

            /// <summary>
            /// Returns the total number of element in the stack as an integer. 
            /// </summary>
            public int Size()
            {
                return list.Count;
            }

            /// <summary>
            /// Returns true if the stack has no elements and false if it has more than one element.
            /// </summary>
            public bool IsEmpty()
            {
                return list.Count == 0;
            }
        }

        /// <summary>
        /// Determines which characters of the two strings provided are common. 
        /// White space is stripped from both argument before being parsed.
        /// </summary>
        /// <param name="arg1">The first string argument to check for common characters.</param>
        /// <param name="arg2">The second string argument to check for common characters.</param>
        /// <returns>
        ///     Returns a string of all common characters found in both supplied arguments.
        ///     If either argument supplied is null, whitespace or empty, an emptry string is returned.
        /// </returns>
        public static string CharIntersect(string arg1, string arg2)
        {
            List<char> charIntersects = new List<char>();
            // Only continue if both arguments are not null or whitespace.
            if (!string.IsNullOrWhiteSpace(arg1) && !string.IsNullOrWhiteSpace(arg2))
            {
                // Replace all white spaces with an empty stirng and convert both arguments in char arrays.
                char[] arg1Letters = arg1.Replace(" ", string.Empty).ToCharArray();
                char[] arg2Letters = arg2.Replace(" ", string.Empty).ToCharArray();
                // Iterate through both character arrays to find matching characters
                for (int i = 0; i < arg1Letters.Length; i++)
                {
                    for (int g = 0; g < arg2Letters.Length; g++)
                    {
                        // If the characters are identical
                        // and the matching character has not been inserted into the 
                        // char list, then add it to the end of char list.
                        if (arg1Letters[i] == arg2Letters[g] && 
                            !charIntersects.Contains(arg1Letters[i]))
                        {
                            charIntersects.Add(arg1Letters[i]);
                        }
                    }
                }
            }
            charIntersects.Sort();
            return new String(charIntersects.ToArray());
        }

        /// <summary>
        /// Reverses the order of words of a sentence.
        /// </summary>
        /// <param name="sentence">The sentence you wish to reverse.</param>
        /// <returns>
        ///     Returns the sentence in reversed order as a string. 
        ///     If the sentence provided is null or empty and empty string is returned.
        /// </returns>
        public static string ReverseString(string sentence)
        {
            string reversedSentence = string.Empty;
            if (!string.IsNullOrEmpty(sentence))
            {
                // Strip all none alpha numeric characters.
                string[] words = Regex.Replace(sentence, @"[^\w\s]", string.Empty).Split();
                for (int i = words.Length - 1; i >= 0; i--)
                {
                    // If this is the first iteration of the for loop, 
                    // capitalize the first letter of the word.
                    if (words.Length > 1 && i == words.Length - 1)
                    {
                        char[] letters = words[i].ToCharArray();
                        letters[0] = char.ToUpper(letters[0]);
                        reversedSentence += new String(letters) + ' ';
                    }
                    // If this is the last iteration of the for loop,
                    // add the punctuation supplied at the end of the original sentence amd 
                    // lower case of the first letter unless it is only one word long.
                    else if (i == 0)
                    {
                        char[] letters = words[i].ToCharArray();
                        if (words.Length == 1)
                        {
                            letters[0] = char.ToUpper(letters[0]);
                        }
                        else
                        {
                            letters[0] = char.ToLower(letters[0]);
                        }
                        char lastLetter = sentence.ToCharArray()[sentence.ToCharArray().Length - 1];
                        reversedSentence += new String(letters) + lastLetter;
                    }
                    // Append the word to the end of the sentence.
                    else
                    {
                        reversedSentence += words[i] + ' ';
                    }

                }
            }
            return reversedSentence;
        }
    }
}
