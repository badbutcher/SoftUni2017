﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class Launcher
    {
        static void Main()
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoreFromCourse("Unity", "Ivan");
        }
    }
}