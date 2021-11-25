using CustomWinFormsComponents.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CustomWinFormsComponents.Components
{
    public partial class CustomGrid : UserControl
    {
        /// <summary>
        /// Получает индекс выбранной строки
        /// </summary>
        public int SelectedRow
        {
            set
            {
                dataGridView.ClearSelection();
                if (dataGridView.Rows.Count > value && value >= 0)
                {
                    dataGridView.Rows[value].Selected = true;
                }
            }
            get
            {
                return dataGridView.SelectedRows.Count > 0 ? dataGridView.SelectedRows[0].Index : -1;
            }
        }

        public CustomGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Настраивает колонки в таблице
        /// </summary>
        public void ConfigureColumns(List<CreateColumnModel> userColumns)
        {
            dataGridView.Columns.Clear();
            var columns = GetColumnsArray(userColumns);
            dataGridView.Columns.AddRange(columns);
        }

        /// <summary>
        /// Очищает строки
        /// </summary>
        public void ClearRows()
        {
            dataGridView.DataSource = null;
        }

        /// <summary>
        /// Получает объект из выделенной строки
        /// </summary>
        public T GetSelectedItem<T>()
        {
            if (SelectedRow == -1)
                throw new Exception("Выберите строку");

            T result = (T)Activator.CreateInstance(typeof(T));
            var prop = typeof(T).GetProperties();
            foreach (var el in prop)
            {
                var elName = el.Name.ToLower();
                if (dataGridView.Columns[elName] != null)
                {
                    var value = dataGridView.SelectedRows[0].Cells[elName].Value;
                    el.SetValue(result, value);
                }
            }
            return result;
        }

        /// <summary>
        /// Добавляет данные в таблицу
        /// </summary>
        public void AddData<T>(List<T> data)
        {
            if (data == null || data.Count == 0)
                return;

            dataGridView.DataSource = data;
        }

        private DataGridViewColumn[] GetColumnsArray(List<CreateColumnModel> list)
        {
            if (list == null)
                return new DataGridViewColumn[] { };

            return list.Where(el => el != null).Select(CreateModel).ToArray();
        }

        private DataGridViewColumn CreateModel(CreateColumnModel model)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = model.Header,
                Width = model.Width,
                Visible = model.Visible,
                Name = model.DataColumnName,
                DataPropertyName = model.DataColumnName
            };
        }
    }
}
