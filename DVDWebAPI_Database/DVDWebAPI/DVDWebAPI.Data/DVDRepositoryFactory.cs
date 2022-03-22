using DVDWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data
{
    public static class DVDRepositoryFactory
    {
        public static IDVDRepository Create()
        {
            
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "MemoryRepository":
                    return new MemoryRepository();
                case "ADORepository":
                    return new ADORepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
            
        }
    }
}
