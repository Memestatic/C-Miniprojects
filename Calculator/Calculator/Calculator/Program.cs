namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to simple calculator!");

            bool calculated = false;

            while (!calculated)
            {
                Console.WriteLine("Choose operation to perform:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("Type 'exit' to quit the program.");

                List<double> numbers = new();
                double result = 0;

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":         
                        bool success = false;
                        do
                        {
                            Console.WriteLine("Enter first number");
                            success = double.TryParse(Console.ReadLine(), out double firstNumber);
                            if(success)
                                numbers.Add(firstNumber);
                        }
                        while (!success);
                        success = false;
                        do
                        {
                            Console.WriteLine("Enter second number");
                            success = double.TryParse(Console.ReadLine(), out double secondSumber);
                            if(success)
                                numbers.Add(secondSumber);
                        }
                        while (!success);

                        calculated = true;
                        result = numbers[0] + numbers[1];
                        Console.WriteLine($"The result of adding {numbers[0]} and {numbers[1]} is {result}");

                        break;
                    default:
                        break;
                }
            }
        }
    }
}