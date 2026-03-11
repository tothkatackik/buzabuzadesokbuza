using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheatEU
{
    public partial class BuzaForm : Form
    {
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
                string[] firstLine = sr.ReadLine().Split(';');
                firstLine.Skip(1);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Dictionary<string, int> helpme = new Dictionary<string, int>();
                    
                }
            }
        }
    }
}
