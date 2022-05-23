using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public enum CountryCodes
    {
        RO,UK,US
    }


    static public class ShippingRate
    {

        private static  Dictionary<CountryCodes, double> countryRate = new Dictionary<CountryCodes, double>();

        //return rate(double) for specific country(enum)
        public static double getRateForCountry(CountryCodes country) { return countryRate[country]; }
        public static void setCountryRate(CountryCodes  country, double rate){ countryRate[country] = rate; }

    }
}
