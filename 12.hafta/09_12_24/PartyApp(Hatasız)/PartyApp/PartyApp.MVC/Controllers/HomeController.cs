using Microsoft.AspNetCore.Mvc;
using PartyApp.Business.Concrete;
using PartyApp.MVC.Models;
using PartyApp.Shared.ViewModels;
using System.Diagnostics;

namespace PartyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly InvitationService _invitationService;
        private readonly ParticipantService _participantService;

        public HomeController(InvitationService invitationService, ParticipantService participantService)
        {
            _invitationService = invitationService;
            _participantService = participantService;
        }

        public IActionResult Index()
        {
            var invitations = _invitationService.GetAll();
            return View(invitations);
        }
    
        public IActionResult Join(int id)
        {
            var invitation = _invitationService.GetById(id);
            var participants = _participantService.GetAllByInvitationId(id);
            var countOfParticipants = participants.Count();

            JoinViewModel model = new()
            {
                Invitation = invitation,
                Participants = participants,
                CountOfParticipants = countOfParticipants
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Join(ParticipantViewModel participant, int invitationId)
        {
            if (ModelState.IsValid)
            {
                _participantService.Create(participant, invitationId);
                return RedirectToAction("Index");
            }
            var invitation = _invitationService.GetById(invitationId);
            var participants = _participantService.GetAllByInvitationId(invitationId);
            var countOfParticipants = participants.Count();

            JoinViewModel model = new()
            {
                Invitation = invitation,
                Participants = participants,
                CountOfParticipants = countOfParticipants
            };
            return View(model);
        }
    }
}
