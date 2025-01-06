using Party.Data.Concrete;
using Party.Entity.Concrete;
using Party.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business.Concrete
{
    public class InvitationService
    {
        private readonly InvitationRepository _repository;

        public InvitationService(InvitationRepository repository)
        {
            _repository = repository;
        }

        public List<InvitationsViewModel> GetAll()
        {
           var i = _repository.GetAll();
            var ivm = i.Select(x => new InvitationsViewModel
            {
                Id = x.Id,
                EventName = x.EventName,
                EventDate = x.EventDate
            }).ToList();
            return ivm;
        }

        public InvitationsViewModel GetById(int id) {
            var i = _repository.GetById(id);
            var result = new InvitationsViewModel()
            {
                Id= i.Id,
                EventName = i.EventName,
                EventDate = i.EventDate,
            };
            return result;
        }

        public void Create(InvitationsViewModel model)
        {
            Invitation i = new()
            {
                Id=model.Id,
                EventName=model.EventName,
                EventDate=model.EventDate,
            };
            _repository.Create(i);
        }
        public void Update(InvitationsViewModel model)
        {

            var i = _repository.GetById(model.Id);
            model.EventDate = i.EventDate;
            model.EventName = model.EventName;
            _repository.Update(i);
        }

        public void Delete(InvitationsViewModel model) {

            var i = _repository.GetById(model.Id);
            _repository.Delete(i);
        }



    }
}
