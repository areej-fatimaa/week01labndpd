using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Enter first number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int num2 = int.Parse(Console.ReadLine());
            int sum = Task17(num1, num2);
            Console.WriteLine("Sum is: {0}", sum);
            Console.ReadKey();
           float result;
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price of washing machine");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("enter price of unit toy");
            int toyprice = int.Parse(Console.ReadLine());

            result = Task16(age, price, toyprice);
            if (result > price)
            {
                float savedprice = result - price;
                Console.WriteLine("Yes! {0}", savedprice);
            }
            else if (result < price)
            {
                float savedprice = price - result;
                Console.WriteLine("No! {0}", savedprice);
            }
            //Task11();
        }
        static void Task1()
        {
            Console.Write("HELLO WORLD!");
            Console.ReadKey();
        }
        static void Task2()
        {
            int variable = 7;
            Console.WriteLine("value:");
            Console.Write(variable);
            Console.ReadKey();
        }
        static void Task3()
        {
            string variable = "i am string ";
            Console.WriteLine("string:");
            Console.Write(variable);
            Console.ReadKey();
        }
        static void Task4()
        {
            char variable = 'A';
            Console.WriteLine("character:");
            Console.Write(variable);
            Console.ReadKey();
        }
        static void Task5()
        {
            float variable = 1.2f;
            Console.Write("float:");
            Console.Write(variable);
            Console.ReadKey();
        }
        static void Task6()
        {
            string str;
            str = Console.ReadLine();
            Console.WriteLine("you have inputted:");
            Console.Write(str);
            Console.ReadKey();
        }
        static void Task7()
        {
            string str;
            str = Console.ReadLine();
            Console.WriteLine("you have inputted:");
            Console.Write(str);
            Console.ReadKey();
        }
        static void Task8()
        {
            string str;
            str = Console.ReadLine();
            Console.WriteLine("you have inputted: ");
            int num = int.Parse(str);
            Console.WriteLine("the number is");
            Console.Write(num);
            Console.ReadKey();
        }
        static void Task9()
        {
            string str;
            str = Console.ReadLine();
            Console.WriteLine("you have inputted: ");
            float num = float.Parse(str);
            Console.WriteLine("the floating value is");
            Console.Write(num);
            Console.ReadKey();

        }
        static void Task10()
        {
            string str;
            Console.WriteLine("Enter length of one side of squre: ");
            str = Console.ReadLine();
            int length = int.Parse(str);
            int area = length * length;
            Console.WriteLine("Area of square is:{0}", area);
            Console.ReadLine();
        }


        static void Task11()
        {
            Console.WriteLine("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            if (num > 50)
            {
                Console.WriteLine("You are passed!");
            }
            else
            {
                Console.WriteLine("You are failed!");
            }
            Console.ReadKey();
        }
        static void Task12()
        {
            for(int x=0;x<5;x++)
            {
                Console.WriteLine("welcome jack");
            }
            Console.Read();
        }
        static void Task13()
        {
            int num;
            int sum = 0;
            Console.WriteLine("Enter number");
            num = int.Parse(Console.ReadLine());
            while (num != -1)
            {
                sum = sum + num;
                Console.WriteLine("Enter number");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("total sum is:{0}", sum);
            Console.ReadKey();
    }
        static void Task14()
        {
            int num;
            int sum = 0;
            do
            {
                Console.WriteLine("Enter number");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            sum = sum + 1;
            Console.WriteLine("total sum is:{0}", sum);
            Console.ReadKey();
        }
        static void Task15()
        {
            int[] number = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter number{0}:", i);
                number[i] = int.Parse(Console.ReadLine());
            }
            //finding largest
            int largest = -1;
            for (int i = 0; i < 3; i++)
            {
                if (number[i] > largest)
                {
                    largest = number[i];
                }
            }
            Console.WriteLine("Largest is: {0}", largest);
            Console.Read();
        }
        static float Task16(int age, float price,int toyprice)    //lily's saved money
        {

            int totalprice = 0;
            int totalpricetoy = 0;
            int totalmoney = 0;
            int money = 0;
            for (int n = 1; n <= age; n = n + 2)
            {
                totalpricetoy = toyprice + totalpricetoy;
            }
            for (int m = 2; m <= age; m = m + 2)
            {
                money = money + 10;
                totalprice = totalprice + money - 1;
            }
            totalmoney = totalpricetoy + totalprice;
            return totalmoney;

        }
        static int Task17(int num1,int num2)      //add two numbers passing parameters
        {
            return num1 + num2;

        }
    }

}
