using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvIdentity.Models
{
    public class UsersViewModel
    {
        public string ID
        { get; set; }
        public string Name
        { get; set; }
        public string Surname
        { get; set; }
        public string Email
        { get; set; }
        public string Phone
        { get; set; }
    }
}