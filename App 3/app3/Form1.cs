using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static app3.Form1;

namespace app3
{
    public partial class Form1 : Form
    {
        public interface IIncidentFactory
        {
            Incident CreateIncident(string incidentID, string incidentDate, string reportedDate, string comments, Staff reportingStaff);
            DenialOfService CreateDenialOfService(string incidentID, string incidentDate, string reportedDate, string comments,
                                                   Staff reportingStaff, string serverID, string service, string outcome, bool isActive);
        }

        public class IncidentFactory : IIncidentFactory
        {
            public Incident CreateIncident(string incidentID, string incidentDate, string reportedDate, string comments, Staff reportingStaff)
            {
                // Implement logic to create an Incident object
                return new Incident(incidentID, incidentDate, reportedDate, comments, reportingStaff);
            }

            public DenialOfService CreateDenialOfService(string incidentID, string incidentDate, string reportedDate, string comments,
                                                          Staff reportingStaff, string serverID, string service, string outcome, bool isActive)
            {
                // Implement logic to create a DenialOfService object
                return new DenialOfService(incidentID, incidentDate, reportedDate, comments, reportingStaff, serverID, service, outcome, isActive);
            }
        }



        private readonly IIncidentFactory _incidentFactory;
        public Form1()
        {
            InitializeComponent();
            _incidentFactory = new IncidentFactory(); // Instantiate the factory
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void createIncidentButton_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            List<string> emptyFields = new List<string>();
            if (string.IsNullOrWhiteSpace(incidentIDTextBox.Text))
                emptyFields.Add("Incident ID");
            if (string.IsNullOrWhiteSpace(incidentDateTextBox.Text))
                emptyFields.Add("Incident Date");
            if (string.IsNullOrWhiteSpace(reportedDateTextBox.Text))
                emptyFields.Add("Reported Date");
            if (string.IsNullOrWhiteSpace(commentsTextBox.Text))
                emptyFields.Add("Comments");
            if (string.IsNullOrWhiteSpace(staffIDTextBox.Text))
                emptyFields.Add("Staff ID");
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
                emptyFields.Add("First Name");
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
                emptyFields.Add("Surname");
            if (string.IsNullOrWhiteSpace(departmentTextBox.Text))
                emptyFields.Add("Department");

            // If any fields are empty, display an error message
            if (emptyFields.Any())
            {
                string errorMessage = "Please fill in the following required fields:";
                foreach (string field in emptyFields)
                {
                    errorMessage += $"\n- {field}";
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get values from text boxes
            string incidentID = incidentIDTextBox.Text;
            string incidentDate = incidentDateTextBox.Text;
            string reportedDate = reportedDateTextBox.Text;
            string comments = commentsTextBox.Text;
            string staffID = staffIDTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string surname = surnameTextBox.Text;
            string department = departmentTextBox.Text;

            // Create Staff object
            Staff reportedBy = new Staff { StaffID = staffID, FirstName = firstName, Surname = surname, Department = department };

            // Create Incident object using factory method
            Incident incident = _incidentFactory.CreateIncident(incidentID, incidentDate, reportedDate, comments, reportedBy);

            // Logic to process or store the incident object (e.g., save to database)
            // Replace with your specific logic for storing incidents

            MessageBox.Show("New incident created successfully!");

            // Clear text boxes for next entry (optional)
            ClearTextBoxes();

        }

        private void createDOSButton_Click(object sender, EventArgs e)
        {

            // Check if any of the required fields are empty
            List<string> emptyFields = new List<string>();
            if (string.IsNullOrWhiteSpace(incidentIDTextBox.Text))
                emptyFields.Add("Incident ID");
            if (string.IsNullOrWhiteSpace(incidentDateTextBox.Text))
                emptyFields.Add("Incident Date");
            if (string.IsNullOrWhiteSpace(reportedDateTextBox.Text))
                emptyFields.Add("Reported Date");
            if (string.IsNullOrWhiteSpace(commentsTextBox.Text))
                emptyFields.Add("Comments");
            if (string.IsNullOrWhiteSpace(staffIDTextBox.Text))
                emptyFields.Add("Staff ID");
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
                emptyFields.Add("First Name");
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
                emptyFields.Add("Surname");
            if (string.IsNullOrWhiteSpace(departmentTextBox.Text))
                emptyFields.Add("Department");
            if (string.IsNullOrWhiteSpace(serverIDTextBox.Text))
                emptyFields.Add("Server ID");
            if (string.IsNullOrWhiteSpace(serviceTextBox.Text))
                emptyFields.Add("Service");
            if (string.IsNullOrWhiteSpace(outcomeTextBox.Text))
                emptyFields.Add("Outcome");
            if (!yesRadioButton.Checked && !noRadioButton.Checked)
                emptyFields.Add("Is Active");

            // If any fields are empty, display an error message
            if (emptyFields.Any())
            {
                string errorMessage = "Please fill in the following required fields:";
                foreach (string field in emptyFields)
                {
                    errorMessage += $"\n- {field}";
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            // Get values from text boxes
            string incidentID = incidentIDTextBox.Text;
            string incidentDate = incidentDateTextBox.Text;
            string reportedDate = reportedDateTextBox.Text;
            string comments = commentsTextBox.Text;
            string staffID = staffIDTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string surname = surnameTextBox.Text;
            string department = departmentTextBox.Text;
            string serverID = serverIDTextBox.Text;
            string service = serviceTextBox.Text;
            string outcome = outcomeTextBox.Text;
            bool isActive = yesRadioButton.Checked; // Assuming yesRadioButton is selected for active incident

            // Create Staff object
            Staff reportedBy = new Staff { StaffID = staffID, FirstName = firstName, Surname = surname, Department = department };

            // Create DenialOfService object using factory method
            DenialOfService dosIncident = _incidentFactory.CreateDenialOfService(incidentID, incidentDate, reportedDate, comments,
                                                                                 reportedBy, serverID, service, outcome, isActive);

            // Logic to process or store the dosIncident object (e.g., save to database)
            // Replace with your specific logic for storing incidents

            MessageBox.Show("New Denial-of-Service incident created successfully!");

            // Clear text boxes for next entry (optional)
            ClearTextBoxes();
        
        
        }


        private void ClearTextBoxes()
        {
            incidentIDTextBox.Text = "";
            incidentDateTextBox.Text = "";
            reportedDateTextBox.Text = "";
            commentsTextBox.Text = "";
            staffIDTextBox.Text = "";
            firstNameTextBox.Text = "";
            surnameTextBox.Text = "";
            departmentTextBox.Text = "";
            serverIDTextBox.Text = "";
            serviceTextBox.Text = "";
            outcomeTextBox.Text = "";
        }
    }

    public class Staff
    {
        public string StaffID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
    }

    public class Incident
    {
        public string IncidentID { get; set; }
        public string IncidentDate { get; set; }
        public string ReportedDate { get; set; }
        public string Comments { get; set; }
        public Staff ReportedBy { get; set; }

        public Incident(string incidentID, string incidentDate, string reportedDate, string comments, Staff reportedBy)
        {
            IncidentID = incidentID;
            IncidentDate = incidentDate;
            ReportedDate = reportedDate;
            Comments = comments;
            ReportedBy = reportedBy;
        }

        public virtual string NewIncidentMessage()
        {
            return "New Incident created successfully";
        }
    }

    public class DenialOfService : Incident
    {
        public string ServerID { get; set; }
        public string Service { get; set; }
        public string Outcome { get; set; }
        public bool IsActive { get; set; }

        public DenialOfService(string incidentID, string incidentDate, string reportedDate, string comments, Staff reportedBy,
                               string serverID, string service, string outcome, bool isActive)
            : base(incidentID, incidentDate, reportedDate, comments, reportedBy)
        {
            ServerID = serverID;
            Service = service;
            Outcome = outcome;
            IsActive = isActive;
        }

        public override string NewIncidentMessage()
        {
            return "New Denial-of-Service Incident created successfully";
        }
    }
}
