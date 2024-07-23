namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string? choice;
            bool choiceValid = false;
            bool endProgram = false;

            while(!endProgram)
            {
                do
                {
                    Console.WriteLine("Choose operation to perform:");
                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Subtract");
                    Console.WriteLine("3. Multiply");
                    Console.WriteLine("4. Divide");
                    Console.WriteLine("5. Exponentiation");
                    Console.WriteLine("6. Root");
                    Console.WriteLine("Type 'exit' to quit the program.");

                    choice = Console.ReadLine();

                    if (choice == "exit")
                    {
                        endProgram = true;
                        break;
                    }

                    try
                    {
                        bool corectParse = int.TryParse(choice, out int choiceInt);
                        if (!corectParse)
                        {
                            throw new FormatException("Invalid input. Please enter a number:");
                        }
                        if (choiceInt < 1 || choiceInt > 6)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        choiceValid = true;
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        continue;
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        continue;
                    }
                    
                }
                while(!choiceValid);

                if(endProgram)
                {
                    break;
                }
                

                Console.WriteLine("Enter first number:");
                double num1;
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                }

                Console.WriteLine("Enter second number:");
                double num2;
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                }

                double output = 0;
                bool operationValid = false;

                switch(choice)
                {
                    case "1":
                        output = num1 + num2;
                        operationValid = true;
                        break;
                    case "2":
                        output = num1 - num2;
                        operationValid = true;
                        break;
                    case "3":
                        output = num1 * num2;
                        operationValid = true;
                        break;
                    case "4":
                        try
                        {
                            output = num1 / num2;
                            if(num2 == 0)
                            {
                                throw new DivideByZeroException("Cannot divide by zero.");
                            }
                            operationValid = true;
                        }
                        catch(DivideByZeroException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                        break;
                    case "5":
                        if (num1 == 0 && num2 <= 0)
                        {
                            Console.WriteLine("Error: Cannot raise 0 to a non-positive power.");
                        }
                        else
                        {
                            try
                            {
                                output = Math.Pow(num1, num2);
                                if (double.IsInfinity(output))
                                {
                                    throw new OverflowException("Result is too large to be displayed.");
                                }
                                operationValid = true;                          
                            }
                            catch(OverflowException e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                            }
                        }
                        break;

                    case "6":
                        try
                        {
                            if (num1 < 0 && num2 % 2 == 0)
                            {
                                throw new ArgumentException("Cannot calculate even root of a negative number.");
                            }
                            output = Math.Pow(num1, 1.0 / num2);
                            if (double.IsInfinity(output))
                            {
                                throw new OverflowException("Result is too large to be displayed.");
                            }
                            operationValid = true;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                        
                }
                if(operationValid)
                    Console.WriteLine($"Result: {output}");
                else
                    Console.WriteLine("Invalid operation. Please try again.");

                    Console.WriteLine("Do you want to perform another operation? (y/n)"); 
                string? answer = Console.ReadLine();
                if (answer?.ToLower().Trim() != "y")
                {
                    break;
                }

            }
            Console.WriteLine("Thanks for using our calculator!");
        }
    }
}