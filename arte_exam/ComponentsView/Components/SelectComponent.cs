using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentsView.Components
{
    public partial class SelectComponent : UserControl
    {
        private int _selectedIndex;
        public SelectComponent()
        {
            InitializeComponent();
        }

        public void AddElement(string element)
        {
            comboBox.Items.Add(element);
        }

        public string SelectedText
        {
            get { return comboBox.Text; }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value > -2 && value < comboBox.Items.Count)
                {
                    _selectedIndex = value; comboBox.SelectedIndex = _selectedIndex;
                }
            }
        }
    }
}
