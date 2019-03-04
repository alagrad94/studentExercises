using System;
using System.Collections.Generic;

namespace studentExercises {

  public class Instructor {

    public Instructor (int instructorId, string firstName, string lastName, string slackHandle, int cohortId) {
      InstructorId = instructorId;
      FirstName = firstName;
      LastName = lastName;
      SlackHandle = slackHandle;
      CohortId = cohortId;
    }

    public int InstructorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SlackHandle { get; set; }
    public int CohortId { get; set; }

    public void AssignExercises (Student student, Exercise exercise) {

      student.AssignedExercises.Add(exercise);

    }

  }

}
