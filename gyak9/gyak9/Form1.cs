using System.Windows.Forms;

namespace gyak9
{
    public partial class Form1 : Form
    {
        Models.StudentContext studentContext = new Models.StudentContext();
        public Form1()
        {
            InitializeComponent();
            studentBindingSource.DataSource = studentContext.Students.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                studentContext.SaveChanges();
            }
            catch (Exception kiv�tel)
            {
                MessageBox.Show(kiv�tel.InnerException.Message);
            }
        }
    }
}