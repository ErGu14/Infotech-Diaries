using Microsoft.AspNetCore.Mvc;
using PartyApp.Business.Concrete;
using PartyApp.Entity.Concrete;
using PartyApp.MVC.Models;
using PartyApp.Shared.ViewModels;
using System.Diagnostics;

namespace PartyApp.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly InvitationService _invitationService;
        private readonly ParticipantService _participantsService;

        public HomeController(InvitationService invitationService, ParticipantService participantsService)
        {
            _invitationService = invitationService;
            _participantsService = participantsService;
        }

        public IActionResult Index()
        {
            var invitations = _invitationService.GetAll();
            return View(invitations);
        }
        public IActionResult Join(int id)
        {
            var i = _invitationService.GetById(id);
            var p = _participantsService.GetAllByInvitationId(id);
            var count = p.Count();
            JoinViewModel joinViewModel = new()
            {
                Invitation = i,
                Participants = p,
                CountOfParticipants = count
            };
            return View(joinViewModel);
        }



        [HttpPost]
        public IActionResult Join(ParticipantViewModel participant, int invitationId)
        {
            if (ModelState.IsValid)
            {
                _participantsService.Create(participant, invitationId);
                return RedirectToAction("Index");
            }
            var i = _invitationService.GetById(invitationId);
            var p = _participantsService.GetAllByInvitationId(invitationId);
            var count = p.Count();
            JoinViewModel joinViewModel = new()
            {
                Invitation = i,
                Participants = p,
                CountOfParticipants = count
            };
            return View(joinViewModel);
        }

        
       
        

    }
    }

