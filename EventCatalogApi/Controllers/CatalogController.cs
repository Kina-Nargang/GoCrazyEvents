using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public CatalogController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery]int pageIndex = 0, 
            [FromQuery]int pageSize = 6)
        {
            //// check if EventInfoView is existing
            ////var checkView = @"SELECT Count(*) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = '[dbo].[EventInfoView]'";
            ////var count = await _context.Database.ExecuteSqlRawAsync(checkView);
            //var checkView = @"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'EventInfoView') BEGIN PRINT 'T' END";

            //var count = await _context.Database.ExecuteSqlRawAsync(checkView);


            //if (count != 1)
            //{
            //    //create EventInfoView
            //    string sql = @"CREATE VIEW EventInfoView AS " +
            //              "SELECT ED.Id, ED.EventName, ED.Description, ED.PictureUrl, " +
            //                     "ED.Price, ED.isFree, ED.isPublic, ED.StartDate, " +
            //                     "ED.EndDate, ED.CreatedDate, " +
            //                     "EO.OrganizerName, EO.OrganizerDescription, " +
            //                     "EL.LocationName, EL.Address, EL.Address2, " +
            //                     "EL.City, EL.State, EL.ZipCode, EL.Country " +
            //            "FROM EventDetails ED " +
            //            "INNER JOIN EventOrganizers EO ON ED.EventOrganizerId = EO.Id " +
            //            "INNER JOIN EventLocations EL ON ED.EventLocationId = EL.Id";

            //    await _context.Database.ExecuteSqlRawAsync(sql);
            //}

            //string sql = @"IF NOT EXISTS (SELECT 0 FROM sys.views WHERE TABLE_NAME = 'EventInfoView') " +
            //          "BEGIN " + 
            //              "CREATE VIEW EventInfoView AS " +
            //              "SELECT ED.Id, ED.EventName, ED.Description, ED.PictureUrl, " +
            //                     "ED.Price, ED.isFree, ED.isPublic, ED.StartDate, " +
            //                     "ED.EndDate, ED.CreatedDate, " +
            //                     "EO.OrganizerName, EO.OrganizerDescription, " +
            //                     "EL.LocationName, EL.Address, EL.Address2, " +
            //                     "EL.City, EL.State, EL.ZipCode, EL.Country " +
            //            "FROM EventDetails ED " +
            //            "INNER JOIN EventOrganizers EO ON ED.EventOrganizerId = EO.Id " +
            //            "INNER JOIN EventLocations EL ON ED.EventLocationId = EL.Id " +
            //         "END";

            //await _context.Database.ExecuteSqlRawAsync(sql);


            var eventsCount = await _context.EventInfoView.LongCountAsync();

            // need to crab location and organier here!!
            var events = await _context.EventInfoView
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            events = ChangePictureUrl(events);


            var model = new PaginatedEventViewModel<EventInfoViewModel>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = eventsCount,
                Events = events
            };

            return Ok(model);
        }

        private List<EventInfoViewModel> ChangePictureUrl(List<EventInfoViewModel> events)
        {
            events.ForEach(
                e => e.PictureUrl =
                        e.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", 
                                              _config["ExternalCatalogBaseUrl"])
                        );

            return events;
        }

        private List<EventLocation> GetLocations()
        {
            var locations = _context.EventLocations.ToList();
            return locations;
        }

        private List<EventOrganizer> GetOrgnaizners()
        {
            var organziers = _context.EventOrganizers.ToList();
            return organziers;
        }
    }
}