using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IApplicationDbContext
    {
        IDbConnection DbConnection { get; }
        DbSet<CUser> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
