using Newme.Purchase.Domain.Models.Abstracts;

namespace Newme.Purchase.Domain.Models.Entities
{
    public class Buyer : Entity
    {
        private Buyer() { }
        public Buyer(
            Guid id, 
            string name, 
            string surname, 
            string username, 
            string email) : base(id)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Email = email;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}