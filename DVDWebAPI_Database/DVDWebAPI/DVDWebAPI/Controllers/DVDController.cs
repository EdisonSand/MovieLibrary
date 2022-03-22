using DVDWebAPI.Data;
using DVDWebAPI.Models;
using DVDWebAPI.Models.Interfaces;
using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        // GET: DVD
       // private IDVDRepository _DVDRepository = DVDRepositoryFactory.Create(); // place in every method
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            return Ok(_DVDRepository.GetAll());
        }
        [Route("dvd/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateDVD(AddDVDRequest request)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DVD dvd = new DVD()
            {
                DvdId = _DVDRepository.GetAll().LastOrDefault().DvdId +1 ,
                Director = request.director,
                Rating = request.rating,
                DvdTitle = request.dvdTitle,
                ReleaseYear = request.releaseYear,
                Notes = request.Notes
            };
            _DVDRepository.AddDVD(dvd);
            return Created($"dvd/get/{dvd.DvdId}", dvd); //returns the created object after the post
        }

        [Route("dvds/get/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int dvdId)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            DVD dvd = _DVDRepository.GetDVDById(dvdId);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }
        [Route("dvds/get/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            DVD dvd = _DVDRepository.GetByTitle(title);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }
        [Route("dvds/get/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            List<DVD> dvd = _DVDRepository.GetByRating(rating);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }
        [Route("dvds/get/releaseyear/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int releaseYear)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            List<DVD> dvd = _DVDRepository.GetByReleaseYear(releaseYear);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }
        [Route("dvds/get/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            List<DVD> dvd = _DVDRepository.GetByDirector(director);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateDVDRequest request)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //DVD dvd = _DVDRepository.GetDVDById(request.DvdId);
            DVD dvd = new DVD
            {
                DvdId = request.DvdId,
                DvdTitle = request.Title,
                Director = request.director,
                Rating = request.Rating,
                ReleaseYear = request.releaseYear,
                Notes = request.Notes
            };
            if (dvd == null)
            {
                return NotFound();
            }
            _DVDRepository.UpdateDVD(dvd);
            return Ok(dvd);
        }
        [Route("dvd/delete/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            IDVDRepository _DVDRepository = DVDRepositoryFactory.Create();
            DVD dvd = _DVDRepository.GetDVDById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            _DVDRepository.DeleteDVD(dvdId);
            return Ok(dvd); // returns deleted object
        }
    }
}
