namespace vacancyTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            nameValidation(firstName, 2, 20);
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            nameValidation(lastName, 2, 35);
            Console.WriteLine("Enter father name:");
            string fatherName = Console.ReadLine();
            nameValidation(fatherName, 2, 20);
            Console.WriteLine("Enter the age(18-65):");
            int age;
            if (!(int.TryParse(Console.ReadLine(), out age)))
                Console.WriteLine("information must be digit");
            ageValidation(age);
            Console.WriteLine("Enter the FIN(FIN must be consist of uppercase letters and numbers):");
            string FIN = Console.ReadLine();
            FINvalidation(FIN);
            Console.WriteLine("Enter the position(Aviable positions are \"HR\" , \"Audit\" , \"Engineer\"): ");
            string position = Console.ReadLine().ToLower();
            positionValidation(position);
            Console.WriteLine("Enter the phone number:");
            string phoneNumber = Console.ReadLine();
            phoneNumberValidation(phoneNumber);
            Console.WriteLine("Enter the salary:");
            int salary;
            if (!(int.TryParse(Console.ReadLine(), out salary)))
                Console.WriteLine("information must be digit");
            salaryValidation(salary);
            Console.WriteLine($"{firstName} {lastName} {fatherName} has been added to the system");
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
                
                if (!char.IsLetter(letter))
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
            while (validLength == false || allElementsLetter==false || firstLetterIsUpper==false)
            {
                name = Console.ReadLine();
                validLength= nameLength(name,  minCharacter,  maxCharacter);
                allElementsLetter= OnlyLetters(name);
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
            foreach(char chr in FIN)
            {
                int asciiCode = (int)chr;
                if ((asciiCode >= 65 & asciiCode <= 90) || (asciiCode >= 48 && asciiCode <= 57))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("FIN code must be consist of only upper letters and digits");
                    return false;
                }
            }
            return true;
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
        static void FINvalidation(string FIN)
        {
            
            bool charactersIsValid = onlyUpperLettersAndNumbers(FIN);
            bool lengthIsValid = FIN_length(FIN);
            while (charactersIsValid == false || lengthIsValid == false)
            {
                FIN = Console.ReadLine();
                charactersIsValid = onlyUpperLettersAndNumbers(FIN);
                lengthIsValid = FIN_length(FIN);
            }           
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
        static void positionValidation(string position)
        {
            bool positionIsValid = validPosition(position);
            while (positionIsValid == false)
            {
                position = Console.ReadLine().ToLower();
                positionIsValid = validPosition(position);
            }
        }
        static bool OnlyNumber(string number)
        {
            while (number.Length > 0)
            {

                for (int i = 1; i < number.Length; i++)
                {
                    int digit = (int)number[i];
                    if ((digit >= 48 && digit <= 57) && number[0] == '+')
                        return true;
                    else
                    {
                        Console.WriteLine("number should be consist of digits and country code");
                        return false;
                    }
                }
            }
            return false;
        }
        static bool numberLength(string number)
        {
            if (number.Length != 13)
            {
                Console.WriteLine("your number length is not correct");
                return false;
            }
            else
                return true;
        }
        static bool countryCode(string number)
        {
            while (number.Length > 3)
            {
                if (number[0] == '+' & number[1] == '9' & number[2] == '9' & number[3] == '4')
                    return true;
                else
                {
                    Console.WriteLine("country code is not right");
                    return false;
                }
            }
            return false;
        }
        static void phoneNumberValidation(string number)
        {
            bool consistsOfNumbers = OnlyNumber(number);
            bool lengthIsValid = numberLength(number);
            bool countryCodeIsRight = countryCode(number);
            while (consistsOfNumbers == false || lengthIsValid == false || countryCodeIsRight == false)
            {
                number = Console.ReadLine();
                consistsOfNumbers = OnlyNumber(number);
                lengthIsValid = numberLength(number);
                countryCodeIsRight = countryCode(number);
            }
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
