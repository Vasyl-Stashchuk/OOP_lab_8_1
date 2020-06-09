using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1_
{
    public class Employee : IComparable
    {
        private int id;
        private string fio;
        private string position;
        private float salary;
        private DateTime startWork;

        public int ID{ get { return id; } set { id = value; } }
        public string FIO { get { return fio; } set { fio = value; } }
        public string Position { get { return position; } set { position = value; } }
        public float Salary { get { return salary; } set { salary = value; } }
        public DateTime StartWork { get { return startWork; } set { startWork = value; } }

        public Employee(int id, string fio, string position, float salary, DateTime startWork)
        {
            this.id = id;
            this.fio = fio;
            this.position = position;
            this.salary = salary;
            this.startWork = startWork;
        }

        public void showInfo()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("ФІП: " + FIO);
            Console.WriteLine("Посада: " + Position);
            Console.WriteLine("Зарплата: " + Salary);
            Console.WriteLine("Дата прийняття на роботу: " + StartWork.ToString("dd/MM/yyyy"));
        }

        public int CompareTo(object obj)
        {
            Employee employee = (Employee)obj;
            if (this.ID > employee.ID) return 1;
            if (this.ID < employee.ID) return -1;
            return 0;
        }

        public class SortByID : IComparer
        {
            public int Compare(object e1, object e2)
            {
                Employee emp1 = (Employee)e1;
                Employee emp2 = (Employee)e2;
                if (emp1.ID > emp2.ID) return 1;
                if (emp1.ID < emp2.ID) return -1;
                return 0;
            }
        }
        public class SortBySalarey : IComparer<Employee>
        {
            public int Compare(Employee emp1, Employee emp2)
            {
                if (emp1.Salary > emp2.Salary) return 1;
                if (emp1.Salary < emp2.Salary) return -1;
                return 0;
            }
        }

        public class SortByDate : IComparer<Employee>
        {
            public int Compare(Employee emp1, Employee emp2)
            {
                if (emp1.StartWork > emp2.StartWork) return 1;
                if (emp1.StartWork < emp2.StartWork) return -1;
                return 0;
            }
        }
    }
}
