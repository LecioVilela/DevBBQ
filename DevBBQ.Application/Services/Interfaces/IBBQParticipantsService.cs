using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Application.InputModels;
using DevBBQ.Application.ViewModels;

namespace DevBBQ.Application.Services.Interfaces
{
    public interface IBBQParticipantsService
    {
        List<BBQParticipantsViewModel> GetAll(string query);
        BBQParticipantsViewModel GetById(int id);
        int Create(int id, NewBBQParticipantsInputModel inputModel);
    }
}