﻿namespace P02._Identity_Before
{
    using Contracts;
    using P02.Identity_After.Contracts;

    public class AccountController
    {
        private readonly IPasswordChanger manager;

        public AccountController(IPasswordChanger manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
