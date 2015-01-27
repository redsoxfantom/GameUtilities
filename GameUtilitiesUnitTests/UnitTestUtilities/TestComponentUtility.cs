using GameUtilities.Components;
using GameUtilities.Framework.Utilities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilitiesUnitTests.UnitTestUtilities
{
    /// <summary>
    /// Test component for use with Unit Tests
    /// </summary>
    public class TestComponentUtility : BaseComponent
    {
        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="timeSinceLastFrame"></param>
        /// <param name="messages"></param>
        protected override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            
        }
    }
}
