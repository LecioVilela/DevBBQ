using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Core.Entities;

namespace DevBBQ.Application.ViewModels
{
    public class BBQViewModel
    {
        public BBQViewModel(int id, string titleBBQ, DateTime createdAt, DateTime bBQDay)
        {
            Id = id;
            TitleBBQ = titleBBQ;
            CreatedAt = createdAt;
            BBQDay = bBQDay;
        }

        public int Id { get; private set; }
        public string TitleBBQ { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime BBQDay { get; private set; }
    }
}