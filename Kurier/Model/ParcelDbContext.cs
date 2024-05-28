using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurier.Model
{
    public class ParcelDbContext:DbContext
    {
        public ParcelDbContext():base("ParcelDbContext")
        {
                
        }
        public DbSet<Parcel> Parcels { get; set;}
        public DbSet<ParcelType> ParcelsTypes { get; set;}
    }
}
