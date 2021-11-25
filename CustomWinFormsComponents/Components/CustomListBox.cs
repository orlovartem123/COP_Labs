using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomWinFormsComponents.Components
{
    public partial class CustomListBox : UserControl
    {
        /// <summary>
        /// Получает выбранный элемент
        /// </summary>
        public string SelectedItem
        {
            get => listBoxItems.SelectedItem != null ? listBoxItems.SelectedItem.ToString() : string.Empty;
            set
            {
                if (listBoxItems.Items.Contains(value))
                {
                    listBoxItems.SelectedItem = value;
                }
            }
        }

        public CustomListBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавляет строки в список
        /// </summary>
        public bool AddItems(List<string> strs)
        {
            if (strs == null)
                return false;

            listBoxItems.Items.AddRange(strs.ToArray());
            return true;
        }

        /// <summary>
        /// Очищает список элементов
        /// </summary>
        public void ClearList()
        {
            listBoxItems.Items.Clear();
        }

        private event EventHandler _changeSelectedEvent;

        /// <summary>
        /// Событие вызываемое при смене индекса в списке
        /// </summary>
        [Category("Special event"), Description("Событие вызываемое при смене выбранного элемента")]
        public event EventHandler ChangeSelectedEvent
        {
            add { _changeSelectedEvent += value; }
            remove { _changeSelectedEvent -= value; }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changeSelectedEvent.Invoke(sender, e);
        }
    }
}
