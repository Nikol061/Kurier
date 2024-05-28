using Kurier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurier
{
    public class ParcelLogic
    {
        private ParcelDbContext _parcelDbContext = new ParcelDbContext();

        public object Id { get; internal set; }

        public Parcel Get (int id)
        {
            Parcel findedParcel = _parcelDbContext.Parcels.Find (id);
            if(findedParcel != null)
            {
               _parcelDbContext.Entry(findedParcel).Reference(x => x.Types).Load();

            }
            return findedParcel;
        }
        public List<Parcel> GetAll()
        {
            return _parcelDbContext.Parcels.Include("Types").ToList();
        }
        public void Create(Parcel parcel)
        {
            _parcelDbContext.Parcels.Add(parcel);
            _parcelDbContext.SaveChanges();
        }
        public void Update(int id, Parcel parcel)
        {
            Parcel findedParcel = _parcelDbContext.Parcels.Find(id);
            if(findedParcel == null)
            {
                return;
            }
            findedParcel.Price = parcel.Price;
            findedParcel.Name = parcel.Name;
            findedParcel.Description = parcel.Description;
            findedParcel.Kg= parcel.Kg;
            _parcelDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Parcel findedParcel = _parcelDbContext.Parcels.Find(id);
            _parcelDbContext.Parcels.Remove(findedParcel);
            _parcelDbContext.SaveChanges();
        }
    }
}
