using Application.Common.Mappings;
using Application.Interfaces.Repositories;
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
    public record AddUser : IRequest, IMapFrom<CUser>
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// MobileNo
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// EmailId
        /// </summary>
        public string EmailId { get; set; }
        /// <summary>
        /// Username
        /// </summary>                    
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(CUser), GetType());
            profile.CreateMap(GetType(), typeof(CUser));
        }
    }

    public class AddUserHandler : IRequestHandler<AddUser>
    {
        public AddUserHandler(IMapper mapper, IUserRepository userRepo)
        {
            Mapper = mapper;
            UserRepo = userRepo;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepo { get; }

        public async Task<Unit> Handle(AddUser request, CancellationToken cancellationToken)
        {
            try
            {
                CUser user = Mapper.Map<CUser>(request);
                await UserRepo.Insert(user);
                return Unit.Value;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
