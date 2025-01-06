
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entity.Concrete
{
    public class Participant 
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public byte? Age { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public byte NumberOfPeople { get; set; }

        public List<InvitationParticipant>? InvitationParticipants { get; set; }


    }
}
