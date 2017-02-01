CREATE DATABASE ExercisesTableRelations
USE ExercisesTableRelations

-- Problem 1. One-To-One Relationship
CREATE TABLE Persons(
PersonID int NOT NULL,
FirstName nvarchar(50) NOT NULL,
Salary float,
PassportID int
)

CREATE TABLE Passports(
PassportID int NOT NULL,
PassportNumber nvarchar(20) NOT NULL
)

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

-- OR

CREATE TABLE Passports(
PassportID int PRIMARY KEY NOT NULL,
PassportNumber nvarchar(20) NOT NULL
)

CREATE TABLE Persons(
PersonID int PRIMARY KEY NOT NULL,
FirstName nvarchar(50) NOT NULL,
Salary float,
PassportID int FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

-- Problem 2. One-To-Many Relationship
CREATE TABLE Manufacturers(
ManufacturerID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
Name nvarchar(50),
EstablishedOn date
)

CREATE TABLE Models(
ModelID int PRIMARY KEY IDENTITY(100,1) NOT NULL,
Name nvarchar(50),
ManufacturerID int FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models
VALUES ('X1', 1), 
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

INSERT INTO Manufacturers
VALUES ('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

-- Problem 3. Many-To-Many Relationship
CREATE TABLE Students(
StudentID int,
Name nvarchar(50)
)

CREATE TABLE Exams(
ExamID int,
Name varchar(50)
)

CREATE TABLE [Students Exams](
StudentID int,
ExamID int
)

-- Problem 4. Self-Referencing 
CREATE TABLE Teachers(
TeacherID int,
Name nvarchar(50),
ManagerID int
)

-- Problem 5. Online Store Database
CREATE TABLE Orders(
OrderID int,
CustomerId int
)

-- Problem 6. University Database

-- Problem 7. SoftUni Design

-- Problem 8. Geography Design

-- Problem 9. *Peaks in Rila