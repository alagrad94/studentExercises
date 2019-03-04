using System;
using System.Collections.Generic;

namespace studentExercises {

  public class Student {

    public Student (int studentId, string firstName, string lastName, string slackHandle, int cohortId) {
      StudentId = studentId;
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
    public List<Exercise> AssignedExercises { get; set; }

  }

}
