using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option;
            int checker;
            string uname;
            int uage;
            double usalary;
            int sample=0;
            IDictionary<int, Tuple<string, int, double>> Employees = new Dictionary<int, Tuple<string, int, double>>();
            Employee emp = new Employee();
            Reenter_option:
            try
            { 
                do
                {
                    Console.WriteLine(" Please enter the option\n1.Add an employee\n2.Modify an employee detail\n" +
                        "3.Print all employee's details\n4.Print an employee detail\n5.Exit");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                        Reenter_details:
                            try
                            {
                                do
                                {
                                    emp.TakeEmployeeDetailsFromUser();
                                    Employees.Add(emp.Id, Tuple.Create(emp.Name, emp.Age, emp.Salary));
                                    Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                                    checker = Convert.ToInt32(Console.ReadLine());
                                } while (checker == 1);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Id already exists!!,Reenter the details with different id");
                                sample = 1;
                            }
                            if (sample == 1)
                            {
                                sample = sample + 1;
                                goto Reenter_details;
                            }
                            break;
                        case 2:
                        Reenter_id:
                            Console.WriteLine("Please enter the employee ID");
                            int identityno = Convert.ToInt32(Console.ReadLine());
                            if (Employees.ContainsKey(identityno))
                            {
                                foreach (var empp in Employees)
                                {
                                    if (empp.Key == identityno)
                                    {
                                        Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", empp.Key, empp.Value.Item1, empp.Value.Item2, empp.Value.Item3);
                                    }
                                }
                                Employees.Remove(identityno);
                                Console.WriteLine("Please enter the updated employee details");
                                Console.WriteLine("Please enter the employee name");
                                uname = Console.ReadLine();
                                Console.WriteLine("Please enter the employee age");
                                uage = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Please enter the employee salary");
                                usalary = Convert.ToDouble(Console.ReadLine());
                                Employees.Add(identityno, Tuple.Create(uname, uage, usalary));
                            }
                            else
                            {
                                Console.WriteLine("Id not exists");
                                goto Reenter_id;
                            }
                            break;
                        case 3:
                            foreach (var empp in Employees)
                            {
                                Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", empp.Key, empp.Value.Item1, empp.Value.Item2, empp.Value.Item3);
                            }
                            break;
                        case 4:
                        Reenter:
                            Console.WriteLine("Please enter the employee ID");
                            int idno = Convert.ToInt32(Console.ReadLine());
                            if (Employees.ContainsKey(idno))
                            {
                                foreach (var empp in Employees)
                                {
                                    if (empp.Key == idno)
                                    {
                                        Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", empp.Key, empp.Value.Item1, empp.Value.Item2, empp.Value.Item3);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Id not exixts");
                                goto Reenter;
                            }
                            break;
                        case 5:
                            break;

                        default:
                            Console.WriteLine("Please enter the valid option");
                            break;
                    }

                } while (option != 5);
            }
            catch (Exception)
            {
                Console.WriteLine("Please give the option in numerals");
                sample = 1;
            }
            if (sample == 1)
            {
                sample = 0;
                goto Reenter_option;
            }
            Console.ReadKey();
        }
    }
}
