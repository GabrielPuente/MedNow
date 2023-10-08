using Flunt.Notifications;

namespace MedNow.Application.Commands
{
    public abstract class Command : Notifiable<Notification>
    {
        public abstract void Validate();
    }
}
