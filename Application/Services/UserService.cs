using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
    {
        IUserRepository UserRepo { get; }
        Task Delete(int Id);
        Task<CUser> GetById(int id);
        Task Insert(CUser data);
        Task Update(CUser data);
        Task<IEnumerable<CUser>> GetAll(int offset, int size);
    }
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepo)
        {
            UserRepo = userRepo;
        }

        public IUserRepository UserRepo { get; }

        public async Task Delete(int Id)
        {
            await UserRepo.Delete(Id);
        }

        public async Task<IEnumerable<CUser>> GetAll(int offset, int size)
        {
            return await UserRepo.GetAll(offset, size);
        }

        public async Task<CUser> GetById(int id)
        {
            return await UserRepo.GetById(id);
        }

        public async Task Insert(CUser data)
        {
            await UserRepo.Insert(data);
        }

        public async Task Update(CUser data)
        {
            await UserRepo.Update(data);
        }
    }
}
