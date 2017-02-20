-- Problem 1. Create Database
CREATE DATABASE Minions

-- Problem 2. Create Tables
CREATE TABLE Minions(
Id int PRIMARY KEY,
Name nvarchar(50),
Age tinyint
)

CREATE TABLE Towns(
Id int PRIMARY KEY,
Name nvarchar(50)
)

-- Problem 3. Alter Minions Table
ALTER TABLE Minions
ADD TownId int

ALTER TABLE Minions
ADD FOREIGN KEY (TownId)
REFERENCES Towns (Id)

-- Problem 4. Insert Records in Both Tables
INSERT INTO Towns (Id, Name)
VALUES ('1', 'Sofia'),
('2', 'Plovdiv'),
('3', 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES ('1', 'Kevin', '22', '1'),
('2', 'Bob', '15', '3'),
('3', 'Steward', NULL, '2')

-- Problem 5. Truncate Table Minions
DELETE Minions

-- Problem 6. Drop All Tables
DROP TABLE Minions, Towns

-- Problem 7. Create Table People
CREATE TABLE People (
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200) NOT NULL,
Picture varbinary(MAX) CHECK (DATALENGTH(Picture) <= 2097152),
Height float,
Weight float,
Gender char CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
Birthday date NOT NULL,
Biography nvarchar(MAX) NOT NULL
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Pavel', 123456789, '1.79', '81', 'm', '1996.08.30','Dulga eeeeeeeeeeeeeeeee'),
('Pavel', 123456789, '1.79', '81', 'm', '1996.08.30','Dulga eeeeeeeeeeeeeeeee'),
('Pavel', 123456789, '1.79', '81', 'm', '1996.08.30','Dulga eeeeeeeeeeeeeeeee'),
('Pavel', 123456789, '1.79', '81', 'm', '1996.08.30','Dulga eeeeeeeeeeeeeeeee'),
('Pavel', 123456789, '1.79', '81', 'm', '1996.08.30','Dulga eeeeeeeeeeeeeeeee')

-- Problem 8. Create Table Users
CREATE TABLE Users (
Id bigint IDENTITY(1, 1) PRIMARY KEY,
Username varchar(30) NOT NULL,
Password varchar(26) NOT NULL,
ProfilePicture varbinary(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime date,
IsDeleted bit
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES ('badbutcher', '123456789', 1234567, '1000.10.10','0'),
('badbutcher', '123456789', 1234567, '1000.10.10','0'),
('badbutcher', '123456789', 1234567, '1000.10.10','0'),
('badbutcher', '123456789', 1234567, '1000.10.10','0'),
('badbutcher', '123456789', 1234567, '1000.10.10','0')

-- Problem 9. Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07EA93BCDF

ALTER TABLE Users
ADD PRIMARY KEY(Id, Username)

-- Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_CheckPass CHECK(LEN(Password) >= 5)

-- Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime 
DEFAULT GETDATE() FOR LastLoginTime

-- Problem 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK__Users__77222459BB5DB1F7

ALTER TABLE Users
ADD PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_UsernameLenght CHECK(LEN(Username) >= 3)

-- Problem 13. Movies Database
CREATE TABLE Directors(
Id int PRIMARY KEY IDENTITY(1, 1),
DirectorName nvarchar(50) NOT NULL,
Notes nvarchar(MAX)
)

CREATE TABLE Genres(
Id int PRIMARY KEY IDENTITY(1, 1),
GenreName nvarchar(50) NOT NULL,
Notes nvarchar(MAX)
)

CREATE TABLE Categories(
Id int PRIMARY KEY IDENTITY(1, 1),
CategoryName nvarchar(50) NOT NULL,
Notes nvarchar(MAX)
)

CREATE TABLE Movies(
Id int PRIMARY KEY IDENTITY(1, 1),
Title nvarchar(50) NOT NULL,
DirectorId int NOT NULL,
CopyrightYear time NOT NULL,
Length int NOT NULL, 
GenreId int NOT NULL, 
CategoryId int NOT NULL, 
Rating int NOT NULL, 
Notes nvarchar(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES ('asd','aa'), 
('asd','asdsadasdasdasd'), 
('asd','aa'), 
('asd','sadasdasdasd'), 
('asd','aa')

INSERT INTO Genres(GenreName, Notes)
VALUES ('asd','aa'), 
('asd','asdsadasdasdasd'), 
('asd','aa'), 
('asd','sadasdasdasd'), 
('asd','aa')

INSERT INTO Categories(CategoryName, Notes)
VALUES ('asd','aa'), 
('asd','asdsadasdasdasd'), 
('asd','aa'), 
('asd','sadasdasdasd'), 
('asd','aa')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES ('asd','1','1999-01-12','120','1','1','10','aaa'), 
('asd','1','1999-01-12','120','1','1','10','aa'), 
('asd','1','1999-01-12','120','1','1','10','aa'), 
('asd','1','1999-01-12','120','1','1','10','aa'), 
('asd','1','1999-01-12','120','1','1','10','aa')

-- Problem 14. Car Rental Database
CREATE TABLE Categories(
Id int PRIMARY KEY IDENTITY(1, 1),
Category nvarchar(50),
DailyRate decimal,
WeeklyRate decimal,
MonthlyRate decimal NOT NULL,
WeekendRate decimal
)

CREATE TABLE Cars(
Id int PRIMARY KEY IDENTITY(1, 1), 
PlateNumber nvarchar(20) NOT NULL, 
Make nvarchar(50) NOT NULL, 
Model nvarchar(50) NOT NULL, 
CarYear time NOT NULL, 
CategoryId int, 
Doors tinyint, 
Picture bit, 
Condition bit, 
Available bit
)

CREATE TABLE Employees(
Id int PRIMARY KEY IDENTITY(1, 1), 
FirstName nvarchar(50) NOT NULL, 
LastName nvarchar(50) NOT NULL, 
Title nvarchar(50), 
Notes text
)

CREATE TABLE Customers(
Id int PRIMARY KEY IDENTITY(1, 1), 
DriverLicenceNumber int NOT NULL, 
FullName nvarchar(50) NOT NULL,
Address nvarchar(50) NOT NULL, 
City nvarchar(50) NOT NULL, 
ZIPCode tinyint, 
Notes text
)

CREATE TABLE RentalOrders(
Id int PRIMARY KEY IDENTITY(1, 1), 
EmployeeId int NOT NULL, 
CustomerId int NOT NULL, 
CarId int NOT NULL, 
CarCondition bit NOT NULL, 
TankLevel int, 
KilometrageStart int,
KilometrageEnd int, 
TotalKilometrage int NOT NULL, 
StartDate date, 
EndDate date, 
TotalDays date NOT NULL, 
RateApplied int, 
TaxRate int, 
OrderStatus int,
Notes text
)

INSERT INTO Categories(Category, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('asd', NULL, NULL, '123.24', '21.42'), 
('asd', NULL, NULL, '123.24', '21.42'),
('asd', NULL, NULL, '123.24', '21.42')

INSERT INTO Cars (PlateNumber, Make, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES ('ab12345cd','dsad','c4','2017.12.12','1','4','1','0','1'),
('ab12345cd','dsad','c4','2017.12.12','1','4','1','0','1'),
('ab12345cd','dsad','c4','2017.12.12','1','4','1','0','1')

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES ('az','ti','god','nqmam'),
('az','ti','god','nqmam'),
('az','ti','god','nqmam')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES ('1234','das bad','4eren petuk','earth','111','tova e dulgo'),
('1234','das bad','4eren petuk','earth','111','tova e dulgo'),
('1234','das bad','4eren petuk','earth','111','tova e dulgo')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, CarCondition, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus,Notes)
VALUES ('1','1','1','1','1','1','1','1','1234.12.12','1234.12.12','1234.12.12','1','1','1','nai nakraq'),
('1','1','1','1','1','1','1','1','1234.12.12','1234.12.12','1234.12.12','1','1','1','nai nakraq'),
('1','1','1','1','1','1','1','1','1234.12.12','1234.12.12','1234.12.12','1','1','1','nai nakraq')

-- Problem 15. Hotel Database
CREATE TABLE Employees(
Id int PRIMARY KEY IDENTITY(1, 1), 
FirstName nvarchar(50) NOT NULL, 
LastName nvarchar(50), 
Title nvarchar(50), 
Notes nvarchar(max)
)

CREATE TABLE Customers(
AccountNumber int PRIMARY KEY IDENTITY(1, 1),
FirstName nvarchar(50) NOT NULL, 
LastName nvarchar(50), 
PhoneNumber int NOT NULL, 
EmergencyName nvarchar(50) NOT NULL, 
EmergencyNumber int NOT NULL,
Notes nvarchar(max)
)

CREATE TABLE RoomStatus(
RoomStatus nvarchar(50) NOT NULL, 
Notes nvarchar(max)
)

CREATE TABLE RoomTypes(
RoomType nvarchar(50) NOT NULL, 
Notes nvarchar(max)
)

CREATE TABLE BedTypes(
BedType nvarchar(50) NOT NULL, 
Notes nvarchar(max)
)

CREATE TABLE Rooms(
RoomNumber int PRIMARY KEY IDENTITY(1, 1), 
RoomType nvarchar(50) NOT NULL, 
BedType nvarchar(50) NOT NULL, 
Rate int, 
RoomStatus nvarchar(50), 
Notes nvarchar(max)
)

CREATE TABLE Payments(
Id int PRIMARY KEY IDENTITY(1, 1), 
EmployeeId int NOT NULL, 
PaymentDate date NOT NULL,
AccountNumber int NOT NULL, 
FirstDateOccupied date, 
LastDateOccupied date,
TotalDays int NOT NULL, 
AmountCharged int, 
TaxRate int, 
TaxAmount int, 
PaymentTotal int NOT NULL, 
Notes nvarchar(max)
)

CREATE TABLE Occupancies(
Id int PRIMARY KEY IDENTITY(1, 1), 
EmployeeId int NOT NULL, 
DateOccupied date NOT NULL, 
AccountNumber int NOT NULL, 
RoomNumber int NOT NULL, 
RateApplied int, 
PhoneCharge nvarchar(50),
Notes nvarchar(max)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES ('1','1','1','1'),
('1','1','1','1'),
('1','1','1','1')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('1','1','1','1','1','1'),
('1','1','1','1','1','1'),
('1','1','1','1','1','1')

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES ('1','1'),
('1','1'),
('1','1')

INSERT INTO RoomTypes (RoomType, Notes)
VALUES ('1','1'),
('1','1'),
('1','1')

INSERT INTO BedTypes (BedType, Notes)
VALUES ('1','1'),
('1','1'),
('1','1')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES ('1','1','1','1','1'),
('1','1','1','1','1'),
('1','1','1','1','1')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES ('1','1111.11.11','1','1111.11.11','1111.11.11','1','1','1','1','1','1'),
('1','1111.11.11','1','1111.11.11','1111.11.11','1','1','1','1','1','1'),
('1','1111.11.11','1','1111.11.11','1111.11.11','1','1','1','1','1','1')

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge,Notes)
VALUES ('1','1111.11.11','1','1','1','1','1'),
('1','1111.11.11','1','1','1','1','1'),
('1','1111.11.11','1','1','1','1','1')

-- Problem 16. Create SoftUni Database
CREATE DATABASE SoftUni

CREATE TABLE Towns(
Id int PRIMARY KEY IDENTITY(1, 1), 
Name nvarchar(50) NOT NULL
)

CREATE TABLE Addresses(
Id int PRIMARY KEY IDENTITY(1, 1), 
AddressText nvarchar(50) NOT NULL, 
TownId int FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id int PRIMARY KEY IDENTITY(1, 1), 
Name nvarchar(50) NOT NULL
)

CREATE TABLE Employees(
Id int PRIMARY KEY IDENTITY(1, 1), 
FirstName nvarchar(30) NOT NULL, 
MiddleName nvarchar(30), 
LastName nvarchar(30) NOT NULL, 
JobTitle nvarchar(50) NOT NULL, 
DepartmentId int FOREIGN KEY REFERENCES Departments(Id), 
HireDate date, 
Salary decimal NOT NULL, 
AddressId int FOREIGN KEY REFERENCES Addresses(Id)
)

-- Problem 17. Backup Database
-- Done

-- Problem 18. Basic Insert
INSERT INTO Towns(Name)
VALUES ('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments(Name)
VALUES('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, Department, HireDate, Salary)
VALUES ('Ivan','Ivanov','Ivanov','.NET Developer','Soft Developer','2013-02-01','3500.00'),
('Petar','Petrov','Petrov','Senior Engineer','Engineering','2004-02-21','4000.00'),
('Maria','Petrova','Ivanova','Intern','Quality Assurance','2016-08-28','525.25'),
('Georgi','Teziev','Ivanov','CEO','Sales','2007-12-09','3000.00'),
('Peter','Pan','Pan','Intern','Marketing','2016-08-28','599.88')

-- Problem 19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- Problem 20. Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY Name
SELECT * FROM Departments ORDER BY Name
SELECT * FROM Employees ORDER BY Salary DESC

-- Problem 21. Basic Select Some Fields !!!!!!!
SELECT Name FROM Towns ORDER BY Name
SELECT Name FROM Departments ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

-- Problem 22. Increase Employees Salary
UPDATE Employees
SET Salary +=(Salary*10)/100
SELECT Salary FROM Employees 

-- Problem 23. Decrease Tax Rate
UPDATE Payments
SET TaxRate -=(TaxRate*3)/100
SELECT TaxRate FROM Payments

-- Problem 24. Delete All Records
DELETE Occupancies
