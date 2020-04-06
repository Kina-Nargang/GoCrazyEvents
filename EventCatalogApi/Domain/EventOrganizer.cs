using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Domain
{
    public class EventOrganizer
    {
        public int Id { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerDescription { get; set; }
    }
}
