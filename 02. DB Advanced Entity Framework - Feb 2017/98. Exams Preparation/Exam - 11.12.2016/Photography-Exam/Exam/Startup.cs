﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Startup
    {
        static void Main()
        {
            PhotoContext context = new PhotoContext();
            context.Database.Initialize(true);
        }
    }
}
