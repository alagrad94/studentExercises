using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises { 

    class Program {

        static void Main() {

            DatabaseInterface db = new DatabaseInterface();


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------");
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Display All Students.");
                Console.WriteLine("2. Display All Instructors.");
                Console.WriteLine("3. Display All Exercises.");
                Console.WriteLine("4. Display All Cohorts.");
                Console.WriteLine("5. Search Students By Last Name.");
                Console.WriteLine("6. Create a New Cohort.");
                Console.WriteLine("7. Add a Student and Assign Them to an Existing Cohort.");
                Console.WriteLine("8. Add an Instructor and Assign Them to an Existing Cohort.");
                Console.WriteLine("9. Display All Students in a Cohort.");
                Console.WriteLine("10. Move a Student to Another Cohort.");
                Console.WriteLine("11. List the Exercises for a Student.");
                Console.WriteLine("12. Assign an Exercise to a Student.");


                string option = Console.ReadLine();

                switch (Int32.Parse(option))
                {
                    case 1:
                        List<Student> allStudents = db.GetAllStudents();
                        PrintAllStudents(allStudents);
                        Pause();
                        break;

                    case 2:
                        List<Instructor> allInstructors = db.GetAllInstructors();
                        PrintAllInstructors(allInstructors);
                        Pause();
                        break;

                    case 3:
                        List<Exercise> allExercises = db.GetAllExercises();
                        PrintAllExercises(allExercises);
                        Pause();
                        break;

                    case 4:
                        List<Cohort> allCohorts = db.GetAllCohorts();
                        PrintAllCohorts(allCohorts);
                        Pause();
                        break;

                    case 5:
                        Console.WriteLine("Please enter the last name of a Student:");
                        string name = Console.ReadLine();
                        Student student = db.GetStudentByLastName(name);
                        PrintStudent(student);
                        break;

                    case 6:
                        Console.WriteLine("Please enter a name for the Cohort:");
                        string newCohortName = Console.ReadLine();
                        db.AddCohort(newCohortName);
                        Cohort newCohort = db.GetCohortByName(newCohortName);
                        Console.WriteLine($"{newCohort.CohortName} was created.");
                        break;

                    case 7:
                        Console.WriteLine("Please enter the Student's First Name:");
                        string stFirstName = Console.ReadLine();
                        Console.WriteLine("Please enter the Student's Last Name:");
                        string stLastName = Console.ReadLine();
                        Console.WriteLine("Please enter the Student's Slack Handle:");
                        string stSlack = Console.ReadLine();
                        Console.WriteLine("Please enter the Name of the Cohort the Student will be assigned to:");
                        string stCohort = Console.ReadLine();
                        db.AddStudent(stFirstName, stLastName, stSlack, stCohort);
                        Student newStudent = db.GetStudentByLastName(stLastName);
                        string cohortName = db.GetCohortById(newStudent.CohortId).CohortName;
                        Console.WriteLine($"{newStudent.FirstName} {newStudent.LastName} was created and placed in {cohortName}.");
                        break;

                    case 8:
                        Console.WriteLine("Please enter the Instructor's First Name:");
                        string instFirstName = Console.ReadLine();
                        Console.WriteLine("Please enter the Student's Last Name:");
                        string instLastName = Console.ReadLine();
                        Console.WriteLine("Please enter the Student's Slack Handle:");
                        string instSlack = Console.ReadLine();
                        Console.WriteLine("Please enter the Name of the Cohort the Student will be assigned to:");
                        string instCohort = Console.ReadLine();
                        int instCohortId = db.GetCohortByName(instCohort).CohortId;
                        Instructor newInst = new Instructor(instFirstName, instLastName, instSlack, instCohortId);
                        db.AddInstructor(newInst);
                        string instCohortName = db.GetCohortById(newInst.CohortId).CohortName;
                        Console.WriteLine($"{newInst.FirstName} {newInst.LastName} was created and placed in {instCohortName}.");
                        break;

                    case 9:
                        Console.WriteLine("Please enter a Cohort Name:");
                        string studentsCohort = Console.ReadLine();
                        List<Student> cohortStudents = db.GetCohortStudents(studentsCohort);
                        PrintAllStudents(cohortStudents, $"The Students in Cohort {studentsCohort} are:");
                        break;

                    case 10:
                        Console.WriteLine("Please enter the Student's Last Name:");
                        string studentToMoveLastName = Console.ReadLine();
                        Student studentToMove = db.GetStudentByLastName(studentToMoveLastName);
                        Console.WriteLine("Please enter the name of the Cohort you would like to move the student to:");
                        string studentsNewCohort = Console.ReadLine();
                        db.MoveStudent(studentToMove, studentsNewCohort);
                        Student updatedStudent = db.GetStudentByLastName(studentToMoveLastName);
                        string oldAssignedCohort = db.GetCohortById(studentToMove.CohortId).CohortName;
                        string newAssignedCohort = db.GetCohortById(updatedStudent.CohortId).CohortName;
                        Console.WriteLine($"{studentToMove.FirstName} {studentToMove.LastName} was moved from {oldAssignedCohort} to {newAssignedCohort}.");
                        break;

                    case 11:
                        Console.WriteLine("Please enter the Student's Last Name:");
                        string studentToSearch = Console.ReadLine();
                        Student studentToFindExercises = db.GetStudentByLastName(studentToSearch);
                        List<Exercise> studentsExercises = db.GetStudentExercises(studentToFindExercises.StudentId);
                        PrintAllExercises(studentsExercises, $"{studentToFindExercises.FirstName} {studentToFindExercises.LastName} is working on the following exercises:");
                        break;

                    case 12:
                        Console.WriteLine("Please enter the Student's Last Name:");
                        string studentToAssignLastName = Console.ReadLine();
                        Student studentToAssignExercise = db.GetStudentByLastName(studentToAssignLastName);
                        Console.WriteLine("Please enter the Exercise Name:");
                        string exerciseToAssignName = Console.ReadLine();
                        Exercise exerciseToAssign = db.GetExerciseByName(exerciseToAssignName);
                        db.AddAssignedExercise(studentToAssignExercise, exerciseToAssign);
                        Console.WriteLine($"{studentToAssignExercise.FirstName} {studentToAssignExercise.FirstName} has been assigned {exerciseToAssign.ExerciseName}");
                        break;

                    default:
                        Console.WriteLine("That's an Invalid Option");
                        break;
                }
            }

            //List<Exercise> javascriptExercises = db.GetExercisesByLanguage("JavaScript");
            //PrintExercises("JavaScript Exercises", javascriptExercises);

            //Pause();

            //List<Exercise> allExercises = db.GetAllExercises();
            //PrintExercises("All Exercises", allExercises);

            //Pause();

            //Exercise newExercise = new Exercise("New Exercise", "CSharp");
            //db.AddExercise(newExercise);
            //allExercises = db.GetAllExercises();
            //PrintExercises("All Exercises after adding New Exercise", allExercises);

            //Pause();

            //List<Instructor> instructors = db.GetInstructorsWithCohort();
            //PrintInstructorsWithCohort("All Instructors", instructors);

            //Pause();

            //Instructor newInstructor = new Instructor("Bob", "Smith", "BobSmith", 3);
            //db.AddInstructor(newInstructor);
            //instructors = db.GetInstructorsWithCohort();
            //PrintInstructorsWithCohort("All Instructors after adding Bob", instructors);

            //Pause();

            //Student student1 = db.GetStudentById(1);
            //AssignExerciseToStudent(1, 6);
            //List<Student> studentsWithCohortAndExercises = db.GetStudentsWithCohortAndExercises();
            //PrintStudentsWithCohortAndExercises("All Students With Cohort and Exercises", studentsWithCohortAndExercises);

            //Pause();

        }

        private static void PrintAllCohorts(List<Cohort> cohorts, string title = "") {
            if (title != "") { Console.WriteLine(title); };
            int index = 0;

            foreach (Cohort cohort in cohorts)
            {
                index++;

                Console.WriteLine($"{index}. {cohort.CohortName}");
            }
        }

        private static void PrintCohort(Cohort cohort, string title = "") {

            if (title != "") { Console.WriteLine(title); };


            Console.WriteLine($"{cohort.CohortName}");
        }

        private static void PrintAllStudents (List<Student> students, string title = "") {

            if (title != "") { Console.WriteLine(title); };
            int index = 0;

            foreach (Student student in students)
            {
                index++;

                Console.WriteLine($"{index}. {student.FirstName} {student.LastName}");
            }

        }

        private static void PrintStudent(Student student, string title = "") {

            if (title != "") { Console.WriteLine(title); };


            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        private static void PrintAllInstructors(List<Instructor> instructors, string title = "") {

            if (title != "") { Console.WriteLine(title); };
            int index = 0;

            foreach (Instructor instructor in instructors)
            {
                index++;

                Console.WriteLine($"{index}. {instructor.FirstName} {instructor.LastName}");
            }

        }

        private static void PrintStudentsWithCohortAndExercises(List<Student> students, string title = "") {

            if (title != "") { Console.WriteLine(title); };
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

        public static void PrintAllExercises(List<Exercise> exercises, string title = "") {

            if (title != "") { Console.WriteLine(title); };
            int index = 0;

            foreach (Exercise ex in exercises) {
                index++;
                Console.WriteLine($"{index}. {ex.ExerciseName} {ex.ExerciseLanguage}");
            }
        }

        public static void PrintInstructorsWithCohort (List<Instructor> instructors, string title = "") {

            if (title != "") { Console.WriteLine(title); };
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
