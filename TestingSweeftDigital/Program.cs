using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSweeftDigital
{
    class Program
    {
        public static bool IsPolindrome(string text)
        {
            char[] rev = text.ToCharArray();
            Array.Reverse(rev);
            string reversed = new string(rev);


            if (text.Equals(reversed))
                return true;

            else return false;
        }


        public static int minSplit(int amount)
        {
            int value = amount;
            int temp;
            int first = value / 50;

            temp = value % 50;

            int second = temp / 20;

            temp = temp % 20;

            int third = temp / 10;

            temp = temp % 10;

            int fourth = temp / 5;

            return first + second + third + fourth;

        }

        public static int NotContains(int [] array)
        {
            int[] wholenumber = array;
            int arrsize = wholenumber.Length;
            int ptr = 0;

            // თუ 1 შედის ამ მასივში
            for( int  i = 0; i< arrsize; i++)
            {
                if(wholenumber[i] == 1)
                {
                    ptr = 1;
                    break;
                }
            }
            //თუ 1 არ შედის მასივში
            if (ptr == 0)
                return 1;

            for(int i = 0; i < arrsize; i++)
            {
                if (wholenumber[i] <= 0 || wholenumber[i] > arrsize)
                    wholenumber[i] = 1;
            }

            //ინდექსების განახლება მნიშვნელობების მიხედვით
            for(int i = 0; i< arrsize; i++)
            {
                wholenumber[(wholenumber[i] - 1) % arrsize] += arrsize;
            }
            

            for(int i = 0; i < arrsize; i++)
            {
                if (wholenumber[i] <= arrsize)
                    return i + 1;
            }
            return arrsize + 1;
        }

        public static bool IsProperly(String sequence)
        {
            bool correct = true;
            int count = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                { count++; }
                else
                { count--; }

                if (count < 0)
                {
                    correct = false;
                    break;
                }
            }
            if(count != 0)
            {
                correct = false;
            }
            return correct;
        }



        public static int CountVariants(int stairsCount)
        {
            int[] arr = new int[stairsCount];
            arr[0] = 1;
            arr[1] = 2;

            for(int i = 2; i< arr.Length; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[stairsCount - 1];
        }
        static void Main(string[] args)
        {
           
            // ტექსტი არის თუ არა პოლინდრომი
            string newText;
            bool checkingText;

            Console.WriteLine("Input a String");
            newText = Console.ReadLine();
            checkingText = IsPolindrome(newText);

            if (checkingText == true)
            {
                Console.WriteLine("" + newText + " is Polindrome");
            }
            else
            {
                Console.WriteLine("" + newText + " is not Polindrome");
            }



            // მონეტების მინიმალური რეოდენობა თანხის დასახურდავებლად
            Console.WriteLine(minSplit(1000));


            // მასივი არ შეიცავს მინიმალურ რიცხვს რომელიც 0-ზე მეტია
            int[] numberArray = { -4, 15, 14, 13, 6, 8, 1, 2, 4, 3 };
            Console.WriteLine(NotContains(numberArray));

            //ფრჩხილების შემოწმება მათემატიკურ სისწორეზე
            string sequence = "((()))";
            Console.WriteLine(IsProperly(sequence));

            // n სართულიანი კიბის ვარიანტების დათვლა
            Console.WriteLine(CountVariants(5));


            //დაწერეთ საკუთარი მონაცემთა სტრუქტურა, რომელიც საშუალებას მოგვცემს O(1) დროში წავშალოთ ელემენტი

            MyStructure myStructs = new MyStructure(3);
            myStructs.Insert(10);
            myStructs.Insert(20);
            myStructs.Insert(30);
            myStructs.Insert(40);
            myStructs.Delete(2);
            myStructs.Print();


            //დაწერეთ ფუნქცია, რომელსაც გადაეცემა ორი ვალუტის იდენტიფიკატორი(USD, GEL, EUR…) და აბრუნებს ვალუტებს შორის გაცვლის კურსს.
            string fromCurrency = "GEL";
            string toCurrency = "USD";
            int amount = 1;

            string[] availableCurrency = CurrencyCourse.GetCurrencyTags();

            Console.WriteLine("Insert Currency you want to convert FROM");
            fromCurrency = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Insert Currency you want to convert TO");
            toCurrency = Console.ReadLine();
            Console.WriteLine("\n");

            double exchangeCurrency = CurrencyCourse.ExchangeRate(fromCurrency, toCurrency);
            Console.WriteLine("FROM " + amount + " " + fromCurrency.ToUpper() + " TO " + toCurrency.ToUpper() + " = " + exchangeCurrency);
        }
    }
}
