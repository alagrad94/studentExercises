using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentExercises{

    public class DatabaseInterface {

        public SqlConnection Connection {

            get {
                // This is "address" of the database
                string _connectionString = "Server=10.37.129.4\\SQLEXPRESS;Database=StudentExercises;User Id = russ;Password = russ;";

                return new SqlConnection(_connectionString);
            }
        }

        /************************************************************************************
        * Cohorts
        ************************************************************************************/

        public List<Cohort> GetAllCohorts() {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = $@"SELECT id, CohortName FROM Cohort;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read()) {

                        Cohort cohort = new Cohort(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("CohortName")));

                        cohorts.Add(cohort);
                    }

                    reader.Close();

                    return cohorts;
                }
            }
        }

        public void AddCohort(string newCohortName) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"INSERT INTO Cohort (CohortName) 
                                              VALUES ('{newCohortName}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Cohort GetCohortByName(string cohortName) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $@"SELECT id, CohortName FROM Cohort WHERE CohortName = @name";
                    cmd.Parameters.Add(new SqlParameter("@name", cohortName));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Cohort foundCohort = null;

                    if (reader.Read()) {

                        foundCohort = new Cohort(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("CohortName")));
                    }

                    reader.Close();

                    return foundCohort;
                }
            }
        }

        public Cohort GetCohortById(int cohortId) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, CohortName FROM Cohort WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", cohortId));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Cohort cohort = null;

                    if (reader.Read()) {

                        cohort = new Cohort(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("CohortName")));
                    }

                    reader.Close();

                    return cohort;
                }
            }
        }

        public List<Student> GetCohortStudents(string cohortName) {

            int cohortId = GetCohortByName(cohortName).CohortId;

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, FirstName, LastName, SlackHandle, CohortId FROM Student WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", cohortId));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read()) {

                        Student student = new Student(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("CohortId")));

                        students.Add(student);
                    }

                    reader.Close();

                    return students;
                }
            }
        }
        /************************************************************************************
        * Exercises
        ************************************************************************************/

        public List<Exercise> GetExercisesByLanguage (string lang) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, ExerciseName, ExerciseLanguage FROM Exercise WHERE ExerciseLanguage = @lang";
                    cmd.Parameters.Add(new SqlParameter("@lang", lang));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read()) {

                        Exercise exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")), 
                            reader.GetString(reader.GetOrdinal("ExerciseName")), 
                            reader.GetString(reader.GetOrdinal("ExerciseLanguage")));

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public Exercise GetExerciseByName(string name) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, ExerciseName, ExerciseLanguage FROM Exercise WHERE ExerciseName = @name";
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;

                    if (reader.Read()) {

                        exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("ExerciseName")),
                            reader.GetString(reader.GetOrdinal("ExerciseLanguage")));
                    }

                    reader.Close();

                    return exercise;
                }
            }
        }

        public Exercise GetExerciseById(int exerciseId) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, ExerciseName, ExerciseLanguage FROM Exercise WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", exerciseId));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;

                    if (reader.Read()) {

                        exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("ExerciseName")),
                            reader.GetString(reader.GetOrdinal("ExerciseLanguage")));
                    }

                    reader.Close();

                    return exercise;
                }
            }
        }


        public List<Exercise> GetAllExercises() {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $"SELECT id, ExerciseName, ExerciseLanguage FROM Exercise";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read()) {

                        Exercise exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("ExerciseName")),
                            reader.GetString(reader.GetOrdinal("ExerciseLanguage")));

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public void AddExercise(Exercise exercise) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"INSERT INTO Exercise (ExerciseName, ExerciseLanguage) 
                                              VALUES ('{exercise.ExerciseName}', '{exercise.ExerciseLanguage}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /************************************************************************************
        * Instructors
        ************************************************************************************/

        public List<Instructor> GetAllInstructors() {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = $@"SELECT id, FirstName, LastName, SlackHandle, CohortId FROM Instructor;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read()) {

                        Instructor instructor = new Instructor(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("CohortId")));

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return instructors;
                }
            }
        }

        public void AddInstructor(Instructor instructor) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) 
                                              VALUES ('{instructor.FirstName}', 
                                                '{instructor.LastName}',
                                                '{instructor.SlackHandle}',
                                                '{instructor.CohortId}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Instructor> GetInstructorsWithCohort() {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $@"SELECT i.id AS instId, i.FirstName, i.LastName, i.SlackHandle, c.CohortName, c.id AS chrtId
                                           FROM Instructor i JOIN Cohort c ON i.CohortId = c.id";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();


                    while (reader.Read()) {

                        Instructor instructor = new Instructor(reader.GetInt32(reader.GetOrdinal("instId")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("chrtId"))) {
                            Cohort = new Cohort(
                                reader.GetInt32(reader.GetOrdinal("chrtId")),
                                reader.GetString(reader.GetOrdinal("CohortName")))};

                        instructors.Add(instructor);
                    }
                    reader.Close();

                    return instructors;
                }
            }
        }

        /************************************************************************************
        * Students
        ************************************************************************************/

       public List<Student> GetAllStudents() {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = $@"SELECT id, FirstName, LastName, SlackHandle, CohortId FROM Student;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read()) {

                        Student student = new Student(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("CohortId")));

                        students.Add(student);
                    }

                    reader.Close();

                    return students;
                }
            }
        }

        public void AddStudent (string firstName, string lastName, string slackHandle, string cohortName) {

            int stCohortId = GetCohortByName(cohortName).CohortId;

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) 
                                              VALUES ('{firstName}', '{lastName}', '{slackHandle}', '{stCohortId}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MoveStudent(Student student, string cohortName) {

            int studentId = student.StudentId;

            int newCohortId = GetCohortByName(cohortName).CohortId;

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"UPDATE Student SET CohortId = '{newCohortId}'
                                          WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", studentId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Student GetStudentById (int studentId) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $@"SELECT id, FirstName, LastName, SlackHandle, CohortId FROM Student WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", studentId));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student student = null;

                    if (reader.Read()) {

                        student = new Student(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("CohortId")));
                    }

                    reader.Close();

                    return student;
                }
            }
        }

        public Student GetStudentByLastName(string name) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $@"SELECT id, FirstName, LastName, SlackHandle, CohortId FROM Student WHERE lastName = @name";
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student student = null;

                    if (reader.Read()) {

                        student = new Student(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("CohortId")));
                    }

                    reader.Close();

                    return student;
                }
            }
        }

        public List<Exercise> GetStudentExercises(int studentId) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = cmd.CommandText = $@"SELECT e.id, e.ExerciseName, e.ExerciseLanguage
                                           FROM AssignedExercise ae JOIN Exercise e ON ae.ExerciseId = e.id
                                           WHERE ae.StudentId = {studentId}";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read()) {

                        Exercise exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("ExerciseName")),
                            reader.GetString(reader.GetOrdinal("ExerciseLanguage")));

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public void AddAssignedExercise(Student student, Exercise exercise) {

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = $@"INSERT INTO AssignedExercise (ExerciseId, StudentId) 
                                              VALUES ('{exercise.ExerciseId}', '{student.StudentId}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetStudentsWithCohortAndExercises() {

            List<Student> students = new List<Student>();

            using (SqlConnection conn = Connection) {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {

                    // String interpolation lets us inject the id passed into this method.
                    cmd.CommandText = $@"SELECT s.id AS stdtId, s.FirstName, s.LastName, s.SlackHandle, c.CohortName, c.id AS chrtId
                                           FROM Student s JOIN Cohort c ON s.CohortId = c.id";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read()) {

                        Student student = new Student(reader.GetInt32(reader.GetOrdinal("stdtId")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            reader.GetInt32(reader.GetOrdinal("chrtId"))) {
                            Cohort = new Cohort(
                                reader.GetInt32(reader.GetOrdinal("chrtId")),
                                reader.GetString(reader.GetOrdinal("CohortName")))};

                        students.Add(student);
                    }

                    reader.Close();
                }
            }

            using (SqlConnection conn2 = Connection) {

                conn2.Open();

                using (SqlCommand cmd = conn2.CreateCommand()) {

                    foreach (Student student in students) {

                        cmd.CommandText = $@"SELECT e.id, e.ExerciseName, e.ExerciseLanguage
                                           FROM AssignedExercise ae JOIN Exercise e ON ae.ExerciseId = e.id
                                           WHERE ae.StudentId = {student.StudentId}";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read()) {

                            Exercise exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("ExerciseName")),
                                reader.GetString(reader.GetOrdinal("ExerciseLanguage")));

                            student.AssignedExercises.Add(exercise);
                        }

                        reader.Close();
                    }

                    return students;
                }
            }
        }
    }
}