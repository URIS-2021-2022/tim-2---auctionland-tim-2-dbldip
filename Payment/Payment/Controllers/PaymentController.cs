using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using PaymentService.Data;
using PaymentService.Entities;
using PaymentService.Models;
using PaymentService.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Controllers
{
    [Controller]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public PaymentController(IPaymentRepository paymentRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.paymentRepository = paymentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PaymentDto>> GetPayments()
        {
            var payments = paymentRepository.GetPayments();

            if (payments == null || payments.Count == 0)
            {
                this.loggerService.LogMessage("List of payments is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            this.loggerService.LogMessage("List of payments is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PaymentDto>>(payments));
        }

        [HttpGet("{paymentId}")]
        public ActionResult<PaymentDto> GetPayment(Guid paymentId)
        {
            var payment = paymentRepository.GetPaymentById(paymentId);
            if (payment == null)
            {
                this.loggerService.LogMessage("There is no payment with that id", "Get", LogLevel.Warning);
                return NoContent();
            }

            this.loggerService.LogMessage("Payment is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<PaymentDto>(payment));
        }

        [HttpPost]
        public ActionResult<PaymentConfirmationDto> CreatePayment([FromBody] PaymentCreationDto payment)
        {
            Payment paymentToCreate = mapper.Map<Payment>(payment);
            PaymentConfirmation confirmation = paymentRepository.CreatePayment(paymentToCreate);
            paymentRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetPayment", controller: "Payment", values: new { paymentId = confirmation.paymentId });
            this.loggerService.LogMessage("Payment created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<PaymentConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<PaymentDto> UpdatePayment(PaymentUpdateDto payment)
        {
            var oldPayment = paymentRepository.GetPaymentById(payment.paymentId);
            if (oldPayment == null)
                return NotFound();

            Payment paymentEntity = mapper.Map<Payment>(payment);
            mapper.Map(paymentEntity, oldPayment);
            paymentRepository.SaveChanges();
            this.loggerService.LogMessage("Payment updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<PaymentDto>(oldPayment));
        }

        [HttpDelete("{paymentId}")]
        public IActionResult DeletePayment(Guid paymentId)
        {
            try
            {
                var paymentToDelete = paymentRepository.GetPaymentById(paymentId);
                if (paymentToDelete == null)
                    return NotFound();

                paymentRepository.DeletePayment(paymentId);
                paymentRepository.SaveChanges();
                this.loggerService.LogMessage("Payment deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
