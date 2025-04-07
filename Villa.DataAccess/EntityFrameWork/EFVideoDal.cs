using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repository;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntityFrameWork
{
    public class EFVideoDal : GenericRepository<Video>, IVideoDal
    {
        public EFVideoDal(VillaContext context) : base(context)
        {
        }
    }
}
