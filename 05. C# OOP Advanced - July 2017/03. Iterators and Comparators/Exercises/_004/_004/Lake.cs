namespace _004
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        public Lake(List<int> stones)
        {
            this.Stones = stones;
        }

        public IList<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return Stones[i];
                }
            }

            for (int i = Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}