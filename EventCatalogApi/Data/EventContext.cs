using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        { }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventDetail> EventDatails { get; set; }
        public DbSet<EventInfoViewModel> EventInfoView { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table EventCategories
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("EventCategories");

                e.Property(g => g.Id)
                // Gets or sets a value that instructs the serialization engine 
                // that the member must be present when reading or deserializing.
                 .IsRequired()
                 .UseHiLo("event_categories_hilo");

                e.Property(g => g.Category)
                 .IsRequired()
                 .HasMaxLength(100);
            });

            // Table EventLocations
            modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("EventLocations");

                e.Property(l => l.Id)
                 .IsRequired()
                 .UseHiLo("event_location_hilo");

                e.Property(l => l.LocationName)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(l => l.City)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(l => l.State)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(l => l.Country)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(l => l.ZipCode)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(l => l.Address)
                 .IsRequired()
                 .HasMaxLength(200);

                e.Property(l => l.Address2)
                 .HasMaxLength(200);
            });

            // Table EventOrganizers
            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.ToTable("EventOrganizers");

                e.Property(o => o.Id)
                 .IsRequired()
                 .UseHiLo("event_organizer_hilo");

                e.Property(o => o.OrganizerName)
                 .IsRequired()
                 .HasMaxLength(150);

                e.Property(o => o.OrganizerDescription)
                 .IsRequired()
                 .HasMaxLength(1000);
            });

            // Table EventTypes
            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");

                e.Property(t => t.Id)
                 .IsRequired()
                 .UseHiLo("event_type_hilo");

                e.Property(t => t.Type)
                 .IsRequired()
                 .HasMaxLength(100);
            });

            //Table EventDatails
            modelBuilder.Entity<EventDetail>(e =>
            {
                e.ToTable("EventDetails");

                e.Property(d => d.Id)
                 .IsRequired()
                 .UseHiLo("event_detail_hilo");

                e.Property(d => d.EventName)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(d => d.isFree)
                 .IsRequired()
                 .HasDefaultValue("Free")
                 .HasMaxLength(10);

                e.Property(d => d.isPublic)
                 .IsRequired()
                 .HasDefaultValue("Public")
                 .HasMaxLength(10);

                e.Property(d => d.PictureUrl)
                 .HasMaxLength(200);

                e.Property(d => d.Price)
                 .IsRequired()
                 .HasDefaultValue(0.00);

                e.Property(d => d.StartDate)
                 .IsRequired();

                e.Property(d => d.EndDate)
                 .IsRequired();

                e.Property(d => d.CreatedDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

                e.Property(d => d.Description)
                 .IsRequired()
                 .HasDefaultValue(1000);

                e.HasOne(d => d.EventCategory)
                 .WithMany()
                 .HasForeignKey(d => d.EventCategoryId);

                e.HasOne(d => d.EventLocation)
                 .WithMany()
                 .HasForeignKey(d => d.EventLocationId);

                e.HasOne(d => d.EventOrganizer)
                 .WithMany()
                 .HasForeignKey(d => d.EventOrganizerId);

                e.HasOne(d => d.EventType)
                 .WithMany()
                 .HasForeignKey(d => d.EventTypeId);
            });

            // EventInfoView
            modelBuilder.Entity<EventInfoViewModel>(v =>
            {
                v.HasNoKey();
                v.ToView("EventInfoView");

                v.Property(d => d.Id)
                 .IsRequired();

                v.Property(d => d.EventName)
                 .IsRequired()
                 .HasMaxLength(100);

                v.Property(d => d.isPublic)
                 .IsRequired()
                 .HasMaxLength(10);

                v.Property(d => d.isFree)
                 .IsRequired()
                 .HasMaxLength(10);

                v.Property(d => d.PictureUrl)
                 .HasMaxLength(200);

                v.Property(d => d.Price)
                 .IsRequired();

                v.Property(d => d.StartDate)
                 .IsRequired();

                v.Property(d => d.EndDate)
                 .IsRequired();

                v.Property(d => d.CreatedDate)
                .IsRequired();

                v.Property(d => d.Description)
                 .IsRequired()
                 .HasDefaultValue(1000);

                v.Property(o => o.OrganizerName)
                 .IsRequired()
                 .HasMaxLength(150);

                v.Property(o => o.OrganizerDescription)
                 .IsRequired()
                 .HasMaxLength(1000);

                v.Property(l => l.LocationName)
                 .IsRequired()
                 .HasMaxLength(100);

                v.Property(l => l.City)
                 .IsRequired()
                 .HasMaxLength(50);

                v.Property(l => l.State)
                 .IsRequired()
                 .HasMaxLength(50);

                v.Property(l => l.Country)
                 .IsRequired()
                 .HasMaxLength(100);

                v.Property(l => l.ZipCode)
                 .IsRequired()
                 .HasMaxLength(50);

                v.Property(l => l.Address)
                 .IsRequired()
                 .HasMaxLength(200);

                v.Property(l => l.Address2)
                 .HasMaxLength(200);

            });
        }
    }
}
