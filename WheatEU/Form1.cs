using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
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
            for (int i = 0; i < BuzaDataGrid.ColumnCount; i++)
            {
                BuzaDataGrid.Columns[i].HeaderText = (2009 + i).ToString();
                BuzaDataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            CategoryComboBox.Enabled = true;
            CategoryComboBox.SelectedIndex = 0;
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

        private void FilteredShow(double max, double pu, double pl)
        {
            BuzaDataGrid.Rows.Clear();
            List<Country> q = countries.Where(x => Convert.ToDouble(x.WheatAmount[2016] == ":" ? "0" : x.WheatAmount[2016]) >= pl * max && Convert.ToDouble(x.WheatAmount[2016] == ":" ? "0" : x.WheatAmount[2016]) < pu * max).ToList();
            if (pu == 1) q.Add(countries.Find(x => Convert.ToDouble(x.WheatAmount[2016] == ":" ? "0" : x.WheatAmount[2016]) == max));
            BuzaDataGrid.RowCount = q.Count();
            for (int i = 0; i < BuzaDataGrid.Rows.Count; i++)
            {
                BuzaDataGrid.Rows[i].HeaderCell.Value = q[i].Name;
                for (int j = 0; j < BuzaDataGrid.Columns.Count; j++)
                {
                    string amt = q[i].WheatAmount[2009 + j];
                    BuzaDataGrid.Rows[i].Cells[j].Value = amt == ":" ? "-" : amt;
                }
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (sender as ComboBox).SelectedItem.ToString();
            int year = 2016;
            double max = -67;
            foreach (Country country in countries)
            {
                string temp = country.WheatAmount[year];
                if (temp == ":") continue;
                double n = Convert.ToDouble(temp);
                if (n > max)
                {
                    max = n;
                }
            }
            switch (selected)
            {
                case "Minden kategória...":
                    {
                        ShowDataGrid();
                        break;
                    }
                case "Törpe":
                    {
                        FilteredShow(max, 0.1, 0);
                        break;
                    }
                case "Kicsi":
                    {
                        FilteredShow(max, 0.2, 0.1);
                        break;
                    }
                case "Közepes":
                    {
                        FilteredShow(max, 0.4, 0.2);
                        break;
                    }
                case "Nagy":
                    {
                        FilteredShow(max, 0.6, 0.4);
                        break;
                    }
                case "Óriási":
                    {
                        FilteredShow(max, 1, 0.6);
                        break;
                    }
            }
        }
    }
}
