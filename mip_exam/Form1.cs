using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace mip_exam
{
    // Coordinates the Windows Forms user interface and application services.
    public partial class Form1 : Form
    {
        private readonly string databasePath;

        private readonly DeliveryService deliveryService;

        private readonly DeliveryProcessor deliveryProcessor;

        public Form1()
        {
            InitializeComponent();

            databasePath =
                Path.Combine(
                    Application.StartupPath,
                    "ponyexpress.db");

            ConfigureTrace();

            IDeliveryRepository deliveryRepository =
                new SqliteDeliveryRepository(
                    databasePath);

            deliveryService =
                new DeliveryService(
                    deliveryRepository);

            deliveryProcessor =
                new DeliveryProcessor(
                    deliveryService,
                    RefreshControlsFromWorker,
                    ProcessingFinished);

            LoadDeliveries();
        }

        // Configures trace output to be written to trace.log.
        private void ConfigureTrace()
        {
            string tracePath =
                Path.Combine(
                    Application.StartupPath,
                    "trace.log");

            Trace.Listeners.Clear();

            Trace.Listeners.Add(
                new TextWriterTraceListener(
                    tracePath));

            Trace.AutoFlush = true;
        }

        // Validates and saves a delivery entered by the user.
        private void addDeliveryButton_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateDeliveryInput(
                    out string recipient,
                    out int priority))
            {
                return;
            }

            deliveryService.AddDelivery(
                recipient,
                priority);

            recipientTextBox.Clear();

            LoadDeliveries();
        }

        // Generates and saves the required SQLite dataset.
        private void generateDatasetButton_Click(
            object sender,
            EventArgs e)
        {
            int generatedCount =
                deliveryService.GenerateDataset();

            LoadDeliveries();

            MessageBox.Show(
                "Generated " +
                generatedCount +
                " delivery records.",
                "Dataset generated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Starts background delivery processing.
        private void startProcessingButton_Click(
            object sender,
            EventArgs e)
        {
            if (deliveryProcessor.IsRunning)
            {
                MessageBox.Show(
                    "Processing is already running.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            deliveryProcessor.Start();

            startProcessingButton.Enabled = false;
            stopProcessingButton.Enabled = true;
        }

        // Requests that background processing stop cooperatively.
        private void stopProcessingButton_Click(
            object sender,
            EventArgs e)
        {
            deliveryProcessor.Stop();

            stopProcessingButton.Enabled = false;
        }

        // Checks the recipient and priority entered in the form.
        private bool ValidateDeliveryInput(
            out string recipient,
            out int priority)
        {
            recipient =
                recipientTextBox.Text.Trim();

            priority = 0;

            if (string.IsNullOrWhiteSpace(recipient))
            {
                MessageBox.Show(
                    "Recipient cannot be empty.",
                    "Validation error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (priorityComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Select a valid priority.",
                    "Validation error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            priority =
                Convert.ToInt32(
                    priorityComboBox.SelectedItem);

            if (priority < 1 || priority > 3)
            {
                MessageBox.Show(
                    "Priority must be 1, 2 or 3.",
                    "Validation error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // Refreshes the grid and status counts from the database.
        private void LoadDeliveries()
        {
            List<Delivery> deliveries =
                deliveryService.LoadDeliveries();

            deliveryDataGridView.Rows.Clear();

            foreach (Delivery delivery in deliveries)
            {
                deliveryDataGridView.Rows.Add(
                    delivery.Id,
                    delivery.Recipient,
                    delivery.Priority,
                    delivery.Status);
            }

            UpdateCounts(deliveries);
        }

        private void UpdateCounts(
            List<Delivery> deliveries)
        {
            // GroupBy is intentionally performed over Delivery objects
            // to satisfy the LINQ requirement for the user interface.
            Dictionary<string, int> groupedCounts =
                deliveries
                    .GroupBy(delivery => delivery.Status)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Count());

            int pendingCount =
                GetCount(
                    groupedCounts,
                    "Pending");

            int processingCount =
                GetCount(
                    groupedCounts,
                    "Processing");

            int completedCount =
                GetCount(
                    groupedCounts,
                    "Completed");

            pendingLabel.Text =
                "Pending: " + pendingCount;

            processingLabel.Text =
                "Processing: " + processingCount;

            completedLabel.Text =
                "Completed: " + completedCount;
        }

        private int GetCount(
            Dictionary<string, int> groupedCounts,
            string status)
        {
            if (groupedCounts.ContainsKey(status))
            {
                return groupedCounts[status];
            }

            return 0;
        }

        // Refreshes Windows Forms controls safely from the worker thread.
        private void RefreshControlsFromWorker()
        {
            if (IsDisposed || Disposing)
            {
                return;
            }

            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed && !Disposing)
                {
                    LoadDeliveries();
                }
            }));
        }

        // Re-enables the processing buttons when the worker finishes.
        private void ProcessingFinished()
        {
            if (IsDisposed || Disposing)
            {
                return;
            }

            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed && !Disposing)
                {
                    startProcessingButton.Enabled = true;
                    stopProcessingButton.Enabled = false;

                    LoadDeliveries();
                }
            }));
        }

        // Stops the worker and flushes the trace log before closing.
        private void Form1_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            deliveryProcessor.Stop();
            deliveryProcessor.WaitForCompletion();

            Trace.Flush();

            foreach (TraceListener listener in
                Trace.Listeners)
            {
                listener.Close();
            }
        }
    }
}