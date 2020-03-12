namespace CSharpTraining.ChapterOne
{
    using System;

    internal class Calculator
    {
        enum ArthmeticOperation
        {
            Addition = 1,
            Subtraction = 2,
            Multiplication = 3,
            Division = 4,
            None = 5
        }

        public void Run()
        {
            do
            {
                var operation = UserOperation();

                var numbers = UserNumbers();
                switch (operation)
                {
                    case ArthmeticOperation.Addition:
                        Console.WriteLine($"The sum is : {Addition(numbers)}");
                        break;
                    case ArthmeticOperation.Subtraction:
                        Console.WriteLine($"The difference is : {Subtraction(numbers)}");
                        break;
                    case ArthmeticOperation.Multiplication:
                        Console.WriteLine($"The product is : {Multiplication(numbers)}");
                        break;
                    case ArthmeticOperation.Division:
                        Console.WriteLine($"The quota is : {Division(numbers[0], numbers[1])}");
                        break;
                    case ArthmeticOperation.None:
                    default:
                        Console.WriteLine("Invalid Operation.");
                        break;
                }

            } while (Quite());
        }

        private float Division(int a, int b)
        {
            if(b == 0)
            {
                throw (new DivideByZeroException());
            }

            return (float)a / (float)b;
        }

        private int Multiplication(int[] numbers)
        {
            var product = numbers[0];

            for(int i = 1; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }

        private int Subtraction(int[] numbers)
        {
            var sum = numbers[0];

            for(int i = 1; i < numbers.Length; i++)
            {
                sum -= numbers[i];
            }

            return sum;
        }

        private int Addition(int[] numbers)
        {
            var sum = 0;

            foreach(var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private ArthmeticOperation UserOperation()
        {
            ArthmeticOperation operation = ArthmeticOperation.None;

            Console.WriteLine("Press the following key to perform an arthmetic option: ");

            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division");

            var answer = Console.ReadLine();

            try
            {
                var myOptions = int.Parse(answer);

                operation = (ArthmeticOperation)myOptions;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                operation = ArthmeticOperation.None;
            }

            return operation;
        }

        private bool Quite()
        {
            var quite = false;

            Console.WriteLine("Do you want to do another calculation? (Y/N)");

            var answer = Console.ReadLine();

            quite = answer.ToLower().Equals("y");

            return quite;
        }

        private int[] UserNumbers()
        {
            int[] numbers = new int[2];

            for(int i = 0; i < 2; i++)
            {
                Console.Write("Enter your number :");
                var answer = Console.ReadLine();

                try
                {
                    var number = int.Parse(answer);

                    numbers[i] = number;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return numbers;
        }
    }
}
