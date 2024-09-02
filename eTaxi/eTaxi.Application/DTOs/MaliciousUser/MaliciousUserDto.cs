using eTaxi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.MaliciousUser
{
    public class MaliciousUserDto
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public int UserId { get; set; }
        public bool IsSuspicious { get; set; }

        public UserDto  User { get; set; }
    }
}
