﻿namespace _005.Moods
{
    public abstract class Mood
    {
        public Mood(string moodName)
        {
            this.MoodName = moodName;
        }

        public string MoodName { get; private set; }

        public override string ToString()
        {
            return this.MoodName;
        }
    }
}