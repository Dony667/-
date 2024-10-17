using System;
using System.Linq;

namespace module4
{
    public class homework_module4
    {
        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public double CalculateTotalPrice()
            {
                return Quantity * Price * 0.9;
            }

            public void ProcessPayment(string paymentDetails)
            {
                Console.WriteLine("Payment processed using: " + paymentDetails);
            }

            public void SendConfirmationEmail(string email)
            {
                Console.WriteLine("Confirmation email sent to: " + email);
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            public double BaseSalary { get; set; }
            public string EmployeeType { get; set; } 
        }

        public class EmployeeSalaryCalculator
        {
            public double CalculateSalary(Employee employee)
            {
                if (employee.EmployeeType == "постоянный")
                {
                    return employee.BaseSalary * 1.2; 
                }
                else if (employee.EmployeeType == "контракт")
                {
                    return employee.BaseSalary * 1.1; 
                }
                else if (employee.EmployeeType == "стажер")
                {
                    return employee.BaseSalary * 0.8; 
                }
                else
                {
                    throw new NotSupportedException("тип сотрудника не поддерживается");
                }
            }
        }

        public interface IPrinter
        {
            void Print(string content);
            void Scan(string content);
            void Fax(string content);
        }

        public class AllInOnePrinter : IPrinter
        {
            public void Print(string content)
            {
                Console.WriteLine("печаетает: " + content);
            }

            public void Scan(string content)
            {
                Console.WriteLine("скан: " + content);
            }

            public void Fax(string content)
            {
                Console.WriteLine("факс: " + content);
            }
        }

        public class BasicPrinter : IPrinter
        {
            public void Print(string content)
            {
                Console.WriteLine("печатает: " + content);
            }

            public void Scan(string content)
            {
                throw new NotImplementedException();
            }

            public void Fax(string content)
            {
                throw new NotImplementedException();
            }
        }

        public class EmailSender
        {
            public void SendEmail(string message)
            {
                Console.WriteLine("эмайл: " + message);
            }
        }

        public class SmsSender
        {
            public void SendSms(string message)
            {
                Console.WriteLine("смс: " + message);
            }
        }

        public class NotificationService
        {
            private EmailSender emailSender = new EmailSender();
            private SmsSender smsSender = new SmsSender();

            public void SendNotification(string message)
            {
                emailSender.SendEmail(message);
                smsSender.SendSms(message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("программа запущена");
        }
    }
}