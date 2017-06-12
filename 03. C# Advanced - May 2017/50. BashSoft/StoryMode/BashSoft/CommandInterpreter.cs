namespace BashSoft
{
    using System.Diagnostics;

    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolutely(input, data);
                    break;
                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    break;
                case "order":
                    break;
                case "decOrder":
                    break;
                case "download":
                    break;
                case "downloadAsync":
                    break;
                default:
                    DisplayInvalidCommandsMessage(input);
                    break;
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string username = data[2];
                StudentsRepository.GetStudentScoreFromCourse(courseName, username);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryChangePathAbsolutely(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                Tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExeptionMessage);
                }
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandsMessage(input);
            }
        }

        private static void DisplayInvalidCommandsMessage(string input)
        {
            OutputWriter.WriteMessageOnNewLine($"The command '{input}' is invalid");
        }
    }
}
