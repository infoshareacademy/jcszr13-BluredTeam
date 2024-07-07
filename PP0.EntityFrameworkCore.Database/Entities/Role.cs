namespace PP0.EntityFrameworkCore.Database.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Role()
        {

        }
    }

}
