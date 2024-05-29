using System.Xml.Linq;

namespace vacancyTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first name:");
            string firstName = nameValidation(Console.ReadLine(), 2, 20);

            Console.WriteLine("Enter last name: ");
            string lastName = nameValidation(Console.ReadLine(), 2, 35);

            Console.WriteLine("Enter father name:");
            string fatherName = nameValidation(Console.ReadLine(), 2, 20);

            Console.WriteLine("Enter the age(18-65):");
            int age;
            if (!(int.TryParse(Console.ReadLine(), out age)))
                Console.WriteLine("information must be digit");
            ageValidation(age);
            Console.WriteLine("Enter the FIN(FIN must be consist of uppercase letters and numbers):");
            string FIN = FINvalidation(Console.ReadLine());

            Console.WriteLine("Enter the position(Aviable positions are \"HR\" , \"Audit\" , \"Engineer\"): ");
            string position = positionValidation(Console.ReadLine().ToLower());

            Console.WriteLine("Enter the phone number:");
            string phoneNumber = phoneNumberValidation(Console.ReadLine());
            
            Console.WriteLine("Enter the salary:");
            if (!(int.TryParse(Console.ReadLine(), out int salary)))
                Console.WriteLine("information must be digit");
            salaryValidation(salary);
            Console.WriteLine($"{salary} {phoneNumber} has been added to the system");
        }
        static bool nameLength(string name, int minCharacter, int maxCharacter)
        {
            if (name.Length < minCharacter || name.Length > maxCharacter)
            {
                Console.WriteLine($"length of the information must be between {minCharacter} and {maxCharacter}");
                return false;
            }
            return true;
        }
        private static bool OnlyLetters(string name)
        {
            foreach (char letter in name)
            {
                
                if (char.IsLetter(letter)==false)
                {
                    Console.WriteLine("this information must be consist of only letters");
                    return false;
                }
            }
            return true;
        }
        static bool firstLetterUpper(string name)
        {
            while (name.Length > 0)
            {
                char firstLetter = name[0];
                if (!char.IsUpper(firstLetter))
                {
                    Console.WriteLine("first letter must be uppercase");
                    return false;
                }
                return true;
            }
            return false;
        }
        static string nameValidation(string name, int minCharacter, int maxCharacter)
        {
            bool validLength = nameLength(name, minCharacter, maxCharacter);
            bool allElementsLetter = OnlyLetters(name);
            bool firstLetterIsUpper = firstLetterUpper(name);
            while (validLength == false || allElementsLetter == false || firstLetterIsUpper == false)
            {
                name = Console.ReadLine();
                validLength = nameLength(name, minCharacter, maxCharacter);
                allElementsLetter = OnlyLetters(name);
                firstLetterIsUpper = firstLetterUpper(name);

            }
            return name;
        }
        static bool ageGap(int age)
        {
            if (age >= 18 && age < 65)
                return true;
            else
            {
                Console.WriteLine("Age must be between 18 and 65");
                return false;
            }
        }
        static void ageValidation(int age)
        {
            bool ageIsValid = ageGap(age);
            while (ageIsValid == false)
            {
                if(!(int.TryParse(Console.ReadLine(),out age)))
                    Console.WriteLine("information must be digit");
                ageIsValid = ageGap(age);
            }
        }
        static bool onlyUpperLettersAndNumbers(string FIN)
        {
                bool finIsValid = false;
            foreach(char chr in FIN)
            {
                int asciiCode = (int)chr;
                if ((asciiCode >= 65 & asciiCode <= 90) || (asciiCode >= 48 && asciiCode <= 57))
                {
                    finIsValid= true;
                }
                else
                {
                    Console.WriteLine("FIN code must be consist of only upper letters and digits");
                    return false;
                }
            }
            return finIsValid ;
        }
        static bool FIN_length(string FIN) 
        {
            if (FIN.Length == 7)
            {
                return true;
            }
            else
            {
                Console.WriteLine("length of FIN must be 7");
                return false;
            }
        }
        static string FINvalidation(string FIN)
        {
            
            bool charactersIsValid = onlyUpperLettersAndNumbers(FIN);
            bool lengthIsValid = FIN_length(FIN);
            while (charactersIsValid == false || lengthIsValid == false)
            {
                FIN = Console.ReadLine();
                charactersIsValid = onlyUpperLettersAndNumbers(FIN);
                lengthIsValid = FIN_length(FIN);
            }
            return FIN;
        }
        static bool validPosition(string position)
        {
            if (position=="hr"||position=="audit"||position=="engineer")
                return true;
            else
            {
                Console.WriteLine("only aviable positions are \"HR\" , \"Audit\" , \"Engineer\"");
                return false;
            }
        }
        static string positionValidation(string position)
        {
            bool positionIsValid = validPosition(position);
            while (positionIsValid == false)
            {
                position = Console.ReadLine().ToLower();
                positionIsValid = validPosition(position);
            }
            return position;
        }
        static bool OnlyNumber(string number)
        {
            while (number.Length > 0)
            {
                for (int i = 1; i < number.Length; i++)
                {
                    if (!char.IsDigit(number[i]))
                    {
                        Console.WriteLine("number should be consist of digits and country code");
                        return false;
                    }
                }
                break;
            }
            return true;
        }
        static bool numberLength(string number)
        {
            if (number.Length != 13)
            {
                Console.WriteLine("your number length is not correct");
                return false;
            }
                return true;
        }

        static bool countryCode(string number)
        {
            if (number.Length > 3)
            {
                if (number[0] == '+' && number[1] == '9' && number[2] == '9' && number[3] == '4')
                    return true;
                else
                {
                    Console.WriteLine("country code is not right");
                    return false;
                }
            }
            Console.WriteLine("country code is not right");
            return false;
        }

        static string phoneNumberValidation(string number)
        {
            bool consistsOfNumbers = OnlyNumber(number);
            bool lengthIsValid = numberLength(number);
            bool countryCodeIsRight = countryCode(number);
            while (!consistsOfNumbers || !lengthIsValid || !countryCodeIsRight)
            {
                number = Console.ReadLine();
                consistsOfNumbers = OnlyNumber(number);
                lengthIsValid = numberLength(number);
                countryCodeIsRight = countryCode(number);
            }
            return number;
        }

        static bool salaryGap(int salary)
        {
            if (salary >= 1500 && salary <= 5000)
                return true;
            else
            {
                Console.WriteLine("salary must be between 1500 and 5000 azn");
                return false;
            }
        }
        static void salaryValidation(int salary)
        {
            bool salaryIsValid = salaryGap(salary);
            while (salaryIsValid == false)
            {
                if (!(int.TryParse(Console.ReadLine(), out salary)))
                    Console.WriteLine("information must be digit");
                salaryIsValid = salaryGap(salary);
            }
        }
    }
}
