using ApiCombination.BL;
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
        private readonly IBissnes _bissnes;

        public CombinationController(IBissnes bissnes)
        {
            _bissnes = bissnes;
        }





        [HttpGet]
        [Route("GetStartApi/{num}")]
        public ActionResult GetStartApi(int num)
        {
            try
            {
                return Ok(_bissnes.StartApi(num));
            }
            catch (Exception ex)
            {
                throw new Exception("error in CombinationController function GetStartApi" + ex);

            }
        }


        [HttpGet]
        [Route("GetNextApi")]
        public async Task<IActionResult> GetNextApi()
        {
            try
            {
                return Ok(_bissnes.NextApi());
            }
            catch (Exception ex)
            {
                throw new Exception("error in CombinationController function GetNextApi" + ex);

            }
        }

        [HttpGet]
        [Route("GetAllApi/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllApi(int pageNumber, int pageSize)
        {
            try
            {
                var combination = await _bissnes.GetCombination(pageNumber, pageSize);
                return Ok(combination);
            }
            catch (Exception ex)
            {
                throw new Exception("error in CombinationController function GetAllApi" + ex);
            }
        }
    }
}
