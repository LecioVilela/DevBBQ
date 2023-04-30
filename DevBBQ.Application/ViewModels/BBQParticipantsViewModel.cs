using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Application.ViewModels
{
    public class BBQParticipantsViewModel
    {
        public BBQParticipantsViewModel(string name, decimal contribution)
        {
            Name = name;
            Contribution = contribution;
        }

        public string Name { get; private set; }
        public decimal Contribution { get; private set; }
    }
}