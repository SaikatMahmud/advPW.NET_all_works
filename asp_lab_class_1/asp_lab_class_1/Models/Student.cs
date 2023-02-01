using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_lab_class_1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static void Main()
        {
            Student[] students = new Student[2];

            students[0] = new Student();
            students[0].Id = 1;
            students[0].Name = "John Doe";

            students[1] = new Student();
            students[1].Id = 2;
            students[1].Name = "Jane Doe";
        }
    }


}