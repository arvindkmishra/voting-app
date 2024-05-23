namespace VotingApp.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Votes { get; private set; }

        public void Add(string name, int votes)
        {
            Name = name;
            Votes = votes;
        }
    }
}
