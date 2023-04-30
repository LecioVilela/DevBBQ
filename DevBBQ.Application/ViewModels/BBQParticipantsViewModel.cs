using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Application.ViewModels
{
    public class BBQParticipantsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Contribution { get; set; }
        public int BBQId { get; set; }

        public BBQParticipantsViewModel(int id, string name, decimal contribution, int bbqId)
        {
            Id = id;
            Name = name;
            Contribution = contribution;
            BBQId = bbqId;
        }
    }

}