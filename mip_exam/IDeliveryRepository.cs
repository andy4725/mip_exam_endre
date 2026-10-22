using System.Collections.Generic;

namespace mip_exam
{
    // Defines the database operations used by the application.
    public interface IDeliveryRepository
    {
        // Inserts a delivery and returns its generated database Id.
        int Insert(Delivery delivery);

        // Loads all deliveries from the database.
        List<Delivery> LoadAll();

        // Saves a delivery status change in the database.
        void UpdateStatus(int id, string status);
    }
}