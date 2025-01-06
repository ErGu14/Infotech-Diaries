using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Shared.ViewModels
{
    public class JoinViewModel
    {
        public InvitationViewModel Invitation { get; set; }
        public List<ParticipantViewModel> Participants { get; set; }
        public int CountOfParticipants { get; set; }
        public ParticipantViewModel Participant { get; set; }
    }
}
