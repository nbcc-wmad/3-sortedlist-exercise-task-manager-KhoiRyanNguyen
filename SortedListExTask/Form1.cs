using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SortedList<string, string> TASK = new SortedList<string, string>();


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string day = dtpTaskDate.Value.ToString();
            string task = txtTask.Text;
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("you must enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TASK.ContainsKey(day))
            {
                MessageBox.Show("Only one task per date is allowed", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               TASK.Add(day, txtTask.Text);               
                lstTasks.Items.Add(day);
                txtTask.Text = string.Empty;
            }
        }
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                lblTaskDetails.Text = string.Empty;
                string show = TASK[lstTasks.SelectedItem.ToString()];
                lblTaskDetails.Text = show;
            }

        }


        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            string item = Convert.ToString(lstTasks.SelectedItem);

            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("you must select a task to remove", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblTaskDetails.Text = string.Empty;
                TASK.Remove(item);
                lstTasks.Items.Remove(item);
                
            }

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            foreach (var a in TASK)
            {
                msg += a.Key + " " + a.Value + Environment.NewLine;
            }
            MessageBox.Show(msg);


        }


       
    }
}