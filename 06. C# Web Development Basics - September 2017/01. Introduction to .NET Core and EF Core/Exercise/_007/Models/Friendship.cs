﻿namespace _007
{
    using _007.Models;

    public class Friendship
    {
        public int FromUserId { get; set; }

        public User FromUser { get; set; }

        public int ToUserId { get; set; }

        public User ToUser { get; set; }
    }
}