using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insendlu.Entities.Connection;


namespace Insendu.Services
{
    public class UserService
    {
        private readonly InsendluEntities _insendluEntities;

        public UserService()
        {
            _insendluEntities = new InsendluEntities();
        }

        public List<User> GetUserByName(string name)
        {
            return _insendluEntities.Users.Where(x => x.name.StartsWith(name.ToLower())).ToList();
        }
        public User GetUserById(long id)
        {
            return _insendluEntities.Users.FirstOrDefault(x => x.id == id);
        }

        public User GetUserByEmailAndTempPass(string email, string pass)
        {
            return _insendluEntities.Users.FirstOrDefault(x => x.email == email && x.temporary_password == pass);
        }
    }
}
