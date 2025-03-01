namespace DotnetFullstack.Domain.Entities
{
    public class Professor(string name, string biography)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public string Biography { get; private set; } = biography;

        public void Update(string name, string biography)
        {
            Name = name;
            Biography = biography;
        }
    }
}
