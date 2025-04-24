using System;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionAppTests
{
    public class GuestManagerTests
    {
        [Fact]
        public void Test_AddGuest_AddsGuestToList()
        {
            var guestManager = new GuestManager();
            string guestName = "John Doe";

            guestManager.AddGuest(guestName);

            Assert.Contains(guestName, guestManager.GetGuestList());
        }

        [Fact]
        public void Test_RemoveGuest_RemovesGuestFromList()
        {
            var guestManager = new GuestManager();
            string guestName = "John Doe";
            guestManager.AddGuest(guestName);

            bool removed = guestManager.RemoveGuest(guestName);

            Assert.True(removed);
            Assert.DoesNotContain(guestName, guestManager.GetGuestList());
        }
    }
}