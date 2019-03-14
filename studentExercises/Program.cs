using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises { 

    class Program {

        static void Main() {

            DatabaseInterface db = new DatabaseInterface();

            List<Exercise> javascriptExercises = db.GetExercisesByLanguage("JavaScript");
            PrintExercises("JavaScript Exercises", javascriptExercises);

            Pause();

            List<Exercise> allExercises = db.GetAllExercises();
            PrintExercises("All Exercises", allExercises);

            Pause();

            Exercise newExercise = new Exercise("New Exercise", "CSharp");
            db.AddExercise(newExercise);
            allExercises = db.GetAllExercises();
            PrintExercises("All Exercises after adding New Exercise", allExercises);

            Pause();

            List<Instructor> instructors = db.GetInstructorsWithCohort();
            PrintInstructorsWithCohort("All Instructors", instructors);

            Pause();

            Instructor newInstructor = new Instructor("Bob", "Smith", "BobSmith", 3);
            db.AddInstructor(newInstructor);
            instructors = db.GetInstructorsWithCohort();
            PrintInstructorsWithCohort("All Instructors after adding Bob", instructors);

            Pause();

            Student student1 = db.GetStudentById(1);
            AssignExerciseToStudent(1, 6);
            List<Student> studentsWithCohortAndExercises = db.GetStudentsWithCohortAndExercises();
            PrintStudentsWithCohortAndExercises("All Students With Cohort and Exercises", studentsWithCohortAndExercises);

            Pause();

        }

        private static void PrintStudentsWithCohortAndExercises(string title, List<Student> students) {

            Console.WriteLine(title);
            int index = 0;

            foreach (Student student in students) {
                int index2 = 0;
                index++;

                Console.WriteLine($"{index}. {student.FirstName} {student.LastName}.  Cohort: {student.Cohort.CohortName}. \n Exercises:");
                foreach (Exercise exercise in student.AssignedExercises) {
                   
                   index2++;
                   Console.WriteLine($"     {index2}. {exercise.ExerciseName} {exercise.ExerciseLanguage}");
                }
            }
        }

        public static void PrintExercises(string title, List<Exercise> exercises) {

            Console.WriteLine(title);
            int index = 0;

            foreach (Exercise ex in exercises) {
                index++;
                Console.WriteLine($"{index}. {ex.ExerciseName} {ex.ExerciseLanguage}");
            }
        }

        public static void PrintInstructorsWithCohort (string title, List<Instructor> instructors) {

            Console.WriteLine(title);
            int index = 0;

            foreach (Instructor inst in instructors) {
                index++;
                Console.WriteLine($"{index}. {inst.FirstName} {inst.LastName}.  Cohort: {inst.Cohort.CohortName}.");
            }
        }

        public static void AssignExerciseToStudent(int studentId, int exerciseId) {

            DatabaseInterface db = new DatabaseInterface();
            Student student = db.GetStudentById(studentId);
            Exercise exercise = db.GetExerciseById(exerciseId);

            db.AddAssignedExercise(student, exercise);
        }

        public static void Pause() {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
