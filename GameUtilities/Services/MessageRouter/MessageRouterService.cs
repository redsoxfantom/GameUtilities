using GameUtilities.Services;

namespace GameUtilities.Services.MessageRouter
{
    /// <summary>
    /// The message router service.
    /// Uses a subscription-based model where Components and Services can register for Topics, and then retrieve Messages each Frame
    /// </summary>
    public class MessageRouterService : IMessageRouterService, BaseService
    {

    }
}
