using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.tweetapp.Dal.Infrastructure.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection connection { get; }
    }
}
