using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;

namespace program
{
    class program
    {
        static void Main(string[] args)
        {
            String Name;
            double Total;
            String subjectName;
            double result;
            double sum = 0;
            double average;
            IDictionary<string, double> subjectResults = new Dictionary<string, double>();
            Console.WriteLine("Enter Full Name");
            Name = Console.ReadLine();

            Console.WriteLine("how many subjects you have taken");
            Total = Convert.ToDouble(Console.ReadLine());
            bool valid = true;
            for (int i = 0; i < Total; i++)
            {

                Console.WriteLine("Enter subject Name");
                subjectName = Console.ReadLine();
                Console.WriteLine("Enter result");
                result = Convert.ToDouble(Console.ReadLine());
                if (result < 0 || result > 100)
                {
                    while (valid)
                    {
                        Console.WriteLine("invalid result please enter again");
                        result = Convert.ToDouble(Console.ReadLine());
                        if (result > 0 && result < 100)
                        {
                            valid = false;
                        }
                    }
                }
                sum = sum + result;
                subjectResults.Add(subjectName, result);

            }
            Console.WriteLine("students:Name {0}", Name);
            foreach (KeyValuePair<string, double> kvp in subjectResults)
                Console.WriteLine("subject: {0}, result: {1}", kvp.Key, kvp.Value);
            average = sum / Total;
            Console.WriteLine("average result: {0}", average);
        }

    }
}
