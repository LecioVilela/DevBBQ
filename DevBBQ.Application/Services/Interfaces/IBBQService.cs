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
        void AddParticipantsToBBQ(int id, List<BBQParticipant> bbqParticipants);
        BBQCompleteViewModel GetCompleteBBQ(int id);
    }
}