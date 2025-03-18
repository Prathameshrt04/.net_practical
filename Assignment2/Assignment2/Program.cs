using System;

abstract class CalculatorOperation
{
    protected double result;
    private readonly string operationName;

    public CalculatorOperation(string opName)
    {
        operationName = opName;
        result = 0;
    }

    public virtual double Calculate(double num1, double num2)
    {
        return result;
    }

    public void DisplayResult()
    {
        Console.WriteLine($"{operationName} Result: {result}");
    }

    ~CalculatorOperation()
    {
        // Cleanup code (if needed)
    }
}

class Addition : CalculatorOperation
{
    public Addition() : base("Addition") { }

    public double Calculate(int num1, int num2)
    {
        return num1 + num2;
    }
    public override double Calculate(double num1, double num2)
    {
        result = num1 + num2;
        return result;
    }
}

class Subtraction : CalculatorOperation
{
    public Subtraction() : base("Subtraction") { }

    public override double Calculate(double num1, double num2)
    {
        result = num1 - num2;
        return result;
    }
}

class Multiplication : CalculatorOperation
{
    public Multiplication() : base("Multiplication") { }

    public override double Calculate(double num1, double num2)
    {
        result = num1 * num2;
        return result;
    }
}

class Division : CalculatorOperation
{
    public Division() : base("Division") { }

    public override double Calculate(double num1, double num2)
    {
        if (num2 == 0)
            throw new DivideByZeroException("Cannot divide by zero!");

        result = num1 / num2;
        return result;
    }
}

class CalculatorProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\n=== Calculator Menu ===");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                Console.Write("Select operation: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 5)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (choice < 1 || choice > 5)
                {
                    throw new ArgumentException("Invalid menu choice!");
                }

                Console.Write("Enter first number: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = double.Parse(Console.ReadLine());

                CalculatorOperation operation = null;

                switch (choice)
                {
                    case 1:
                        operation = new Addition();
                        break;
                    case 2:
                        operation = new Subtraction();
                        break;
                    case 3:
                        operation = new Multiplication();
                        break;
                    case 4:
                        operation = new Division();
                        break;
                }

                operation.Calculate(num1, num2);
                operation.DisplayResult();

                if (choice == 1)
                {
                    Addition add = new Addition();
                    int intResult = (int)add.Calculate(5, 3); 
                    Console.WriteLine($"Integer Addition (5 + 3): {intResult}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}