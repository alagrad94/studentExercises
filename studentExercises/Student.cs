using System;
using System.Collections.Generic;

namespace StudentExercises { 

    public class Student {

        public Student (int studentId, string firstName, string lastName, string slackHandle, int cohortId) {
           
           StudentId = studentId;
           FirstName = firstName;
           LastName = lastName;
           SlackHandle = slackHandle;
           CohortId = cohortId;
           AssignedExercises = new List<Exercise>();
        }

        public Student(string firstName, string lastName, string slackHandle, int cohortId) {
            
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            CohortId = cohortId;
            AssignedExercises = new List<Exercise>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
        public List<Exercise> AssignedExercises { get; set; }

    }
}
