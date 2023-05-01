using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Core.Entities
{
    public class BBQParticipant : BaseEntity
    {
        public BBQParticipant(string name, decimal contribution)
        {
            Name = name;
            Contribution = contribution;
        }

        public string Name { get; private set; }
        public decimal Contribution { get; private set; }
        public int BBQId { get; set; } // Navegation property
        public BBQ BBQ { get; set; } // Navegation property
    }
}