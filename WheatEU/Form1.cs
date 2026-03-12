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
                firstLine.Skip(1);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Dictionary<int, string> temp = new Dictionary<int, string>();
                    for (int i = 0; i < firstLine.Length; i++)
                    {
                        temp.Add(Convert.ToInt32(firstLine[i]), line[i + 1]);
                    }
                    Country country = new Country(line[0], temp);
                    countries.Add(country);
                }
            }
            ShowDataGrid();
        }

        private void ShowDataGrid()
        {
            BuzaDataGrid.ColumnCount = countries.Count;
            BuzaDataGrid.RowCount = countries[0].WheatAmount.Count;
            for (int i = 0; i < BuzaDataGrid.Rows.Count; i++)
            {
                BuzaDataGrid.Rows[i].HeaderCell.Value = countries[i].Name;
                for (int j = 0; j < BuzaDataGrid.Columns.Count; j++)
                {
                    BuzaDataGrid.Columns[j].HeaderCell.Value = countries[i].WheatAmount.Keys;
                }
            }
        }
    }
}
