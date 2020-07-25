using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCBuilding
{
    public partial class MainWindow : Window
    {
        string data;
        string[] tokens;

        public MainWindow()
        {
            Components com = new Components();

            InitializeComponent();

            DirectoryInfo di = new DirectoryInfo(@"hardware/cpu");
            foreach (var fi in di.GetFiles())
            {
                var result = (fi.Name);
                data = result;
                string[] tokens = data.Split(' ','.');
                if (!cpuBrand.Items.Contains(data))
                    cpuBrand.Items.Add(tokens[0]);
            }
        }

        private void cpuBrand_DropDownClosed(object sender, EventArgs e)
        {
            Components com = new Components();

            cpuModel.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@"hardware/cpu");
            foreach (var fi in di.GetFiles())
            {
                var result = (fi.Name);
                data = result;
                tokens = data.Split(' ', '.');
                if (tokens[0] == cpuBrand.Text)
                    cpuModel.Items.Add(com.CPU_Series + " " + com.CPU_Model);
            }
            var lines = File.ReadAllLines(@"hardware/cpu/" + com.CPU_Brand + " " + com.CPU_Series + " " + com.CPU_Model + ".xml");
            com.CPU_Brand = lines[0];
            com.CPU_Series = lines[1];
            com.CPU_Model = lines[2];
            com.CPU_Socket = lines[3];

        }

        private void cpuModel_DropDownClosed(object sender, EventArgs e)
        {
            Components com = new Components();
            DirectoryInfo di = new DirectoryInfo(@"hardware/mb");
            foreach (var fi in di.GetFiles())
            {
                var result = (fi.Name);
                data = result;
                tokens = data.Split(' ', '.');
                if (com.CPU_Socket == com.MB_Socket)
                    cpuBrand.Items.Add(tokens[0]);
            }

        }
    }
}
