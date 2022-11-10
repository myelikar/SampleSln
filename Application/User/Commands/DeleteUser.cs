using Application.Common.Mappings;
using Application.Interfaces.Repositories;
using Application.User.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands
{
    public record DeleteUser : IRequest
    {
        public int Id { get; set; }

    }

    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        public DeleteUserHandler(IMapper mapper, IUserRepository userRepo)
        {
            Mapper = mapper;
            UserRepo = userRepo;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepo { get; }
        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            //Delete User from Db
            await UserRepo.Delete(request.Id);
            return Unit.Value;
        }
    }
}
