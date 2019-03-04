using System;
using System.Collections.Generic;

namespace studentExercises {

  public class Cohort {

    public Cohort (int cohortId, string cohortName) {
      CohortName = cohortName;
      CohortId = cohortId;
      StudentList = new List<Student>();
      InstructorList = new List<Instructor>();
    }

    public int CohortId { get; set; }
    public string CohortName { get; set; }
    public List<Student> StudentList { get; set; }
    public List<Instructor> InstructorList { get; set; }

  }
}
