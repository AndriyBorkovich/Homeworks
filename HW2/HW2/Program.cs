using System.Linq;
namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1
            Console.WriteLine("Please, enter numbers (1 row with spaces beetween numbers):");
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length == 0)
            {
                Console.WriteLine("You forgot to enter values!");
                Environment.Exit(-1);
            }

            int[] array1 = new int[input.Length];
            for(var i = 0; i < input.Length; ++i)
            {
                bool result = int.TryParse(input[i], out int value);
                if (!result)
                {
                    Console.WriteLine("Invalid input!");
                    Environment.Exit(-1);
                }
                else
                {
                    array1[i] = value;
                }
            }

            Console.WriteLine($"Sum of elements: {array1.Sum()}");
            Console.WriteLine($"Max element: {array1.Max()}");
            Console.WriteLine();

            // task 2
            Console.WriteLine("Enter text with numbers and spaces at the start:");
            string[] text = Console.ReadLine().Trim().Split(' ');
            Console.WriteLine("Text without spaces at the start:");
            Console.WriteLine(string.Join(' ', text));
            if (text.Length == 0)
            {
                Console.WriteLine("You forgot to enter values!");
                Environment.Exit(-1);
            }

            int[] array2 = new int[text.Length];
            for (var i = 0; i < text.Length; ++i)
            {
                bool result = int.TryParse(text[i], out int value);
                if (!result)
                {
                    Console.WriteLine("Invalid input!");
                    Environment.Exit(-1);
                }
                else
                {
                    array2[i] = value;
                }
            }

            Console.WriteLine($"Index of max element ({array2.Max()}): {Array.IndexOf(array2, array2.Max())}\n");

            //task 3
            const int BooksCount = 100, CarsCount = 40, 
                MinPages = 50, MaxPages = 1000, 
                MinSpeed = 100, MaxSpeed = 250;
            int[] pagesInBooks = new int[BooksCount]; 

            // fill with random values
            Random rnd1 = new Random();
            for (int i = 0; i < BooksCount; i++)
            {
                pagesInBooks[i] = rnd1.Next(MinPages, MaxPages);
            }

            Console.WriteLine("Finding max pages...");
            Console.WriteLine(string.Join(' ', pagesInBooks));
            
            int maxPages = pagesInBooks.Max();
            
            Console.WriteLine($"Max pages ({maxPages}) are in {Array.IndexOf(pagesInBooks, maxPages)} book\n");

            // task 4
            int[] carsSpeed = new int[CarsCount];
            
            Random rnd2 = new Random();
            for (int i = 0; i < CarsCount; i++)
            {
                carsSpeed[i] = rnd2.Next(MinSpeed, MaxSpeed);
            }

            Console.WriteLine("Finding the fastest car...");
            Console.WriteLine(string.Join(' ', carsSpeed));
            
            int maxSpeed = carsSpeed.Max();
            int firstMaxSpeedIndex = Array.IndexOf(carsSpeed, maxSpeed);
            int lastMaxSpeedIndex = Array.LastIndexOf(carsSpeed, maxSpeed);

            Console.WriteLine($"The fastest car ({maxSpeed}) is uder index: (FirstIndexOf: {firstMaxSpeedIndex}, LastIndexOf: {lastMaxSpeedIndex})");
        }
    }
}