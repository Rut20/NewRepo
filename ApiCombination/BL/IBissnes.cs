using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCombination.BL
{
    public interface IBissnes
    {
        Task<dynamic> GetCombination(int pageNumber, int pageSize);
        IEnumerable<int> NextApi();
        int StartApi(int num);
    }
}