using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CombinationController : ControllerBase
    {


        private readonly ILogger<CombinationController> _logger;

        public CombinationController(ILogger<CombinationController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetStartApi/{num}")]
        public int GetStartApi(int num)
        {
            try {
            return BL.Bissnes.StartApi(num);
            }
            catch(Exception ex)
            {
                throw new Exception("error in CombinationController function GetStartApi" + ex);

            }
        }
    

        [HttpGet]
        [Route("GetNextApi")]
        public IEnumerable<int> GetNextApi()
        {
            try
            {
                return BL.Bissnes.NextApi();
            }
            catch(Exception ex)
            {
                throw new Exception("error in CombinationController function GetNextApi" + ex);

            }
        }

        [HttpGet]
        [Route("GetAllApi/{pageNumber}/{pageSize}")]
        public async Task<dynamic> GetAllApi(int pageNumber, int pageSize)
        {
            try
            {
                return BL.Bissnes.GetCombination(pageNumber, pageSize);
            }
            catch(Exception ex)
            {
                throw new Exception("error in CombinationController function GetAllApi" + ex);
            }
        }
    }
}
