using Kurier.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurier.Controller
{
    public class ParcelTypeController
    {
        private ParcelDbContext _parcelDbContext = new ParcelDbContext();

        public static string Name { get; internal set; }

        public List<ParcelType> GetAllParcels()
        {
            return _parcelDbContext.ParcelsTypes.ToList();
        }
        public string GetParcelById(int id)
        {
            return _parcelDbContext.ParcelsTypes.Find(id).Name;
        }
    }
}
