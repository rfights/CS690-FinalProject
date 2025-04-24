using System;
using System.Collections.Generic;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionApp
{
    public class VenueManager
    {
        private string venue = "Not Set";
        private List<string> notes = new List<string>();

        public void SetVenue(string newVenue)
        {
            venue = newVenue;
        }

        public string GetVenue()
        {
            return venue;
        }

        public void AddNoteToVenue(string note)
        {
            notes.Add(note);
        }

        public List<string> GetVenueNotes()
        {
            return new List<string>(notes);
        }
    }
}

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