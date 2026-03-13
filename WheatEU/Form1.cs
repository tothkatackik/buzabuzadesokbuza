using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheatEU
{
    public partial class BuzaForm : Form
    {
        private List<Country> countries;
        public BuzaForm()
        {
            InitializeComponent();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel fájl|*.csv|Minden fájl|*.*";
            ofd.InitialDirectory = Application.StartupPath;
            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK) return;
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                countries = new List<Country>();
                string[] firstLine = sr.ReadLine().Split(';');
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Dictionary<int, string> temp = new Dictionary<int, string>();
                    for (int i = 1; i < firstLine.Length; i++)
                    {
                        temp.Add(Convert.ToInt32(firstLine[i]), line[i].ToString());
                    }
                    Country country = new Country(line[0], temp);
                    countries.Add(country);
                }
            }
            ShowDataGrid();
        }

        private void ShowDataGrid()
        {
            BuzaDataGrid.ColumnCount = countries[0].WheatAmount.Count;
            BuzaDataGrid.RowCount = countries.Count;
            for (int i = 0; i < BuzaDataGrid.Rows.Count; i++)
            {
                BuzaDataGrid.Rows[i].HeaderCell.Value = countries[i].Name;
                for (int j = 0; j < BuzaDataGrid.Columns.Count; j++)
                {
                    string amt = countries[i].WheatAmount[2009 + j];
                    BuzaDataGrid.Rows[i].Cells[j].Value = amt==":"?"-":amt;
                }
            }
            IncompleteDataItem.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IncompleteDataItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem c = sender as ToolStripMenuItem;
            foreach (DataGridViewRow row in BuzaDataGrid.Rows)
            {
                if (c.Checked == false)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString() == "-")
                        {
                            row.Visible = false;
                            break;
                        }
                    }
                }
                else
                {
                    row.Visible = true;
                }
            }
        }
    }
}
