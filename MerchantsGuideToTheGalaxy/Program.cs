using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MerchantsGuideToTheGalaxy.GalaxyFile;

namespace MerchantsGuideToTheGalaxy
{
    /// <summary>
    /// Read a file with reference values of galact coins, either in roman numeral or Credits, 
    /// and questions about transactions using combinations of this coins.
    /// Answer as many valid questions as possible, given the reference values extracted.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory
                                        .Replace(@"\MerchantsGuideToTheGalaxy\bin\Release\", @"\input.txt");
                Console.WriteLine(filePath);
                args = new string[] { filePath };
            }

            string path = args[0];
            
            FileAnalyzer analyzer = new FileAnalyzer();
            var fileInfo = analyzer.Analyze(path);

            Console.Clear();
            Console.WriteLine("Test Input: ");
            if (fileInfo.ReferenceValues != null && fileInfo.ReferenceValues.Count() > 0)
            {
                foreach (var item in fileInfo.ReferenceValues)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("The file don't have any line with reference values or don't exists!");
            }

            if (fileInfo.Questions != null && fileInfo.Questions.Count() > 0)
            {
                foreach (var item in fileInfo.Questions)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("The file don't have any line with question or don't exists!");
            }

            Console.WriteLine();

            Console.WriteLine("Test Output: ");
            if (fileInfo.Output != null && fileInfo.Output.Count() > 0)
            {
                foreach (var item in fileInfo.Output)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("The file don't have any output or don't exists!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            
            Console.ReadKey();
        }
    }
}
