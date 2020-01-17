using System;
using System.Text;

namespace MasterMind
{
    class ProgramTest
    {
        private static int TotalAttempts = 0;

        private static string RandomValue;

        private static Random RandomDigit = new Random();
        public bool Status { get; private set; }

        //  program starts from here 
        static void Main(string[] args)
        {
            RandomValue = RandomSize(4);  // RandomValue initialisation
            Console.WriteLine("Ready to play MasterMind /nPlease enter a 4 digitd number you gessed");
            var masterMind = new ProgramTest();
            do
            {
                Console.WriteLine("\n");
                var userinput = Console.ReadLine();

                if ((userinput.Length == RandomValue.Length) && (int.TryParse(userinput, out int number1)))
                {
                    Console.WriteLine(masterMind.GetResult(userinput));
                }
                else
                {
                    Console.WriteLine($"This is not valid Please enter a 4 digitd a number only");
                }
            } while (!masterMind.Status);
        }

        //  generating  the random a number of 4 digitsized 
        private static string RandomSize(int size)
        {
            var Randombuild = new StringBuilder(size);

            for (var index = 0; index < size; index++)
            {
                Randombuild.Append(RandomDigit.Next(2, 6));  //  generating  the random number in between 1 to 6
            }
            return Randombuild.ToString();
        }

        //  return the final result 
        public string GetResult(string InputValue)
        {
            TotalAttempts = TotalAttempts + 1;
            Console.WriteLine("you have only  : {0} choices left", 10 - TotalAttempts);
            string FinalResult = Examine(InputValue);

            if (FinalResult == "++++")  // if the number gussed is correct then set the Status to true 
            {
                Status = true;
                return $"Congrats , you won in {TotalAttempts} turms only";
            }

            if (TotalAttempts > 9)      // if the number of attempts exceeds 10 then set the Status to true 
            {
                Status = true;
                return $"******** Sorry you lost game, the Number you need to guess is : {RandomValue} ";
            }
            return FinalResult;
        }

        //  return the result based on the matching criteria 
        public string Examine(string userInput)
        {
            var builder = new StringBuilder(userInput.Length);
            for (var index = 0; index < userInput.Length; index++)
            {
                var randomdigit = userInput[index];
                var result = ' ';
                if (RandomValue.Contains(randomdigit.ToString()))
                    result = RandomValue[index] == randomdigit ? '+' : '-';  // return + when matched else return - when not matched
                builder.Append(result);
            }
            return builder.ToString();
        }
    }

}
