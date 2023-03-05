using Flunt.Notifications;

namespace MedNow.Domain.DefaultEntity
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
