using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1_
{
    public class ResourseDepartment
    {
        private List<Employee> employees;
        private ReaderWriter readerWriter;
        public ResourseDepartment()
        {
            readerWriter = new ReaderWriter();
            employees = createList();
        }

        public void setComands()
        {
            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Сортування за ідефікаційним номером: N");
            Console.WriteLine("Сортування за зарплатою: S");
            Console.WriteLine("Сортування за датою прийняття на роботу: D");
            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    addNew();
                    setComands();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    edit();
                    setComands();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    delete();
                    setComands();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    showList();
                    setComands();
                    break;

                case ConsoleKey.N:
                    Console.WriteLine();
                    showSortByID();
                    setComands();
                    break;

                case ConsoleKey.D:
                    Console.WriteLine();
                    showSortByDate();
                    setComands();
                    break;
                case ConsoleKey.S:
                    Console.WriteLine();
                    showSortBySalary();
                    setComands();
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
        public Employee parseInfo(string strInfo)
        {
            string[] words = new string[6];
            words = strInfo.Split(',');
            Employee employee = new Employee(int.Parse(words[0]), words[1], words[2], float.Parse(words[3]), DateTime.Parse(words[4]));
            return employee;
        }
        public List<Employee> createList()
        {
            List<Employee> e = new List<Employee>();
            List<string> strs = readerWriter.readDataFromFile();
            int strCount = 0;
            foreach (string s in strs)
            {
                e.Add(parseInfo(s));
                strCount++;
            }
            return e;
        }

        public void showList()
        {
            Console.WriteLine("{0, -5} {1, -28} {2, -10} {3, -10} {4}", "ID", "Фамілія, імя, по-батькові", "Посада", "Зарплата", "Дата прийняття на роботу");
            foreach (Employee e in employees)
                Console.WriteLine("{0, -5} {1, -28} {2, -10} {3, -10} {4}", e.ID, e.FIO, e.Position, e.Salary, e.StartWork.Date.ToString("dd/MM/yyyy"));
        }

        public void addNew()
        {
            Console.WriteLine("Введiть данi через кому:");
            try
            {
                string strInfo = Console.ReadLine();
                Employee employee = parseInfo(strInfo);
                employees.Add(employee);
                readerWriter.saveList(employees);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void delete()
        {
            Console.WriteLine("Введіть ID: ");
            try
            {
                int count = 0;
                int num = int.Parse(Console.ReadLine());
                foreach (Employee emp in employees)
                {
                    if (emp.ID == num)
                    {
                        emp.showInfo();
                        Console.WriteLine("Видалити? (Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            employees.Remove(emp);
                            Console.WriteLine("Видалено успішно!");
                            break;
                        }
                    }
                    else
                        count++;
                }
                if (count == employees.Count)
                    Console.WriteLine("Такого диску немає в колекції дисків8");
                else
                    readerWriter.saveList(employees);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void edit()
        {
            Console.WriteLine("Введіть інвентарний номер: ");
            try
            {
                int count = 0;
                int num = int.Parse(Console.ReadLine());
                foreach (Employee emp in employees)
                {
                    if (emp.ID == num)
                    {
                        emp.showInfo();
                        Console.WriteLine("Введіть нову інформацію через кому");
                        string strInfo = Console.ReadLine();
                        Employee editedEmp = parseInfo(strInfo);
                        editedEmp.showInfo();
                        Console.WriteLine("Зберегти зміни(Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            employees.Remove(emp);
                            employees.Add(editedEmp);
                            break;
                        }
                    }
                    else
                        count++;
                }
                if (count == employees.Count)
                    Console.WriteLine("Такого диску немає в колекції дисків8");
                else
                    readerWriter.saveList(employees);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void showSortByID()
        {
            employees.Sort();
            //Array.Sort(employees.ToArray(), new Employee.SortByID());
            showList();
        }
        private void showSortByDate()
        {
            employees.Sort(0, employees.Count, new Employee.SortByDate());
            showList();
        }
        private void showSortBySalary()
        {
            employees.Sort(0,employees.Count, new Employee.SortBySalarey());
            showList();
        }
    }
}
