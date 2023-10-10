using System;
using System.Diagnostics;

public class Employee
{
    private string name;
    private string profession;
    private double salary;

    public Employee(string name, string profession, double salary)
    {
        this.name = name;
        this.profession = profession;
        this.salary = salary;
    }

    public string getName()
    {
        return name;
    }

    public string getProfession()
    {
        return profession;
    }

    public double getSalary()
    {
        return salary;
    }
}

public class Manager : Employee
{
    private string car;
    private double bonus;

    public Manager(string name, string profession, double salary, string car, double bonus)
        : base(name, profession, salary)
    {
        this.car = car;
        this.bonus = bonus;
    }

    public string getCar()
    {
        return car;
    }

    public double getBonus()
    {
        return bonus;
    }
}

public class Program
{
    public static void Main()
    {
        Employee employee1 = new Employee("Kirsi Kernel", "Teacher ", 1200);
        Manager manager1 = new Manager("Hanna Husso", "Head of Institute", 9000, "Audi ", 5000);

        Console.WriteLine($"Employee:\n Name: {employee1.getName()}\n Profession: {employee1.getProfession()}\n Salary: {employee1.getSalary()}\n");

        Console.WriteLine($"Manager:\n Name: {manager1.getName()}\n Profession: {manager1.getProfession()}\n Salary: {manager1.getSalary()}\n Car: {manager1.getCar()}\n Bonus: ${manager1.getBonus()}\n");

        employee1 = new Employee("Kirsi Kernel", "Principal Teacher", 2200);
        Console.WriteLine($"Employee:\n Name: {employee1.getName()}\n Profession: {employee1.getProfession()}\n Salary: {employee1.getSalary()}\n");
    }
}