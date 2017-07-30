using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Data.UnitOfWork;
using XMLToAnyViewParser.Entities;

namespace XMLToAnyViewParser.Data.Repository
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(DbContext dbContext) : base(dbContext) { }

    }
}
