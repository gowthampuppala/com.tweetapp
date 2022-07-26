using com.tweetapp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories.Interface
{
    public interface IUserRegistrationRepository
    {
        string AddUserToDb(UserDetails userDetails);
    }
}
