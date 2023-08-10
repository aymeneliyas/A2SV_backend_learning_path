namespace occurences
{
    public class palindrome
    {
        static void Main(string[] args)
        {
            string string1, rev;
            Console.WriteLine("enter a word");
            string1 = Console.ReadLine();
            char[] ch = string1.ToCharArray();
            Array.Reverse(ch);
            rev = new string(ch);
            bool palindrome = string1.Equals(rev, StringComparison.OrdinalIgnoreCase);
            if (palindrome == true)
            {
                Console.WriteLine("" + string1 + " is a Palindrome!");
            }
            else
            {
                Console.WriteLine(" " + string1 + " is not a Palindrome!");
            }
        }
    }
}

