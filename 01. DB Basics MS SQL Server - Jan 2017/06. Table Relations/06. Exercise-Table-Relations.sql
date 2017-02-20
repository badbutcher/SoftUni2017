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
StudentID int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
Name nvarchar(50)
)

CREATE TABLE Exams(
ExamID int PRIMARY KEY IDENTITY(101, 1) NOT NULL,
Name varchar(50)
)

CREATE TABLE StudentsExams(
StudentID int NOT NULL FOREIGN KEY REFERENCES Students(StudentID), 
ExamID int NOT NULL FOREIGN KEY REFERENCES Exams(ExamID)
PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students
VALUES ('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams
VALUES ('SpringMVC'), ('Neo4j'), ('Oracle 11g')

INSERT INTO StudentsExams
VALUES(1, 101),(1, 102),(2, 101),(3, 103),(2, 102),(2, 103);

-- Problem 4. Self-Referencing 
CREATE TABLE Teachers(
TeacherID int PRIMARY KEY IDENTITY(101,1) NOT NULL,
Name nvarchar(50),
ManagerID int FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES ('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- Problem 5. Online Store Database
CREATE TABLE Cities(
CityID int PRIMARY KEY,
Name varchar(50)
)

CREATE TABLE Customers(
CustomerID int PRIMARY KEY,
Name varchar(50),
Birthday date,
CityID int FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID int PRIMARY KEY,
CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID int PRIMARY KEY,
Name varchar(50)
)

CREATE TABLE Items(
ItemID int PRIMARY KEY,
Name varchar(50),
ItemTypeID int FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID int FOREIGN KEY REFERENCES Orders(OrderId),
ItemID int FOREIGN KEY REFERENCES Items(ItemID)
PRIMARY KEY (OrderID, ItemID)
)

-- Problem 6. University Database
CREATE TABLE Majors(
MajorID int PRIMARY KEY,
Name varchar(50)
)

CREATE TABLE Subjects(
SubjectID int PRIMARY KEY,
SubjectName varchar(50)
)

CREATE TABLE Students(
StudentID int PRIMARY KEY,
StudentNumber int,
StudentName varchar(50),
MajorID int FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda(
StudentID int FOREIGN KEY REFERENCES Students(StudentID),
SubjectID int FOREIGN KEY REFERENCES Subjects(SubjectID)
PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments(
PaymentID int PRIMARY KEY,
PaymentDate date,
PaymentAmount decimal,
StudentID int FOREIGN KEY REFERENCES Students(StudentID)
)

-- Problem 7. SoftUni Design
-- DONE

-- Problem 8. Geography Design
-- DONE

-- Problem 9. *Peaks in Rila
SELECT MountainRange, PeakName, Elevation FROM
Mountains JOIN Peaks ON
Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

-- OR 

SELECT m.MountainRange, p.PeakName, p.Elevation 
  FROM Mountains AS  m
  JOIN Peaks As p ON p.MountainId = m.Id
  WHERE m.MountainRange = 'Rila' ORDER BY p.Elevation DESC
