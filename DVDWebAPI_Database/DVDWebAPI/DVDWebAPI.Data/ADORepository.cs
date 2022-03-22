using DVDWebAPI.Models;
using DVDWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DVDWebAPI.Data
{
    public class ADORepository:IDVDRepository
    {
        //All searches are handled by stored procedures

        private string _connectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
        public void AddDVD(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", dvd.DvdId);
                parameters.Add("@title", dvd.DvdTitle);
                parameters.Add("@director", dvd.Director);
                parameters.Add("@rating", dvd.Rating);
                parameters.Add("@releaseYear", dvd.ReleaseYear);
                parameters.Add("@notes", dvd.Notes);

                conn.Execute("AddDvd", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteDVD(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", dvdId);

                conn.Execute("DeleteDvd", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<DVD> GetAll()
        {
            using (SqlConnection conn = new SqlConnection()) {
                conn.ConnectionString = _connectionString;
                return conn.Query<DVD>("LoadData", commandType: CommandType.StoredProcedure).ToList();
            }
              
        }

        public List<DVD> GetByDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@director", director);

                return conn.Query<DVD>("GetDvdByDirector", parameters, commandType: CommandType.StoredProcedure).ToList();
            };
        }

        public List<DVD> GetByRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@rating", rating);

                return conn.Query<DVD>("GetDvdByRating", parameters, commandType: CommandType.StoredProcedure).ToList();
            };
        }

        public List<DVD> GetByReleaseYear(int releaseYear)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@releaseYear", releaseYear);

                return conn.Query<DVD>("GetDvdByReleaseYear", parameters, commandType: CommandType.StoredProcedure).ToList();
            };
        }

        public DVD GetByTitle(string title)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@title", title);

                return conn.Query<DVD>("GetDvdByTitle", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            };
        }

        public DVD GetDVDById(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", dvdId);

                return conn.Query<DVD>("GetDvdById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            };
        }

        public void UpdateDVD(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();

                // declare output parameter
                parameters.Add("@id", dvd.DvdId);
                parameters.Add("@Title", dvd.DvdTitle);
                parameters.Add("@Director", dvd.Director);
                parameters.Add("@Rating", dvd.Rating);
                parameters.Add("@ReleaseYear", dvd.ReleaseYear);
                parameters.Add("@Notes", dvd.Notes);

                conn.Execute("UpdateDvd", parameters, commandType: CommandType.StoredProcedure);

             
            }
        }
    }
}
