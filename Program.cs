using System;
using System.Collections.Generic;

namespace studentExercises {

  class Program {

      static void AssignStudentToCohort(Student student, Cohort cohort) => cohort.StudentList.Add(student);

      static void AssignInstructorToCohort(Instructor instructor, Cohort cohort) => cohort.InstructorList.Add(instructor);

    static void Main() {


      Cohort cohort1 = new Cohort(1, "Cohort 1");
      Cohort cohort2 = new Cohort(2, "Cohort 2");
      Cohort cohort3 = new Cohort(3, "Cohort 3");

      Exercise exercise1 = new Exercise (1, "Planets", "CSharp");
      Exercise exercise2 = new Exercise (2, "Random Numbers", "CSharp");
      Exercise exercise3 = new Exercise (3, "Classes", "CSharp");
      Exercise exercise4 = new Exercise (4, "Dictionaries", "CSharp");
      Exercise exercise5 = new Exercise (5, "Sets", "CSharp");
      Exercise exercise6 = new Exercise (6, "Student Exercises", "CSharp");

      Student student1 = new Student (1, "Russell", "Reiter", "Russ", 1);
      Student student2 = new Student (2, "Ashwin", "Prakash", "Ashwin", 1);
      Student student3 = new Student (3, "Zac", "Crawford", "Zac Crawford", 2);
      Student student4 = new Student (4, "JD", "Wheeler", "JDWheeler", 2);
      Student student5 = new Student (5, "Hunter", "Metts", "Hunter Metts", 3);
      Student student6 = new Student (6, "Joseph", "Baugh", "Joey Baugh", 3);

      AssignStudentToCohort(student1, cohort1);
      AssignStudentToCohort(student2, cohort1);
      AssignStudentToCohort(student3, cohort2);
      AssignStudentToCohort(student4, cohort3);

      Instructor instructor1 = new Instructor (1, "Andy", "Collins", "andyc", 1);
      Instructor instructor2 = new Instructor (2, "Madi", "Peper", "Madi", 2);
      Instructor instructor3 = new Instructor (3, "Leah", "Hoefling", "Leah", 3);

      AssignInstructorToCohort(instructor1, cohort1);
      AssignInstructorToCohort(instructor2, cohort2);
      AssignInstructorToCohort(instructor3, cohort3);

      instructor1.AssignExercises(student1, exercise1);
      instructor1.AssignExercises(student1, exercise2);
      instructor1.AssignExercises(student2, exercise1);
      instructor1.AssignExercises(student2, exercise2);
      instructor1.AssignExercises(student3, exercise1);
      instructor1.AssignExercises(student3, exercise2);
      instructor1.AssignExercises(student4, exercise1);
      instructor1.AssignExercises(student4, exercise2);
      instructor1.AssignExercises(student5, exercise1);
      instructor1.AssignExercises(student5, exercise2);
      instructor1.AssignExercises(student6, exercise1);
      instructor1.AssignExercises(student6, exercise2);

      instructor2.AssignExercises(student1, exercise3);
      instructor2.AssignExercises(student1, exercise4);
      instructor2.AssignExercises(student2, exercise3);
      instructor2.AssignExercises(student2, exercise4);
      instructor2.AssignExercises(student3, exercise3);
      instructor2.AssignExercises(student3, exercise4);
      instructor2.AssignExercises(student4, exercise3);
      instructor2.AssignExercises(student4, exercise4);
      instructor2.AssignExercises(student5, exercise3);
      instructor2.AssignExercises(student5, exercise4);
      instructor2.AssignExercises(student6, exercise3);
      instructor2.AssignExercises(student6, exercise4);

      instructor3.AssignExercises(student1, exercise5);
      instructor3.AssignExercises(student1, exercise6);
      instructor3.AssignExercises(student2, exercise5);
      instructor3.AssignExercises(student2, exercise6);
      instructor3.AssignExercises(student3, exercise5);
      instructor3.AssignExercises(student3, exercise6);
      instructor3.AssignExercises(student4, exercise5);
      instructor3.AssignExercises(student4, exercise6);
      instructor3.AssignExercises(student5, exercise5);
      instructor3.AssignExercises(student5, exercise6);
      instructor3.AssignExercises(student6, exercise5);
      instructor3.AssignExercises(student6, exercise6);

      List<Student> students = new List<Student>() {student1, student2, student3, student4, student5, student6};
      List<Exercise> exercises = new List<Exercise> () {exercise1, exercise2, exercise3, exercise4, exercise5, exercise6};

      foreach (Student student in students) {

        List<string> assignedExercises = new List<string>();

        foreach (Exercise exercise in student.AssignedExercises) {
            assignedExercises.Add(exercise.ExerciseName);
        }
        string exerciseList = String.Join(", ", assignedExercises);
        Console.WriteLine($"{student.FirstName} {student.LastName} is working on the following exercises: {exerciseList}");
      }
    }
  }
}
