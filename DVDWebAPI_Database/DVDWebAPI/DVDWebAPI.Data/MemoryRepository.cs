using DVDWebAPI.Models;
using DVDWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data
{
    public class MemoryRepository : IDVDRepository
    {
        private static List<DVD> _DVDs = new List<DVD>() {
            new DVD
            {
                DvdId = 1,
                Director = "Bryan Howard",
                Rating = "PG",
                DvdTitle = "Encanto",
                ReleaseYear = 2021,
                Notes = "Vibrantly colored, beautiful cast of characters, and music that's catchy as hell"
            },
            new DVD
            {
                DvdId = 2,
                Director = "Anthony Russo",
                Rating = "PG-13",
                DvdTitle = "Avengers: Endgame",
                ReleaseYear = 2019,
                Notes = "Marks the end of the Infinity Saga. Is spellbinding and surely an enthralling experience."
            }
        };

        /*
         *can't do .add in constructor or else duplicates will keep forming whenever it is called
        public MemoryRepository()
        {
            _DVDs.Add(new DVD
            {
                DvdId = 1,
                Director = "Bryan Howard",
                Rating = "PG",
                DvdTitle = "Encanto",
                ReleaseYear = 2021,
                Notes = "Vibrantly colored, beautiful cast of characters, and music that's catchy as hell"
            });
            _DVDs.Add(new DVD
            {
                DvdId = 2,
                Director = "Anthony Russo",
                Rating = "PG-13",
                DvdTitle = "Avengers: Endgame",
                ReleaseYear = 2019,
                Notes = "Marks the end of the Infinity Saga. Is spellbinding and surely an enthralling experience."
            });
        }
        */

        public void AddDVD(DVD dvd)
        {
            _DVDs.Add(dvd);
        }

        public void DeleteDVD(int dvdId)
        {
            _DVDs.RemoveAll(x => x.DvdId == dvdId);
            /* var dvd = from x in _DVDs
                       where x.DvdId == dvdId       
                       select x;
            */
        }

        public List<DVD> GetAll()
        {
            return _DVDs;
        }

        public List<DVD> GetByDirector(string directorName)
        {
            var dvdList = from x in _DVDs
                          where x.Director == directorName
                          select x;
            return dvdList.ToList();
        }

        public List<DVD> GetByRating(string rating)
        {
            var dvdList = from x in _DVDs
                          where x.Rating == rating
                          select x;
            return dvdList.ToList();
        }

        public List<DVD> GetByReleaseYear(int releaseYear)
        {
            var dvdList = from x in _DVDs
                          where x.ReleaseYear == releaseYear
                          select x;
            return dvdList.ToList();
        }

        public DVD GetByTitle(string title)
        {
            var dvd = from x in _DVDs
                      where x.DvdTitle == title
                      select x;
            return dvd.FirstOrDefault();
        }

        public DVD GetDVDById(int dvdId)
        {
            var dvd = from x in _DVDs
                      where x.DvdId == dvdId
                      select x;
            return dvd.FirstOrDefault();
        }

        public void UpdateDVD(DVD dvd)
        {
            /*
            var updatedDvd = from x in _DVDs
                      where x.DvdId == dvd.DvdId
                      select x;
            updatedDvd.FirstOrDefault() = dvd;
            */

            for (int i = 0; i < _DVDs.Count; i++)
            {
                if (_DVDs[i].DvdId == dvd.DvdId)
                {
                    _DVDs[i] = dvd;
                }
            }
        }
    }
}
