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
            int age = Convert.ToInt32(Console.ReadLine());
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
            int salary = Convert.ToInt32(Console.ReadLine());
            salaryValidation(salary);
            Console.WriteLine($"{firstName} {lastName} {fatherName} sisteme elave olundu");
        }
        #region comment
        //static void nameLength(string name,int minCharacter, int maxCharacter)
        //{
        //    if (name.Length<minCharacter || name.Length>maxCharacter)
        //        Console.WriteLine($"melumatin uzunlugu {minCharacter} ve {maxCharacter} arasinda olmalidir");
        //}
        //private static void OnlyLetters(string name)
        //{
        //    bool isLetter = false;
        //    foreach(char letter in name)
        //    {
        //        int asciiCode = (int)letter;
        //        if ((asciiCode >= 65 & asciiCode <= 90) || (asciiCode >= 97 & asciiCode <= 122))
        //            isLetter = true;

        //    }
        //        if(isLetter==false)
        //            Console.WriteLine("daxil etdiyiniz melumal atcaq herflerden ibaret olmalidir");
        //}
        //static void firstLetterUpper(string name)
        //{
        //    bool firstLetterisUpper = false;
        //    char firstLetter = name[0];
        //    if (firstLetter >= 65 & firstLetter <= 90)
        //        firstLetterisUpper = true;

        //    if(firstLetterisUpper==false)
        //        Console.WriteLine("ilk herf boyuk olmalidir");
        //} 
        #endregion
        static bool nameLength(string name, int minCharacter, int maxCharacter)
        {
            if (name.Length < minCharacter || name.Length > maxCharacter)
            {
                Console.WriteLine($"melumatin uzunlugu {minCharacter} ve {maxCharacter} arasinda olmalidir");
                return false;
            }
            return true;
        }
        private static bool OnlyLetters(string name)
        {
            foreach (char letter in name)
            {
                int asciiCode = (int)letter;
                if (!((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122)))
                {
                    Console.WriteLine("daxil etdiyiniz melumat ancaq herflerden ibaret olmalidir");
                    return false;
                }
            }
            return true;
        }
        static bool firstLetterUpper(string name)
        {
            char firstLetter = name[0];
            if (!(firstLetter >= 65 && firstLetter <= 90))
            {
                Console.WriteLine("ilk herf boyuk olmalidir");
                return false;
            }
            return true;
        }
        static void nameValidation(string name, int minCharacter, int maxCharacter)
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
            
        }
        static bool ageGap(int age)
        {
            if (age >= 18 && age < 65)
                return true;
            else
            {
                Console.WriteLine("yas araligi 18 ve 65 arasinda olmalidir");
                return false;
            }
        }
        static void ageValidation(int age)
        {
            bool ageIsValid = ageGap(age);
            while (ageIsValid == false)
            {
                age = Convert.ToInt32(Console.ReadLine());
                ageIsValid = ageGap(age);
            }
        }
        static bool onlyUpperLettersAndNumbers(string FIN)
        {
            foreach(char chr in FIN)
            {
                int asciiCode = (int)chr;
                if (!(asciiCode >= 65 & asciiCode <= 90) || !(asciiCode >= 48 && asciiCode <= 57))
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
                Console.WriteLine("FIN uzunlugu 7 olamalidir");
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
                Console.WriteLine("Aviable positions are *\"HR*\" , *\"Audit*\" , *\"Engineer*\"");
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
            bool numberIsValid = false;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = (int)number[i];
                if ((digit >= 48 && digit <= 57))
                    numberIsValid = true;
                else if ((int)number[0] == 43)
                    numberIsValid = true;
                else
                {
                    Console.WriteLine("number should be consist of digits and country code");
                    numberIsValid=false;
                }
            }
            return numberIsValid;
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
                Console.WriteLine("Maas 1500 ve 5000 azn arasinda ola biler");
                return false;
            }
        }
        static void salaryValidation(int salary)
        {
            bool salaryIsValid = salaryGap(salary);
            while (salaryIsValid == false)
            {
                salary = Convert.ToInt32(Console.ReadLine());
                salaryIsValid = salaryGap(salary);
            }
        }
    }
}
