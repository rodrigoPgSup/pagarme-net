﻿//
// Transaction.cs
//
// Author:
//       Jonathan Lima <jonathan@pagar.me>
//
// Copyright (c) 2014 Pagar.me
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;

namespace PagarMe
{
    public class Transaction : Base.Model
    {
        protected override string Endpoint { get { return "/transactions"; } }

        public Subscription Subscription
        {
            get { return GetAttribute<Subscription>("subscription"); }
            set { SetAttribute("subscription", value); }
        }

        public Card Card
        {
            get { return GetAttribute<Card>("card"); }
            set { SetAttribute("card", value); }
        }

        public Customer Customer
        {
            get { return GetAttribute<Customer>("customer"); }
            set { SetAttribute("customer", value); }
        }

        public Address Address
        {
            get { return GetAttribute<Address>("address"); }
            set { SetAttribute("address", value); }
        }

        public Phone Phone
        {
            get { return GetAttribute<Phone>("phone"); }
            set { SetAttribute("phone", value); }
        }

        public TransactionStatus Status
        {
            get { return GetAttribute<TransactionStatus>("status"); }
            set { SetAttribute("status", value); }
        }

        public string CardHash
        {
            get { return GetAttribute<string>("card_hash"); }
            set { SetAttribute("card_hash", value); }
        }

        public string CardNumber
        {
            get { return GetAttribute<string>("card_number"); }
            set { SetAttribute("card_number", value); }
        }

        public string CardExpirationDate
        {
            get { return GetAttribute<string>("card_expiration_date"); }
            set { SetAttribute("card_expiration_date", value); }
        }

        public string StatusReason
        {
            get { return GetAttribute<string>("status_reason"); }
            set { SetAttribute("status_reason", value); }
        }

        public string AcquirerResponseCode
        {
            get { return GetAttribute<string>("acquirer_response_code"); }
            set { SetAttribute("acquirer_response_code", value); }
        }

        public string AcquirerName
        {
            get { return GetAttribute<string>("acquirer_name"); }
            set { SetAttribute("acquirer_name", value); }
        }

        public string AuthorizationCode
        {
            get { return GetAttribute<string>("authorization_code"); }
            set { SetAttribute("authorization_code", value); }
        }

        public string SoftDescriptor
        {
            get { return GetAttribute<string>("soft_descriptor"); }
            set { SetAttribute("soft_descriptor", value); }
        }

        public int Tid
        {
            get { return GetAttribute<int>("tid"); }
            set { SetAttribute("tid", value); }
        }

        public int Nsu
        {
            get { return GetAttribute<int>("nsu"); }
            set { SetAttribute("nsu", value); }
        }

        public int Amount
        {
            get { return GetAttribute<int>("amount"); }
            set { SetAttribute("amount", value); }
        }

        public int? Installments
        {
            get { return GetAttribute<int?>("installments"); }
            set { SetAttribute("installments", value); }
        }

        public int Cost
        {
            get { return GetAttribute<int>("cost"); }
            set { SetAttribute("cost", value); }
        }

        public string CardHolderName
        {
            get { return GetAttribute<string>("card_holder_name"); }
            set { SetAttribute("card_holder_name", value); }
        }

        public string CardCvv
        {
            get { return GetAttribute<string>("card_cvv"); }
            set { SetAttribute("card_cvv", value); }
        }

        public string CardLastDigits
        {
            get { return GetAttribute<string>("card_last_digits"); }
            set { SetAttribute("card_last_digits", value); }
        }

        public string CardFirstDigits
        {
            get { return GetAttribute<string>("card_first_digits"); }
            set { SetAttribute("card_first_digits", value); }
        }

        public CardBrand CardBrand
        {
            get { return GetAttribute<CardBrand>("card_brand"); }
            set { SetAttribute("card_brand", value); }
        }

        public string PostbackUrl
        {
            get { return GetAttribute<string>("postback_url"); }
            set { SetAttribute("postback_url", value); }
        }

        public PaymentMethod PaymentMethod
        {
            get { return GetAttribute<PaymentMethod>("payment_method"); }
            set { SetAttribute("payment_method", value); }
        }

        public float? AntifraudScore
        {
            get { return GetAttribute<float?>("antifraud_score"); }
            set { SetAttribute("antifraud_score", value); }
        }

        public string BoletoUrl
        {
            get { return GetAttribute<string>("boleto_url"); }
            set { SetAttribute("boleto_url", value); }
        }

        public DateTime? BoletoExpirationDate
        {
            get { return GetAttribute<DateTime?>("boleto_expiration_date"); }
            set { SetAttribute("boleto_expiration_date", value); }
        }

        public string BoletoBarcode
        {
            get { return GetAttribute<string>("boleto_barcode"); }
            set { SetAttribute("boleto_barcode", value); }
        }

        public string Referer
        {
            get { return GetAttribute<string>("referer"); }
            set { SetAttribute("referer", value); }
        }

        public string IP
        {
            get { return GetAttribute<string>("ip"); }
            set { SetAttribute("ip", value); }
        }

        public bool? ShouldCapture
        {
            get { return GetAttribute<bool>("capture"); }
            set { SetAttribute("capture", value); }
        }

        public Base.AbstractModel Metadata
        {
            get { return GetAttribute<Base.AbstractModel>("metadata"); }
            set { SetAttribute("metadata", value); }
        }

		public SplitRule[] SplitRules
		{
			get { return GetAttribute<SplitRule[]>("split_rules"); }
			set { SetAttribute("split_rules", value); }
		}

        public Transaction()
            : this(null)
        {

        }

        public Transaction(PagarMeService service)
            : base(service)
        {
            Metadata = new Base.AbstractModel(Service);
        }

        public void Capture(int? amount = null)
        {
            var request = CreateRequest("POST", "/capture");

            if (amount.HasValue)
                request.Query.Add(new Tuple<string, string>("amount", amount.Value.ToString()));

            ExecuteSelfRequest(request);
        }

        public async void CaptureAsync(int? amount = null)
        {
            var request = CreateRequest("POST", "/capture");

            if (amount.HasValue)
                request.Query.Add(new Tuple<string, string>("amount", amount.Value.ToString()));

            await ExecuteSelfRequestAsync(request);
        }

        public void Refund()
        {
            var request = CreateRequest("POST", "/refund");

            ExecuteSelfRequest(request);
        }

        public async void RefundAsync()
        {
            var request = CreateRequest("POST", "/refund");

            await ExecuteSelfRequestAsync(request);
        }

        protected override void CoerceTypes()
        {
            base.CoerceTypes();

            CoerceAttribute("card", typeof(Card));
            CoerceAttribute("customer", typeof(Customer));
            CoerceAttribute("address", typeof(Address));
            CoerceAttribute("phone", typeof(Phone));

            var subscriptionId = GetAttribute<object>("subscription_id");

            if (subscriptionId != null)
                SetAttribute("subscription", Service.Subscriptions.Find(subscriptionId.ToString(), false));
        }

        protected override PagarMe.Base.NestedModelSerializationRule SerializationRuleForField(string field, Base.SerializationType type)
        {
            if (field == "customer" && type != Base.SerializationType.Shallow)
                return PagarMe.Base.NestedModelSerializationRule.Full;

            return base.SerializationRuleForField(field, type);
        }
    }
}

