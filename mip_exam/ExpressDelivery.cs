namespace mip_exam
{
    // Represents priority 3 deliveries.
    public class ExpressDelivery : Delivery
    {
        public ExpressDelivery(
            int id,
            string recipient,
            int priority,
            string status = "Pending")
            : base(id, recipient, priority, status)
        {
            if (priority != 3)
            {
                throw new System.ArgumentException(
                    "ExpressDelivery priority must be 3.");
            }
        }

        // Express deliveries require 300 milliseconds to process.
        public override int GetProcessingDelayMs()
        {
            return 300;
        }
    }
}