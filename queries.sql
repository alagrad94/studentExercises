-- Create Tables

CREATE TABLE Cohort (
	Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
	CohortName TEXT NOT NULL
);

CREATE TABLE Students (
	Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	SlackHandle TEXT NOT NULL,
	CohortId INTEGER NOT NULL,
	FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Instructors (
	Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	SlackHandle TEXT NOT NULL,
	CohortId INTEGER NOT NULL,
	FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Exercises (
	Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
	ExerciseName TEXT NOT NULL,
	ExerciseLanguage TEXT NOT NULL
);

CREATE TABLE AssignedExercises (
	Id INTEGER NOT NULL PRIMARY KEY Autoincrement,
	ExerciseId INTEGER NOT NULL,
	StudentId INTEGER NOT NULL,
	FOREIGN KEY(ExerciseId) REFERENCES Exercises(Id),
	FOREIGN KEY(StudentId) REFERENCES Students(Id)
);

-- Insert Data
INSERT INTO Cohort ("CohortName") VALUES ("Cohort 1");
INSERT INTO Cohort ("CohortName") VALUES ("Cohort 2");
INSERT INTO Cohort ("CohortName") VALUES ("Cohort 3");

INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Planets", "CSharp");
INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Random Numbers", "JavaScript");
INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Classes", "CSharp");
INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Dictionaries", "JavaScript");
INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Sets", "CSharp");
INSERT INTO Exercises ("ExerciseName", "ExerciseLanguage") VALUES ("Student Exercises", "CSharp");

INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Russell", "Reiter", "Russ", 1);
INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ( "Ashwin", "Prakash", "Ashwin", 1);
INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Zac", "Crawford", "Zac Crawford", 2);
INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("JD", "Wheeler", "JDWheeler", 2);
INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Hunter", "Metts", "Hunter Metts", 3);
INSERT INTO "Students" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Joseph", "Baugh", "Joey Baugh", 3);

INSERT INTO "Instructors" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Andy", "Collins", "andyc", 1);
INSERT INTO "Instructors" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ( "Madi", "Peper", "Madi", 2);
INSERT INTO "Instructors" ("FirstName", "LastName", "SlackHandle", "CohortId") VALUES ("Leah", "Hoefling", "Leah", 3);

INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (1,1);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (1,2);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (2,1);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (2,2);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (3,1);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (3,2);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (4,1);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (4,2);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,1);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,2);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (1,3);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (1,4);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (2,3);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (2,4);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (3,3);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (3,4);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (4,3);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (4,4);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,3);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,4);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,5);
INSERT INTO AssignedExercises ("ExerciseId", "StudentId") VALUES (5,6);