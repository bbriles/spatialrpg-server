using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SpatialRPGServer.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [BindRequired]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
