namespace VotingApp.Domain.Entities
{
    public class Voter
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool HasVoted { get; private set; }

        public void Add(string name)
        {
            Name = name;
        }
    }
}
