using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Factura:IDataBaseItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //public string CodigoFactura { get; set; }
        public Cliente Cliente{ get; set; }
        public string Ciudad { get; set; }
        
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Retencion { get; set; }

        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public bool Pagada { get; set; }
        public string FechaPago { get; set; }

    }
}
