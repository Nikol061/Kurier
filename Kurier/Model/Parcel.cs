using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurier.Model
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Kg { get; set; }
        public int TypesId { get; set; }
        public ParcelType Types { get; set; }
    }
}
