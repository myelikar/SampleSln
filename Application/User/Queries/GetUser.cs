using Application.Common.Models;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public record GetUser : IRequest<UserDTO>
    {
        public int Id { get; set; }

    }

    public class GetUserHandler : IRequestHandler<GetUser, UserDTO>
    {
        public GetUserHandler(IMapper mapper, IUserRepository userRepo)
        {
            Mapper = mapper;
            UserRepo = userRepo;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepo { get; }
        public async Task<UserDTO> Handle(GetUser request, CancellationToken cancellationToken)
        {

            //Get Data from Db
            CUser user = await UserRepo.GetById(request.Id);
            //Map to UserDTO
            UserDTO UserDTO = Mapper.Map<UserDTO>(user);
            return Mapper.Map<UserDTO>(user);
        }
    }
}
