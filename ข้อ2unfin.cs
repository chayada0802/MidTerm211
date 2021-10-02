using System;
using System.Collections.Generic;

namespace Libraries
{
    class Program
    {
        enum Menu
        {
            Login = 1,
            Register
        }
        enum person
        {
            Student = 1,
            Employee = 2
        }
        static void Main(string[] args)
        {
            PrintMenuScreen();
        }
        static void PrintMenuScreen()
        {

            header();
            PrintListMenu();
            InputMenuFromKeyboard();
        }
        static void header()
        {

            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("--------------------------");
        }
        static void PrintListMenu()
        {

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
        }
        static void InputMenuFromKeyboard()
        {
            Console.Write("Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.Register)
            {
                Register();
            }
            else if (menu == Menu.Login)
            {
                Login();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }

            static void ShowMessageInputMenuIsInCorrect()
            {
                Console.Clear();
                Console.WriteLine("Menu Incorrect Please try again.");
                InputMenuFromKeyboard();
            }
            static void Register()
            {
                PrintHeaderRegister();
            }
            static void Login()
            {
                PrintHeaderLogin();
            }

            static void PrintHeaderRegister()
            {
                Console.Clear();
                Console.WriteLine("Register new Person");
                Console.WriteLine("---------------------");
                NewPerson();
            }
            static Student NewPerson()
            {
                return new Student(InputName(), InputPassword());
                static string InputName()
                {
                    Console.Write("Name: ");

                    return Console.ReadLine();
                }

                static string InputPassword()
                {
                    Console.Write("Password: ");

                    return Console.ReadLine();
                }
            }
            static void PrintHeaderLogin()
            {
                Console.Clear();
                Console.WriteLine("Login Screen");
                Console.WriteLine("------------");
                Logininput();
            }
            static void Logininput()
            {
                InputNameLog();
                InputPasswordLog();
                static string InputNameLog()
                {
                    Console.Write("Name: ");

                    return Console.ReadLine();
                }

                static string InputPasswordLog()
                {
                    Console.Write("Password: ");

                    return Console.ReadLine();
                }
            }
        }
    }
    class Person
    {
        protected string name;
        protected string password;


        public Person(string name, string password)
        {
            this.name = name;
            this.password = password;

        }

        public string GetName()
        {
            return this.name;
        }
    }
    class Student : Person
    {
        private string studentID;

        public Student(string name, string password) : base(name, password)
        {
            this.studentID = studentID;
        }


        class Employee : Person
        {
            private string EmployeeID;

            public Employee(string name, string password, string EmployeeID)
            : base(name, password)
            {
                this.EmployeeID = EmployeeID;
            }

        }
        class PersonList
        {
            private List<Person> personList;

            public PersonList()
            {
                this.personList = new List<Person>();
            }

            public void AddNewPerson(Person person)
            {
                this.personList.Add(person);
            }
            static void InputExitFromKeyboard()
            {
                string text =
                ""
                ;

                while (text != "exit")
                {
                    Console.WriteLine("Input: ");
                    text = Console.ReadLine();
                }
            }
            public class Book

            {
                
                private List<Book> carryDestionations = new List<Book>
                {
                    new Book( "Book name: NOW I UNDERSTAND",1),
                    new Book("REVOLUTIONARY WEALTH",2),
                    new Book("Six Degrees",3),
                    new Book("Les Vacances",4)
                };
                private string v1;
                private int v2;

                public Book(string v1, int v2)
                {
                    this.v1 = v1;
                    this.v2 = v2;
                }
            }
        }
    }
}
    

    


