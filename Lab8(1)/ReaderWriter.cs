using Lab8_1_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1_
{
    public class ReaderWriter
    {
        public List<string> readDataFromFile()
        {
            List<string> lines = new List<string>();
            string line;
            StreamReader file = new StreamReader("department.txt", Encoding.GetEncoding(1251));
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines;
        }

        public void saveList(List<Employee> employees)
        {
            using (StreamWriter save = new StreamWriter("department.txt", false, Encoding.GetEncoding(1251)))
            {
                string str = null;

                foreach (Employee e in employees)
                {
                    str = e.ID +","+ e.FIO + "," + e.Position + "," + e.Salary + "," + e.StartWork.ToString("dd/MM/yyyy");
                    save.WriteLine(str);
                }
            }
        }
    }
}
