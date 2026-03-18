using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WheatEU
{
    public partial class BarForm : Form
    {
        private List<Country> countries;
        public BarForm(List<Country> countries)
        {
            InitializeComponent();
            this.countries = new List<Country>(countries);
        }

        private void BarForm_Load(object sender, EventArgs e)
        {
            Series series = DataChart.Series[0];
            series.Color = Color.Black;
            series.LegendText = "Kategóriák gyakorisága";

            DataPointCollection points = series.Points;
            points.Clear();


        }
    }
}
