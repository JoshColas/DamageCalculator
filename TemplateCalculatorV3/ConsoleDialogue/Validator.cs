using System;

namespace Calculator
{
    public class BoolValidator
    {
        public static bool ValidateBool(string userResponse, bool attackProperty)
        {
            if (userResponse == "y")
            {
                attackProperty = true;
            }
            else
            {
                attackProperty = false;
            }
            return attackProperty;
        }
    }

    public class UintValidator
    {
        public static uint ValidateUint(string userResponse, string question, bool isZeroPermitted)
        {
            uint value = 0;
            int attempts = 0;
            bool repeat = true;
            while (repeat)
            {
                try
                {
                    if (!isZeroPermitted)
                    {
                        value = Convert.ToUInt32(userResponse);
                        if (value != 0)
                        {
                            repeat = false;
                        }
                        else
                        {
                            throw new FormatException();
                        }
                    }
                    if (isZeroPermitted)
                    {
                        value = Convert.ToUInt32(userResponse);
                        repeat = false;
                    }
                }
                catch (Exception exception)
                {
                    if (exception is OverflowException || exception is FormatException)
                    {
                        attempts++;
                        if (attempts > 3)
                        {
                            Console.WriteLine("MAXIMUM NUMER OF RETRIES EXCEEDED");
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                            break;
                        }
                        Console.WriteLine("Invalid Entry.");
                        Console.Write(question);
                        userResponse = Console.ReadLine();
                    }
                }
            }
            return value;
        }
    }
}