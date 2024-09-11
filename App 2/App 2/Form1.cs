using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace App_2
{
    public partial class Form1 : Form
    {
        private string logFilePath;
        private MyLogFileHandler logFileHandler;
        public Form1()
        {
            InitializeComponent();
            logFileHandler = new MyLogFileHandler();
            logFilePathTextBox.Click += LogFilePathTextBox_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LogFilePathTextBox_Click(object sender, EventArgs e)
        {// Open file dialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Log File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the selected file path in the TextBox
                logFilePathTextBox.Text = openFileDialog.FileName;
                logFilePath = openFileDialog.FileName; // Update the log file path
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the file contents
                string fileContents = logFileHandler.ReadFile(logFilePath);

                // Display the file contents in the editor view
                editorViewTextBox.Text = fileContents;
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                MessageBox.Show($"An error occurred while reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Write the contents of the editor view to the file
                logFileHandler.WriteFile(logFilePath, editorViewTextBox.Text);

                // Display success message
                MessageBox.Show("File successfully written.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                MessageBox.Show($"An error occurred while writing to the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    public class MyLogFileHandler
    {
        public string ReadFile(string filePath)
        {
            // Read the contents of the file
            return System.IO.File.ReadAllText(filePath);
        }

        public void WriteFile(string filePath, string content)
        {
            // Write content to the file
            System.IO.File.WriteAllText(filePath, content);
        }
    }

}
