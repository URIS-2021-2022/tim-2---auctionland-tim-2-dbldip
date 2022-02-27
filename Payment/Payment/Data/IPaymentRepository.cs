using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Entities;

namespace PaymentService.Data
{
    public interface IPaymentRepository
    {
        List<Payment> GetPayments();
        Payment GetPaymentById(Guid paymentId);
        PaymentConfirmation CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Guid paymentId);
        bool SaveChanges();

    }
}
