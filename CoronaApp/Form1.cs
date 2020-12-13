using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoronaApp
{
    public partial class Form1 : Form
    {
        private readonly CountyContext _context;

        public Form1(CountyContext db)
        {
            InitializeComponent();
            _context = db;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var bi = new BindingSource();
            bi.DataSource = _context.Counties.ToList();
            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();

            comboBox1.DataSource = bi.DataSource;

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";

            QueryCountyData();
        }

        private void QueryCountyData()
        {
            var name = ((County)comboBox1.SelectedItem).Name;
            var county = from c in _context.Counties
                         where 
                             c.Name.Equals(
                                 name, 
                                 StringComparison.CurrentCultureIgnoreCase)
                         select c;
            textBox1.Text = county.First().AllCases.ToString();
            textBox2.Text = county.First().NewCases.ToString();
            textBox3.Text = county.First().WeeklyCases.ToString();
            textBox4.Text = county.First().PerCapitaCases.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryCountyData();
        }

        private void ExportToCSV()
        {
            var path = "./output";
            Directory.CreateDirectory(path);

            var now = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            var fileName = $"export_{now}.csv";
            var filePath = Path.Combine(path, fileName);
            // A File.CreateText() mindig létrehoz egy új fájlt,
            // ezért egy másodpercen belül többször is meghívhatjuk
            using (var w = File.CreateText(filePath))
            {
                foreach (var item in _context.Counties.ToList())
                {
                    var line = string.Format(
                        "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                        item.Name,
                        item.AllCases,
                        item.NewCases,
                        item.WeeklyCases,
                        item.PerCapitaCases);

                    w.WriteLine(line);
                    w.Flush();
                }
            }

            MessageBox.Show(
                $"Adatok sikeresen kimentve a következő fájlba:\n{fileName}",
                "CSV Export",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 
                (comboBox1.SelectedIndex + 1) % comboBox1.Items.Count;
        }
    }
}
