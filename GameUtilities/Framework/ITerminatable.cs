using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Framework
{
    /// <summary>
    /// Interface for objects that can shut down
    /// </summary>
    public interface ITerminatable
    {
        /// <summary>
        /// Shut down the object
        /// </summary>
        void Terminate();
    }
}
