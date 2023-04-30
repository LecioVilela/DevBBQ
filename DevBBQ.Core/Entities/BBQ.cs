using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBBQ.Core.Entities
{
    public class BBQ : BaseEntity
    {
        public BBQ(string titleBBQ, string description, string extraInfo, DateTime bBQDay)
        {
            TitleBBQ = titleBBQ;
            Description = description;
            ExtraInfo = extraInfo;
            CreatedAt = DateTime.Now;
            BBQDay = bBQDay;
            // Participants = participants;
        }

        public string TitleBBQ { get; private set; }
        public string Description { get; private set; }
        public string ExtraInfo { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime BBQDay { get; private set; }
        public ICollection<BBQParticipants> Participants { get; private set; }

        public void Update(string titleBBQ, string description, DateTime bbqDay)
        {
            TitleBBQ = titleBBQ;
            Description = description;
            BBQDay = bbqDay;
        }
    }
}