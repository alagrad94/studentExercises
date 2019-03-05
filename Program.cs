using System;
using System.Collections.Generic;
using System.Linq;

namespace studentExercises {

  class Program {

      static void AssignStudentToCohort(Student student, Cohort cohort) => cohort.StudentList.Add(student);

      static void AssignInstructorToCohort(Instructor instructor, Cohort cohort) => cohort.InstructorList.Add(instructor);

    static void Main() {


      Cohort cohort1 = new Cohort(1, "Cohort 1");
      Cohort cohort2 = new Cohort(2, "Cohort 2");
      Cohort cohort3 = new Cohort(3, "Cohort 3");

      Exercise exercise1 = new Exercise (1, "Planets", "CSharp");
      Exercise exercise2 = new Exercise (2, "Random Numbers", "JavaScript");
      Exercise exercise3 = new Exercise (3, "Classes", "CSharp");
      Exercise exercise4 = new Exercise (4, "Dictionaries", "JavaScript");
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

      instructor3.AssignExercises(student5, exercise5);
      instructor3.AssignExercises(student5, exercise6);

      List<Student> students = new List<Student>() {student1, student2, student3, student4, student5, student6};
      List<Exercise> exercises = new List<Exercise> () {exercise1, exercise2, exercise3, exercise4, exercise5, exercise6};
      List<Cohort> cohorts = new List<Cohort> () {cohort1, cohort2, cohort3};
      List<Instructor> instructors = new List<Instructor> () {instructor1, instructor2, instructor3};

      foreach (Student student in students) {

        List<string> assignedExercises = new List<string>();

        foreach (Exercise exercise in student.AssignedExercises) {
            assignedExercises.Add(exercise.ExerciseName);
        }
        string exerciseList = String.Join(", ", assignedExercises);
        Console.WriteLine($"{student.FirstName} {student.LastName} is working on the following exercises: {exerciseList}");
      }

      IEnumerable<Exercise> javascriptExercises = exercises.Where(exercise => exercise.ExerciseLanguage == "JavaScript");
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine("The exercises with JavaScript language are: ");
      foreach (Exercise ex in javascriptExercises) {
          Console.WriteLine($"{ex.ExerciseName} : {ex.ExerciseLanguage}");
      }
      Console.WriteLine("--------------------------------------------");

      IEnumerable<Student> studentsInCohort1 = students.Where(student => student.CohortId == 1);
      Console.WriteLine("The students in Cohort 1 are: ");
      foreach (Student student in studentsInCohort1) {
          Console.WriteLine($"{student.FirstName} {student.LastName}");
      }
      Console.WriteLine("--------------------------------------------");

      IEnumerable<Instructor> instructorsInCohort1 = instructors.Where(instructor => instructor.CohortId == 1);
      Console.WriteLine("The instructors in Cohort 1 are: ");
      foreach (Instructor instructor in instructorsInCohort1) {
          Console.WriteLine($"{instructor.FirstName} {instructor.LastName}");
      }
      Console.WriteLine("--------------------------------------------");

      IEnumerable<Student> orderedStudents = students.OrderBy(student => student.LastName);
      Console.WriteLine("The students in alphabetical order by last name are: ");
      foreach (Student student in orderedStudents) {
          Console.WriteLine($"{student.FirstName} {student.LastName}");
      }
      Console.WriteLine("--------------------------------------------");

      IEnumerable<Student> studentsWithoutExercises = students.Where(student => student.AssignedExercises.Count() == 0);
      Console.WriteLine("The students with no exercises are: ");
      foreach (Student student in studentsWithoutExercises) {
          Console.WriteLine($"{student.FirstName} {student.LastName}");
      }
      Console.WriteLine("--------------------------------------------");

      var studentWithMaxExercises = (from student in students
        let count = student.AssignedExercises.Count()
        orderby count descending
        select student).First();

      Console.WriteLine($"The student working on the most exercises is: {studentWithMaxExercises.FirstName} {studentWithMaxExercises.LastName}.  He is working on {studentWithMaxExercises.AssignedExercises.Count()} exercises");
      Console.WriteLine("--------------------------------------------");

      var studentsByCohort = from cohort in cohorts
        select new {
          CohortName = cohort.CohortName,
          StudentsInCohort = students.Count(student => student.CohortId == cohort.CohortId)
        };

      foreach (var cohort in studentsByCohort) {
          Console.WriteLine($"{cohort.CohortName} has {cohort.StudentsInCohort} students.");
      }
    }
  }
}
