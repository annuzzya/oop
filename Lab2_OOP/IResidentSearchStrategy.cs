using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryApp
{
    public interface IResidentSearchStrategy
    {
        List<Resident> Search(string xmlFilePath, SearchCriteria criteria);
    }
}
