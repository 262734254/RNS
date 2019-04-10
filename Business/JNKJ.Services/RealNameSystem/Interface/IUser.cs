using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUser
    {
        User GetUserByName(string userName);


        bool InsertUser(User user);
    }
}
