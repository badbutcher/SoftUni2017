﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    public class Car
    {
        private string model;
        private int speed;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}