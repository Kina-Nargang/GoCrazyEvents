﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Domain
{
    public class EventDetail
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


        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public int EventLocationId { get; set; }
        public int EventOrganizerId { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public virtual EventLocation EventLocation { get; set; }
        public virtual EventOrganizer EventOrganizer { get; set; }
    }
}
