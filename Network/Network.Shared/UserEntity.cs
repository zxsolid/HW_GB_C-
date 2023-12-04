namespace Network.Shared
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UserEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
       
    }
}