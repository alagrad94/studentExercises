-- Create Tables

--CREATE TABLE Cohort (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	CohortName VARCHAR(55) NOT NULL
--);

--CREATE TABLE Student (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(55) NOT NULL,
--	LastName VARCHAR(55) NOT NULL,
--	SlackHandle VARCHAR(55) NOT NULL,
--	CohortId INTEGER NOT NULL,
--	CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
--);

--CREATE TABLE Instructor (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(55) NOT NULL,
--	LastName VARCHAR(55) NOT NULL,
--	SlackHandle VARCHAR(55) NOT NULL,
--	CohortId INTEGER NOT NULL,
--	CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
--);

--CREATE TABLE Exercise (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	ExerciseName VARCHAR(55) NOT NULL,
--	ExerciseLanguage VARCHAR(55) NOT NULL
--);

--CREATE TABLE AssignedExercise (
--	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--	ExerciseId INTEGER NOT NULL,
--	StudentId INTEGER NOT NULL,
--	CONSTRAINT FK_AssignedExercise_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id),
--	CONSTRAINT FK_AssignedExercise_Student FOREIGN KEY(StudentId) REFERENCES Student(Id)
--);

-- Insert Data
--INSERT INTO Cohort (CohortName) VALUES ('Cohort 1');
--INSERT INTO Cohort (CohortName) VALUES ('Cohort 2');
--INSERT INTO Cohort (CohortName) VALUES ('Cohort 3');

INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Planets', 'CSharp');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Random Numbers', 'JavaScript');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Classes', 'CSharp');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Dictionaries', 'JavaScript');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Sets', 'CSharp');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Student Exercise', 'CSharp');

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Russell', 'Reiter', 'Russ', 1);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ( 'Ashwin', 'Prakash', 'Ashwin', 1);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Zac', 'Crawford', 'Zac Crawford', 2);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('JD', 'Wheeler', 'JDWheeler', 2);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Hunter', 'Metts', 'Hunter Metts', 3);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Joseph', 'Baugh', 'Joey Baugh', 3);

INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Andy', 'Collins', 'andyc', 1);
INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ( 'Madi', 'Peper', 'Madi', 2);
INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Leah', 'Hoefling', 'Leah', 3);

INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (1,1);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (1,2);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (2,1);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (2,2);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (3,1);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (3,2);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (4,1);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (4,2);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,1);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,2);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (1,3);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (1,4);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (2,3);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (2,4);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (3,3);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (3,4);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (4,3);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (4,4);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,3);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,4);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,5);
INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (5,6);