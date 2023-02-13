using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace LaboratoryWorks
{
    public sealed partial class LabWorkForm3 : Form
    {
        private static readonly System.ComponentModel.ComponentResourceManager Resources = new(typeof(LabWorkForm3));

        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private readonly SqlConnection _sqlConnection = new ("Data Source=localhost;" +
                                                             "Initial Catalog=lessonsUrFU;" +
                                                             "Persist Security Info=True;" +
                                                             "User ID=sa;" +
                                                             "Password=KqGN?a9Yvi");


        // ------------------------------------
        // Текстовые метки в качестве ---------
        // заголовков перед таблицами ---------
        // ------------------------------------

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы «Оборудование»
        /// </summary>
        private readonly Label _labelEquipment = new()
        {
            AutoSize = true,
            Location = new Point(15, 26),
            Text = "Таблица «Оборудование»:",
            Font = new Font("Arial", 8.25F, FontStyle.Bold),
            TabIndex = 0
        };

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы «Ответственные»
        /// </summary>
        private readonly Label _labelResponsible = new()
        {
            AutoSize = true,
            Location = new Point(555, 26),
            Text = "Таблица «Ответственные»:",
            Font = new Font("Arial", 8.25F, FontStyle.Bold),
            TabIndex = 0
        };

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы связей «Ответственность за оборудование»
        /// </summary>
        private readonly Label _labelResponsibility = new()
        {
            AutoSize = true,
            Location = new Point(15, 359),
            Text = "Таблица-связей «Ответственность за оборудование»:",
            Font = new Font("Arial", 8.25F, FontStyle.Bold),
            TabIndex = 0
        };


        // ------------------------------------
        // DatGridViews -----------------------
        // ------------------------------------

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы «Оборудование»
        /// </summary>
        private readonly DataGridView _dataGridViewEquipment = new()
        {
            Size = new Size(520, 307),
            Location = new Point(12, 41),
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            TabIndex = 1
        };

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы «Ответственные»
        /// </summary>
        private readonly DataGridView _dataGridViewResponsible = new()
        {
            Size = new Size(520, 307),
            Location = new Point(552, 41),
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            TabIndex = 2
        };

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private readonly DataGridView _dataGridViewResponsibility = new()
        {
            Size = new Size(1060, 275),
            Location = new Point(12, 374),
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            TabIndex = 3
        };


        // ------------------------------------
        // DataTable --------------------------
        // ------------------------------------
        private readonly DataTable _dataTableEquipment = new();

        private readonly DataTable _dataTableResponsible = new();

        private readonly DataTable _dataTableResponsibility = new();


        // ------------------------------------
        // SqlDataAdapter ---------------------
        // ------------------------------------
        private readonly SqlDataAdapter _dataAdapterEquipment;

        private readonly SqlDataAdapter _dataAdapterResponsible;

        private readonly SqlDataAdapter _dataAdapterResponsibility;


        // ------------------------------------
        // Кнопки -----------------------------
        // ------------------------------------
        private readonly Button _buttonSave = new()
        {
            Location = new Point(988, 9),
            Size = new Size(85, 23),
            Text = "Сохранить",
            TextAlign = ContentAlignment.MiddleRight,
            Image = (Image)Resources.GetObject("save.Image"),
            ImageAlign = ContentAlignment.MiddleLeft,
            TabIndex = 4
        };


        // ------------------------------------
        // Конструктор ------------------------
        // ------------------------------------

        public LabWorkForm3()
        {
            InitializeComponent();

            // Настроки формы
            this.Text = "Лабораторная работа №3 по ADO.NET УрФУ";
            this.MinimumSize = new Size(1100, 700);
            this.MaximumSize = new Size(1100, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Добавление текстовых меток на форму
            this.Controls.Add(_labelEquipment);
            this.Controls.Add(_labelResponsible);
            this.Controls.Add(_labelResponsibility);

            // Добавление DataGridView-ов на форму
            this.Controls.Add(_dataGridViewEquipment);
            this.Controls.Add(_dataGridViewResponsible);
            this.Controls.Add(_dataGridViewResponsibility);

            // Добавление кнопки на форму
            this.Controls.Add(_buttonSave);


            // --------------------------------
            // Работа с базой данных ----------
            // --------------------------------

            // Создание запросов на получение данных
            var commands = new[]
            {
                new SqlCommand(@"SELECT InventoryID            AS N'Инвентарный номер оборудования',
                                        SerialNumber           AS N'Серийный номер',
                                        EquipmentName          AS N'Наименование',
                                        RegistrationDate       AS N'Дата регистрации',
                                        Price                  AS N'Цена',
                                        WarrantyServiceAddress AS N'Адреса гарантийного обслуживания',
                                        Supplier               AS N'Поставщик'
                                 FROM Equipment;", _sqlConnection),

                new SqlCommand(@"SELECT PersonnelNumber AS N'Табельный номер сотрудника',
                                        Surname         AS N'Фамилия',
                                        Name            AS N'Имя',
                                        MiddleName      AS N'Отчество',
                                        Workshop        AS N'Цех',
                                        LotNumber       AS N'Номер участка',
                                        Department      AS N'Отдел',
                                        RoomNumber      AS N'Номер комнаты',
                                        Telephone       AS N'Телефон'
                                 FROM Responsible;", _sqlConnection),

                new SqlCommand(@"SELECT Id              AS N'Уникальный номер записи',
                                        Responsible     AS N'Табельный номер ответственного',
                                        Equipment       AS N'Инвентарный ID оборудования',
                                        DateOfReceiving AS N'Дата получения',
                                        ReturnDate      AS N'Дата возврата',
                                        PurposeOfUse    AS N'Цель использования',
                                        ReasonForReturn AS N'Причина возврата'
                                 FROM Responsibility;", _sqlConnection)
            };

            _sqlConnection.Open();

            try
            {
                // Создания SQL адаптеров на основе ранее созданных объектов-команд
                _dataAdapterEquipment = new SqlDataAdapter(commands[0]);
                _dataAdapterResponsible = new SqlDataAdapter(commands[1]);
                _dataAdapterResponsibility = new SqlDataAdapter(commands[2]);

                var dataAdapters = new[]
                {
                    _dataAdapterEquipment, 
                    _dataAdapterResponsible, 
                    _dataAdapterResponsibility
                };
                var dataTables = new[]
                {
                    _dataTableEquipment, 
                    _dataTableResponsible,
                    _dataTableResponsibility
                };
                var dataGridViews = new[]
                {
                    _dataGridViewEquipment, 
                    _dataGridViewResponsible, 
                    _dataGridViewResponsibility
                };


                for (int i = 0; i < 3; i++)
                {
                    dataTables[i].Reset();

                    // Отпрака запроса
                    dataAdapters[i].Fill(dataTables[i]);

                    // Связка DataGridView с DataTable
                    dataGridViews[i].DataSource = dataTables[i];
                }
            }
            finally
            {
                _sqlConnection.Close();
            }

            _buttonSave.Click += SaveData;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку «Сохранить»
        /// </summary>
        private void SaveData(object sender, EventArgs e)
        {
            // Создание необходимых объектов, включая объекы SqlCommandBuilder, выполняющий автоматическое создание однотабличных команд
            var dataAdapters = new[]
            {
                _dataAdapterEquipment, 
                _dataAdapterResponsible,
                _dataAdapterResponsibility
            };
            var dataTables = new[]
            {
                _dataTableEquipment,
                _dataTableResponsible,
                _dataTableResponsibility
            };
            var commandsBuilders = new[]
            {
                new SqlCommandBuilder(_dataAdapterEquipment),
                new SqlCommandBuilder(_dataAdapterResponsible),
                new SqlCommandBuilder(_dataAdapterResponsibility)
            };

            for (int i = 0; i < 3; i++)
            {
                _sqlConnection.Open();

                try
                {
                    dataAdapters[i].UpdateCommand = commandsBuilders[i].GetUpdateCommand();
                    dataAdapters[i].InsertCommand = commandsBuilders[i].GetInsertCommand();
                    dataAdapters[i].DeleteCommand = commandsBuilders[i].GetDeleteCommand();

                    // Отправка изменений
                    dataAdapters[i].Update(dataTables[i]);
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }
    }
}