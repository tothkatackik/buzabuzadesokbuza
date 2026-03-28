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
    public partial class LineForm : Form
    {
        private Country h;
        private Country r;
        private Country p;
        public LineForm(Country hu, Country ro, Country pl)
        {
            h = hu;
            r = ro;
            p = pl;
            InitializeComponent();
        }

        private void LineForm_Load(object sender, EventArgs e)
        {
            ChartArea area = DataChart.ChartAreas[0];
            area.AxisY.MinorGrid.Enabled = true;
            area.AxisY.MinorGrid.Interval = 100;
            area.AxisY.Interval = 500;
            area.AxisY.MinorGrid.LineColor = Color.Gray;
            area.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;

            Series hu = DataChart.Series[0];
            hu.LegendText = "Magyarország";
            hu.BorderWidth = 3;
            DataPointCollection huP = hu.Points;
            foreach (KeyValuePair<int, string> data in h.WheatAmount)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(data.Key, Convert.ToDouble(data.Value));
                huP.Add(p);
            }

            Series ro = DataChart.Series[1];
            ro.LegendText = "Románia";
            ro.BorderWidth = 3;
            DataPointCollection roP = ro.Points;
            foreach (KeyValuePair<int, string> data in r.WheatAmount)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(data.Key, Convert.ToDouble(data.Value));
                roP.Add(p);
            }

            Series pl = DataChart.Series[2];
            pl.LegendText = "Lengyelország";
            pl.BorderWidth = 3;
            DataPointCollection plP = pl.Points;
            foreach (KeyValuePair<int, string> data in p.WheatAmount)
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(data.Key, Convert.ToDouble(data.Value));
                plP.Add(p);
            }
        }
    }
}
