using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace xUnitMongoDBDataAttribute
{
    /// <summary>
    /// QA Http Request and response validation
    /// </summary>
    public class QARequest
    {
        /// <summary> 
        /// Gets or sets the Body Content Dictionary 
        /// </summary> 
        public Dictionary<string, object> BodyContent { get; set; }

        /// <summary> 
        /// Gets or sets the Body Validation Dictionary 
        /// </summary> 
        public Dictionary<string, object> BodyValidate { get; set; }

        /// <summary>
        /// Gets or sets the Body collection to validate
        /// </summary>
        public IList<Dictionary<string, object>> BodyCollectionValidate { get; set; }

        /// <summary>
        /// Gets or sets the OData Query
        /// </summary>
        public Dictionary<string, object> ODataQuery { get; set; }

        /// <summary> 
        /// Gets or sets the request order 
        /// </summary> 
        public int RequestOrder { get; set; }

        /// <summary> 
        /// Gets or sets the Expected Response Status Code 
        /// </summary> 
        public HttpStatusCode ExpectedStatusCode { get; set; }

        /// <summary> 
        /// Gets or sets the Request Headers 
        /// </summary> 
        public Dictionary<string, object> RequestHeaders { get; set; }

        /// <summary> 
        /// Gets or sets the Expected Response Headers 
        /// </summary> 
        public Dictionary<string, object> ResponseHeaders { get; set; }

        /// <summary>
        /// Gets or sets the Request Method Type
        /// </summary>
        public RequestMethodType RequestMethod { get; set;}

        /// <summary>
        /// Gets or sets the Request Url
        /// </summary>
        public string RequestUrl { get; set; }
    }
}
