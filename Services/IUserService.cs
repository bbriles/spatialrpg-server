using System.Collections.Generic;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services 
{

    public interface IUserService
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
    }

}