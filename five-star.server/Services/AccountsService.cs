using System;
using five_star.server.Models;
using five_star.server.Repositories;

namespace five_star.server.Services
{
    public class AccountsService
    {
        private readonly AccountsRepository _repo;

        public AccountsService(AccountsRepository repo)
        {
            _repo = repo;
        }



        public Account GetOrCreateAccount(Account userInfo)
        {
            Account account = _repo.GetById(userInfo.Id);
            if (account == null)
            {
                return _repo.Create(userInfo);
            }
            return account;
        }



        public string GetProfileEmailById(string id)
        {
            return _repo.GetById(id).Email;
        }



        public Account GetProfileByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }



        public Account Edit(Account edit, string userEmail)
        {
            Account original = GetProfileByEmail(userEmail);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            original.Picture = edit.Picture.Length > 0 ? edit.Picture : original.Picture;
            return _repo.Edit(original);
        }
    }
}