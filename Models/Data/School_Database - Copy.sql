
Create Database School;
Use School;
  CREATE TABLE StudentResults
 ( 
  StudentNumber varchar(50) NOT NULL,
  Firstname varchar(50) NOT NULL,
  Surname varchar(50) NOT NULL,
  CourseCode    varchar(50) NOT NULL,
  CourseDescription    varchar(50) NOT NULL,
  Grade    varchar(5) NOT NULL,
  PRIMARY KEY (StudentNumber) ,
 );


 Create Database CollegeDB;
CREATE TABLE Students
( 
 StudentId varchar(50) NOT NULL,
 Firstname varchar(50) NOT NULL,
 Surname varchar(50) NOT NULL,
 PRIMARY KEY (StudentId)
);

create table Grades
(
StudentId varchar(50) NOT NULL ,
CourseId varchar(50) NOT NULL ,
Grade varchar(5) NOT NULL ,
 PRIMARY KEY (StudentId,CourseId)
);

create table Courses
(
CourseId varchar(50) NOT NULL ,
CourseName varchar(50) NOT NULL ,
 PRIMARY KEY (CourseId)
);



create table Grades1
(
GradeId varchar(50) NOT NULL ,
StudentId varchar(50) NOT NULL ,
CourseId varchar(50) NOT NULL ,
Grade varchar(5) NOT NULL ,
 PRIMARY KEY (GradeId)
);

create table Courses1
(
CourseId varchar(50) NOT NULL ,
CourseCode varchar(50) NOT NULL ,
CourseDescription varchar(50) NOT NULL ,
 PRIMARY KEY (CourseId)
);


CREATE TABLE Students1
( 
 StudentId varchar(50) NOT NULL,
 Firstname varchar(50) NOT NULL,
 Surname varchar(50) NOT NULL,
 PRIMARY KEY (StudentId) ,
  UNIQUE (StudentNumber)
);


INSERT INTO Students(StudentId,Firstname,Surname)
values('96041','Faheem','Takbot')
INSERT INTO Courses(CourseId,CourseName)
values('CS101','Computer Science 1')
INSERT INTO Grades(CourseId,StudentId,Grade)
values('CS101','96041','A')

INSERT INTO Students(StudentId,Firstname,Surname)
values('96041','Faheem','Takbot')
INSERT INTO Courses(CourseId,CourseName)
values('IS101','Information System 1')
INSERT INTO Grades(CourseId,StudentId,Grade)
values('IS101','96041','A')


INSERT INTO Students(StudentId,Firstname,Surname)
values('97041','Elleanor','Lozano')
INSERT INTO Courses(CourseId,CourseName)
values('CS101','Computer Science 1')
INSERT INTO Grades(CourseId,StudentId,Grade)
values('CS101','97041','C')

INSERT INTO Students(StudentId,Firstname,Surname)
values('97041','Elleanor','Lozano')
INSERT INTO Courses(CourseId,CourseName)
values('IS101','Information System 1')
INSERT INTO Grades(CourseId,StudentId,Grade)
values('IS101','97041','A')





INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('96041','Faheem','Takbot','CS101','Computer Science 1','A')
INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('96041','Faheem','Takbot','IS101','Information System 1','A')

INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('97041','Elleanor','Lozano','CS101','Computer Science 1','C')
INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('97041','Elleanor','Lozano','IS101','Information System 1','A')

INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('98041','Ameer','Rees','CS201','Computer Science 2','D')
INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('98041','Ameer','Rees','BS102','Business Science 1','B')

INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('99041','Paula','Pike','CS201','Computer Science 2','E')
INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('99041','Paula','Pike','BS102','Business Science 1','B')

INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('20041','Ritchie','Terrel','BS102','Business Science 1','A')
INSERT INTO StudentResults(StudentNumber,Firstname,Surname,CourseCode,CourseDescription,Grade)
values('20041','Ritchie','Terrel','CS101','Computer Science 1','D')



CREATE TABLE Student
( 
StudentId varchar(50) NOT NULL,
 StudentNumber varchar(50) NOT NULL,
 Firstname varchar(50) NOT NULL,
 Surname varchar(50) NOT NULL,
 PRIMARY KEY (StudentId) ,
  UNIQUE (StudentNumber)
);