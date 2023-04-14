using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace fileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\oopweek01lab\\fileHandling\\ggg.txt";
               if (File.Exists(path))
               {
                   StreamReader fileVariable = new StreamReader(path);
                   string record;
                   while ((record = fileVariable.ReadLine()) != null)
                   {
                       Console.WriteLine(record);
                   }
                   fileVariable.Close();
               }
               else
               {
                   Console.WriteLine("not exists");
               }
            /* string path = "D:\\oopweek01lab\\fileHandling\\ggg.txt";
             StreamWriter fileVariable = new StreamWriter(path, true);
             fileVariable.WriteLine("hello");
             fileVariable.Flush();
             fileVariable.Close();*/
            Console.ReadKey();

        }
    }
}
