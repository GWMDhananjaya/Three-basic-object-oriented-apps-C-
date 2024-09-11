using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_1
{
    public partial class Form1 : Form
    {
        private float[] serverDowntimes = new float[5];
        private bool[] downtimeEntered = new bool[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if any of the server downtime values are empty
            /* if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter values for all server downtime fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Store inputted server downtime values in the array
            serverDowntimes[0] = float.Parse(textBox1.Text);
            serverDowntimes[1] = float.Parse(textBox2.Text);
            serverDowntimes[2] = float.Parse(textBox3.Text);
            serverDowntimes[3] = float.Parse(textBox4.Text);
            serverDowntimes[4] = float.Parse(textBox5.Text);
            
          //  MessageBox.Show("Exam scores array created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

            // Sort the server downtime values
            float[] sortedDowntimes = serverDowntimes.OrderBy(d => d).ToArray();

            // Display sorted downtime values
            sortedDowntimesTextBox.Clear();
            foreach (var downtime in sortedDowntimes)
            {
                sortedDowntimesTextBox.AppendText(downtime.ToString() + Environment.NewLine);
            }
            */
            // Check if each downtime value is entered
            if (string.IsNullOrWhiteSpace(textBox01.Text))
            {
                MessageBox.Show("Please enter value for Downtime 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                serverDowntimes[0] = float.Parse(textBox01.Text);
                downtimeEntered[0] = true;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter value for Downtime 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                serverDowntimes[1] = float.Parse(textBox2.Text);
                downtimeEntered[1] = true;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter value for Downtime 3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                serverDowntimes[2] = float.Parse(textBox3.Text);
                downtimeEntered[2] = true;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter value for Downtime 4.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                serverDowntimes[3] = float.Parse(textBox4.Text);
                downtimeEntered[3] = true;
            }

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter value for Downtime 5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                serverDowntimes[4] = float.Parse(textBox5.Text);
                downtimeEntered[4] = true;
            }

            MessageBox.Show("Server downtime values stored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if any downtime value is not entered
            for (int i = 0; i < 5; i++)
            {
                if (!downtimeEntered[i])
                {
                    MessageBox.Show($"Please enter value for Downtime {i + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Calculate average downtime
            /*  float averageDowntime = serverDowntimes.Sum() / serverDowntimes.Length;
              averageDowntimeTextBox.Text = "Average downtime score is" + averageDowntime.ToString();

              // Sort the server downtime values
              float[] sortedDowntimes = serverDowntimes.OrderBy(d => d).ToArray();

              // Display sorted downtime values
              averageDowntimeTextBox.Clear();
              foreach (var downtime in sortedDowntimes)
              {
                  averageDowntimeTextBox.AppendText("Sorted downtime scores " + downtime.ToString() + Environment.NewLine);
              }*/

            // Calculate average downtime
            float averageDowntime = serverDowntimes.Sum() / serverDowntimes.Length;

            // Sort the server downtime values
            float[] sortedDowntimes = serverDowntimes.OrderBy(d => d).ToArray();

            // Create a string for displaying both average downtime and sorted downtime scores
            string displayText = $"Average downtime score is {averageDowntime:F1}  Sorted downtime scores ";

            // Append sorted downtime scores to the display text
            for (int i = 0; i < sortedDowntimes.Length; i++)
            {
                displayText += $"{(int)sortedDowntimes[i]}";
                if (i < sortedDowntimes.Length - 1)
                {
                    displayText += " ";
                }
            }

            // Set the TextBox text to the display text
            averageDowntimeTextBox.Text = displayText;


        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox01_TextChanged(object sender, EventArgs e)
        {

        }

        private void averageDowntimeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
