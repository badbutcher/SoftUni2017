namespace _005
{
    using _005.Moods;

    public class MoodFactory
    {
        public Mood GetMood(int hapinessPoints)
        {
            if (hapinessPoints < -5)
            {
                return new Angry();
            }

            if (hapinessPoints <= 0)
            {
                return new Sad();
            }

            if (hapinessPoints <= 15)
            {
                return new Happy();
            }

            return new JavaScript();
        }
    }
}