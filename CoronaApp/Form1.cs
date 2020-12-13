using System;
using System.Linq;
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
