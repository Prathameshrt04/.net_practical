using System;
using System.IO;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
    public bool IsPassing { get; set; }
    public char GradeLetter { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
        CalculateGradeStatus();
    }

    private void CalculateGradeStatus()
    {
        if (Grade >= 90)
        {
            GradeLetter = 'A';
            IsPassing = true;
        }
        else if (Grade >= 80)
        {
            GradeLetter = 'B';
            IsPassing = true;
        }
        else if (Grade >= 70)
        {
            GradeLetter = 'C';
            IsPassing = true;
        }
        else
        {
            GradeLetter = 'F';
            IsPassing = false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "students.txt";

        while (true)
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("Student Grade Manager");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choiceStr = Console.ReadLine();
            int choice;
            bool isValidChoice = int.TryParse(choiceStr, out choice);

            switch (choice)
            {
                case 1:
                    AddStudent(filePath);
                    break;
                case 2:
                    DisplayStudents(filePath);
                    break;
                case 3:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    static void AddStudent(string filePath)
    {
        try
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student age: ");

            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter student grade (0-100): ");

            double grade = double.Parse(Console.ReadLine());

            Student student = new Student(name, age, grade);

            string studentInfo = $"{student.Name},{student.Age},{student.Grade},{student.GradeLetter},{student.IsPassing}";
            File.AppendAllText(filePath, studentInfo + Environment.NewLine);

            Console.WriteLine($"Added: {student.Name} - Grade: {student.GradeLetter}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DisplayStudents(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No student records found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        Console.WriteLine("\nStudent Records:");
        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            string displayName = data[0].Substring(0, Math.Min(10, data[0].Length)).PadRight(12);
            string displayLine = $"{i + 1}. {displayName} Age: {data[1]} Grade: {data[3]}";

            Console.WriteLine(displayLine);
        }
    }
}