using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Application.InputModels;
using DevBBQ.Application.ViewModels;
using DevBBQ.Core.Entities;

namespace DevBBQ.Application.Services.Interfaces
{
    public interface IBBQService
    {
        List<BBQViewModel> GetAll(string query);
        BBQViewModel GetById(int id);
        int Create(NewBBQInputModel inputModel);
        void Update(UpdateBBQInputModel inputModel);
        void Delete(int id);
        // BBQ GetCompleteBBQ(int id);
        void AddParticipantsToBBQ(int id, List<BBQParticipants> bbqParticipants);
        BBQCompleteViewModel GetCompleteBBQ(int id);
    }
}