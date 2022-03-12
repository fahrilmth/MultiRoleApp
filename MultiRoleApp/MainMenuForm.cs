using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiRoleApp.Models;

namespace MultiRoleApp
{
    public partial class MainMenuForm : Form
    {
        private readonly RoleDatabase _db;

        public MainMenuForm()
        {
            InitializeComponent();
            _db = new RoleDatabase();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            
            if (Form1.CurrentRole == "R01")
            {
                IsAdmin();
            }
            if (Form1.CurrentRole == "R02")
            {
                IsOperator();
            }
            if (Form1.CurrentRole == "R03")
            {
                IsUser();
            }
            else
            {
                return;
            }

        }

        private void LoadData()
        {
            dgvUser.DataSource =
                (
                from u in _db.Users
                where u.Name.Contains(tbSearch.Text) || u.Email.Contains(tbSearch.Text)
                select new
                {
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Pin,
                    role = u.Role.Name
                }
                ).ToList();
        }

        private void IsAdmin()
        {
            LoadData();
            groupBox1.Enabled = true;
            btnAdd.Enabled = btnDel.Enabled = btnEdit.Enabled = btnLogout.Enabled = true;
        }

        private void IsOperator()
        {
            LoadData();
            btnEdit.Enabled = btnLogout.Enabled = true;
            btnAdd.Enabled = btnDel.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void IsUser()
        {
            LoadData();
            btnAdd.Enabled = btnDel.Enabled = btnEdit.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
