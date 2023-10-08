using Flunt.Notifications;

namespace MedNow.Application.Commands
{
    public class CommandResponse
    {
        public CommandResponse(IReadOnlyCollection<Notification> notifications, string message)
            : this(notifications)
        {
            Message = message;
        }

        public CommandResponse(IReadOnlyCollection<Notification> notifications)
        {
            Notifications = notifications;
        }

        public IReadOnlyCollection<Notification> Notifications { get; protected set; }

        public bool IsValid => Notifications == null || Notifications.Count == 0;

        public string Message { get; private set; }
    }

    public class CommandResponse<TData> : CommandResponse
    {
        public CommandResponse(TData data, IReadOnlyCollection<Notification> notifications, string message)
            : base(notifications, message)
        {
            Data = data;
        }

        public CommandResponse(TData data, string message)
            : this(data, null, message)
        {
        }

        public CommandResponse(TData data)
            : this(data, null, null)
        {
        }

        public CommandResponse(TData data, IReadOnlyCollection<Notification> notifications)
            : this(data, notifications, null)
        {
        }

        public TData Data { get; }
    }
}
