using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass
{
    class Person
    {
        public string Name;
        public byte age;
        public int BirthDate;
        public byte GenderNumberInput;
        public string GenderStringInput;
        public Genders Gender;

        public int currentYear = DateTime.Now.Year;

        public enum Genders
        {
            Male,
            Female
        }
        public Person(string[] args)
        {
            this.Name = args[0];
            int.TryParse(args[1], out BirthDate);
            this.age = (byte)(currentYear - BirthDate);
            byte.TryParse(args[2], out GenderNumberInput);
            this.GenderStringInput = args[3];
            Enum.TryParse(GenderStringInput, out Gender);
        }
        public override string ToString()
        {
            //System.Console.WriteLine("Gender: {0}", Enum.GetName(typeof(Genders), GenderNumberInput));
            return "Name: " + Name + " Age: " + age + " BirthDate: " + BirthDate + " Gender: " + Gender;
        }
        static void Main(string[] args)
        {
            Person person = new Person(args);
            System.Console.WriteLine(person.ToString());
            Employee employee = new Employee(args);
            employee.Room = new Room(1);
            Employee employee2 = (Employee)employee.Clone();
            System.Console.WriteLine(employee.ToString());
            employee2.Room.Number = 2;
            System.Console.WriteLine(employee2.ToString());
            Console.ReadKey();
        }
    }
    class Employee : Person, ICloneable
    {
        int Salary;
        string Profession;
        public Room Room;
        public Employee(string[] args) : base(args)
        {
            Enum.TryParse(GenderStringInput, out Gender);
            int.TryParse(args[4], out Salary);
            this.Profession = args[5];
        }
        public override string ToString()
        {
            return "Name: " + Name + ", Age: " + age + ", BirthDate: " + BirthDate + ", Gender: " + Gender + ", Salary: " + Salary + ", Profession: " + Profession + ", Room: " + Room.Number;
        }
        public object Clone()
        {
            //return this.MemberwiseClone();
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }
    }

    class Room
    {
        public int Number;
        public Room(int RoomNumber)
        {
            this.Number = RoomNumber;
        }
    }
}
