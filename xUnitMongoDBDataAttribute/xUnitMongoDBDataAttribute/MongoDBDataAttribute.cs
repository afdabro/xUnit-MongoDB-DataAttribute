// Author: Andrew F. Dabrowski
// Date: 4/20/2014
// copyright Andrew F. Dabrowski © 2014


using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this.RegisterClass();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDBDataAttribute"/> class.
        /// </summary>
        public MongoDBDataAttribute()
        {
            this.repository = new MongoDBRepository();
            this.RegisterClass();
        }

        /// <summary>
        /// Register QA Test
        /// </summary>
        public void RegisterClass()
        {
            BsonClassMap.RegisterClassMap<QATest>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.Name).SetDefaultValue("Test");
                //cm.MapCreator(p => new MyTestClass(p.FirstName, p.LastName));
                cm.SetExtraElementsMember(cm.GetMemberMap(c => c.CatchAll));
            });
        }

        /// <summary>
        /// Get Data from MongoDB instance
        /// </summary>
        /// <param name="methodUnderTest">The method currently under test</param>
        /// <param name="parameterTypes">Parameter types to return</param>
        /// <returns></returns>
        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            if (this.CheckQueryOptions())
                return repository.GetSpecificEntities<QATest>().Select(e => new object[] { e });

            return repository.GetAllEntities<QATest>().Select(e => new object[] { e });
        }

        /// <summary>
        /// Check if using query
        /// </summary>
        /// <returns></returns>
        public bool CheckQueryOptions()
        {
            bool IsQuery = true;
            if (String.IsNullOrWhiteSpace(this.repository.mongoConfiguration.QueryProperty))
                IsQuery = false;

            if (String.IsNullOrWhiteSpace(this.repository.mongoConfiguration.QueryValue))
                IsQuery = false;

            if (String.IsNullOrWhiteSpace(this.repository.mongoConfiguration.QueryValueType))
                IsQuery = false;

            return IsQuery;
        }
    }
}
