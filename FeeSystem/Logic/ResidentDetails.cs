using FeeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
