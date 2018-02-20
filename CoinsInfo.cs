using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    /// <summary>
    /// Holds all the roman and credits coins and its values.
    /// </summary>
    public class CoinsInfo
    {

        /// <summary>
        /// Gets or sets the roman coin values.
        /// </summary>
        /// <value>
        /// The roman coin values in roman numeral format.
        /// </value>
        public Dictionary<string, string> RomanCoinValues { get; set; }

        /// <summary>
        /// Gets or sets the credit coin values.
        /// </summary>
        /// <value>
        /// The credit coin values as <c>double</c>.
        /// </value>
        public Dictionary<string, double> CreditCoinValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinsInfo"/> class.
        /// </summary>
        public CoinsInfo()
        {
            this.RomanCoinValues = new Dictionary<string, string>();
            this.CreditCoinValues = new Dictionary<string, double>();
        }
    }
}
