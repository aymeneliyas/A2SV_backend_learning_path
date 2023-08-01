using System;

namespace occurences
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word");
            IDictionary<char, double> charCount = new Dictionary<char, double>();

            string input = Console.ReadLine();

            input = clearWord(input);



            foreach (char ch in input.Replace(" ", string.Empty))
            {
                if (charCount.ContainsKey(ch))
                {
                    charCount[ch] = charCount[ch] + 1;
                }
                else
                {
                    charCount.Add(ch, 1);
                }
            }


            foreach (KeyValuePair<char, double> kvp in charCount)
                Console.WriteLine("character: {0}, occurence: {1}", kvp.Key, kvp.Value);


        }

        static string clearWord(string word)
        {

            List<Char> newword = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsPunctuation(word[i]))
                    continue;
                newword.Add(char.ToLower(word[i]));


            }
            return string.Join("", newword);
        }
    }

}
