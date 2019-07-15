using Digix.Raking.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Core.Entities
{
    public class Person: Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate{ get; set; }
    }
}
