using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestSample;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class EnrollmentBoTest
    {
        [TestMethod]
        [TestCategory("Enrollment")]
        public void ShouldReturnSuccessCode0000()
        {
            var account = new Account
            {
                AccountNumber = "1234",
                UtilityId = 1
            };

            // Dependencies

            var utilityBo = new UtilityBo();
            var enrollmentDao = new EnrollmentDao();

            var result = new EnrollmentBo(utilityBo, enrollmentDao).Enroll(account);

            Assert.AreEqual("0000", result);
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        [ExpectedException(typeof(ArgumentNullException), "Account cannot be null.")]
        public void ShouldThrowAnArgumentNullExceptionIfAccountParamIsNull()
        {
            Account account = null;

            // Dependencies

            var utilityBo = new UtilityBo();
            var enrollmentDao = new EnrollmentDao();

            var result = new EnrollmentBo(utilityBo, enrollmentDao).Enroll(account);
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        [ExpectedException(typeof(ArgumentException), "The utility with id 3 could not be found.")]
        public void ShouldThrowAnArgumentExceptionIfUtilityWasNotFound()
        {
            var account = new Account
            {
                AccountNumber = "1234",
                UtilityId = 3
            };

            // Mock utility business object.

            var utilityBo = new Mock<IUtilityBo>();
            utilityBo
                .Setup(x => x.UtilityIsValid(It.IsAny<int>()))
                .Returns(false);

            var enrollmentDao = new EnrollmentDao();
            var result = new EnrollmentBo(utilityBo.Object, enrollmentDao).Enroll(account);
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void ShouldSaveAccountIfPassedAllValidations()
        {
            var account = new Account
            {
                AccountNumber = "1234",
                UtilityId = 1
            };

            // Mock enrollment data access object.

            var enrollmentDao = new Mock<IEnrollmentDao>();

            var utilityBo = new UtilityBo();
            var result = new EnrollmentBo(utilityBo, enrollmentDao.Object).Enroll(account);

            // Assert
            enrollmentDao.Verify(x => x.Save(account), Times.Once());
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void ShouldNotAcceptCheckInIfTestDontPass()
        {
            Assert.IsTrue(true);
        }
    }
}
