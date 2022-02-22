using AutoMapper;
using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext context;
        private readonly IMapper mapper;
        public PaymentRepository(PaymentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PaymentConfirmation CreatePayment(Payment payment)
        {
            var createdEntity = context.Add(payment);
            return mapper.Map<PaymentConfirmation>(createdEntity.Entity);
        }

        public void DeletePayment(Guid paymentId)
        {
            Payment payment = GetPaymentById(paymentId);
            context.Remove(payment);
        }

        public Payment GetPaymentById(Guid paymentId)
        {
            return context.Payments.FirstOrDefault(e => e.paymentId == paymentId);
        }

        public List<Payment> GetPayments()
        {
            return context.Payments.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
