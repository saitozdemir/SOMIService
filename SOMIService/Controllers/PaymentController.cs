﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOMIService.Extensions;
using SOMIService.Models.Payment;
using SOMIService.Services.Payment;
using SOMIService.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SOMIService.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            //var result = _paymentService.CheckInstallments("4157920000000002", 1000);
            ////var binNumbers = new string[]
            ////{
            ////    "4543590000000006","4157920000000002","374427000000003","4766620000000001"
            ////};
            ////foreach (var bin in binNumbers)
            ////{
            ////    var result = _paymentService.CheckInstallments(bin, 100);
            ////}
            return View();
        }

        [HttpPost]
        public IActionResult CheckInstallment(string binNumber,decimal price)
        {
            var result = _paymentService.CheckInstallments(binNumber, price);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {
            var paymentModel = new PaymentModel()
            {
                Installment = model.Installment,
                Address = new AddressModel(),
                BasketList = new List<BasketModel>(),
                Customer = new CustomerModel(),
                CardModel = model.CardModel,
                Price = 1000,
                UserId = HttpContext.GetUserId(),
                Ip = Request.HttpContext.Connection.RemoteIpAddress?.ToString()
            };

            var installmentInfo = _paymentService.CheckInstallments(paymentModel.CardModel.CardNumber, paymentModel.Price);

            var installmentNumber =
                installmentInfo.InstallmentPrices.FirstOrDefault(x => x.InstallmentNumber == model.Installment);

            paymentModel.PaidPrice = decimal.Parse(installmentNumber != null ? installmentNumber.TotalPrice.Replace('.', ',') : installmentInfo.InstallmentPrices[0].TotalPrice.Replace('.', ','));

            //legacy code

            var result = _paymentService.Pay(paymentModel);
            return View();
        }


    }

   
}
