using System;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionAppTests
{
    public class VenueManagerTests
    {
        [Fact]
        public void Test_SetVenue_UpdatesVenueInformation()
        {
            var venueManager = new VenueManager();
            string newVenue = "Central Park";

            venueManager.SetVenue(newVenue);

            Assert.Equal(newVenue, venueManager.GetVenue());
        }

        [Fact]
        public void Test_AddNote_AddsNoteToVenue()
        {
            var venueManager = new VenueManager();
            string note = "Bring extra chairs";

            venueManager.AddNoteToVenue(note);

            Assert.Contains(note, venueManager.GetVenueNotes());
        }
    }
}