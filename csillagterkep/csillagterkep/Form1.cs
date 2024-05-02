namespace csillagterkep
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            g.Clear(Color.White);

            Color c = Color.White;

            Pen toll = new Pen(c, 1);
            Brush brush = new SolidBrush(c);

            Models.hajosContext context = new Models.hajosContext();

            var stars = from x in context.StarData select new {x.Hip, x.X, x.Y, x.Magnitude};

            double nagyítás = 300;
            int cx = ClientRectangle.Width / 2;
            int cy = ClientRectangle.Height / 2;

            g.Clear(Color.DarkBlue);
            
            foreach (var star in stars)
            {
                if (star.Magnitude > 6) continue;
                if (Math.Sqrt(Math.Pow(star.X, 2) + Math.Pow(star.Y, 2)) > 1) continue;

                float x = (float)(star.X * nagyítás + cx);
                float y = (float)(star.Y * nagyítás + cy);
                double size = 20 * Math.Pow(10, star.Magnitude / -2.5);

                g.FillEllipse(brush, x, y, (float)size, (float)size);
            }

            var lines = context.ConstellationLines.ToList();

            foreach (var line in lines)
            {
                var star1 = (from x in stars where x.Hip == line.Star1 select x).FirstOrDefault();
                var star2 = (from x in stars where x.Hip == line.Star2 select x).FirstOrDefault();

                if (star1 == null || star2 == null) continue;

                float x1 = (float)(star1.X * nagyítás + cx);
                float y1 = (float)(star1.Y * nagyítás + cy);

                float x2 = (float)(star2.X * nagyítás + cx);
                float y2 = (float)(star2.Y * nagyítás + cy);

                g.DrawLine(toll, x1, y1, x2, y2);
            }
                
          
        }
    }
}