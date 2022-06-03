using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetNextAPIController : ControllerBase
    {
        public static int[] lastCombination;
        int n;

        [HttpGet("{num}")]
        public IEnumerable<int> GetCombination(int num)
        {
           
            int[] currentCombination = new int[num];

            if (lastCombination == null)
            {
                for (int i = 1; i <= num; i++)
                {
                    currentCombination[i - 1] = i;
                }
                lastCombination = currentCombination;
            }
            else
            {
                currentCombination = lastCombination;
                for (int i = 0; i < num; i++)
                {

                    if (currentCombination[i] == num && i != 0)
                    {
                        currentCombination[i - 1] = lastCombination[i];
                        currentCombination[i] = lastCombination[i - 1];
                    }
                }

            }
            lastCombination = currentCombination;
            return currentCombination;
        }

    }
}
