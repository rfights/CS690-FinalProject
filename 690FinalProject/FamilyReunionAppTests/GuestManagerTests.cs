using System.Collections.Generic;
using Xunit;

namespace FamilyReunionAppTests
{
    public class GuestManagerTestsTest
    {
        [Fact]
        public void AddGuest_ShouldAddGuestToList()
        {
            // Arrange
            var guestManager = new GuestManager();
            var guest = new Guest { Name = "John Doe", Age = 30 };

            // Act
            guestManager.AddGuest(guest);

            // Assert
            Assert.Contains(guest, guestManager.GetGuests());
        }

        [Fact]
        public void RemoveGuest_ShouldRemoveGuestFromList()
        {
            // Arrange
            var guestManager = new GuestManager();
            var guest = new Guest { Name = "Jane Doe", Age = 25 };
            guestManager.AddGuest(guest);

            // Act
            guestManager.RemoveGuest(guest);

            // Assert
            Assert.DoesNotContain(guest, guestManager.GetGuests());
        }

        [Fact]
        public void GetGuests_ShouldReturnAllGuests()
        {
            // Arrange
            var guestManager = new GuestManager();
            var guest1 = new Guest { Name = "Alice", Age = 40 };
            var guest2 = new Guest { Name = "Bob", Age = 35 };
            guestManager.AddGuest(guest1);
            guestManager.AddGuest(guest2);

            // Act
            var guests = guestManager.GetGuests();

            // Assert
            Assert.Equal(2, guests.Count);
            Assert.Contains(guest1, guests);
            Assert.Contains(guest2, guests);
        }

        [Fact]
        public void AddGuest_ShouldNotAllowDuplicateGuests()
        {
            // Arrange
            var guestManager = new GuestManager();
            var guest = new Guest { Name = "Charlie", Age = 28 };
            guestManager.AddGuest(guest);

            // Act
            guestManager.AddGuest(guest);

            // Assert
            Assert.Single(guestManager.GetGuests());
        }
    }

    // Mock classes for testing
    public class GuestManager
    {
        private readonly List<Guest> _guests = new List<Guest>();

        public void AddGuest(Guest guest)
        {
            if (!_guests.Contains(guest))
            {
                _guests.Add(guest);
            }
        }

        public void RemoveGuest(Guest guest)
        {
            _guests.Remove(guest);
        }

        public List<Guest> GetGuests()
        {
            return _guests;
        }
    }

    public class Guest
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Guest guest &&
                   Name == guest.Name &&
                   Age == guest.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}