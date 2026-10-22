using System;

namespace mip_exam
{
    // Abstract base class for all deliveries.
    //
    // A Delivery contains the data shared by every delivery type:
    // Id, Recipient, Priority and Status.

    public abstract class Delivery
    {
        public int Id { get; private set; }

        public string Recipient { get; private set; }

        // Valid priorities are 1, 2 and 3.
        public int Priority { get; private set; }

        // Valid statuses are Pending, Processing and Completed.
        public string Status { get; private set; }

        protected Delivery(
            int id,
            string recipient,
            int priority,
            string status)
        {
            // A new delivery uses Id 0 before it is inserted.
            // Persisted deliveries receive a positive database Id.
            if (id < 0)
            {
                throw new ArgumentException(
                    "Id cannot be negative.");
            }

            // The recipient must contain a non-empty name.
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException(
                    "Recipient cannot be empty.");
            }

            // The examination allows only priorities 1, 2 and 3.
            if (priority < 1 || priority > 3)
            {
                throw new ArgumentException(
                    "Priority must be 1, 2 or 3.");
            }

            // Validate the initial status before storing it.
            ValidateStatus(status);

            Id = id;

            // Trim removes accidental spaces before or after the name.
            Recipient = recipient.Trim();

            Priority = priority;
            Status = status;
        }

        // Changes the status while still enforcing the allowed values.
        public void SetStatus(string status)
        {
            ValidateStatus(status);
            Status = status;
        }

        // Keeps status validation in one place so that both the
        // constructor and SetStatus use the same rules.
        private void ValidateStatus(string status)
        {
            if (status != "Pending" &&
                status != "Processing" &&
                status != "Completed")
            {
                throw new ArgumentException(
                    "Invalid delivery status.");
            }
        }

        // Each subtype must provide its own processing delay.
        // RegularDelivery returns 600 ms and ExpressDelivery returns 300 ms.
        public abstract int GetProcessingDelayMs();
    }
}