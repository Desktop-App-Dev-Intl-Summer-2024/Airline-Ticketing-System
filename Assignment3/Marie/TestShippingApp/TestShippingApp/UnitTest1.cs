using ShippingAppWithNUnit;

namespace TestShippingApp
{
    public class Tests
    {
        Freight freight = null;
        [SetUp]
        public void Setup()
        {
            freight = new Freight();
        }

        [Test]
        public void TestPackage2kg400mi()
        {
            freight.weight = 2;
            freight.distance = 400;

            double expectedResult = 1.1;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage2kg600mi()
        {
            freight.weight = 2;
            freight.distance = 600;

            double expectedResult = 2.2;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage5kg400mi()
        {
            freight.weight = 5;
            freight.distance = 400;

            double expectedResult = 2.2;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage5kg600mi()
        {
            freight.weight = 5;
            freight.distance = 600;

            double expectedResult = 4.4;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage8kg400mi()
        {
            freight.weight = 8;
            freight.distance = 400;

            double expectedResult = 3.7;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage8kg600mi()
        {
            freight.weight = 8;
            freight.distance = 600;

            double expectedResult = 7.4;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage12kg400mi()
        {
            freight.weight = 12;
            freight.distance = 400;

            double expectedResult = 4.8;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void TestPackage12kg600mi()
        {
            freight.weight = 12;
            freight.distance = 600;

            double expectedResult = 9.6;
            double actualResult = freight.totalShippingCharges(freight.weight, freight.distance);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }
    }
}