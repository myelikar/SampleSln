using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class UserDTO:IMapFrom<CUser>
    {
        public int Id { get; set; }
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(CUser), GetType());
            profile.CreateMap(GetType(), typeof(CUser));
        }
    }
}
