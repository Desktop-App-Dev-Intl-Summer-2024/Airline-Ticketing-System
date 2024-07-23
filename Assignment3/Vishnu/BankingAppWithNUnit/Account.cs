using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppWithNUnit
{
    public class Account
    {
        public double endingBalance { get; set; }
        public int numberOfChecks { get; set; }

        public Account() {
            this.endingBalance = 0.0;
            this.numberOfChecks = 0;
        }


        public double getServiceCharges()
        {
            double serviceCharges = 10.0;

            if (this.numberOfChecks < 20)
            {
                serviceCharges += 0.1 * this.numberOfChecks;
            }
            else if (this.numberOfChecks < 40)
            {
                serviceCharges += 0.08 * this.numberOfChecks;
            }
            else if (this.numberOfChecks < 60)
            {
                serviceCharges += 0.06 * this.numberOfChecks;
            }
            else
            {
                serviceCharges += 0.04 * this.numberOfChecks;
            }

            if (this.endingBalance < 400)
            {
                serviceCharges += 15;
            }

            return serviceCharges;
        }
    }
}
