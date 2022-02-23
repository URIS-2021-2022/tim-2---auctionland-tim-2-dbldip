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

        /// <summary>
        /// PaymentController constructor
        /// </summary>
        /// <param name="paymentRepository">Payment repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger service</param>
        public PaymentController(IPaymentRepository paymentRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.paymentRepository = paymentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all payments
        /// </summary>
        /// <returns>List of payments</returns>
        /// <response code="200">Returns all payments</response>
        /// <response code="404">No payment found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PaymentDto>> GetPayments()
        {
            var payments = paymentRepository.GetPayments();

            if (payments == null || payments.Count == 0)
            {
                loggerService.LogMessage("List of payments is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("List of payments returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PaymentDto>>(payments));
        }

        /// <summary>
        /// Returns payment by ID
        /// </summary>
        /// <param name="paymentId">Payment ID</param>
        /// <returns>Payment</returns>
        /// <response code="200">Returns payment by ID</response>
        /// <response code="404">No payment by ID found</response>
        [HttpGet("{paymentId}")]
        public ActionResult<PaymentDto> GetPayment(Guid paymentId)
        {
            var payment = paymentRepository.GetPaymentById(paymentId);
            if (payment == null)
            {
                loggerService.LogMessage("There is no payment with that id", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("Payment returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<PaymentDto>(payment));
        }

        /// <summary>
        /// Create new payment
        /// </summary>
        /// <param name="payment">Creation payment DTO</param>
        /// <returns>Confirmation of created applipaymentcation</returns>
        /// <response code="201">Returns confirmation of created payment</response>
        /// <response code="500">Payment creation error</response>
        [HttpPost]
        public ActionResult<PaymentConfirmationDto> CreatePayment([FromBody] PaymentCreationDto payment)
        {
            Payment paymentToCreate = mapper.Map<Payment>(payment);
            PaymentConfirmation confirmation = paymentRepository.CreatePayment(paymentToCreate);
            paymentRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetPayment", controller: "Payment", values: new { paymentId = confirmation.paymentId });
            loggerService.LogMessage("Payment created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<PaymentConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Payment modify
        /// </summary>
        /// <param name="payment">Update payment DTO</param>
        /// <returns>Confirmation of updated payment</returns>
        /// <response code="200">Returns confirmation of updated payment</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found payment by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<PaymentDto> UpdatePayment([FromBody] PaymentUpdateDto payment)
        {
            var oldPayment = paymentRepository.GetPaymentById(payment.paymentId);
            if (oldPayment == null)
            {
                loggerService.LogMessage("There is no payment with that id", "Get", LogLevel.Warning);
                return NotFound();
            }

            Payment paymentEntity = mapper.Map<Payment>(payment);
            mapper.Map(paymentEntity, oldPayment);
            paymentRepository.SaveChanges();
            loggerService.LogMessage("Payment updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<PaymentDto>(oldPayment));
        }

        /// <summary>
        /// Delete payment
        /// </summary>
        /// <param name="paymentId">Payment ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Payment deleted</response>
        /// <response code="404">Payment by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{paymentId}")]
        public IActionResult DeletePayment(Guid paymentId)
        {
            try
            {
                var paymentToDelete = paymentRepository.GetPaymentById(paymentId);
                if (paymentToDelete == null)
                {
                    loggerService.LogMessage("There is no payment with that id", "Get", LogLevel.Warning);
                    return NotFound();
                }

                paymentRepository.DeletePayment(paymentId);
                paymentRepository.SaveChanges();
                loggerService.LogMessage("Payment deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
