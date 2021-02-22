using Core.Interfaces.DL;
using Core.Interfaces.DTO;
using Data.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


namespace Data.Repository
{
    public class EmployeeClientRepository : IEmployeeClientRepository
    {
        IConfiguration configuration;
        public EmployeeClientRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public List<IEmployeeDTO> GetEmployeeList()
        {
            try
            {
                List<EmployeeDTO> jsonResult;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configuration.GetSection("EmployeeApiUrl").Value);
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonResult = JsonConvert.DeserializeObject<List<EmployeeDTO>>(reader.ReadToEnd());
                }
                return jsonResult.Cast<IEmployeeDTO>().ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                ex.Data.Add("EmployeeClientRepository", "GetEmployeeList()");
                throw ex;
            }
        }
    }
}
