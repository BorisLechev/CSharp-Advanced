using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Identity_After.Contracts
{
    public interface ILogin
    {
        void Login(string username, string password);
    }
}
