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

        [Test]
        public void TestChargesWithBalanceAbove400TenChecks()
        {
            account.endingBalance = 500.0;
            account.numberOfChecks = 10;

            double expectedResult = 10.0 + account.numberOfChecks * 0.10;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }

        [Test]
        public void TestChargesWithBalanceAbove400TwentyChecks()
        {
            account.endingBalance = 500.0;
            account.numberOfChecks = 20;

            double expectedResult = 10.0 + account.numberOfChecks * 0.08;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }

        [Test]
        public void TestChargesWithBalanceAbove400FourtyChecks()
        {
            account.endingBalance = 500.0;
            account.numberOfChecks = 40;

            double expectedResult = 10.0 + account.numberOfChecks * 0.06;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }

        [Test]
        public void TestChargesWithBalanceAbove400SixtyChecks()
        {
            account.endingBalance = 500.0;
            account.numberOfChecks = 60;

            double expectedResult = 10.0 + account.numberOfChecks * 0.04;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }

        [Test]
        public void TestChargesWithBalanceBelow400SixtyChecks()
        {
            account.endingBalance = 300.0;
            account.numberOfChecks = 60;

            double expectedResult = 10.0 + account.numberOfChecks * 0.04 + 15.0;

            double result = account.getServiceCharges();

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
    }
}