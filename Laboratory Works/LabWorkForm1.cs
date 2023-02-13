using System;
using System.Windows.Forms;

namespace LaboratoryWorks
{
    public sealed partial class LabWorkForm1 : Form
    {
        public LabWorkForm1()
        {
            InitializeComponent();
        }

        private void LoadMainForm(object sender, EventArgs e)
        {
            tableAdapterResponsibility.Fill(dataSetLessonsUrfu.Responsibility);
            tableAdapterResponsible.Fill(dataSetLessonsUrfu.Responsible);
            tableAdapterEquipment.Fill(dataSetLessonsUrfu.Equipment);
        }

        /// <summary>
        /// Сохранение элементов в таблицы
        /// </summary>
        private void SaveItem(object sender, EventArgs e)
        {
            Validate();

            bindingSourceEquipment.EndEdit();
            bindingSourceResponsible.EndEdit();
            bindingSourceResponsibility.EndEdit();

            tableAdapterManager.UpdateAll(dataSetLessonsUrfu);
        }

        /// <summary>
        /// Обработчик события выполняющий смену источника данных для панели навигации, при выборе элемента
        /// </summary>
        /// <param name="sender">DataGridView вызывающий событие</param>
        private void ChangeNavigatorBindingSource(object sender, DataGridViewCellEventArgs e) =>
            tablesBindingNavigator.BindingSource = (sender as DataGridView)?.DataSource as BindingSource;
    }
}