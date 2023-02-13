namespace LaboratoryWorks
{
    partial class LabWorkForm1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabWorkForm1));
            this.labelResponsibility = new System.Windows.Forms.Label();
            this.labelResponsible = new System.Windows.Forms.Label();
            this.labelEquipment = new System.Windows.Forms.Label();
            this.dataGridViewResponsibility = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnDateOfReceiving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnPurposeOfUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnReasonForReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceResponsibility = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetLessonsUrfu = new LaboratoryWorks.dataSetLessonsUrfu();
            this.dataGridViewResponsible = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumnPersonnelNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnPatronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnWorkshop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnRoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceResponsible = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumnInventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnRegistrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnWarrantyServiceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceEquipment = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterEquipment = new LaboratoryWorks.lessonsUrFUDataSetTableAdapters.EquipmentTableAdapter();
            this.tableAdapterManager = new LaboratoryWorks.lessonsUrFUDataSetTableAdapters.TableAdapterManager();
            this.tableAdapterResponsibility = new LaboratoryWorks.lessonsUrFUDataSetTableAdapters.ResponsibilityTableAdapter();
            this.tableAdapterResponsible = new LaboratoryWorks.lessonsUrFUDataSetTableAdapters.ResponsibleTableAdapter();
            this.tablesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.navigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.navigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.navigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.navigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.navigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResponsibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLessonsUrfu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResponsible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingNavigator)).BeginInit();
            this.tablesBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelResponsibility
            // 
            this.labelResponsibility.AutoSize = true;
            this.labelResponsibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResponsibility.Location = new System.Drawing.Point(15, 359);
            this.labelResponsibility.Name = "labelResponsibility";
            this.labelResponsibility.Size = new System.Drawing.Size(333, 13);
            this.labelResponsibility.TabIndex = 0;
            this.labelResponsibility.Text = "Таблица-связей «Ответственность за оборудование»:";
            // 
            // labelResponsible
            // 
            this.labelResponsible.AutoSize = true;
            this.labelResponsible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResponsible.Location = new System.Drawing.Point(555, 26);
            this.labelResponsible.Name = "labelResponsible";
            this.labelResponsible.Size = new System.Drawing.Size(171, 13);
            this.labelResponsible.TabIndex = 0;
            this.labelResponsible.Text = "Таблица «Ответственные»:";
            // 
            // labelEquipment
            // 
            this.labelEquipment.AutoSize = true;
            this.labelEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEquipment.Location = new System.Drawing.Point(15, 26);
            this.labelEquipment.Name = "labelEquipment";
            this.labelEquipment.Size = new System.Drawing.Size(164, 13);
            this.labelEquipment.TabIndex = 0;
            this.labelEquipment.Text = "Таблица «Оборудование»:";
            // 
            // responsibilityDataGridView
            // 
            this.dataGridViewResponsibility.AutoGenerateColumns = false;
            this.dataGridViewResponsibility.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResponsibility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResponsibility.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnId,
            this.dataGridViewTextBoxColumnResponsible,
            this.dataGridViewTextBoxColumnEquipment,
            this.dataGridViewTextBoxColumnDateOfReceiving,
            this.dataGridViewTextBoxColumnReturnDate,
            this.dataGridViewTextBoxColumnPurposeOfUse,
            this.dataGridViewTextBoxColumnReasonForReturn});
            this.dataGridViewResponsibility.DataSource = this.bindingSourceResponsibility;
            this.dataGridViewResponsibility.Location = new System.Drawing.Point(12, 374);
            this.dataGridViewResponsibility.Name = "dataGridViewResponsibility";
            this.dataGridViewResponsibility.Size = new System.Drawing.Size(1060, 275);
            this.dataGridViewResponsibility.TabIndex = 2;
            this.dataGridViewResponsibility.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeNavigatorBindingSource);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnId.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumnId.HeaderText = "Уникальный номер записи";
            this.dataGridViewTextBoxColumnId.Name = "dataGridViewTextBoxColumnId";
            this.dataGridViewTextBoxColumnId.ReadOnly = true;
            // 
            // responsibleDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnResponsible.DataPropertyName = "Responsible";
            this.dataGridViewTextBoxColumnResponsible.HeaderText = "Табельный номер ответственного";
            this.dataGridViewTextBoxColumnResponsible.Name = "dataGridViewTextBoxColumnResponsible";
            // 
            // equipmentDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnEquipment.DataPropertyName = "Equipment";
            this.dataGridViewTextBoxColumnEquipment.HeaderText = "Инвентарный ID оборудования";
            this.dataGridViewTextBoxColumnEquipment.Name = "dataGridViewTextBoxColumnEquipment";
            // 
            // dateOfReceivingDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnDateOfReceiving.DataPropertyName = "DateOfReceiving";
            this.dataGridViewTextBoxColumnDateOfReceiving.HeaderText = "Дата получения";
            this.dataGridViewTextBoxColumnDateOfReceiving.Name = "dataGridViewTextBoxColumnDateOfReceiving";
            // 
            // returnDateDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnReturnDate.DataPropertyName = "ReturnDate";
            this.dataGridViewTextBoxColumnReturnDate.HeaderText = "Дата возврата";
            this.dataGridViewTextBoxColumnReturnDate.Name = "dataGridViewTextBoxColumnReturnDate";
            // 
            // purposeOfUseDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnPurposeOfUse.DataPropertyName = "PurposeOfUse";
            this.dataGridViewTextBoxColumnPurposeOfUse.HeaderText = "Цель использования";
            this.dataGridViewTextBoxColumnPurposeOfUse.Name = "dataGridViewTextBoxColumnPurposeOfUse";
            // 
            // reasonForReturnDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnReasonForReturn.DataPropertyName = "ReasonForReturn";
            this.dataGridViewTextBoxColumnReasonForReturn.HeaderText = "Причина возврата";
            this.dataGridViewTextBoxColumnReasonForReturn.Name = "dataGridViewTextBoxColumnReasonForReturn";
            // 
            // responsibilityBindingSource
            // 
            this.bindingSourceResponsibility.DataMember = "Responsibility";
            this.bindingSourceResponsibility.DataSource = this.dataSetLessonsUrfu;
            // 
            // lessonsUrFUDataSet
            // 
            this.dataSetLessonsUrfu.DataSetName = "lessonsUrFUDataSet";
            this.dataSetLessonsUrfu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // responsibleDataGridView
            // 
            this.dataGridViewResponsible.AutoGenerateColumns = false;
            this.dataGridViewResponsible.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResponsible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResponsible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnPersonnelNumber,
            this.dataGridViewTextBoxColumnSurname,
            this.dataGridViewTextBoxColumnName,
            this.DataGridViewTextBoxColumnPatronymic,
            this.dataGridViewTextBoxColumnWorkshop,
            this.dataGridViewTextBoxColumnLotNumber,
            this.dataGridViewTextBoxColumnDepartment,
            this.dataGridViewTextBoxColumnRoomNumber,
            this.dataGridViewTextBoxColumnTelephone});
            this.dataGridViewResponsible.DataSource = this.bindingSourceResponsible;
            this.dataGridViewResponsible.Location = new System.Drawing.Point(552, 41);
            this.dataGridViewResponsible.Name = "dataGridViewResponsible";
            this.dataGridViewResponsible.Size = new System.Drawing.Size(520, 307);
            this.dataGridViewResponsible.TabIndex = 1;
            this.dataGridViewResponsible.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeNavigatorBindingSource);
            // 
            // personnelNumberDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnPersonnelNumber.DataPropertyName = "PersonnelNumber";
            this.dataGridViewTextBoxColumnPersonnelNumber.HeaderText = "Табельный номер сотрудника";
            this.dataGridViewTextBoxColumnPersonnelNumber.Name = "dataGridViewTextBoxColumnPersonnelNumber";
            this.dataGridViewTextBoxColumnPersonnelNumber.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnSurname.DataPropertyName = "Surname";
            this.dataGridViewTextBoxColumnSurname.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumnSurname.Name = "dataGridViewTextBoxColumnSurname";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnName.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumnName.HeaderText = "Имя";
            this.dataGridViewTextBoxColumnName.Name = "dataGridViewTextBoxColumnName";
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.DataGridViewTextBoxColumnPatronymic.DataPropertyName = "MiddleName";
            this.DataGridViewTextBoxColumnPatronymic.HeaderText = "Отчество";
            this.DataGridViewTextBoxColumnPatronymic.Name = "DataGridViewTextBoxColumnPatronymic";
            // 
            // workshopDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnWorkshop.DataPropertyName = "Workshop";
            this.dataGridViewTextBoxColumnWorkshop.HeaderText = "Цех";
            this.dataGridViewTextBoxColumnWorkshop.Name = "dataGridViewTextBoxColumnWorkshop";
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnLotNumber.DataPropertyName = "LotNumber";
            this.dataGridViewTextBoxColumnLotNumber.HeaderText = "Номер участка";
            this.dataGridViewTextBoxColumnLotNumber.Name = "dataGridViewTextBoxColumnLotNumber";
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnDepartment.DataPropertyName = "Department";
            this.dataGridViewTextBoxColumnDepartment.HeaderText = "Отдел";
            this.dataGridViewTextBoxColumnDepartment.Name = "dataGridViewTextBoxColumnDepartment";
            // 
            // roomNumberDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnRoomNumber.DataPropertyName = "RoomNumber";
            this.dataGridViewTextBoxColumnRoomNumber.HeaderText = "Номер комнаты";
            this.dataGridViewTextBoxColumnRoomNumber.Name = "dataGridViewTextBoxColumnRoomNumber";
            // 
            // telephoneDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnTelephone.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumnTelephone.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumnTelephone.Name = "dataGridViewTextBoxColumnTelephone";
            // 
            // responsibleBindingSource
            // 
            this.bindingSourceResponsible.DataMember = "Responsible";
            this.bindingSourceResponsible.DataSource = this.dataSetLessonsUrfu;
            // 
            // equipmentDataGridView
            // 
            this.dataGridViewEquipment.AutoGenerateColumns = false;
            this.dataGridViewEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnInventoryId,
            this.dataGridViewTextBoxColumnSerialNumber,
            this.dataGridViewTextBoxColumnEquipmentName,
            this.dataGridViewTextBoxColumnRegistrationDate,
            this.dataGridViewTextBoxColumnPrice,
            this.dataGridViewTextBoxColumnWarrantyServiceAddress,
            this.dataGridViewTextBoxColumnSupplier});
            this.dataGridViewEquipment.DataSource = this.bindingSourceEquipment;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.Size = new System.Drawing.Size(520, 307);
            this.dataGridViewEquipment.TabIndex = 0;
            this.dataGridViewEquipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeNavigatorBindingSource);
            // 
            // inventoryIdDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnInventoryId.DataPropertyName = "InventoryID";
            this.dataGridViewTextBoxColumnInventoryId.HeaderText = "Инвентарный номер оборудования";
            this.dataGridViewTextBoxColumnInventoryId.Name = "dataGridViewTextBoxColumnInventoryId";
            this.dataGridViewTextBoxColumnInventoryId.ReadOnly = true;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnSerialNumber.DataPropertyName = "SerialNumber";
            this.dataGridViewTextBoxColumnSerialNumber.HeaderText = "Серийный номер";
            this.dataGridViewTextBoxColumnSerialNumber.Name = "dataGridViewTextBoxColumnSerialNumber";
            // 
            // equipmentNameDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnEquipmentName.DataPropertyName = "EquipmentName";
            this.dataGridViewTextBoxColumnEquipmentName.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumnEquipmentName.Name = "dataGridViewTextBoxColumnEquipmentName";
            // 
            // registrationDateDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnRegistrationDate.DataPropertyName = "RegistrationDate";
            this.dataGridViewTextBoxColumnRegistrationDate.HeaderText = "Дата регистрации";
            this.dataGridViewTextBoxColumnRegistrationDate.Name = "dataGridViewTextBoxColumnRegistrationDate";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnPrice.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumnPrice.HeaderText = "Стоимость";
            this.dataGridViewTextBoxColumnPrice.Name = "dataGridViewTextBoxColumnPrice";
            // 
            // warrantyServiceAddressDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnWarrantyServiceAddress.DataPropertyName = "WarrantyServiceAddress";
            this.dataGridViewTextBoxColumnWarrantyServiceAddress.HeaderText = "Адреса гарантийного обслуживания";
            this.dataGridViewTextBoxColumnWarrantyServiceAddress.Name = "dataGridViewTextBoxColumnWarrantyServiceAddress";
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.dataGridViewTextBoxColumnSupplier.DataPropertyName = "Supplier";
            this.dataGridViewTextBoxColumnSupplier.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumnSupplier.Name = "dataGridViewTextBoxColumnSupplier";
            // 
            // equipmentBindingSource
            // 
            this.bindingSourceEquipment.DataMember = "Equipment";
            this.bindingSourceEquipment.DataSource = this.dataSetLessonsUrfu;
            // 
            // equipmentTableAdapter
            // 
            this.tableAdapterEquipment.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EquipmentTableAdapter = this.tableAdapterEquipment;
            this.tableAdapterManager.ReasonsForReturnTableAdapter = null;
            this.tableAdapterManager.ResponsibilityTableAdapter = this.tableAdapterResponsibility;
            this.tableAdapterManager.ResponsibleTableAdapter = this.tableAdapterResponsible;
            this.tableAdapterManager.SuppliersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LaboratoryWorks.lessonsUrFUDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // responsibilityTableAdapter
            // 
            this.tableAdapterResponsibility.ClearBeforeFill = true;
            // 
            // responsibleTableAdapter
            // 
            this.tableAdapterResponsible.ClearBeforeFill = true;
            // 
            // tablesBindingNavigator
            // 
            this.tablesBindingNavigator.AddNewItem = this.navigatorAddNewItem;
            this.tablesBindingNavigator.BindingSource = this.bindingSourceEquipment;
            this.tablesBindingNavigator.CountItem = this.navigatorCountItem;
            this.tablesBindingNavigator.CountItemFormat = "из {0}";
            this.tablesBindingNavigator.DeleteItem = this.navigatorDeleteItem;
            this.tablesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigatorMoveFirstItem,
            this.navigatorMovePreviousItem,
            this.navigatorPositionItem,
            this.navigatorCountItem,
            this.navigatorMoveNextItem,
            this.navigatorMoveLastItem,
            this.navigatorSeparator,
            this.navigatorAddNewItem,
            this.navigatorDeleteItem,
            this.navigatorSaveItem});
            this.tablesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tablesBindingNavigator.MoveFirstItem = this.navigatorMoveFirstItem;
            this.tablesBindingNavigator.MoveLastItem = this.navigatorMoveLastItem;
            this.tablesBindingNavigator.MoveNextItem = this.navigatorMoveNextItem;
            this.tablesBindingNavigator.MovePreviousItem = this.navigatorMovePreviousItem;
            this.tablesBindingNavigator.Name = "tablesBindingNavigator";
            this.tablesBindingNavigator.PositionItem = this.navigatorPositionItem;
            this.tablesBindingNavigator.Size = new System.Drawing.Size(1084, 25);
            this.tablesBindingNavigator.TabIndex = 1;
            this.tablesBindingNavigator.Text = "Пенель навигации";
            // 
            // navigatorAddNewItem
            // 
            this.navigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorAddNewItem.Image")));
            this.navigatorAddNewItem.Name = "navigatorAddNewItem";
            this.navigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.navigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorAddNewItem.Text = "Добавить";
            // 
            // navigatorCountItem
            // 
            this.navigatorCountItem.Name = "navigatorCountItem";
            this.navigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.navigatorCountItem.Text = "из {0}";
            this.navigatorCountItem.ToolTipText = "Всего строк";
            // 
            // navigatorDeleteItem
            // 
            this.navigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorDeleteItem.Image")));
            this.navigatorDeleteItem.Name = "navigatorDeleteItem";
            this.navigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.navigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorDeleteItem.Text = "Удалить";
            // 
            // navigatorMoveFirstItem
            // 
            this.navigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorMoveFirstItem.Image")));
            this.navigatorMoveFirstItem.Name = "navigatorMoveFirstItem";
            this.navigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.navigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorMoveFirstItem.Text = "Перейти в начало";
            // 
            // navigatorMovePreviousItem
            // 
            this.navigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorMovePreviousItem.Image")));
            this.navigatorMovePreviousItem.Name = "navigatorMovePreviousItem";
            this.navigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.navigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorMovePreviousItem.Text = "Перейти назад";
            // 
            // navigatorPositionItem
            // 
            this.navigatorPositionItem.AccessibleName = "Положение";
            this.navigatorPositionItem.AutoSize = false;
            this.navigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.navigatorPositionItem.Name = "navigatorPositionItem";
            this.navigatorPositionItem.Size = new System.Drawing.Size(40, 23);
            this.navigatorPositionItem.Text = "0";
            this.navigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.navigatorPositionItem.ToolTipText = "Текущая строка";
            // 
            // navigatorMoveNextItem
            // 
            this.navigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorMoveNextItem.Image")));
            this.navigatorMoveNextItem.Name = "navigatorMoveNextItem";
            this.navigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.navigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorMoveNextItem.Text = "Перейти вперед";
            // 
            // navigatorMoveLastItem
            // 
            this.navigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorMoveLastItem.Image")));
            this.navigatorMoveLastItem.Name = "navigatorMoveLastItem";
            this.navigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.navigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorMoveLastItem.Text = "Перейти в конец";
            // 
            // navigatorSeparator
            // 
            this.navigatorSeparator.Name = "navigatorSeparator";
            this.navigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // navigatorSaveItem
            // 
            this.navigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("navigatorSaveItem.Image")));
            this.navigatorSaveItem.Name = "navigatorSaveItem";
            this.navigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.navigatorSaveItem.Text = "Сохранить изменения";
            this.navigatorSaveItem.Click += new System.EventHandler(this.SaveItem);
            // 
            // MainFormLW1
            // 
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.tablesBindingNavigator);
            this.Controls.Add(this.labelResponsibility);
            this.Controls.Add(this.labelResponsible);
            this.Controls.Add(this.labelEquipment);
            this.Controls.Add(this.dataGridViewResponsibility);
            this.Controls.Add(this.dataGridViewResponsible);
            this.Controls.Add(this.dataGridViewEquipment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 700);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainFormLW1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №1 по ADO.NET УрФУ";
            this.Load += new System.EventHandler(this.LoadMainForm);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResponsibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLessonsUrfu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResponsible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingNavigator)).EndInit();
            this.tablesBindingNavigator.ResumeLayout(false);
            this.tablesBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        // ------------------------------------
        // Панель навигации -------------------
        // ------------------------------------

        /// <summary>
        /// Панель навигации при работе с таблицами
        /// </summary>
        private System.Windows.Forms.BindingNavigator tablesBindingNavigator;

        /// <summary>
        /// Кнопка на панели навигации для перехода к первой строке
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorMoveFirstItem;

        /// <summary>
        /// Кнопка на панели навигации для перехода к предыдущей строке
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorMovePreviousItem;

        /// <summary>
        /// Текстовое поле на панели навигации отображающее номер текущей строки
        /// </summary>
        private System.Windows.Forms.ToolStripTextBox navigatorPositionItem;

        /// <summary>
        /// Текстовая метка на панели навигации отображающее общее количество строк
        /// </summary>
        private System.Windows.Forms.ToolStripLabel navigatorCountItem;

        /// <summary>
        /// Кнопка на панели навигации для перехода к следующей строке
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorMoveNextItem;

        /// <summary>
        /// Кнопка на панели навигации для перехода к последней строке
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorMoveLastItem;

        /// <summary>
        /// Разделитель на панели навигации, для разделения блока кнопок для навигации и 
        /// кнопок для добавления, изменения и сохранения
        /// </summary>
        private System.Windows.Forms.ToolStripSeparator navigatorSeparator;

        /// <summary>
        /// Кнопка на панели навигации для добавления новой строки
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorAddNewItem;

        /// <summary>
        /// Кнопка на панели навигации для удаления строки
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorDeleteItem;

        /// <summary>
        /// Кнопка на панели навигации для сохранения изменений
        /// </summary>
        private System.Windows.Forms.ToolStripButton navigatorSaveItem;



        // ------------------------------------
        // Вкладки ----------------------------
        // ------------------------------------


        /// <summary>
        /// DataSet для работы с базой данных lessonsUrFU
        /// </summary>
        private dataSetLessonsUrfu dataSetLessonsUrfu;


        
        // ------------------------------------
        // Текстовые метки в качестве ---------
        // заголовков перед таблицами ---------
        // ------------------------------------

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.Label labelEquipment;

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы «Ответственные»
        /// </summary>
        private System.Windows.Forms.Label labelResponsible;

        /// <summary>
        /// Текстовая метка, в качестве заголовка таблицы связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.Label labelResponsibility;



        // ------------------------------------
        // Источники данных -------------------
        // ------------------------------------

        /// <summary>
        /// Источник данных для таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.BindingSource bindingSourceEquipment;

        /// <summary>
        /// Источник данных для таблицы «Ответственные»
        /// </summary>
        private System.Windows.Forms.BindingSource bindingSourceResponsible;

        /// <summary>
        /// Источник данных для таблицы связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.BindingSource bindingSourceResponsibility;



        // ------------------------------------
        // Табличные адаптеры -----------------
        // ------------------------------------

        private lessonsUrFUDataSetTableAdapters.TableAdapterManager tableAdapterManager;

        /// <summary>
        /// Табличный адаптер для работы с таблицей «Оборудование», базы данных «lessonsUrFU»
        /// </summary>
        private lessonsUrFUDataSetTableAdapters.EquipmentTableAdapter tableAdapterEquipment;


        /// <summary>
        /// Табличный адаптер для работы с таблицей «Ответственные», базы данных «lessonsUrFU»
        /// </summary>
        private lessonsUrFUDataSetTableAdapters.ResponsibleTableAdapter tableAdapterResponsible;

        /// <summary>
        /// Табличный адаптер для работы с таблицей-связей «Ответственность за оборудование», базы данных «lessonsUrFU»
        /// </summary>
        private lessonsUrFUDataSetTableAdapters.ResponsibilityTableAdapter tableAdapterResponsibility;



        // ------------------------------------
        // DatGridViews -----------------------
        // ------------------------------------

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridViewEquipment;

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы «Ответственные»
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridViewResponsible;

        /// <summary>
        /// DataGridView для отображения столбцов и строк таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridViewResponsibility;



        // ------------------------------------
        // Столбцы таблицы «Оборудование» -----
        // ------------------------------------

        /// <summary>
        /// Столбец «Инвентарный номер оборудования» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnInventoryId;

        /// <summary>
        /// Столбец «Серийный номер» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnSerialNumber;

        /// <summary>
        /// Столбец «Наименование» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnEquipmentName;

        /// <summary>
        /// Столбец «Дата регистрации» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnRegistrationDate;

        /// <summary>
        /// Столбец «Стоимость» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnPrice;

        /// <summary>
        /// Столбец «Адреса гарантийного обслуживания» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnWarrantyServiceAddress;

        /// <summary>
        /// Столбец «Поставщик» таблицы «Оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnSupplier;



        // ------------------------------------
        // Столбцы таблицы «Ответственные» ----
        // ------------------------------------

        /// <summary>
        /// Столбец «Табельный номер сотрудника» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnPersonnelNumber;

        /// <summary>
        /// Столбец «Фамилия» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnSurname;

        /// <summary>
        /// Столбец «Имя» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnName;

        /// <summary>
        /// Столбец «Отчество» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnPatronymic;

        /// <summary>
        /// Столбец «Цех» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnWorkshop;

        /// <summary>
        /// Столбец «Номер участка» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnLotNumber;

        /// <summary>
        /// Столбец «Отдел» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDepartment;

        /// <summary>
        /// Столбец «Номер комнаты» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnRoomNumber;

        /// <summary>
        /// Столбец «Телефон» таблицы «Ответственны»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnTelephone;



        // ------------------------------------
        // Столбцы таблицы для связей        --
        // «Ответственность за оборудование» --
        // ------------------------------------

        /// <summary>
        /// Столбец «Уникальный номер записи» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnId;

        /// <summary>
        /// Столбец «Табельный номер ответственного» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnResponsible;

        /// <summary>
        /// Столбец «Инвентарный ID оборудования» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnEquipment;

        /// <summary>
        /// Столбец «Дата получения» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDateOfReceiving;

        /// <summary>
        /// Столбец «Дата возврата» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnReturnDate;

        /// <summary>
        /// Столбец «Цель использования» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnPurposeOfUse;

        /// <summary>
        /// Столбец «Причина возврата» таблицы-связей «Ответственность за оборудование»
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnReasonForReturn;
    }
}