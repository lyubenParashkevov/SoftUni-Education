namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (SixToTenCharacters(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (OnlyLettersAndDigits(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (MustHaveTwoDigits(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (SixToTenCharacters(password) == true && OnlyLettersAndDigits(password) == true && MustHaveTwoDigits(password) == true)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool SixToTenCharacters(string password)
        {
            bool isValid = false;
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                counter++;
            }
            if (counter >= 6 && counter <= 10)
            {
                isValid = true;
            }
            
            return isValid;
        }

        static bool OnlyLettersAndDigits(string password)
        {
            bool isValid = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57 || password[i] >= 65 && password[i] <= 90 || password[i] >=97 && password[i] <= 122)
                {
                    isValid = true;
                }  
                else
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
        static bool MustHaveTwoDigits(string password)
        {
            bool isValid = false;
            int digitCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitCounter++;
                }
            }
            if (digitCounter >= 2)
            {
                isValid = true;
            }
            return isValid;
        }

        
    }
}