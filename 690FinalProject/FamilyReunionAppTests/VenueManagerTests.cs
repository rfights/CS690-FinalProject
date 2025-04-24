using System;
using Xunit;
using FamilyReunionApp;
using FamilyReunionApp.Venue;

namespace FamilyReunionAppTests
{
    public class VenueManagerTests
    {
        [Fact]
        public void AddVenue_ShouldAddVenueSuccessfully()
        {
            // Arrange
            var venueManager = new VenueManager();
            var venue = new Venue { Id = 1, Name = "Community Hall", Capacity = 100 };

            // Act
            venueManager.AddVenue(venue);

            // Assert
            Assert.Contains(venue, venueManager.GetVenues());
        }

        [Fact]
        public void RemoveVenue_ShouldRemoveVenueSuccessfully()
        {
            // Arrange
            var venueManager = new VenueManager();
            var venue = new Venue { Id = 1, Name = "Community Hall", Capacity = 100 };
            venueManager.AddVenue(venue);

            // Act
            venueManager.RemoveVenue(venue.Id);

            // Assert
            Assert.DoesNotContain(venue, venueManager.GetVenues());
        }

        [Fact]
        public void GetVenueById_ShouldReturnCorrectVenue()
        {
            // Arrange
            var venueManager = new VenueManager();
            var venue = new Venue { Id = 1, Name = "Community Hall", Capacity = 100 };
            venueManager.AddVenue(venue);

            // Act
            var result = venueManager.GetVenueById(1);

            // Assert
            Assert.Equal(venue, result);
        }
        [Fact]
        public void GetVenueById_ShouldThrowExceptionForNonExistentId()
        {
            // Arrange
            var venueManager = new VenueManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => venueManager.GetVenueById(999));
        }
    }
}

namespace FamilyReunionApp.Venue
{
    public class Venue
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
    }
}

public class VenueManager
{
    private readonly List<Venue> _venues = new List<Venue>();

    public void AddVenue(Venue venue)
    {
        _venues.Add(venue);
    }

    public void RemoveVenue(int venueId)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue != null)
        {
            _venues.Remove(venue);
        }
    }

    public Venue GetVenueById(int venueId)
    {
        return _venues.FirstOrDefault(v => v.Id == venueId) ?? throw new InvalidOperationException("Venue not found.");
    }

    public IEnumerable<Venue> GetVenues()
    {
        return _venues;
    }
}