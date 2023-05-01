using DevBBQ.Application.InputModels;
using DevBBQ.Application.Services.Interfaces;
using DevBBQ.Application.ViewModels;
using DevBBQ.Core.Entities;
using DevBBQ.Infrastructure.Persistence;

namespace DevBBQ.Application.Services.Implementations
{
    public class BBQParticipantsService : IBBQParticipantsService
    {
        private readonly DevBBQDbContext _dbContext;

        public BBQParticipantsService(DevBBQDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(int id, NewBBQParticipantsInputModel inputModel)
        {
            var bbqParticipants = new BBQParticipant(inputModel.Name, inputModel.Contribution)
            {
                BBQId = id
            };

            _dbContext.BBQParticipants.Add(bbqParticipants);
            _dbContext.SaveChanges();

            return bbqParticipants.Id;
        }

        public List<BBQParticipantsViewModel> GetAll(string query)
        {
            var participants = _dbContext.BBQParticipants;

            var bbqViewModel = participants
            .Select(b => new BBQParticipantsViewModel(b.Id, b.Name, b.Contribution, b.BBQId))
            .ToList();

            return bbqViewModel;
        }

        public BBQParticipantsViewModel GetById(int id)
        {
            var bbqParticipants = _dbContext.BBQParticipants.SingleOrDefault(b => b.Id == id);

            if (bbqParticipants is null)
            {
                return null;
            }

            var bbqParticipantsViewModel = new BBQParticipantsViewModel(bbqParticipants.Id, bbqParticipants.Name, bbqParticipants.Contribution, bbqParticipants.BBQId);

            return bbqParticipantsViewModel;
        }

        public void Delete(int id)
        {
            var bbqParticipant = _dbContext.BBQParticipants.SingleOrDefault(b => b.Id == id);

            if (bbqParticipant is not null)
            {
                _dbContext.BBQParticipants.Remove(bbqParticipant);
                _dbContext.SaveChanges();
            }
        }
    }
}