using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Core.Entities
{
    public class BBQParticipants : BaseEntity
    {
        public BBQParticipants(string name, decimal contribution)
        {
            Name = name;
            Contribution = contribution;
        }

        public string Name { get; private set; }
        public decimal Contribution { get; private set; }
    }
}