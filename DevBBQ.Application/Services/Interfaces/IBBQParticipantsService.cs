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
        BBQParticipantsViewModel GetById(int id);
        int Create(NewBBQParticipantsInputModel inputModel);
    }
}