using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Demo
{
    public partial class Form1 : Form
    {
        demodbEntities db = new demodbEntities();
        public Form1()
        {
            InitializeComponent();
            xulydata();
        }

        private void xulydata()
        {
            dgv_Demo.DataSource = db.demotbls.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                demotbl demo = new demotbl()
                {
                    demoCode = txtLastName.Text,
                    demoName = txtFullName.Text
                };
                db.demotbls.Add(demo);
                db.SaveChanges();
                txtFullName.ResetText();
                txtLastName.ResetText();
                MessageBox.Show("Successfull!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xulydata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_Demo.CurrentRow.Cells["col_id"].Value.ToString());
            demotbl demotb = db.demotbls.First(x => x.demoID == id);
            db.demotbls.Remove(demotb);
            db.SaveChanges();
            MessageBox.Show("Successfull!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            xulydata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_Demo.CurrentRow.Cells["col_id"].Value.ToString());
            demotbl demotb = db.demotbls.First(x => x.demoID == id);
            demotb.demoCode = txtLName.Text;
            db.SaveChanges();
            MessageBox.Show("Successfull!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            xulydata();
        }
    }
}