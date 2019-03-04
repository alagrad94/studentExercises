using System;
using System.Collections.Generic;

namespace studentExercises {

  public class Exercise {

    public Exercise (int exerciseId, string exerciseName, string exerciseLanguage) {
      ExerciseId = exerciseId;
      ExerciseName = exerciseName;
      ExerciseLanguage = exerciseLanguage;
    }

    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public string ExerciseLanguage { get; set; }

  }
}
