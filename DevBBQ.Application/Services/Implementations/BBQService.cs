using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Application.InputModels;
using DevBBQ.Application.Services.Interfaces;
using DevBBQ.Application.ViewModels;
using DevBBQ.Core.Entities;
using DevBBQ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevBBQ.Application.Services.Implementations
{
    public class BBQService : IBBQService
    {
        private readonly DevBBQDbContext _dbContext;
        public BBQService(DevBBQDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddParticipantsToBBQ(int bbqId, List<BBQParticipants> bbqParticipants)
        {
            var bbq = _dbContext.BBQs.Include(b => b.Participants).FirstOrDefault(b => b.Id == bbqId);

            if (bbq != null)
            {
                bbq.Participants ??= new List<BBQParticipants>();
                // Add participants in the collection
                bbq.Participants.Add((BBQParticipants)bbq.Participants);

                // Caculates the total of the contributions
                int totalParticipants = bbq.Participants.Count;
                decimal totalContribution = bbq.Participants.Sum(c => c.Contribution);

                // Update the total in BBQ
                bbq.TotalParticipants = totalParticipants;
                bbq.TotalContribution = totalContribution;

                // Save changes in database
                _dbContext.SaveChanges();
            }
        }
        public int Create(NewBBQInputModel inputModel)
        {
            var newBBQ = new BBQ();
            newBBQ.SetBBQ(inputModel.TitleBBQ, inputModel.Description, inputModel.ExtraInfo, inputModel.BBQDay);

            _dbContext.BBQs.Add(newBBQ);
            _dbContext.SaveChanges();

            return newBBQ.Id;
        }

        public BBQParticipants AddParticipants(int bbq, BBQParticipants participants)
        {
            var bbqParticipants = _dbContext.Set<BBQ>().Find(bbq);

            if (bbqParticipants is null)
            {
                return null;
            }

            participants.Id = bbq;
            _dbContext.Add(participants);
            _dbContext.SaveChanges();

            return participants;
        }

        public BBQParticipants RemoveParticipants(int bbq, int participantsID)
        {
            var participants = _dbContext.Set<BBQParticipants>().SingleOrDefault(b => b.Id == participantsID && b.Id == bbq);

            if (participants is null)
            {
                return null;
            }

            _dbContext.Remove(participants);
            _dbContext.SaveChanges();

            return participants;
        }

        public void Delete(int id)
        {
            var bbq = _dbContext.BBQs.SingleOrDefault(b => b.Id == id);
            _dbContext.SaveChanges();
        }

        public List<BBQViewModel> GetAll(string query)
        {
            var bbq = _dbContext.BBQs;

            var bbqViewModel = bbq
            .Select(b => new BBQViewModel(b.Id, b.TitleBBQ, b.CreatedAt, b.BBQDay))
            .ToList();

            return bbqViewModel;
        }

        public BBQViewModel GetById(int id)
        {
            var bbq = _dbContext.BBQs.SingleOrDefault(b => b.Id == id);

            if (bbq is null)
            {
                return null;
            }

            var bbqViewModel = new BBQViewModel(bbq.Id, bbq.TitleBBQ, bbq.CreatedAt, bbq.BBQDay);

            return bbqViewModel;
        }

        public void Update(UpdateBBQInputModel inputModel)
        {
            var bbq = _dbContext.BBQs.SingleOrDefault(b => b.Id == inputModel.Id);

            bbq.Update(inputModel.TitleBBQ, inputModel.Description, inputModel.BBQDay);
        }

        // public BBQ GetCompleteBBQ(int id)
        // {
        //     return _dbContext.BBQs.Include(b => b.Participants).FirstOrDefault(b => b.Id == id);
        // }

        public BBQCompleteViewModel GetCompleteBBQ(int id)
        {
            var bbq = _dbContext.BBQs
                        .Include(b => b.Participants)
                        .FirstOrDefault(b => b.Id == id);

            if (bbq == null)
            {
                return null;
            }

            var participants = bbq.Participants;
            var totalParticipants = participants.Count();
            var totalContribution = participants.Sum(p => p.Contribution);

            var viewModel = new BBQCompleteViewModel
            {
                Id = bbq.Id,
                TitleBBQ = bbq.TitleBBQ,
                Description = bbq.Description,
                ExtraInfo = bbq.ExtraInfo,
                CreatedAt = bbq.CreatedAt,
                BBQDay = bbq.BBQDay,
                Participants = participants.Select(p => new BBQParticipantsViewModel(p.Id, p.Name, p.Contribution, p.BBQ.Id)).ToList(),
                TotalParticipants = totalParticipants,
                TotalContribution = totalContribution
            };

            return viewModel;
        }

    }
}