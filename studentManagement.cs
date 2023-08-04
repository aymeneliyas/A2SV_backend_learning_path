using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace schoolManagement
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public readonly int RollNo;
        public int Grade { get; set; }

        public Student(string name, int age, int rollNo, int grade)
        {
            Name = name;
            Age = age;
            RollNo = rollNo;
            Grade = grade;
        }
    }

    public class StudentList<T>
    {
        public List<Student> Students = new List<Student>();
        public string fileName = "stud.json";

        public void AddStudent(Student s)
        {
            Students.Add(s);
            SerializeJson();
        }
        public void searchStudentByName(string name)
        {
            List<Student> s = (from student in Students where student.Name == name select student).ToList();
            Console.WriteLine("search results by name:\n");
            
            foreach (Student student in s)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNo}, Grade: {student.Grade}\n");
            }
        }

        public void searchStudentByAge(int age)
        {
            List<Student> s = (from student in Students where student.Age == age select student).ToList();
            Console.WriteLine("search results by age: \n");
            foreach (Student student in s)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNo}, Grade: {student.Grade}\n");
            }

        }
        public void DisplayAllStudents()
        {
            Console.WriteLine("----------------------students---------------------");
            foreach (var student in Students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNo}, Grade: {student.Grade}");
                
            }
        }

        private void SerializeJson()
        {
        
            string json = JsonConvert.SerializeObject(Students);
            File.WriteAllText(fileName, json);
        }
        public List<Student> DeserializeFile()
        {
            string json = File.ReadAllText(fileName);
            List<Student>? deserializedFile = JsonConvert.DeserializeObject<List<Student>>(json);
            return deserializedFile;
        }

  }

      public class Program
      {
          public static void Main(string[] args)
          {
              Student s = new Student("Aymen", 22, 10, 3);
              Student a = new Student("Abebe", 21, 11, 4);
              StudentList<Student> stud = new StudentList<Student>();
              stud.AddStudent(s);
              stud.AddStudent(a);
              stud.DisplayAllStudents();

              List<Student> st = stud.DeserializeFile();
              foreach(Student student in st)
              {
                  Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNo}, Grade: {student.Grade}");
              }
              stud.searchStudentByName("Aymen");
              stud.searchStudentByAge(21);
        }
    }



}
