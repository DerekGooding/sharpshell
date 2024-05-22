using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WebSearchDeskBand
{
    public partial class DeskBandUI : UserControl
    {
        public DeskBandUI()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            Process.Start("http://google.com#q=" + textBoxSearch.Text);
        }
    }
}