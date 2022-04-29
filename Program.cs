using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double petsWeight, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
            double poundsToKgs = 2.2; 
            // Use a switch statement to do the math.
            switch (op)
            {
              
                case "r":
                    Console.WriteLine("12 Hour Rimadyl Dose");
                    result = petsWeight / poundsToKgs * 2.2 / 50;
                    break;
                case "rr":
                    Console.WriteLine("24 Hour Rimadyl Dose");
                    result = petsWeight / poundsToKgs * 4.4 / 50;
                    break;
                case "c":
                   Console.WriteLine("Cernia or Convinea Dose");
                   result = petsWeight / poundsToKgs * .1;
                   break;
                case "d":
                    Console.WriteLine("Weight in Kilograms");
                    result = petsWeight / poundsToKgs; 
                    break;
                    
                   
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string getPetsWeight = "";
                double result = 0.00;

                // Ask the user to type the pet's weight.
                Console.Write("Enter Weight: ");
                getPetsWeight = Console.ReadLine();

                double petsWeight = 0;
                while (!double.TryParse(getPetsWeight, out petsWeight))
                {
                    Console.Write("This is not valid weight: ");
                    getPetsWeight = Console.ReadLine();
                }

                
                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\tr - Rimadyl 12 Hour Dose");
                Console.WriteLine("\trr - Rimadyl 24 Hour Dose");
                Console.WriteLine("\tc - Convinea or Cerenia");
                Console.WriteLine("\td - Convert Lbs to Kgs");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(petsWeight, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("That is not one of the options.\n");
                    }
                    if (op == "d")
                        {
                        Console.WriteLine("Your result:{0:0##}" ,result + " Kgs");
                    }
                    else Console.WriteLine("Your result:{0:0.##}" ,result + " mL");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to calculate another dose: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}