using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Works
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void LoadMainForm(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lessonsUrFUDataSet.Responsibility". При необходимости она может быть перемещена или удалена.
            this.responsibilityTableAdapterLW1.Fill(this.lessonsUrFUDataSet.Responsibility);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lessonsUrFUDataSet.Responsible". При необходимости она может быть перемещена или удалена.
            this.responsibleTableAdapterLW1.Fill(this.lessonsUrFUDataSet.Responsible);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lessonsUrFUDataSet.Equipment". При необходимости она может быть перемещена или удалена.
            this.equipmentTableAdapterLW1.Fill(this.lessonsUrFUDataSet.Equipment);
        }

        /// <summary>
        /// Сохранение элементов в таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveItem(object sender, EventArgs e)
        {
            this.Validate();

            //    this.equipmentBindingSourceLW1.EndEdit();
            //    this.responsibleBindingSourceLW1.EndEdit();
            //    this.responsibilityBindingSourceLW1.EndEdit();

            //    this.tableAdapterManagerLW1.UpdateAll(this.lessonsUrFUDataSet);
        }

        /// <summary>
        /// Обработчик события выполняющий смену источника данных для панели навигации, при выборе элемента
        /// </summary>
        /// <param name="sender">DataGridView вызывающий событие</param>
        /// <exception cref="Exception">Исключение вызываемое, если событие было вызвано не DataGridView</exception>
        //private void ChangeNavigatorBindingSource(object sender, EventArgs e)
        //{
        //    BindingSource source;

        //    if (sender is DataGridView && (sender as DataGridView).DataSource is BindingSource)
        //    {
        //        source = (sender as DataGridView).DataSource as BindingSource;
        //    }
        //    else throw new Exception("Неверное использование события для изменения источника данных для панели навигации. Вызывающий объект не является объектом DataFridView или его источник данных не является объектом BindingSource");

        //    tablesBindingNavigator.BindingSource = source;
        //}
    }
}
