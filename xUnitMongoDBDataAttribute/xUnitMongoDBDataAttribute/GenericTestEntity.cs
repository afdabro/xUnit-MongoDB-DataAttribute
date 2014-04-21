// Author: Andrew F. Dabrowski
// Date: 3/20/2014
// copyright© 2014

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitMongoDBDataAttribute
{

    /// <summary>
    /// Generic Test Entity Class to store object content
    /// </summary>
    public class GenericTestEntity : IUniqueId
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the entity properties
        /// </summary>
        public IDictionary<string, KeyValuePair<object, bool>> entity { get; set; }

        /// <summary>
        /// Gets or sets the attrbutes applied to an entity
        /// </summary>
        public IList<IDictionary<string, KeyValuePair<object, bool>>> attributes { get; set; }

    }
}
