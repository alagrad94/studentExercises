using System;
using System.Collections.Generic;

namespace StudentExercises { 

    public class Cohort {

        public Cohort (int cohortId, string cohortName) {

            CohortId = cohortId;
            CohortName = cohortName;
            StudentList = new List<Student>();
            InstructorList = new List<Instructor>();
        }

        public Cohort(string cohortName) {

            CohortName = cohortName;
            StudentList = new List<Student>();
            InstructorList = new List<Instructor>();
        }

        public int CohortId { get; set; }
        public string CohortName { get; set; }
        public List<Student> StudentList { get; set; }
        public List<Instructor> InstructorList { get; set; }
    }
}
