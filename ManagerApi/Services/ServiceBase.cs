using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Services
{
    public class ServiceBase<TEntity> : ServiceAbstractBase<TEntity> where TEntity : class, new()
    {
        public ServiceBase(DbContext dbParameter) : base(dbParameter)
        {
        }
    }
}
