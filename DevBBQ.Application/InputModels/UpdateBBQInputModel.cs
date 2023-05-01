using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Core.Entities;

namespace DevBBQ.Application.InputModels
{
    public class UpdateBBQInputModel
    {
        public int Id { get; set; }
        public string TitleBBQ { get; set; }
        public string Description { get; set; }
        public DateTime BBQDay { get; set; }
    }
}