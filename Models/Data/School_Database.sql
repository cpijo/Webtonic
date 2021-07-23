Create Database School;
use School;
   CREATE TABLE StudentResults
 ( 
  StudentId varchar(50) NOT NULL,
  Firstname varchar(50) NOT NULL,
  Surname varchar(50) NOT NULL,
  CourseId    varchar(50) NOT NULL,
  CourseName    varchar(50) NOT NULL,
  Grade    varchar(5) NOT NULL
 );

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


 INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('96041','Faheem','Takbot','CS101','Computer Science 1','A') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('97041','Elleanor','Lozano','CS101','Computer Science 1','C') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('98041','Ameer ','Rees','CS201','Computer Science 2','D') ;
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('99041','Paula ','Pike','CS201','Computer Science 2','E') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('20041','Ritchie','Terrel','BS102','Business Science 1','A') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('96041','Faheem','Takbot','IS101','Information Systems 1','A') ;
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('97041','Elleanor','Lozano','IS101','Information Systems 1','A') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('98041','Ameer ','Rees','BS102','Business Science 1','B') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('99041','Paula ','Pike','BS102','Business Science 1','B') ; 
INSERT INTO StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values('20041','Ritchie','Terrel','CS101','Computer Science 1','D') ;


INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values('96041','Faheem','Takbot');
INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values('97041','Elleanor','Lozano');
INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values('98041','Ameer ','Rees');
INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values('99041','Paula ','Pike');
INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values('20041','Ritchie','Terrel');


INSERT INTO School.dbo.Courses(CourseId,CourseName) values('CS101','Computer Science 1');
INSERT INTO School.dbo.Courses(CourseId,CourseName) values('CS201','Computer Science 2');
INSERT INTO School.dbo.Courses(CourseId,CourseName) values('BS102','Business Science 1');
INSERT INTO School.dbo.Courses(CourseId,CourseName) values('IS101','Information Systems 1');


INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('96041','CS101','A');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('97041','CS101','C');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('98041','CS201','D');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('99041','CS201','E');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('20041','BS102','A');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('96041','IS101','A');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('97041','IS101','A');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('98041','BS102','B');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('99041','BS102','B');
INSERT INTO School.dbo.Grades(StudentId,CourseId,Grade) values('20041','CS101','D');



