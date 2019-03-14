using System;
using System.Collections.Generic;

namespace StudentExercises { 

  public class Exercise {

    public Exercise (int exerciseId, string exerciseName, string exerciseLanguage) {

        ExerciseId = exerciseId;
        ExerciseName = exerciseName;
        ExerciseLanguage = exerciseLanguage;
    }

    public Exercise(string exerciseName, string exerciseLanguage) {
        
        ExerciseName = exerciseName;
        ExerciseLanguage = exerciseLanguage;
    }

    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public string ExerciseLanguage { get; set; }

  }
}
