using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public OperationTypes OperationType { get; set; }
        public double Count { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Nomenclature Nomenclature { get; set; }
        public virtual Account Account { get; set; }

    }

    public enum OperationTypes
    {
        Receiving,
        Shipping
    }
}
