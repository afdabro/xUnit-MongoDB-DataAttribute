using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitMongoDBDataAttribute
{
    /// <summary>
    /// Test Scenario
    /// </summary>
    [Serializable]
    public class QATest : IUniqueId
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the test
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description of the test
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the request
        /// </summary>
        public List<QARequest> Request { get; set; }
       
        /// <summary>
        /// Catch all extra elements
        /// </summary>
        public BsonDocument CatchAll { get; set; }
    }
}
