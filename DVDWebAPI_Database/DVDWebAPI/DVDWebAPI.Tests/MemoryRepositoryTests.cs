using DVDWebAPI.Data;
using DVDWebAPI.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Tests
{
    [TestFixture]
    public class MemoryRepositoryTests
    {
        [Test]
        public void CanLoadDVDs()
        {
            //arrange
            MemoryRepository repo = new MemoryRepository();
            Assert.AreEqual(2,repo.GetAll().Count);
            // make calls to the repo method that loads dvds

            // assert check if equal

        }
        [Test]
        public void CanAddDVD()
        {
            MemoryRepository repo = new MemoryRepository();
            DVD dvd = new DVD() {
                DvdId = 3,
                Director = "Bryan Howard",
                Rating = "PG",
                DvdTitle = "Encanto 2",
                ReleaseYear = 2025,
                Notes = "Vibrantly colored, beautiful cast of characters, and music that's catchy as hell"
            };
            repo.AddDVD(dvd);
            Assert.AreEqual( 3, repo.GetAll().Count);
        }
        [Test]
        public void CanUpdateDVD()
        {
            MemoryRepository repo = new MemoryRepository();
            DVD dvd = new DVD()
            {
                DvdId = 2,
                Director = "Bryan Howard",
                Rating = "PG",
                DvdTitle = "Encanto 2",
                ReleaseYear = 2025,
                Notes = "Vibrantly colored, beautiful cast of characters, and music that's catchy as hell"
            };
            repo.UpdateDVD(dvd);
            Assert.AreEqual( "Encanto 2", repo.GetAll()[1].DvdTitle);
        }
        [Test]
        public void CanDeleteDVD()
        {
            MemoryRepository repo = new MemoryRepository();
            repo.DeleteDVD(1);
            Assert.AreEqual(1, repo.GetAll().Count);
        }
        [Test]
        public void CanSearchTitle()
        {
            MemoryRepository repo = new MemoryRepository();
            Assert.AreEqual(1,repo.GetByTitle("Encanto").DvdId);
        }
        [Test]
        public void CanSearchDirector()
        {
            MemoryRepository repo = new MemoryRepository();
            Assert.AreEqual(1, repo.GetByDirector("Bryan Howard").Count);
        }
        [Test]
        public void CanSearchReleaseYear()
        {
            MemoryRepository repo = new MemoryRepository();
            Assert.AreEqual(1, repo.GetByReleaseYear(2021).Count);
        }
        [Test]
        public void CanSearchRating()
        {
            MemoryRepository repo = new MemoryRepository();
            Assert.AreEqual(1, repo.GetByRating("PG").Count);
        }
    }
}



