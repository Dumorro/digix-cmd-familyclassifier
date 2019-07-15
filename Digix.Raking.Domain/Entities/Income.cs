using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Core.Entities
{
    public class Income
    {
        public Guid PersonId { get; set; }
        public double Value { get; set; }
    }
}
