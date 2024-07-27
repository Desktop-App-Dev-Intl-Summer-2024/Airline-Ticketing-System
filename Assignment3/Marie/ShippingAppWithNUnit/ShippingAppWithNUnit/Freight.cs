using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAppWithNUnit
{
    public class Freight
    {
        public double weight { get; set; }
        public double distance { get; set; }

        public Freight()
        {
            this.weight = 0;
            this.distance = 0;
        }
        public Freight(double weight, double distance)
        {
            this.weight = weight;
            this.distance = distance;
        }

        public double totalShippingCharges(double weight, double distance)
        {
            double totalCharges = 0.0;
            double shippingRate = 0.0;
            int distanceBlocks = (int)Math.Ceiling(distance / 500);

            if (weight <= 2.0)
            {
                shippingRate = 1.10;
            }
            else if (weight > 2.0 && weight <= 6.0)
            {
                shippingRate = 2.20;
            }
            else if (weight > 6.0 && weight <= 610.0)
            {
                shippingRate = 3.70;
            }
            else if (weight > 10.0)
            {
                shippingRate = 4.80;
            }

            totalCharges = shippingRate * distanceBlocks;
            return totalCharges;
        }
    }
}
