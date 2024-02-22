namespace Pascal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int m = 40;
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop < sor + 1; oszlop++)
                {
                    Button b = new Button();
                    b.Top = sor * m;
                    b.Left = oszlop * m;
                    Controls.Add(b);
                    b.Height = m;
                    b.Width = m;
                    int x = Faktorialis(sor) / (Faktorialis(oszlop)*Faktorialis(sor-oszlop));
                    b.Text = x.ToString();
                }
            }
        }

        int Faktorialis(int n)
        {
            if (n == 0) return 1;
            return n * Faktorialis(n - 1);
        }
    }
}