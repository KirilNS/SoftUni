using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLineParams)
        {
            bool isValid = true;

            if (requestLineParams.Length != 3 || requestLineParams[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                isValid = false;
            }

            return isValid;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNullOrEmpty(queryString, nameof(queryString));

            return true;//TODO: validate query string regex
        }

        private IEnumerable<string> ParsePlainRequestHeader(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length-1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequestMethod(string[] requestLineParams)
        {
            HttpRequestMethod httpRequestMethod;

            bool result = HttpRequestMethod.TryParse(requestLineParams[0], true, out httpRequestMethod);

            if (!result)
            {
                throw new BadRequestException(string.Format(GlobalConstants.UnsuportedMethodExceptionMessage, requestLineParams[0]));

            }

            this.RequestMethod = httpRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLineParams)
        {
            this.Url = requestLineParams[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseRequestHeaders(string[] requestContents)
        {
            requestContents.Select(requestContent => requestContent.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));

        }

        //private void ParseCookies()
        //{

        //}

        private void ParseQueryParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split('?', '#')[1]
                .Split('&')
                .Select(queryParameter => queryParameter.Split('='))
                .ToList()
                .ForEach(queryParametersKeyValuePair => this.QueryData.Add(queryParametersKeyValuePair[0], queryParametersKeyValuePair[1]));
            }
            

        }

        private bool HasQueryString()
        {
            return this.Url.Split('?').Length > 1;
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {
                formData
               .Split('&')
               .Select(queryParameter => queryParameter.Split('='))
               .ToList()
               .ForEach(queryParametersKeyValuePair => this.FormData.Add(queryParametersKeyValuePair[0], queryParametersKeyValuePair[1]));
            }
           
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);

        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);
            string[] requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseRequestHeaders(this.ParsePlainRequestHeader(splitRequestContent).ToArray());
            //this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
