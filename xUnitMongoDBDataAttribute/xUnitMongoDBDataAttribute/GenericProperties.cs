using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitMongoDBDataAttribute
{

    /// <summary>
    /// Unique Id interface
    /// </summary>
    public interface IUniqueId
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        Guid Id { get; set; }
    }

    /// <summary>
    /// Generic Properties Class to store object content
    /// </summary>
    public class GenericProperties : IUniqueId
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
