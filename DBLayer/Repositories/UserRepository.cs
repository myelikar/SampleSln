using Application.Interfaces.Repositories;
using DbLayer.DBContext;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public class UserRepository : BaseRepository<CUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
