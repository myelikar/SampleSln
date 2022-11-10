using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CUser : BaseAuditableEntity
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
    }
}
