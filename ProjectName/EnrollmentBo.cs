using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
    public class EnrollmentBo : IEnrollmentBo
    {
        public EnrollmentBo(IUtilityBo utilityBo,
                            IEnrollmentDao enrollmentDao)
        {
            this.utilityBo = utilityBo;
            this.enrollmentDao = enrollmentDao;
        }
        
        private readonly IUtilityBo utilityBo; 

        private readonly IEnrollmentDao enrollmentDao;

        private readonly string successCode = "0000";

        public string Enroll(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account", "Account cannot be null.");

            if (!utilityBo.UtilityIsValid(account.UtilityId))
                throw new ArgumentException(string.Format("The utility with id {0} could not be found.", account.UtilityId), "account.UtilityId");

            enrollmentDao.Save(account);

            return successCode;
        }
    }
}
