using System;
using System.Drawing;
using System.Windows.Forms;

namespace LaboratoryWorks
{
    public sealed partial class StartForm : Form
    {
        private readonly ComboBox _worksListComboBox = new()
        {
            Size = new Size(283, 23),
            Location = new Point(5, 5),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Items = {
                "ЛР №1 «Создание Windows-приложения мастерами Visual Studio»",
                "ЛР №2 «Представление таблиц, связанных отношением \"один ко многим\"»",
                "ЛР №3 «Создание вручную Windows-приложения для работы с БД»",
                "ЛР №4 «Представление данных связанных отношением \"многие ко многим\"»",
                "ЛР №5 «Использование справочников в формах диалога с БД»"
            },
            SelectedIndex = 0
        };

        private readonly Button _openWorkButton = new()
        {
            Size = new Size(85, 23),
            Location = new Point(292, 5),
            Text = "ОК"
        };

        public StartForm()
        {
            InitializeComponent();

            // Настройка формы
            Text = "Лабораторные работы по ADO.NET УрФУ";
            MinimumSize = new Size(400, 72);
            MaximumSize = new Size(400, 72);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(_openWorkButton);
            Controls.Add(_worksListComboBox);

            _openWorkButton.Click += OpenWork;
        }

        private void OpenWork(object sender, EventArgs e)
        {
            var forms = new Form[] {
                new LabWorkForm1(),
                new LabWorkForm2(),
                new LabWorkForm3(),
                new LabWorkForm4(),
                new LabWorkForm5()
            };

            Hide();
            forms[_worksListComboBox.SelectedIndex].ShowDialog();
            Show();
        }
    }
}
