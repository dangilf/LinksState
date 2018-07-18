using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.DAL.EF
{
    public class LinkStatesDBContext:DbContext
    {
        public DbSet<CheckRequest> CheckRequests { get; set; }
        public DbSet<LinkState> LinkStates { get; set; }

        public LinkStatesDBContext() : base("DBConnection")
        {

        }
    }
}
