﻿//--------------------------------------------------
// <copyright file="WebServiceWithDriverSend.cs" company="Magenic">
//  Copyright 2021 Magenic, All rights Reserved
// </copyright>
// <summary>Web service send unit tests</summary>
//--------------------------------------------------
using Magenic.Maqs.BaseWebServiceTest;
using Magenic.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text;
using WebServiceTesterUnitTesting.Model;

namespace WebServiceTesterUnitTesting
{
    /// <summary>
    /// Test class for unit tests
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WebServiceWithDriverSend : BaseWebServiceTest
    {
        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendWithExpectedSuccess()
        {
            var result = this.WebServiceDriver.SendWithResponse(GetValidRequestMessageWithContent(), null);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendWithExpectedStatusCode()
        {
            var result = this.WebServiceDriver.SendWithResponse(GetValidRequestMessageWithContent(), MediaType.PlainText, HttpStatusCode.OK);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendExpectedSuccess()
        {
            var result = this.WebServiceDriver.Send(GetValidZedRequestMessageWithContent(), MediaType.PlainText);
            Assert.AreEqual("\"ZEDTest\"", result.ToString());
        }

        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendExpectedStatusCode()
        {
            var result = this.WebServiceDriver.Send(GetValidZedRequestMessageWithContent(), MediaType.PlainText, HttpStatusCode.OK);
            Assert.AreEqual("\"ZEDTest\"", result.ToString());
        }


        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendExpectedStatusCode2()
        {
HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(WebServiceVerb.Get), "/api/XML_JSON/GetAllProducts");

var result = this.WebServiceDriver.SendWithResponse(message, MediaType.PlainText);
Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendAndGetDeserializeResponseExpectedSucces()
        {
            var result = this.WebServiceDriver.Send<ArrayOfProduct>(GetValidRequestMessageWithoutContent(), MediaType.AppXml);
            Assert.AreEqual(3, result.Product.Length, "Expected 3 products to be returned");
        }

        /// <summary>
        /// Send and verify status codes
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void SendAndGetDeserializeResponseExpectedStatueCode()
        {
            var result = this.WebServiceDriver.Send<ArrayOfProduct>(GetValidRequestMessageWithoutContent(), MediaType.AppXml, HttpStatusCode.OK);
            Assert.AreEqual(3, result.Product.Length, "Expected 3 products to be returned");
        }

        /// <summary>
        /// Get a valid request message
        /// </summary>
        /// <returns>A valid request message</returns>
        private HttpRequestMessage GetValidRequestMessageWithContent()
        {
            Product product = new Product
            {
                Category = "ff",
                Id = 4,
                Name = "ff",
                Price = 3.25f
            };

            return new HttpRequestMessage(new HttpMethod(WebServiceVerb.Post), "/api/XML_JSON/Post")
            {
                Content = WebServiceUtils.MakeStreamContent(product, Encoding.UTF8, MediaType.AppXml)
            };
        }

        /// <summary>
        /// Get a valid custom request message
        /// </summary>
        /// <returns>A valid request message</returns>
        private HttpRequestMessage GetValidZedRequestMessageWithContent()
        {
            return new HttpRequestMessage(new HttpMethod("ZED"), "/api/ZED")
            {
                Content = WebServiceUtils.MakeStringContent("ZEDTest", Encoding.UTF8, "text/plain")
            };
        }
        

        /// <summary>
        /// Get a valid request message without content
        /// </summary>
        /// <returns>A valid request message</returns>
        private HttpRequestMessage GetValidRequestMessageWithoutContent()
        {
            return new HttpRequestMessage(new HttpMethod(WebServiceVerb.Get), "/api/XML_JSON/GetAllProducts");
        }
    }
}
