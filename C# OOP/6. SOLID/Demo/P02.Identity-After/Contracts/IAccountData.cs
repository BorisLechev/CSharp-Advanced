using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Identity_After.Contracts
{
    public interface IAccountData
    {
        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
