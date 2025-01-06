using PartyApp.Data.Concrete.repos;
using PartyApp.Entity.Concrete;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Abstract
{
    public class InvitationService
    {
        private readonly InvitationRepos _repos;

        public InvitationService(InvitationRepos repos)
        {
            _repos = repos;
        }

        public List<InvitationViewModel> GetAll() {
            var i = _repos.GetAll();
            List<InvitationViewModel> ivm = i.Select(x => new InvitationViewModel
            {
                Id = x.Id,
                EventDate = x.EventDate,
                EventName = x.EventName,

            }).ToList();
            return ivm;
        }
        public InvitationViewModel GetById(int id)
        {
            var i = _repos.GetById(id);
            InvitationViewModel ivm = new InvitationViewModel();
            ivm.Id =i.Id;
            ivm.EventDate = i.EventDate;
            ivm.EventName = i.EventName;
            return ivm;
        }
        public void Create(InvitationViewModel model) {
            Invitation i = new() {
                Id = model.Id,
                EventDate = model.EventDate,
                EventName = model.EventName,
            };
            _repos.Create(i);
        }
        public void Update(InvitationViewModel model) {
            var i = _repos.GetById(model.Id);
            i.EventName = model.EventName;
            i.EventDate = model.EventDate;
            _repos.Update(i);
        }
        public void Delete(int id) {
            var i = _repos.GetById(id);
            _repos.Delete(i);
        }
    }
}
