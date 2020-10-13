using System;
using System.Collections.Generic;
using System.Text;

namespace Cammon.Dto
{
    public class DtoUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
    }
}
