namespace mip_exam
{
    // Represents priority 1 and priority 2 deliveries.
    public class RegularDelivery : Delivery
    {
        public RegularDelivery(
            int id,
            string recipient,
            int priority,
            string status = "Pending")
            : base(id, recipient, priority, status)
        {
            if (priority != 1 && priority != 2)
            {
                throw new System.ArgumentException(
                    "RegularDelivery priority must be 1 or 2.");
            }
        }

        // Regular deliveries require 600 milliseconds to process.
        public override int GetProcessingDelayMs()
        {
            return 600;
        }
    }
}