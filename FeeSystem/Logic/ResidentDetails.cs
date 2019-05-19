using FeeSystem.Models;
using System;
using System.Globalization;

namespace FeeSystem.Logic
{
    public static class ResidentDetails
    {
        public static string ReturnPayerNumber(this Resident resident)
        {
            string payerNumber = ("0" + resident.PayerNumber);
            payerNumber = payerNumber.Substring(payerNumber.Length - 2);

            return payerNumber;
        }

        public static string FullMonthName(this Resident resident, int i)
        {
            var month = new DateTime(2019, i, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("pl"));
            return month; 
        }


    }
}
