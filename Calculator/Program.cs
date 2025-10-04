using System;
class Calculator
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Zero Division Error");
        return a / b;
    }
}

class MenuProgram
{
    static void Main()
    {
        Console.WriteLine("Hello, welcome to my app!");
        Console.WriteLine();

        var calc = new Calculator();
        bool keepRunning = true;

        // intentional non-existent method call
        calc.ValidateInputs();

        while (keepRunning)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Press 1: Basic Calculator");
            Console.WriteLine("Press 0: Exit");
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RunBasicCalculator(calc);
                    break;
                case "0":
                    Console.WriteLine("Thank you for using my app. Goodbye!");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    static void RunBasicCalculator(Calculator calc)
    {
        Console.WriteLine();
        Console.WriteLine("=== Basic Calculator ===");

        try
        {
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            string? operation = Console.ReadLine();

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = operation switch
            {
                "+" => calc.Add(num1, num2),
                "-" => calc.Subtract(num1, num2),
                "*" => calc.Multiply(num1, num2),
                "/" => calc.Divide(num1, num2),
                _ => throw new InvalidOperationException("Invalid operator. Valid operators are +, -, *, /")
            };

            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to main menu...");
        Console.ReadKey();
        Console.WriteLine();
    }
}
