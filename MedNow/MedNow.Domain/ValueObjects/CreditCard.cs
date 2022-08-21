namespace MedNow.Domain.ValueObjects
{
    public class CreditCard
    {
        public Guid OrderId { get; private set; }

        public long Number { get; set; }

        public string Name { get; private set; }

        public int Cvv { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public CreditCard(long number, string name, int cvv, DateTime expirationDate)
        {
            Number = number;
            Name = name;
            Cvv = cvv;
            ExpirationDate = expirationDate;
        }

        public void SetOrderId(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
