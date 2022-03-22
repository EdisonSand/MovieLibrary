using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Models.Interfaces
{
    public interface IDVDRepository
    {
        DVD GetDVDById(int dvdId);
        DVD GetByTitle(string title);
        List<DVD> GetByDirector(string directorName);
        List<DVD> GetByRating(string rating);
        List<DVD> GetByReleaseYear(int releaseYear); // needs to be list in case of multiple movies
        void UpdateDVD(DVD dvd); //saves edits
        void AddDVD(DVD dvd); // post method handles this
        List<DVD> GetAll(); // needs to be list
        void DeleteDVD(int dvdId);
        //get id 
        // get by release year
        // edit
        //delete

    }
}
//make create / updae models w/ validation using attributes or ivalidate interface 
//required / ranged attributes for release year 