using BankingAppWithNUnit;

namespace BankingAppTest
{
    public class Tests
    {
        Account account = null;
        [SetUp]
        public void Setup()
        {
            account = new Account();
        }

        [Test]
        public void TestChargesWithBalanceAbove400ZeroChecks()
        {
            account.endingBalance = 500.0;
            account.numberOfChecks = 0;

            double expectedResult = 10.0;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
    }
}