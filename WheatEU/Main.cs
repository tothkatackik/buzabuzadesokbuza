using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public Dictionary<string, List<Country>> categories;
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
            LoadCategories();
            ShowDataGrid();
        }

        private void LoadCategories()
        {
            categories = new Dictionary<string, List<Country>>();
            categories.Add("Törpe",      new List<Country>());
            categories.Add("Kicsi",      new List<Country>());
            categories.Add("Közepes",    new List<Country>());
            categories.Add("Nagy",       new List<Country>());
            categories.Add("Óriási",     new List<Country>());
            double max = Convert.ToDouble(countries.Select(
                    x => x.WheatAmount[2016] == ":" ? 0 : Convert.ToDouble(x.WheatAmount[2016]))
                    .Max());
            Console.WriteLine(max);
            foreach (Country c in countries)
            {
                string temp = c.WheatAmount[2016];
                double v = temp == ":" ? 0 : Convert.ToDouble(temp);
                if (v < max * 0.1)
                {
                    categories["Törpe"].Add(c);
                }
                else if (v < max * 0.2)
                {
                    categories["Kicsi"].Add(c);
                }
                else if (v < max * 0.4)
                {
                    categories["Közepes"].Add(c);
                }
                else if (v < max * 0.6)
                {
                    categories["Nagy"].Add(c);
                }
                else if (v <= max)
                {
                    categories["Óriási"].Add(c);
                }
            }
            debugmertmarteleakibaszottokom();
        }

        private void debugmertmarteleakibaszottokom()
        {
            foreach (KeyValuePair<string, List<Country>> kvp in categories)
            {
                foreach (Country c in kvp.Value)
                {
                    Console.WriteLine(kvp.Key + " " + c.ToString(2016));
                }
            }
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

        private void FilteredShow(string category)
        {
            BuzaDataGrid.Rows.Clear();
            List<Country> c;
            if (category == "Minden kategória...") c = new List<Country>(countries);
            else c = new List<Country>(categories[category]);
            BuzaDataGrid.RowCount = c.Count;
            for (int i = 0; i < BuzaDataGrid.Rows.Count; i++)
            {
                BuzaDataGrid.Rows[i].HeaderCell.Value = c[i].Name;
                for (int j = 0; j < BuzaDataGrid.Columns.Count; j++)
                {
                    string amt = c[i].WheatAmount[2009 + j];
                    BuzaDataGrid.Rows[i].Cells[j].Value = amt == ":" ? "-" : amt;
                }
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (sender as ComboBox).SelectedItem.ToString();
            FilteredShow(selected);
        }

        private void PieChartMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> data = new Dictionary<string, double>();
            foreach (DataGridViewRow row in BuzaDataGrid.SelectedRows)
            {
                List<double> temp = new List<double>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string value = cell.Value.ToString() == "-" ? "0" : cell.Value.ToString();
                    temp.Add(Convert.ToDouble(value));
                }
                data.Add(row.HeaderCell.Value.ToString(), temp.Average());
            }
            data.Reverse();
            PieForm pieForm = new PieForm(data);
            pieForm.Show();
        }

        private void BarChartMenuItem_Click(object sender, EventArgs e)
        {
            BarForm barForm = new BarForm(categories);
            barForm.ShowDialog();
        }

        private void LineChartMenuItem_Click(object sender, EventArgs e)
        {
            LineForm lineForm = new LineForm(countries.First(x => x.Name == "Magyarország"),
                countries.First(x => x.Name == "Románia"),
                countries.First(x => x.Name == "Lengyelország"));
            lineForm.ShowDialog();
        }
    }
}
