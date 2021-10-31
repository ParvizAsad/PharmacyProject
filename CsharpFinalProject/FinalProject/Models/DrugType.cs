using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class DrugType
    {
        public string TypeName { get; }
        public int ID { get; }
        private static int _counter;
        public DrugType(String typeName)
        {
            TypeName = typeName;
            _counter++;
            ID = _counter;
        }

        public override string ToString()
        {
            return $"TypeName: {TypeName}";
        }

    }
}
