using MultiRoleApp.Models;

namespace MultiRoleApp
{
    public partial class Form1 : Form
    {
        private readonly RoleDatabase _rdb;
        public static string CurrentRole { get; private set; }
        public Form1()
        {
            InitializeComponent();
            _rdb = new RoleDatabase();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _rdb.Users.FirstOrDefault(u => u.Email == tbEmail.Text && u.Pin == int.Parse(tbPin.Text));

            if (user.Email != tbEmail.Text)
            {
                MessageBox.Show("Invalid email address", "Login failled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (user.Pin != int.Parse(tbPin.Text))
            {
                MessageBox.Show("Incorrect Pin!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (user == null)
            {
                MessageBox.Show("Invalid Account");
            }

            CurrentRole = user.RoleId;
            
            Hide();
            MainMenuForm m = new MainMenuForm();
            m.Show();
        }
    }
}