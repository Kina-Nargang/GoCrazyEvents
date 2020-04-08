using EventCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.ViewModels
{
    public class EventInfoViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string isFree { get; set; }
        public string isPublic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerDescription { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

    }
}
