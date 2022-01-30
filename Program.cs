using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;


namespace Cows
{
    class Program
    {
       static private Random newnumber = new Random();
       static private List<int> remembernumber = new List<int>(); //для генирации рандомного числа(оно сюда записываться будет)
      static private  List<int> rememberusernumber = new List<int>(); //ввод пользователя записывается сюда
       static public void print()
        {
            for (int i = 0; i < remembernumber.Count; i++)
            {
                Console.Write(remembernumber[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
           
            int number = 0;
             int trycount = 10;
            int count = 0;
            int count2 = 0;

            //создание рандомного четырехзначного числа
            for (int i = 0; i < 4; )
            {
                number = newnumber.Next(0,9);
               
                if (!remembernumber.Contains(number))
                {
                    remembernumber.Add(number);
                    i++;
                }
            }
         
            //показывает число
            Console.WriteLine("Игра Быки и Коровы.");
            Console.WriteLine("Генирируем число");
            Thread.Sleep(5000);
            Console.WriteLine("Число готово!");
            
            while (trycount>=0)
            {
                
                Console.WriteLine("Введите число: ");
                string uservvod = Console.ReadLine();
                if (uservvod.Length!=4)
                {
                    Console.WriteLine("Введите 4-значное чило");
                    trycount++;
                    
                }
                //записываем число в лист(попутно разбивая его)
                for (int i = 0; i < uservvod.Length; i++)
                {

                    rememberusernumber.Add(Convert.ToInt32(uservvod[i] - 48));

                }
              

                //сравнение чисел
                for (int i = 0; i < remembernumber.Count; i++)
                {
                    for (int j = 0; j < rememberusernumber.Count; j++)
                    {
                        if (remembernumber[i] == rememberusernumber[j])
                        {
                            if (i == j)
                            {
                                count++;

                            }
                            else
                            {
                                count2++;

                            }

                        }

                    }

                }
               
                if (count==4)
                {
                    Console.WriteLine("Вы угадали число!!!");
                    break;
                   
                }
                Console.WriteLine($"быков {count}, Коров {count2}");
                rememberusernumber.Clear();
                trycount--;
                Console.WriteLine($"Количтсво попыток {trycount}");
                count = 0; count2 = 0;
                if (trycount==0&&count!=4)
                {
                    Console.Write($"К сожалению, вы не угадали число. Числом было ");
                    print();
                    break;
                }
            }
            
           




           
           
          
        }

    }
}


