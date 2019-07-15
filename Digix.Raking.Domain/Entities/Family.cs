using Digix.Raking.Domain.Core.Entities.Base;
using System.Collections.Generic;

namespace Digix.Raking.Domain.Core.Entities
{
    public class Family : Entity
    {
        public int Status { get; set; }
        public IList<Person> People { get; set; }
        public IList<Income> Incomes { get; set; }
    }   
}
