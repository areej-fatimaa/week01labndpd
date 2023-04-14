using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace kamyabLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\oopweek01lab\\kamyabLife\\customers.txt";
            Console.WriteLine("Enter orders");
            int order = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            int price = int.Parse(Console.ReadLine());
            ReadData(path, order, price);

        }
        static void ReadData(string path,int order,int price)
        {
            string name;
            int totalOrder;
            string prices;
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record=fileVariable.ReadLine())!=null)
                {
                   name= ParseRecord(record,1);
                    totalOrder = int.Parse(ParseRecord(record, 2));
                    prices = ParseRecord(record, 3);
                }
            }
        }
        static void ParseData(string record,int field)
        {
            string name="";
            string order="";
            string price="";
            int space = 1;
            int []orderPrices=new int[100];
            for(int i=0;i<record.Length;i++)
            {
                if (record[i] == ' ')
                {
                    space++;
                }
                else if (space == 1)
                {
                    name += record[i];
                }
                else if (space == 2)
                {
                    order += record[i];
                }
                else if (record[i] == '[')
                {
                    price += record[i];
                }
            }   
            for(int j=0;j<price.Length;j++)
            {
                if(price[j]==',')
                {
                  
                }
            }
        }
    }
}
