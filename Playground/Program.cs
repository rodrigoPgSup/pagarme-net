﻿//
// Program.cs
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
using System.Linq;
using PagarMe;
using Newtonsoft.Json;

namespace Playground
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			PagarMeService.DefaultApiKey = "ak_test_TSgC3nvXtdYnDoGKgNLIOfk3TFfkl9";


			PagarMeService.DefaultEncryptionKey = "ek_test_UT6AN4fDN3BCUgo6kxUiOq6S20dbKc";


			BankAccount b = new BankAccount ();

			b.Agencia = "0196";
			b.AgenciaDv = "0";
			b.Conta = "05392";
			b.ContaDv = "0";
			b.BankCode = "0341";
			b.DocumentNumber = "05737104141";
			b.LegalName = "JONATHAN LIMA";
			b.Save();

			Recipient r1 = PagarMeService.GetDefaultService ().Recipients.Find("re_ci76hxnym00b8dw16y3hdxb21");
			Recipient r2 = PagarMeService.GetDefaultService ().Recipients.Find("re_ci7nheu0m0006n016o5sglg9t");
			Recipient r3 = new Recipient();

			r3.BankAccount = b;
			r3.TransferEnabled = true;
			r3.TransferInterval = TransferInterval.Weekly;
			r3.TransferDay = 1;
			r3.Save();

			Transaction t = new Transaction();

			t.SplitRules = new[] {
				new SplitRule {
					Recipient = r1,
					Percentage = 10,
					ChargeProcessingFee = true,
					Liable = true
				},
				new SplitRule {
					Recipient = r2,
					Percentage = 40,
					ChargeProcessingFee = false,
					Liable = false
				},
				new SplitRule {
					Recipient = r3,
					Percentage = 50,
					ChargeProcessingFee = false,
					Liable = false
				}
			};

			t.PaymentMethod = PaymentMethod.Boleto;
			t.Amount = 10000;
			t.Save();

        }
    }
}

