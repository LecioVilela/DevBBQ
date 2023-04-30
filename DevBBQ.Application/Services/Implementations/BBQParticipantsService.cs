using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public int Create(NewBBQParticipantsInputModel inputModel)
        {
            var bbqParticipants = new BBQParticipants(inputModel.Name, inputModel.Contribution);

            _dbContext.BBQParticipants.Add(bbqParticipants);
            _dbContext.SaveChanges();

            return bbqParticipants.Id;
        }

        public BBQParticipantsViewModel GetById(int id)
        {
            var bbqParticipants = _dbContext.BBQParticipants.SingleOrDefault(b => b.Id == id);

            if (bbqParticipants is null)
            {
                return null;
            }

            var bbqParticipantsViewModel = new BBQParticipantsViewModel(bbqParticipants.Name, bbqParticipants.Contribution);

            return bbqParticipantsViewModel;
        }
    }
}