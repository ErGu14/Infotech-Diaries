using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entity.Concrete
{
    public class InvitationParticipant
    {
        public int InvitationId { get; set; }
        public Invitation? Invitation { get; set; }
        public int? ParticipantId { get; set; }
        public Participant? Participant { get; set; }
    }
}
