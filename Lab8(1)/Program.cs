using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
            ResourseDepartment resourseDepartment = new ResourseDepartment();
            resourseDepartment.setComands();
            Console.ReadKey();
        }
    }
}
