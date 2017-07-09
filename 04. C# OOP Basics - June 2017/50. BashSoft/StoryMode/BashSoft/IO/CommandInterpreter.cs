namespace BashSoft
{
    using System.Diagnostics;

    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split();
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
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "decOrder":
                    break;
                case "download":
                    break;
                case "downloadAsynch":
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (!IsDataValid(data, 5))
            {
                return;
            }

            var courseName = data[1];
            var comparison = data[2].ToLower();
            var takeCommand = data[3].ToLower();
            var takeQuantity = data[4].ToLower();

            TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison, null);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
                    }
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (!IsDataValid(data, 5))
            {
                return;
            }

            var courseName = data[1];
            var filter = data[2].ToLower();
            var takeCommand = data[3].ToLower();
            var takeQuantity = data[4].ToLower();

            TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter, null);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
                    }
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                var course = data[1];
                StudentsRepository.GetAllStudentsFromCourse(course);
            }
            else if (data.Length == 3)
            {
                var course = data[1];
                var username = data[2];
                StudentsRepository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }

            return;
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

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (!IsDataValid(data, 2))
            {
                return;
            }

            var databasePath = data[1];
            StudentsRepository.InitilizeData(databasePath);
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (!IsDataValid(data, 2))
            {
                return;
            }

            var relPath = data[1];
            IOManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (!IsDataValid(data, 2))
            {
                return;
            }

            var absPath = data[1];
            IOManager.ChangeCurrentDirectoryAbsolute(absPath);
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (!IsDataValid(data, 3))
            {
                return;
            }

            Tester.CompareContent(data[1], data[2]);
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length < 2)
            {
                IOManager.TraverseDirectory(0);
            }
            else
            {
                int depth;
                var success = int.TryParse(data[1], out depth);
                if (success)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnableToParseNumber);
                }
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (!IsDataValid(data, 2))
            {
                return;
            }

            var folderName = data[1];
            IOManager.CreateDirectoryInCurrentFolder(folderName);
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (!IsDataValid(data, 2))
            {
                return;
            }

            var filename = data[1];
            Process.Start(SessionData.CurrentPath + "\\" + filename);
        }

        private static bool IsDataValid(string[] data, int neededLength)
        {
            if (data.Length != neededLength)
            {
                DisplayInvalidCommandMessage(string.Join(" ", data));
                return false;
            }

            return true;
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.WriteMessageOnNewLine($"The command {input} is invalid!");
        }
    }
}