using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            new Application().Run();
        }
    }

    class Application
    {
        Random spin = new Random();// for things such as isLowSet or a check for even/odd where you can use a bool or the modulus which is better to use? memory vs processing
        Tuple<string, bool?, int, bool, int>[] table = // Tuple<number, isRed, rowNumber, isLowSet, columnSet>
        {
            Tuple.Create( "0" , null  as bool?, 0, true , 0),//need nullable bools for 0 and 00
            Tuple.Create( "1" , true  as bool?, 1, true , 1),
            Tuple.Create( "2" , false as bool?, 1, true , 2),
            Tuple.Create( "3" , true  as bool?, 1, true , 3),
            Tuple.Create( "4" , false as bool?, 1, true , 1),
            Tuple.Create( "5" , true  as bool?, 1, true , 2),
            Tuple.Create( "6" , false as bool?, 1, true , 3),
            Tuple.Create( "7" , true  as bool?, 1, true , 1),
            Tuple.Create( "8" , false as bool?, 1, true , 2),
            Tuple.Create( "9" , true  as bool?, 1, true , 3),
            Tuple.Create( "10", false as bool?, 1, true , 1),
            Tuple.Create( "11", false as bool?, 1, true , 2),
            Tuple.Create( "12", true  as bool?, 1, true , 3),
            Tuple.Create( "13", false as bool?, 2, true , 1),
            Tuple.Create( "14", true  as bool?, 2, true , 2),
            Tuple.Create( "15", false as bool?, 2, true , 3),
            Tuple.Create( "16", true  as bool?, 2, true , 1),
            Tuple.Create( "17", false as bool?, 2, true , 2),
            Tuple.Create( "18", true  as bool?, 2, true , 3),
            Tuple.Create( "19", true  as bool?, 2, false, 1),
            Tuple.Create( "20", false as bool?, 2, false, 2),
            Tuple.Create( "21", true  as bool?, 2, false, 3),
            Tuple.Create( "22", false as bool?, 2, false, 1),
            Tuple.Create( "23", true  as bool?, 2, false, 2),
            Tuple.Create( "24", false as bool?, 2, false, 3),
            Tuple.Create( "25", true  as bool?, 3, false, 1),
            Tuple.Create( "26", false as bool?, 3, false, 2),
            Tuple.Create( "27", true  as bool?, 3, false, 3),
            Tuple.Create( "28", false as bool?, 3, false, 1),
            Tuple.Create( "29", false as bool?, 3, false, 2),
            Tuple.Create( "30", true  as bool?, 3, false, 3),
            Tuple.Create( "31", false as bool?, 3, false, 1),
            Tuple.Create( "32", true  as bool?, 3, false, 2),
            Tuple.Create( "33", false as bool?, 3, false, 3),
            Tuple.Create( "34", true  as bool?, 3, false, 1),
            Tuple.Create( "35", false as bool?, 3, false, 2),
            Tuple.Create( "36", true  as bool?, 3, false, 3),
            Tuple.Create( "00", null  as bool?, 0, false, 0)

        };

        public bool Bet(ConsoleKey x)
        {

            switch (x)
            {
                case ConsoleKey.D1:
                    return Number();

                default:
                    return false;
            }
        }

        public bool Number()
        {
            int num = spin.Next(0, 37);
            bool check;
            int betVal = -5;
            Console.WriteLine("Please enter a number between 00 and 36.");
            do
            {

                check = true;

                try
                {
                    betVal = int.Parse(Console.ReadLine());
                    if (betVal > 36 || betVal < 0)
                    {
                        throw new FormatException();
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                    Console.Read();
                    check = false;
                }

            } while (check == false);

            Console.WriteLine(table[num].Item1);
            Console.WriteLine(betVal);

            if (betVal.ToString() == table[num].Item1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool EvenOdd()
        {
            Console.WriteLine("Select your bet.");
            Console.WriteLine("1: Even");
            Console.WriteLine("2: Odd");
            var input = Console.ReadKey().Key;
            bool isEven = input == ConsoleKey.D1 ? isEven = true : isEven = false;
             
            return false;
        }


































        public void Run()
        {
            bool gambling = true;
            while (gambling == true)
            {
                Console.WriteLine("Which type of bet would you like to make?");
                Console.WriteLine
                   ("1. Number\n" +
                    "2. Even/Odd\n" +
                    "3. Red/Black\n" +
                    "4. Low/High\n" +
                    "5. Dozens\n" +
                    "6. Row\n" +
                    "7. Street\n" +
                    "8. Double Street\n" +
                    "9. Split\n" +
                    "0. Corner\n");
                var x = Console.ReadKey().Key;
                Bet(x);
            }
        }
    }
}

//Numbers - table int - done

//Even/Odd - Use Function

//Red/Black - table bool - done

//Lows/Highs - table bool - done

//Row Selection - table int - done

//Column Set - table int - done

//Street - table int with starting number as int i.e. (10, 11, 12) is assigned int 10 

//6 Numbers/Double Street - Street tuples? or just another table int with bottom numbers

//Split - Use function if((row == row && number == number +- 3) || (street != street && number == number +- 1) ) 

//Corner - probably just enter the smallest and highest numbers then use if(smallest number == largest - 4 ){second number = smallest +1; third number = largest - 1;} else{invalid entry} 
//gotta make sure smallest number is < 33 and check that the smallest number column is less than largest number column