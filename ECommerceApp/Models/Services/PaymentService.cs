using System;
using AuthorizeNet.Api.Contracts.V1;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using AuthorizeNet.Api.Controllers;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Pages.Account;

namespace ECommerceApp.Models.Services
{
    public class PaymentService : IPayment
    {
        private IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public string Run(PaymentInput input)
        {
            //controllers.Base for AuthorizeNet:
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AN-ApiLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AN-TransactionKey"]
            };

            //set a credit card
            //can be hard coded or brought in through secrets

            //DO NOT ask the user for their real credit card number. Can put a few testNumbers in a dropdown menu.
            var creditCard = new creditCardType
            {
                cardNumber = input.CreditCard,
                expirationDate = "1022",
                cardCode = "102"
            };

            customerAddressType billingAddress = GetAddress(input);

            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = Convert.ToDecimal(input.Amount),
                payment = paymentType,
                billTo = billingAddress
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            var controller = new createTransactionController(request);

            controller.Execute();

            var response = controller.GetApiResponse();

            if(response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "success";
                }

            }
            return "failed to process";
        }

        /// <summary>
        /// Get the address from user's input
        /// </summary>
        /// <param name="input">Payment model</param>
        /// <returns>Payment model</returns>
        public customerAddressType GetAddress(PaymentInput input)
        {
            //make a call to the db to get the billing address
            //or you bring in what the user typed into the entry
            customerAddressType address = new customerAddressType
            {
                firstName = input.FirstName,
                lastName = input.LastName,
                address = input.ShippingAddress,
                city = input.City,
                state = input.State
            };
            
            return address;
        }
    }
}
