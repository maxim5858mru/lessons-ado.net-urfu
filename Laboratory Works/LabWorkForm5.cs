using System;
using System.Windows.Forms;

namespace LaboratoryWorks
{
    public sealed partial class LabWorkForm5 : Form
    {
        public LabWorkForm5()
        {
            InitializeComponent();
            dataGridViewEquipment.Focus();
        }

        private void LoadMainForm(object sender, EventArgs e)
        {
            tableAdapterSuppliers.Fill(dataSetLessonsUrfu.Suppliers);
            tableAdapterReasonsForReturn.Fill(dataSetLessonsUrfu.ReasonsForReturn);
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
            bindingSourceSuppliers.EndEdit();
            bindingSourceReasonsForReturn.EndEdit();

            tableAdapterManager.UpdateAll(dataSetLessonsUrfu);
        }

        /// <summary>
        /// Обработчик события выполняющий смену источника данных для панели навигации, при выборе элемента,
        /// а также изменение полей текущей записи в GroupBox
        /// </summary>
        private void SelectionChanged(object sender, EventArgs e)
        {
            var source = (sender as DataGridView)!.DataSource as BindingSource;
            var textBoxes = new[]
            {
                textBoxCurrentId,
                textBoxCurrentResponsible,
                textBoxCurrentEquipment,
                textBoxCurrentDateOfReceiving,
                textBoxCurrentReturnDate,
                textBoxCurrentPurposeOfUse,
                textBoxCurrentReasonForReturn
            };


            // Изменяем привязку
            if (source == bindingSourceEquipment)
            {
                bindingSourceResponsibility.DataSource = source;
                bindingSourceResponsibility.DataMember = "FK_Responsibility_Equipment";
            }
            else if (source == bindingSourceResponsible)
            {
                bindingSourceResponsibility.DataSource = source;
                bindingSourceResponsibility.DataMember = "FK_Responsibility_Responsible";
            }

            // Изменяем значения полей
            if (dataGridViewResponsibility.CurrentRow != null)
            {
                for (var i = 0; i < textBoxes.Length - 1; i++)
                {
                    textBoxes[i].Text = dataGridViewResponsibility.CurrentRow.Cells[i].Value?.ToString();
                }

                // Поиск названия причины возврата
                var reasonForReturnId = (dataGridViewResponsibility.CurrentRow.Cells[textBoxes.Length - 1].Value ?? "").ToString();
                foreach (DataGridViewRow row in dataGridViewReasonsForReturn.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == reasonForReturnId)
                    {
                        textBoxCurrentReasonForReturn.Text = row.Cells[1].Value?.ToString();
                        break;
                    }

                    textBoxCurrentReasonForReturn.Text = "";
                }
            }
            else
            {
                foreach (var textBox in textBoxes)
                {
                    textBox.Text = "";
                }
            }
            
            tablesBindingNavigator.BindingSource = source;
        }
    }
}