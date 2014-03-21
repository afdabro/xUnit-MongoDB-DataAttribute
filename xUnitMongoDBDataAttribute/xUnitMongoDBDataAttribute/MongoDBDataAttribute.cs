// Author: Andrew F. Dabrowski
// Date: 3/20/2014
// copyright© 2014


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace xUnitMongoDBDataAttribute
{
    /// <summary>
    /// MongoDB Data Source Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MongoDBDataAttribute : DataAttribute
    {
        /// <summary>
        /// MongoDB Repository
        /// </summary>
        private MongoDBRepository repository;
        
        /// <summary>
        /// Collection name
        /// </summary>
        private string _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDBDataAttribute"/> class.
        /// </summary>
        /// <param name="collectionName">Name of collection</param>
        public MongoDBDataAttribute(string collectionName)
        {
            this._collection = collectionName;
            this.repository = new MongoDBRepository();
        }

        /// <summary>
        /// Get Data from MongoDB instance
        /// </summary>
        /// <param name="methodUnderTest">The method currently under test</param>
        /// <param name="parameterTypes">Parameter types to return</param>
        /// <returns></returns>
        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            return repository.GetAllEntities<GenericTestEntity>(_collection).Select(e => new object[] { e });
        }
    }
}
