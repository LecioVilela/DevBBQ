using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Application.InputModels;
using DevBBQ.Application.ViewModels;

namespace DevBBQ.Application.Services.Interfaces
{
    public interface IBBQService
    {
        List<BBQViewModel> GetAll(string query);
        BBQViewModel GetById(int id);
        int Create(NewBBQInputModel inputModel);
        void Update(UpdateBBQInputModel inputModel);
        void Delete(int id);
    }
}