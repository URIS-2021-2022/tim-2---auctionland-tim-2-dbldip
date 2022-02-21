﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    public class PaymentConfirmation
    {
        public Guid paymentId { get; set; }
        public string accountNumber { get; set; }
        public string referenceNumber { get; set; }
        public int amount { get; set; }

        public Guid buyerId { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }

        public string PaymentPurpose { get; set; }
        public DateTime PaymentDate { get; set; }

        public DateTime date { get; set; }
        public double bestBid { get; set; }

        public string currencyCode { get; set; }
        public double currencyPrice { get; set; }

    }
}
