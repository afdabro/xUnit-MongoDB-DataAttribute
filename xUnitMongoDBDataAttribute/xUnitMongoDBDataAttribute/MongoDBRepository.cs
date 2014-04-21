// Author: Andrew F. Dabrowski
// Date: 4/20/2014
// copyright Andrew F. Dabrowski © 2014

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace xUnitMongoDBDataAttribute
{
    /// <summary>
    /// MongoDB Repository Implementation
    /// </summary>
    public class MongoDBRepository
    {
        /// <summary>
        /// Gets or sets the MongoDB Client
        /// </summary>
        public MongoClient client { get; set; }

        /// <summary>
        /// Gets or sets the MongoDB server
        /// </summary>
        public MongoServer server { get; set; }

        /// <summary>
        /// Gets or sets the MongoDB database
        /// </summary>
        public MongoDatabase database { get; set; }

        /// <summary>
        /// Gets or sets the Mongo configuration
        /// </summary>
        public MongoConfiguration mongoConfiguration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDBRepository"/> class.
        /// </summary>
        public MongoDBRepository()
        {
            mongoConfiguration = ConfigurationManager.GetSection("MongoConfiguration") as MongoConfiguration;
            client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            server = client.GetServer();
            database = server.GetDatabase(mongoConfiguration.DatabaseName);
        }

        /// <summary>
        /// Get all Entities within the collection
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <param name="collectionName">Name of collection</param>
        /// <returns>All entities in collection</returns>
        public IEnumerable<T> GetAllEntities<T>(string collectionName)
        {
            var collection = database.GetCollection<T>(collectionName);
            return collection.FindAll().AsEnumerable<T>();
        }

        /// <summary>
        /// Get all Entities within the collection specified in the Configuration settings
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns>All entities within the configuration settings collection</returns>
        public IEnumerable<T> GetAllEntities<T>()
        {
            return GetAllEntities<T>(mongoConfiguration.CollectionName);
        }

        /// <summary>
        /// Create new Entity
        /// </summary>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <param name="collectionName">Collection name</param>
        /// <param name="entity">Entity to create</param>
        /// <returns>Created Entity</returns>
        public T CreateEntity<T>(string collectionName, T entity) where T : class, IUniqueId
        {
            // If the Unique Id is not set create a new Guid
            if (entity.Id == null)
                entity.Id = new Guid();

            var collection = database.GetCollection<T>(collectionName);
            var result = collection.Insert(entity);

            if (result.Ok)
                return entity;
            else
            {
                throw new Exception(result.ErrorMessage);
            }
        }

        /// <summary>
        /// Create entity in Collection set in Configuration settings
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Entity to create</param>
        /// <returns>Created entity</returns>
        public T CreateEntity<T>(T entity) where T : class, IUniqueId
        {
            return CreateEntity<T>(mongoConfiguration.CollectionName, entity);
        }

        /// <summary>
        /// Get specific entities by query
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="collectionName">Name of collection</param>
        /// <param name="propertyName">Name of property to query</param>
        /// <param name="value">Query value</param>
        /// <returns>Collection of entities</returns>
        public IEnumerable<T> GetSpecificEntities<T>(string collectionName, string propertyName, object value)
        {
            var collection = database.GetCollection<T>(collectionName);

            var searchQuery = Query.EQ(propertyName, BsonTypeMapper.MapToBsonValue(value));
            return collection.Find(searchQuery).AsEnumerable<T>();
        }

        /// <summary>
        /// Get specific entities by query
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <returns>Collection of entities</returns>
        public IEnumerable<T> GetSpecificEntities<T>()
        {
            Type queryType = Type.GetType(mongoConfiguration.QueryValueType);

            var queryValue = Convert.ChangeType(mongoConfiguration.QueryValue, queryType);
            return GetSpecificEntities<T>(mongoConfiguration.CollectionName, mongoConfiguration.QueryProperty, queryValue);
        }
    }
}
