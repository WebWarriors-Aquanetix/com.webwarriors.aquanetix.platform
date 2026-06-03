using Cortex.Mediator.Notifications;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Events;

namespace WebWarriors.Aquanetix.Platform.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}