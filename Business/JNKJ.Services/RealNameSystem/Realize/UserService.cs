using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    public class UserService : IUser
    {
        #region Fields

        private readonly IRepository<User> _user;

        #endregion

        #region Ctor

        public UserService(IRepository<User> user)
        {
            _user = user;
        }

        #endregion
        public User GetUserByName(string userName)
        {
            return _user.Table.FirstOrDefault(s => s.UserName == userName);
        }

        public bool InsertUser(User user)
        {
            if (user == null) { throw new ArgumentNullException("user is null"); }

            bool result = _user.Insert(user);

            return result;
        }
    }
}
