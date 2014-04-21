// Author: Andrew F. Dabrowski
// Date: 4/20/2014
// copyright Andrew F. Dabrowski © 2014

using System;
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
}
