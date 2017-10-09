using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
    public class UtilityBo : IUtilityBo
    {
        public bool UtilityIsValid(int utilityId)
        {
            return utilityId != 0;
        }
    }
}
