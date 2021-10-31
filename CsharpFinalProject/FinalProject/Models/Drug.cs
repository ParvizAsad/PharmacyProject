using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Drug
    {
        public string Name { get; }
        public DrugType Type { get; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int ID { get; }
        private static int _counter;

        public Drug(string name, DrugType type, double price, int count)
        {
            Name = name;
            Type = type;
            Price = price;
            Count = count;
            _counter++;
            ID = _counter++;
        }

        public override string ToString()
        {
            return $"ID:{ID} Product Name: {Name} Price: {Price}  Count: {Count}";
        }

    }
}
