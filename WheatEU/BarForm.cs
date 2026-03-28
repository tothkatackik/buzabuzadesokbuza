using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WheatEU
{
    public partial class BarForm : Form
    {
        private Dictionary<string, List<Country>> categories;
        public BarForm(Dictionary<string, List<Country>> categories)
        {
            InitializeComponent();
            this.categories = new Dictionary<string, List<Country>>(categories);
        }

        private void BarForm_Load(object sender, EventArgs e)
        {
            Series series = DataChart.Series[0];
            series.Color = Color.Black;
            series.LegendText = "Kategóriák gyakorisága";

            ChartArea area = DataChart.ChartAreas[0];
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            DataPointCollection points = series.Points;
            foreach (KeyValuePair<string, List<Country>> cat in categories)
            {
                DataPoint p = new DataPoint();
                p.AxisLabel = cat.Key;
                p.SetValueY(cat.Value.Count);
                points.Add(p);
            }
        }
    }
}
