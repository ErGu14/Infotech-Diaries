using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Shared.ViewModels
{
    public class InvitationsViewModel
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
