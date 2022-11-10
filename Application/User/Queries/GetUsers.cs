using Application.Common.Models;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public record GetUsers : IRequest<PaginatedList<UserDTO>>
    {
        public int pageSize { get; set; }
        public int pageNo { get; set; }
    }

    public class GetUsersHandler : IRequestHandler<GetUsers, PaginatedList<UserDTO>>
    {
        public GetUsersHandler(IMapper mapper, IUserRepository userRepo)
        {
            Mapper = mapper;
            UserRepo = userRepo;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepo { get; }
        public async Task<PaginatedList<UserDTO>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            //Calculate offset number to skip in reading db records
            int offset = (request.pageNo - 1) * request.pageSize;
            //Get Data from Db
            IEnumerable<CUser> users = await UserRepo.GetAll(offset, request.pageSize);
            //Map to UserDTO
            List<UserDTO> UserDTOList = Mapper.Map<List<UserDTO>>(users);
            //Get Count
            int total = await UserRepo.Count();

            return new PaginatedList<UserDTO>(UserDTOList, total, request.pageNo, request.pageSize);


        }
    }




}
