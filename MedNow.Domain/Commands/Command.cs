using Flunt.Notifications;

namespace MedNow.Domain.Commands
{
    public abstract class Command : Notifiable<Notification>
    {
        public abstract void Validate();
    }
}
