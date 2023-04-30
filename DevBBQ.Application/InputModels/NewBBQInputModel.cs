using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Core.Entities;

namespace DevBBQ.Application.InputModels
{
    public class NewBBQInputModel
    {
        public string TitleBBQ { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime BBQDay { get; set; }
        public ICollection<BBQParticipants> Participants { get; set; }
    }
}