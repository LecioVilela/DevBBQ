using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Core.Entities
{
    public class BBQ : BaseEntity
    {
        public BBQ() { }
        public void SetBBQ(string titleBBQ, string description, string extraInfo, DateTime bBQDay)
        {
            TitleBBQ = titleBBQ;
            Description = description;
            ExtraInfo = extraInfo;
            CreatedAt = DateTime.Now;
            BBQDay = bBQDay;

        }

        public string TitleBBQ { get; private set; }
        public string Description { get; private set; }
        public string ExtraInfo { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime BBQDay { get; private set; }
        public ICollection<BBQParticipants> Participants { get; set; }
        public int TotalParticipants { get; set; }
        public decimal TotalContribution { get; set; }

        public void Update(string titleBBQ, string description, DateTime bbqDay)
        {
            TitleBBQ = titleBBQ;
            Description = description;
            BBQDay = bbqDay;
        }
    }
}