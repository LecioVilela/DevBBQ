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
    public class BBQService : IBBQService
    {
        private readonly DevBBQDbContext _dbContext;
        public BBQService(DevBBQDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewBBQInputModel inputModel)
        {
            var bbq = new BBQ(inputModel.TitleBBQ, inputModel.Description, inputModel.ExtraInfo, inputModel.BBQDay);

            _dbContext.BBQs.Add(bbq);
            _dbContext.SaveChanges();

            return bbq.Id;
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
    }
}