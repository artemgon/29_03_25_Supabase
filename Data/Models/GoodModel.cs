using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSupabase.Data.Models
{
    [Table("Goods")]
    public class GoodModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("desc")]
        public string Description { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("price")]
        public double Price { get; set; }
        public string UserId { get; set; } = string.Empty;

        public GoodModel()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Count = 0;
            Price = 0;
        }

        public GoodModel(int id, string name, string description, int count, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Count = count;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nDescription: {Description}\nCount: {Count}\nPrice: {Price}";
        }

    }
}
