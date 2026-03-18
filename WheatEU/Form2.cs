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
    public partial class PieForm : Form
    {
        private Dictionary<string, double> data;
        public PieForm(Dictionary<string, double> data)
        {
            InitializeComponent();
            this.data = data;
        }
        private void PieForm_Load(object sender, EventArgs e)
        {
            Series series = DataChart.Series[0];
            double sum = data.Values.Sum();
            List<KeyValuePair<string, double>> small = new List<KeyValuePair<string, double>>();
            foreach (KeyValuePair<string, double> kvp in data)
            {
                if (kvp.Value/sum<=0.02)
                {
                    small.Add(kvp);
                    continue;
                }
                double value = kvp.Value;
                string category = kvp.Key;
                DataPoint p = new DataPoint();
                p.SetValueY(value);
                p.LegendText = category;
                series.Points.Add(p);
            }
            series.Points.Add(Others(small));
        }
        private DataPoint Others(List<KeyValuePair<string, double>> small)
        {
            double sum = 0;
            foreach (KeyValuePair<string, double> kvp in small)
            {
                sum += kvp.Value;
            }
            DataPoint p = new DataPoint();
            p.SetValueY(sum);
            p.LegendText = "Egyéb";
            return p;
        }
    }
}
