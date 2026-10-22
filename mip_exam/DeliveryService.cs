using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace mip_exam
{
    // Contains application operations that are not directly related
    // to Windows Forms controls.
    public class DeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;

        private readonly object repositoryLock =
            new object();

        public DeliveryService(
            IDeliveryRepository deliveryRepository)
        {
            this.deliveryRepository =
                deliveryRepository;
        }

        // Loads the current deliveries through the repository.
        public List<Delivery> LoadDeliveries()
        {
            lock (repositoryLock)
            {
                return deliveryRepository.LoadAll();
            }
        }

        // Creates and saves one delivery, then records the trace event.
        public int AddDelivery(
            string recipient,
            int priority)
        {
            Delivery delivery =
                CreateDelivery(
                    0,
                    recipient,
                    priority,
                    "Pending");

            int id;

            lock (repositoryLock)
            {
                id =
                    deliveryRepository.Insert(
                        delivery);
            }

            Trace.WriteLine(
                DateTime.Now.ToString(
                    "yyyy-MM-dd HH:mm:ss") +
                " Delivery added. Id=" +
                id);

            Trace.Flush();

            return id;
        }

        // Creates the required dataset with valid priorities and recipients.
        public int GenerateDataset()
        {
            const int generatedCount = 120;

            string[] recipientNames =
            {
        "Alex Pop",
        "Beatrice Ionescu",
        "Cora Muresan",
        "Deni Popescu",
        "Eva Radu",
        "Feri Moldovan",
        "Ana Dumitru",
        "Mihai Stan",
        "Ioana Matei",
        "Victor Enache",
        "Maria Oprea",
        "Andrei Georgescu",
        "Elena Dobre",
        "Rares Neagu",
        "Sofia Pavel",
        "Cristian Ilie",
        "Larisa Nistor",
        "Paul Vasile",
        "Diana Tudor",
        "George Marcu",
        "Irina Costea",
        "Dan Serban",
        "Monica Florea",
        "Tudor Marin",
        "Alina Dragomir"
    };

            Random random =
                new Random();

            int insertedCount = 0;

            for (int i = 1;
                i <= generatedCount;
                i++)
            {
                int priority;

                // Generate at least 40 records for every priority.
                if (i <= 40)
                {
                    priority = 1;
                }
                else if (i <= 80)
                {
                    priority = 2;
                }
                else
                {
                    priority = 3;
                }

                // Several deliveries may have the same recipient.
                // The database Id remains unique for every delivery.
                string recipient =
                    recipientNames[
                        random.Next(
                            recipientNames.Length)];

                AddDelivery(
                    recipient,
                    priority);

                insertedCount++;
            }

            return insertedCount;
        }

        // Updates a delivery status through the repository.
        public void UpdateStatus(
            int id,
            string status)
        {
            lock (repositoryLock)
            {
                deliveryRepository.UpdateStatus(
                    id,
                    status);
            }
        }

        // Creates the correct delivery subtype for the selected priority.
        private Delivery CreateDelivery(
            int id,
            string recipient,
            int priority,
            string status)
        {
            if (priority == 3)
            {
                return new ExpressDelivery(
                    id,
                    recipient,
                    priority,
                    status);
            }

            return new RegularDelivery(
                id,
                recipient,
                priority,
                status);
        }
    }
}