using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltsAndPrices.Data.Domain
{
    //[Table(Name = "Inventory")]
    public class Inventory
    {
        //[Column(Name = "InventoryId", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        //[Key]
        public int InventoryId { get; set; }

        //[Column(Name = "InventoryCode", DbType = "TEXT")]
        public string InventoryCode { get; set; }

       // [Column(Name = "Price", DbType = "NUMERIC")]
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{InventoryId} / {InventoryCode} / {Price}";
        }

    }
}
