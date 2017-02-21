namespace _001
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection
                (
                    @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                );

            connection.Open();
            using (connection)
            {
                string query = @"CREATE TABLE Towns
(
TownID INT PRIMARY KEY,
TownName VARCHAR(50),
CountryName VARCHAR(50)
)

CREATE TABLE Minions
(
MinionId INT PRIMARY KEY,
Name VARCHAR(50),
Age INT,
TownID INT FOREIGN KEY (TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Villains
(
VillainId INT PRIMARY KEY,
Name VARCHAR(100),
EvilnessFactor VARCHAR(10) CHECK (Evilnessfactor = 'good' OR Evilnessfactor = 'bad' OR Evilnessfactor = 'evil' OR Evilnessfactor = 'super evil')
)

CREATE TABLE VilliansMinions
(
VillianId INT FOREIGN KEY REFERENCES Villains(VillainId),
MinionId INT FOREIGN KEY REFERENCES Minions(MinionId)
PRIMARY KEY (VillianId, MinionId)
)

INSERT INTO Towns(TownID, TownName, CountryName)
VALUES 
(1, 'Sofia', 'Bulgaria'),
(2, 'Plovdiv', 'Bulgaria'),
(3, 'Berlin', 'Germany'),
(4, 'Paris', 'France'),
(5, 'Liverpool', 'England'),
(6, 'London', 'England'),
(7, 'Rome', 'Italy'),
(8, 'Faeto', 'Italy'),
(9, 'Imbersago', 'Italy'),
(10, 'Nazzano', 'Italy')

INSERT INTO Minions (MinionId, Name, Age, TownID)
VALUES 
(1, 'Kev', 11, 1),
(2, 'Bobb', 12, 2),
(3, 'Stew', 5, 3),
(4, 'Malk', 3, 4),
(5, 'Tosh', 1, 5),
(6, 'Dean', 11, 6),
(7, 'Wanda', 32, 7),
(8, 'Lonnie', 15, 8),
(9, 'Arturo', 6, 9),
(10, 'Herbert', 77, 10),
(11, 'Carolyn', 31, 3),
(12, 'Delbert', 22, 6),
(13, 'Roger', 45, 8),
(14, 'Jody', 3, 3),
(15, 'Nancy', 3, 9)

INSERT INTO Villains (VillainId, Name, EvilnessFactor)
VALUES
(1, 'Gosho', 'bad'),
(2, 'Tosho', 'good'),
(3, 'Misho', 'evil'),
(4, 'Gogo', 'super evil'),
(5, 'Tiho', 'bad'),
(6, 'Mike', 'bad'),
(7, 'Martha', 'good'),
(8, 'Muriel', 'evil'),
(9, 'Antonia', 'super evil'),
(10,'Denise', 'bad')

INSERT INTO VilliansMinions(VillianId, MinionId)
VALUES 
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(10,10),
(1,11),
(2,12),
(3,13),
(4,14),
(5,15)";

                SqlCommand command = new SqlCommand(query, connection);

                int changes = (int)command.ExecuteNonQuery();
                Console.WriteLine(changes);
            }
        }
    }
}