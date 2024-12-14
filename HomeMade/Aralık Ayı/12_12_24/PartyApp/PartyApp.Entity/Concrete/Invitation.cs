using PartyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Entity.Concrete
{
    public class Invitation : IBaseEntity
    {
        public int Id { get ; set ; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public List<InvitationParticipant> InvitationParticipants { get; set; } //navigation prop


    }

    
}
