using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Application.ViewModels
{
    public class BBQCompleteViewModel
    {
        public int Id { get; set; }
        public string TitleBBQ { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BBQDay { get; set; }
        public List<BBQParticipantsViewModel> Participants { get; set; }
        public int TotalParticipants { get; set; }
        public decimal TotalContribution { get; set; }
    }
}