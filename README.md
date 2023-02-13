# Отчёты по лабораторным работам ADO.NET

***УрФУ ИРИТ-РФТ  
В рамках изучения дисциплины  
«Средства управления информационными ресурсами АС»
Студента группы РИЗ-300016у  
Кулакова Максима Ивановича***

***Преподаватель Парфенов Ю. П.***

## Лабораторная работа №1 «Создание Windows-приложения мастерами Visual Studio»

### Цель работы

Используя визуальные средства разработки диалоговых форм в Visual Studio создать простое Windows-приложение для работы с
таблицей БД.

### Постановка задачи и вариант задания

1. Постройте или восстановите из предыдущего семестра базу, соответствующую варианту вашего индивидуального задания.
   Варианты индивидуальных заданий приведены в приложении.
2. Наполните таблицы 3-4 строками данными, соответствующими заданным ограничениям.
3. Создайте новый проект приложения Windows в Visual Studio.
4. Предусмотрите в форме пять вкладок по числу выполняемых лабораторных работ.
5. На первой вкладке «Лабораторная работа №1» разместите компоненты, необходимые для просмотра и управления данными из
   основной таблицы индивидуального задания.
6. Проверьте работу приложения добавлением, удалением и изменением данных в основной таблице.
7. Изучите классы, созданные конструктором экранной формы на основе структуры используемой таблицы БД.

**Вариант №10:** Типовые объекты предметной области (сущности): Оборудование - единица оборудования, находящаяся на
материальном учёте (монитор, системный блок, принтер, КИП и т. д.). Ответственный пользователь – сотрудник, несущий
ответственность за сохранность оборудования. Требуется:

- Cвязь «Оборудование» ↔ «Ответственный пользователь»: в разные периоды оборудование предаётся разным пользователям.
  Атрибуты:
    - Дата получения;
    - Дата возврата;
    - Цель использования;
    - Причина возврата. Справочник: поломка оборудования, увольнение сотрудника и т. д.
- Сущность «Оборудование». Атрибуты:
    - Инвентарный номер;
    - Серийный номер;
    - Название;
    - Дата постановки на учёт;
    - Стоимость;
    - Адреса гарантийного сервиса;
    - Поставщик (хранится как отдельная сущность), справочник;
- Сущность «Ответственный пользователь». Атрибуты:
    - Табельный номер;
    - ФИО;
    - Место работы:
    - Цех;
    - Номер участка;
    - Отдел;
    - Номер комнаты.

### Скрипт создания базы данных

```sql
------------------------------------------------------------
-- Создание базы данных
------------------------------------------------------------

USE
master;
GO

DROP
DATABASE IF EXISTS lessonsUrFU;
GO

CREATE
DATABASE lessonsUrFU
    ON PRIMARY
    (
        NAME = lessonUrFU_main_db,
        FILENAME = N'/var/opt/mssql/data/lessonUrFU_main.mdf',
        SIZE = 10 MB,
        MAXSIZE = 15 MB,
        FILEGROWTH = 10%),
    FILEGROUP SECONDARY (
        NAME = lessonUrFU_secondary_db,
        FILENAME = N'/var/opt/mssql/data/lessonUrFU_secondary.ndf',
        SIZE = 5 MB,
        MAXSIZE = 10 MB,
        FILEGROWTH = 10%)
    LOG ON (
    NAME = lessonUrFU_db_log,
    FILENAME = N'/var/opt/mssql/data/lessonUrFU.ldf',
    SIZE = 1 MB,
    MAXSIZE = 5 MB,
    FILEGROWTH = 10%
    );
GO

------------------------------------------------------------
-- Создание таблиц
------------------------------------------------------------

USE lessonsUrFU;
GO

-- Таблица-справочник «Поставщики оборудования»
CREATE TABLE Suppliers
(
    Id           INT IDENTITY,          -- Идентификатор поставщика
    SupplierName NVARCHAR(50) NOT NULL, -- Наименование поставщика
    CONSTRAINT PK_Suppliers PRIMARY KEY (Id),
    CONSTRAINT UQ_Suppliers_SuppliersName UNIQUE (SupplierName)
) ON [SECONDARY];

-- Таблица-справочник «Причина возврата»
CREATE TABLE ReasonsForReturn
(
    Id         INT IDENTITY,          -- Идентификатор причины возврата
    ReasonName NVARCHAR(50) NOT NULL, -- Наименование причины возврата
    CONSTRAINT PK_ReasonsForReturn PRIMARY KEY (Id),
    CONSTRAINT UQ_ReasonsForReturn_ReasonName UNIQUE (ReasonName)
) ON [SECONDARY];
GO

-- Таблица «Оборудование»
CREATE TABLE Equipment
(
    InventoryID            INT IDENTITY,          -- Инвентарный номер оборудования
    SerialNumber           INT  NOT NULL,         -- Серийный номер
    EquipmentName          NVARCHAR(60) NOT NULL, -- Наименование
    RegistrationDate       DATE NOT NULL          -- Дата регистрации
        CONSTRAINT DF_Equipment_RegistrationDate DEFAULT GETDATE(),
    Price                  MONEY NULL,            -- Стоимость
    WarrantyServiceAddress NVARCHAR(100) NULL,    -- Адреса гарантийного обслуживания
    Supplier               INT  NOT NULL,         -- Поставщик
    CONSTRAINT PK_Equipment PRIMARY KEY (InventoryID),
    CONSTRAINT UQ_Equipment_SerialNumber UNIQUE (SerialNumber),
    CONSTRAINT FK_Equipment_Suppliers FOREIGN KEY (Supplier)
        REFERENCES Suppliers (Id)
        ON UPDATE CASCADE
) ON [PRIMARY];
GO

-- Таблица «Ответственные»
CREATE TABLE Responsible
(
    PersonnelNumber INT IDENTITY,          -- Табельный номер сотрудника
    Surname         NVARCHAR(30) NOT NULL, -- Фамилия
    Name            NVARCHAR(30) NOT NULL, -- Имя
    MiddleName      NVARCHAR(50) NULL,     -- Отчество
    Workshop        NVARCHAR(35) NOT NULL, -- Цех
    LotNumber       INT NOT NULL,          -- Номер участка
    Department      NVARCHAR(35) NOT NULL, -- Отдел
    RoomNumber      INT NOT NULL,          -- Номер комнаты
    Telephone       NVARCHAR(16) NOT NULL, -- Телефон
    CONSTRAINT PK_Responsible PRIMARY KEY (PersonnelNumber),
    CONSTRAINT CH_Responsible_LotNumber CHECK (LotNumber >= 0),
    CONSTRAINT CH_Responsible_RoomNumber CHECK (RoomNumber > 99),
    CONSTRAINT CH_Responsible_Telephone CHECK (Telephone LIKE
                                               '+[0-9] [0-9][0-9][0-9] [0-9][0-9][0-9] [0-9][0-9]-[0-9][0-9]')
) ON [PRIMARY];
GO

-- Таблица для связей «Ответственность за оборудование»
CREATE TABLE Responsibility
(
    Id              INT IDENTITY,      -- Уникальный номер записи
    Responsible     INT  NOT NULL,     -- Табельный номер ответственного
    Equipment       INT  NOT NULL,     -- Инвентарный ID оборудования
    DateOfReceiving DATE NOT NULL      -- Дата получения
        CONSTRAINT DF_Responsibility_DateOfReceiving DEFAULT GETDATE(),
    ReturnDate      DATE NULL          -- Дата возврата
        CONSTRAINT DF_Responsibility_ReturnDate DEFAULT NULL,
    PurposeOfUse    NVARCHAR(50) NULL, -- Цель использования
    ReasonForReturn INT NULL,          -- Причина возврата
    CONSTRAINT PK_Responsibility PRIMARY KEY (Id),
    CONSTRAINT FK_Responsibility_Responsible FOREIGN KEY (Responsible)
        REFERENCES Responsible (PersonnelNumber)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Responsibility_Equipment FOREIGN KEY (Equipment)
        REFERENCES Equipment (InventoryId)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT CH_Responsibility_ReturnDate CHECK (ReturnDate >= DateOfReceiving),
    CONSTRAINT FK_Responsibility_ReasonForReturn FOREIGN KEY (ReasonForReturn)
        REFERENCES ReasonsForReturn (Id)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    CONSTRAINT CH_Responsibility_ReasonForReturn CHECK ((ReasonForReturn IS NOT NULL AND ReturnDate IS NOT NULL) OR
                                                        ReasonForReturn IS NULL)
) ON [SECONDARY];
GO

------------------------------------------------------------
-- Добавление данных в таблицы
------------------------------------------------------------

INSERT INTO ReasonsForReturn (ReasonName)
VALUES (N'Поломка'),
       (N'Увольнение сотрудника'),
       (N'Плановая замена'),
       (N'По просьбе сотрудника');

INSERT INTO Suppliers (SupplierName)
VALUES ('Samsung'),
       ('Apple'),
       ('Lenovo'),
       ('HP'),
       ('Dell'),
       ('Asus'),
       ('Acer'),
       ('Microsoft'),
       ('LG'),
       ('TOYODA'),
       ('HAAS'),
       ('CIDAN');
GO

INSERT INTO Responsible (Surname, Name, MiddleName, Workshop, LotNumber, Department, RoomNumber, Telephone)
VALUES (N'Голикова', N'Агата', N'Макаровна', N'Административный', 5, N'Бухгалтерия', 305, N'+7 985 724 25-58'),
       (N'Логинов', N'Алексей', N'Миронович', N'Первичной обработки', 1, N'Основной', 105, N'+7 985 524 25-55'),
       (N'Черепанов', N'Семён', N'Тихонович', N'Первичной обработки', 2, N'Основной', 223, N'+7 971 246 45-42'),
       (N'Краснова', N'София', NULL, N'Вторичной обработки', 2, N'Основной', 103, N'+7 354 246 45-42'),
       (N'Назарова', N'Валентина', N'Марковна', N'Подготовительный', 7, N'Дополнительный', 142, N'+7 992 246 45-42'),
       (N'Новиков', N'Илья', N'Викторович', N'Административный', 5, N'Управления', 306, N'+7 985 724 25-58'),
       (N'Комарова', N'Полина', N'Егоровна', N'Подготовительный', 6, N'Внештатный', 140, N'+7 982 258 25-58'),
       (N'Кудрявцев', N'Артур', N'Романович', N'Вторичной обработки', 4, N'Дополнительный', 240, N'+7 922 555 32-21'),
       (N'Олейников', N'Степан', N'Гордеевич', N'Первичной обработки', 2, N'Основной', 124, N'+7 922 234 25-68'),
       (N'Смирнова', N'Надежда', N'Степановна', N'Переработки', 2, N'Дополнительные', 135, N'+7 901 350 25-25'),
       (N'Зимина', N'Владислава', N'Матвеевна', N'Административный', 2, N'Бухгалтерия', 352, N'+7 805 225 55-71'),
       (N'Трифонов', N'Иван', N'Артёмович', N'Подготовительный', 2, N'Основной', 320, N'+7 901 123 25-25'),
       (N'Петров', N'Георгий', N'Ярославович', N'Переработки', 5, N'Дополнительный', 420, N'+7 904 444 25-55'),
       (N'Климова', N'Кира', N'Игоревна', N'Административный', 2, N'Бухгалтерия', 230, N'+7 998 545 12-54'),
       (N'Богомолов', N'Иван', N'Константинович', N'Упаковки', 4, N'Основной', 222, N'+7 954 123 28-45'),
       (N'Попов', N'Арсен', NULL, N'Упаковки', 4, N'Дополнительный', 143, N'+7 985 424 55-88'),
       (N'Кулешова', N'Юлия', NULL, N'Первичной обработки', 5, N'Внештатный', 120, N'+7 922 485 71-82'),
       (N'Игнатов', N'Роман', N'Михайлович', N'Подготовительный', 3, N'Основной', 210, N'+7 977 124 65-22'),
       (N'Филиппов', N'Александр', N'Николаевич', N'Переработки', 5, N'Дополнительный', 244, N'+7 994 145 44-27');

INSERT INTO Equipment (SerialNumber, EquipmentName, RegistrationDate, Price, WarrantyServiceAddress, Supplier)
VALUES (40548143, N'Монитор', DEFAULT, 25000, N'г. Москва, ул. Ленина 1',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'Samsung')),
       (50555167, N'Принтер', '2018-05-01', 10000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (60558144, N'Клавиатура', '2018-08-01', 5000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (70558176, N'Мышь', '2018-02-01', 3000, N'г. Екатеринбург, ул. Вайнера 58',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'Asus')),
       (80558123, N'Монитор', '2018-03-01', 25000, N'г. Москва, ул. Ленина 1',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'Samsung')),
       (90558165, N'Ноутбук', '2018-04-01', 80000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (90558183, N'Ноутбук', '2018-04-01', 80000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (90558110, N'Ноутбук', '2018-04-01', 80000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (90558157, N'Ноутбук', '2018-04-01', 80000, N'г. Тюмень, ул. Республики 158',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HP')),
       (10055813, N'Клавиатура', '2018-05-01', 5580, N'г. Владивосток, ул. Маковского 5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'Microsoft')),
       (14955819, N'Станок фрезерный', '2020-06-21', 3000, N'г. Москва, ул. Ленина 150/5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'TOYODA')),
       (17955818, N'Станок фрезерный', '2020-06-21', 3000, N'г. Москва, ул. Ленина 150/5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'TOYODA')),
       (91955810, N'Станок фрезерный', '2020-06-21', 3000, N'г. Москва, ул. Ленина 150/5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'TOYODA')),
       (11985815, N'Станок шлифовальный', '2020-05-20', 3000, N'г. Москва, ул. Ленина 150/5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'HAAS')),
       (55953018, N'Станок шлифовальный', '2020-05-20', 3000, N'г. Москва, ул. Ленина 150/5',
        (SELECT Id FROM Suppliers WHERE SupplierName = 'CIDAN'));
GO

INSERT INTO Responsibility (Responsible, Equipment, DateOfReceiving, ReturnDate, PurposeOfUse, ReasonForReturn)
VALUES ((SELECT PersonnelNumber FROM Responsible WHERE Surname = N'Краснова' AND Name = N'София'),
        (SELECT InventoryID FROM Equipment WHERE SerialNumber = 40548143),
        '2018-05-01', NULL, N'Работа', NULL),

       ((SELECT PersonnelNumber FROM Responsible WHERE Surname = N'Краснова' AND Name = N'София'),
        (SELECT InventoryID FROM Equipment WHERE SerialNumber = 90558183),
        '2018-05-01', NULL, N'Работа', NULL),

       ((SELECT PersonnelNumber
         FROM Responsible
         WHERE Surname = N'Кудрявцев'
           AND Name = N'Артур'
           AND MiddleName = N'Романович'),
        (SELECT InventoryID FROM Equipment WHERE SerialNumber = 55953018), '2020-05-20', GETDATE(), N'Временная работа',
        (SELECT Id FROM ReasonsForReturn WHERE ReasonName = N'Плановая замена')),

       ((SELECT PersonnelNumber
         FROM Responsible
         WHERE Surname = N'Зимина'
           AND Name = N'Владислава'
           AND MiddleName = N'Матвеевна'),
        (SELECT InventoryID FROM Equipment WHERE SerialNumber = 90558183), '2017-01-25', '2018-04-01', N'Работа',
        (SELECT Id FROM ReasonsForReturn WHERE ReasonName = N'Увольнение')),

       ((SELECT PersonnelNumber
         FROM Responsible
         WHERE Surname = N'Комарова'
           AND Name = N'Полина'
           AND MiddleName = N'Егоровна'),
        (SELECT InventoryID FROM Equipment WHERE SerialNumber = 90558183), '2018-04-02', '2018-04-25', N'Работа',
        (SELECT Id FROM ReasonsForReturn WHERE ReasonName = N'Плановая замена'));
GO
```

### Образы экранных форм в конструкторе и исполняемой программе с описанием используемых компонент и мастеров.

В процессе работы был использован «Мастер настройки источника данных». С его помощью в проект была добавлена база данных
в качестве источника данных, а также строка подключения к базе данных. Основные этапы представлены в следующих снимках
экрана:

![Выбор типа источника данных](Images/Image%20№1.png)

![Выбор модели базы данных](Images/Image%20№2.png)

![Выбор (и создание) строки подключения к базе данных](Images/Image%20№3.png)

![Выбор требуемых объектов базв данных](Images/Image%20№4.png)

Описание основных объектов, используемых в созданной форме:

- `tablesBindingNavigator`: объект класса `BindingNavigator`, представляющий собой навигационную панель, при работе с
  таблицами баз данных.
- `label{\*}`: текстовые метки (где в названии {\*} является названием таблицы), используемая в качестве заголовка
  перед таблицей. Представляют собой объекты класса `Label`.
- `dataGridView{\*}`: контейнеры (где в названии {\*} является названием таблицы), выполняющие отображение строк и
  столбцов таблицы. Позволяют, создавать, изменять и удалять записи. Являются объектами класса `DataGridView`.
- `dataSetLessonsUrfu`: представляет собой кэш данных из используемой базы данных `lessonsUrFU`. Кэш используется в
  дальнейшем другими объектами ADO.NET. Является объектом сгенерированного класса, наследуемого от
  класса `System.Data.DataSet`. Не отображаются в форме.
- `bindingSource{\*}`: инкапсулируют источники данных и обеспечивают возможности навигации, фильтрации, сортировки и
  обновления данных. Являются объектами класса `BindingSource`. В указанном названии {\*} является названием таблицы. Не
  отображаются в форме, используются рядом других объектов. Является экземплярами класса `BindingSource`.
- `tableAdapter{\*}`: выполняют подключение к базам данным для выполнения ряда запросов. Тем самым он также выполняет
  синхронизацию данных `DataGridView` с базой данных. Являются объектами сгенерированных классов. В указанном
  названии {\*} является названием таблицы. Не отображаются в форме.

![Экранная форма в конструкторе](Images/Image%20№5.png)

![Исполняемая программа](Images/Image%20№6.png)

### Описание навигационной панели и её использования для управления данными

![Навигационная панель](Images/Image%20№7.png)

Навигационная панель представляет собой объект класса `System.Windows.Forms.BindingNavigator`. Он включает в себя
ряд элементов класса `ToolStripButton`:

- `navigatorMoveFirstItem`: выполняет переход к первой строке.
- `navigatorMovePreviousItem`: выполняет переход к предыдущей строке.
- `navigatorPositionItem`: отображает текущую позицию в `DataGridView` и позволяет изменить её, путём ввода нового
  значения.
- `navigatorCountItem`: общее количество строк в текущем `DataGridView`.
- `navigatorMoveNextItem`: выполняет переход к следующей строке.
- `navigatorMoveLastItem`: выполняет переход к последней строке.
- `navigatorAddNewItem`: инициирует добавление новой строки в `DataGridView`.
- `navigatorDeleteItem`: выполняет удаление строки из `DataGridView`.
- `navigatorSaveItem`: выполняет отправку изменений сделанных в `DataGridView`, в исходную базу данных.

## Лабораторная работа №2 «Представление таблиц, связанных отношением "один ко многим"»

### Цель работы

Построение Windows-приложения для доступа к данным из связанных отношением 1:М таблиц БД.

### Постановка задачи

1. В проекте для индивидуального задания на второй вкладке «Лабораторная работа №2», используя
   компоненты `DataGridView`, постройте диалог для отображения данных из главной и дополнительной таблиц (с учётом
   связей строк таблиц) аналогично таблицам `authors` и `titleauthor`.
2. Проверьте работу в форме по управлению данными в обеих таблицах.

### Экранная форма конструктора с описанием новых используемых компонент и мастеров

![Экранная форма в конструкторе](Images/Image%20№8.png)

По сравнению с прошлой лабораторной работой в экранную форму был добавлен `GroupBox`, содержащий поля и текстовые метки
для этих полей. Согласно последнему пункту задания, в поля `TextBox` выводится значения с выделенной строки таблицы для
связей «Ответственность за оборудование». По сравнению с прошлой лабораторной работой не были использованы новые
мастера. Описание добавленных объектов:

- `groupBoxCurrentEntry`: объект класса `GroupBox`, выполняющий группировку объектов, предназначенных для отображения
  значений полей выделенной строки таблицы для связей «Ответственность за оборудование».
- `label{\*}`: текстовые метки, класса `Label`, для обозначения столбца отображаемого текстовым полем `TextBox`. {\*} в
  названии является названием столбца таблицы для связей «Ответственность за оборудование».
- `textBox{\*}`: текстовые поля, класса `TextBox`, для вывода значений выделенной ячейки таблицы для связей
  «Ответственность за оборудование». {\*} в названии является названием столбца таблицы, значение которого выводится в
  поле.

Также были изменены параметры у `bindingSourceResponsibility`. При запуске формы он настроен на работу
с `bindingSourceEquipment` в качестве параметра `DataSource`, и в качестве `DataMember` используется внешний
ключ `FK_Responsibility_Equipment`. Для переключения между связанными источниками данных был изменён обработчик
события `CellEnter` у `DataGridView`-ов. Кроме этого, обработчик события выполняет заполнение
полей `groupBoxCurrentEntry`. Код обработчика события:

```csharp
/// <summary>
/// Обработчик события выполняющий смену источника данных для панели навигации, при выборе элемента,
/// а также изменение полей текущей записи в GroupBox
/// </summary>
/// <param name="sender">DataGridView вызывающий событие</param>
private void CellClick(object sender, DataGridViewCellEventArgs e)
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
    if (dataGridViewResponsibility.RowCount <= 2)
    {
        foreach (var textBox in textBoxes)
        {
            textBox.Text = "";
        }
    }
    else
    {
        for (var i = 0; i < textBoxes.Length; i++)
        {
            textBoxes[i].Text = dataGridViewResponsibility.CurrentRow!.Cells[i].Value.ToString();
        }
    }

    tablesBindingNavigator.BindingSource = source;
}
```

Тем самым каждый раз при нажатии на ячейку любого из 3 представленных `DataGridView` выполняется не только изменение
источника данных у `tablesBindingNavigator`, но и у `bindingSourceResponsibility` выполняется изменение связанного
источника данных.

### Образы экранных форм в исполняемой программе с пояснениями элементов управления

![Исполняемая программа](Images/Image%20№9.png)

В данной форме `dataGridViewResponsibility`, представляющий таблицу-связей «Ответственность за оборудование», привязан
к `BindingSource bindingSourceResponsibility`, который связан с оставшимися двумя источниками данных.

Тем самым при выделении любой ячейки в `DataGridView dataGridViewEquipment` (представляет таблицу «Оборудование»)
или `dataGridViewResponsible` (представляет таблицу «Ответственные»), в `dataGridViewResponsibility` будут отображаться
только те строки, которые связанны с ранее выделенной строкой из таблицы «Оборудование» или «Ответственные».

В боковой панели «Текущая запись» отображаются значения выделенной строки. Перезаполнение полей выполняется при каждом
изменении фокуса строки по событию `CellEnter`. Если в результате изменения связанного источника данных в таблице для
связей «Ответственность за оборудование» отсутствуют строки, то поля заполняются пустыми строками. Иначе заполняются
согласно выделенной строке, по свойству `dataGridViewResponsibility.CurrentRow`.

### Описание назначения и используемых свойств компоненты `BindingSource`

Описание основных свойств класса BindingSource:

- `DataSource`: задаёт источник данных, к которому привязан `BindingSource`. Принимает и возвращает `object`. В процессе
  работы программы периодически меняется на `bindingSourceEquipment` или `bindingSourceResponsible`.
- `DataMember`: задаёт список внешних ключей, по которым производится выборка строк. Принимает и возвращает `string`.
- `AllowNew`: можно ли добавлять записи. Принимает и возвращает `bool`. Из-за использования связанного источника данных
  и внешнего ключа имеет значение `false`.
- `Filter`: выражение, по которому производится фильтрация строк. Принимает и возвращает `string`. Не используется в
  лабораторной работе.
- `Sort`: выражение, по которому производится сортировка строк. Принимает и возвращает `string`. Не используется в
  лабораторной работе.

## Лабораторная работа №3 «Создание вручную Windows-приложения для работы с БД»

### Цель работы

Изучение основных классов ADO.NET. путем построения Windows-приложение, в котором:

- с помощью объектов классов `SqlConnection`, `DataTable`, `SqlDataAdapter` в `DataGridview` отображается
  отсортированная таблица прочитанная из БД,
- предоставляется возможность изменениия, добавления и удаления строк с сохранением изменений в БД.

### Постановка задачи

1. На третьей вкладке проекта индивидуального задания «Лабораторная работа №3» разместите компоненту `DataGridView` для
   отображения данных из главной таблицы индивидуального варианта задания.
2. Напишите программный код, создающий объекты, необходимые для отображения и управления данными из главной таблицы.
3. Приведите подробный комментарий для каждого использованного оператора программы.
4. Проверьте работу в форме по управлению данными.

### Образы экранных форм в конструкторе и исполняемой программе с пояснениями элементов управления

![Экранная форма в конструкторе](Images/Image%20№10.png)

![Исполняемая программа](Images/Image%20№11.png)

Согласно заданию, с помощью конструктора форм не были добавлены какие-либо объекты. Все объекты были добавлены на форму
с помощью кода. На форме, по аналогии с первой лабораторной работой, было добавлено:

- три текстовые метки, класса `Label`;
- три табличных представления данных, класса `DataGridView`;
- одна кнопка для отправки изменений на SQL сервер, класса `Button`.

![Структура класса исполняемой программы](Images/Image%20№12.png)

Объекты на форме также являются закрытыми полями класса `LabWorkForm3`. Свойства объектов формы задаются при их
инициализации. В конструкторе класса выполняется добавление объектов на форму, настройка свойств самой формы, а также
подключение и получение данных с базы данных. Метод `SaveData` формирует SQL команды `UPDATE`, `INSERT`, `DELETE` в виде
объектов класса `SqlCommandBuilder`. После, с помощью объектов классов `SqlConnection` и `SqlDataAdapter` выполняет их
отправку на сервер. Код класса `LabWorkForm3`:

```csharp
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
```

### Подробное описание свойств и методов классов `DataTable`, `DbDataAdapter`, `DbCommand`, `DataGridView`, `DbCommandBuilder`

Описание свойств класса `DataTable`:

- `Columns`: возвращает коллекцию столбцов, принадлежащих данной таблице. Возвращает объект
  класса `DataColumnCollection`.
- `Rows`: возвращает коллекцию строк, принадлежащих данной таблице. Возвращает объект класса `DataRowCollection`.
- `TableName`: возвращает или задаёт имя таблицы для объекта `DataTable`. Возвращает и принимает строку типа `string`.
- `DataSet`: возвращает класс `DataSet`, к которому принадлежит данная таблица.
- `IsInitialized`: получает значение, указывающее, инициализирована ли таблица `DataTable`.
- `Locale`: возвращает или задаёт сведения о языке, используемые для сравнения строк таблицы.
- `PrimaryKey`: возвращает или задаёт массив столбцов, которые являются столбцами первичного ключа для таблицы данных.

Описание методов класса `DataTable`:

- `Reset()`: возвращает таблицу в исходное состояние. Метод ничего не возвращает.
- `Cleat()`: очищает таблицу от данных. Метод ничего не возвращает.
- `AcceptChanges()`: фиксирует изменения, внесённые в таблицу.
- `Clone()`: копирует структуру таблицы, включая все схемы и ограничения. Возвращает объект класса `DataTable`.
- `Copy()`: копирует структуру таблицы и данные. Возвращает объект типа `DataTable`.
- `GetChanges()`: возвращает объект класса `DataTable`, который содержит все изменения, внесённые после последней
  фиксации изменений.
- `GetErrors()`: возвращает массив объектов DataRow, которые представляют собой записи с ошибками.
- `ImportRow(DataRow)`: импортирует строки в таблицы, сохраняя все параметры свойств, а также текущие и исходные
  значения. Метод ничего не возвращает.
- `Load(IDataReader, LoadOption)`: заполняет таблицу значениями из источника данных. Если объект `DataTable` уже
  содержит строки, поступающие данные из источника данных объединяются с существующими строками согласно значению
  параметра `LoadOption`. Метод ничего не возвращает.
- `LoadDataRow(Object[], LoadOption)`: находит и обновляет конкретную строку. Если нужная строка не найдена, то с
  помощью заданных значений создаётся новая строка. Возвращает объект `DataRow`.
- `Merge(DataTable)`: выполняет объединение таблиц. Метод ничего не возвращает.
- `NewRow()`: создаёт новый объект класса `DataRow`, который имеет такую же структуру, как и таблица. Возвращает объект
  класса `DataRow`.
- `Select()`: получает массив всех строк таблицы. Возвращает массив класса `DataRow`.

Описание свойств класса `DdDataAdapter`:

- `UpdateCommand`: команда используемая для обновления записей в источнике данных. Возвращает и принимает объект
  класса `SqlCommand`.
- `SelectCommand`: команда используемая для выборки записей в источнике данных. Возвращает и принимает объект
  класса `SqlCommand`.
- `InsertCommand`: команда используемая для вставки новых записей в источник данных. Возвращает и принимает объект
  класса `SqlCommand`.
- `DeleteCommand`: команда используемая для удаления записей из источника данных. Возвращает и принимает объект
  класса `SqlCommand`.

Описание методов класса `DdDataAdapter`:

- `Update(DataTable)`: обновляет значения в базе данных, выполняя соответствующие операторы `INSERT`, `UPDATE`
  или `DELETE` для каждой вставленной, обновлённой или удалённой строки в указанном `DataTable`. Возвращает `int` равное
  количеству строк, успешно обновлённых.
- `TerminateBatching()`: завершает пакетную обработку.
- `InitializeBatching()`: инициализирует пакетную обработку.
- `Fill(DataTable)`: добавляет или обновляет строки в указанном диапазоне в объект `DataSet` для получения соответствия
  строкам в источнике данных с использованием имени `DataTable`. Возвращает `int` равное количеству строк, успешно
  обновлённых.
- `FillSchema(DataTable, SchemaType)`: настраивает схему указанного объекта `DataTable` на основе
  указанного `SchemaType`. Возвращает объект класса `DataTable`.
- `GetFillParameters()`: получает параметры, заданные пользователем при выполнении оператора SQL `SELECT`. Возвращает
  массив объектов класса `IDataParameter`.

Описание свойств класса `DataGridView`:

- `DataSource`: источник данных, для которого выполняется отображение данных. Возвращает и принимает `object`.
- `DataBindings`: привязка данных к объекту. Возвращает коллекцию класса `ControlBindingsCollection`.
- `DataMember`: имя таблицы или списка, для которого `DataGridView` выполняет отображение данных. Возвращает и принимает
  строку типа `string`.
- `NewRowIndex`: индекс строки для новых записей. Возвращает значение типа `int`.
- `ColumnCount`: количество столбцов, отображаемых в `DataGridView`. Возвращает и принимает значение типа `int`.
- `RowCount`: количество строк, отображаемых в `DataGridView`. Возвращает и принимает значение типа `int`.
- `Columns`: коллекция, содержащая все столбцы. Возвращает объект класса `DataGridViewColumnCollection`.
- `Rows`: коллекция, содержащая все строки. Возвращает объект класса `DataGridViewRowCollection`.
- `SelectedCells`: коллекция ячеек, выделенных пользователем. Возвращает объект
  класса `DataGridViewSelectedCellCollection`.
- `CurrentCell`: активная ячейка. Возвращает и принимает объект класса `DataGridViewCell`.
- `RowTemplate`: шаблон строки. возвращает объект класса `DataGridViewRow`.
- `SortOrder`: значение, указывающие порядок сортировки. Возвращает значение перечисления `SortOrder`.
- `Size`: высота и ширина элемента. Возвращает и принимает объект класса `Size`.
- `Location`: координаты левого верхнего угла элемента. Возвращает и принимает объект типа `Point`.
- `AutoSizeColumnsMode`: значение, указывающие как определяется ширина столбца. Возвращает и принимает
  перечисление `DataGridViewAutoSizeColumnsMode`.
- `ColumnHeadersHeightSizeMode`: значение, указывающие может ли настраиваться высота заголовков пользователем или она
  должна автоматически настраиваться по содержимому. Возвращает и принимает
  перечисление `DataGridViewColumnHeadersHeightSizeMode`.

Описание методов класса `DataGridView`:

- `AreAllCellsSelected(Boolean)`: возвращает `bool` значение, указывающие выбраны ли все сейчас ячейки. Передаваемый
  параметр указывает, следует ли учитывать скрытые ячейки.
- `AutoResizeColumns()`: корректирует ширину столбцов по содержимому всех ячеек. Метод ничего не возвращает.
- `AutoResizeRows()`: корректирует высоту строк по содержимому всех ячеек. Метод ничего не возвращает.
- `BeginEdit(Boolean)`: переводит текущую ячейку в режим редактирования. Передаваемый параметр указывает, следует ли
  выделять всё содержимое ячейки. Возвращает `bool`, указывающий находится ли ячейка уже в режиме редактирования.
- `CancelEdit()`: отменяет режим редактирования для текущей ячейки и удаляет все изменения. Возвращает `bool`,
  указывающий успешность отмены редактирования.
- `ClearSelection()`: отменяет выделение всех выбранных ячеек. Метод ничего не возвращает.
- `EndEdit()`: фиксирует и завершает редактирование ячейки. Возвращает `bool`, указывающий успешность фиксации
  изменений.
- `SelectAll()`: выбирает все ячейки. Метод ничего не возвращает.

Описание свойств класса `DdCommandBuilder`:

- `DataAdapter`: `DbDataAdapter`, для которого автоматически создаются инструкции T-SQL. Возвращает и принимает объект
  класса `SqlDataAdapter`.
- `QuotePrefix`: начальный символ или символы, используемые для указания объекта базы данных, имена которых содержат
  пробел. Возвращает и принимает `string`.
- `QuoteSuffix`: конечный символ или символы, используемые для указания объекта базы данных, имена которых содержат
  пробел. Возвращает и принимает `string`.
- `SchemaSeparator`: символ, который используется в качестве разделится между идентификатором схемы и остальными
  идентификаторами. Возвращает и принимает `string`.
- `SetAllValues`: указывает, следует ли включать все столбцы в инструкцию `UPDATE` или только те, чьи значения были
  изменены. Возвращает и принимает `bool`.

Описание методов класса `DdCommandBuilder`:

- `GetDeleteCommand()`: генерирует команду для выполнения операций удаления в источнике данных. Возвращает объект
  класса `SqlCommand`.
- `GetInsertCommand()`: генерирует команду для выполнения операций вставки записей в источник данных. Возвращает объект
  класса `SqlCommand`.
- `GetUpdateCommand()`: генерирует команду для выполнения операций обновления записей в источнике данных. Возвращает
  объект класса `SqlCommand`.
- `RefreshSchema()`: очищает команды связанные с этим объектом. Метод ничего не возвращает.

## Лабораторная работа №4 «Представление данных связанных отношением "многие ко многим"»

### Цель работы

Создать приложение, в котором при отображения двух таблиц базы поддерживается «длинная» связь их строк через отношение
«многие ко многим».

### Постановка задачи

На четвертой вкладке «Лабораторная работа №4» постройте диалог, демонстрирующий работу со строками, связанными
отношением «многие ко многим». Для этого источниками данных для двух объектов `DataGridView` являются справочная и
главная таблицы индивидуального задания.

1. Напишите программный код, создающий необходимые объекты и задающий их свойства.
2. Приведите подробный комментарий для каждого использованного оператора программы.
3. Проверьте работу по управлению данными в полученной форме.

### Образы экранных форм в конструкторе и исполняемой программе с пояснениями элементов управления.

![Экранная форма в конструкторе](Images/Image%20№13.png)

![Исполняемая программа](Images/Image%20№14.png)

Согласно заданию, с помощью конструктора форм не были добавлены какие-либо объекты. Все объекты были добавлены на форму
с помощью кода. На форме находятся:

- три текстовые метки, класса `Label`;
- три табличных представления данных, класса `DataGridView`;
- одна кнопка для отправки изменений на SQL-сервер, класса `Button`.

`_dataGridViewResponsibility` теперь используется в режиме ReadOnly.

### Добавленный программный код с пояснениями.

По сравнению с прошлой лабораторной работой, был изменён конструктор формы. Из него была удалён код, отвечающий за
получение данных с таблицы «Ответственность за оборудование». Получение данных для этой таблицы выполняется в рамках
метода `GetResponsibilityData(object, EventArgs)`. Данный метод используется в качестве обработчика
события `SelectionChanged` для табличных представлений `_dataGridViewEquipment` и `_dataGridViewResponsible`. При
формировании SQL-запроса используется свойство `Parameters` класса `SqlCommand`.

Код конструктора формы:

```csharp
public LabWorkForm4()
{
    InitializeComponent();

    // Настроки формы
    this.Text = "Лабораторная работа №4 по ADO.NET УрФУ";
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
                         FROM Responsible;", _sqlConnection)
        };

        _sqlConnection.Open();

        try
        {
            // Создания SQL адаптеров на основе ранее созданных объектов-команд
            _dataAdapterEquipment = new SqlDataAdapter(commands[0]);
            _dataAdapterResponsible = new SqlDataAdapter(commands[1]);

            var dataAdapters = new[]
            {
                _dataAdapterEquipment,
                _dataAdapterResponsible
            };
            var dataTables = new[]
            {
                _dataTableEquipment,
                _dataTableResponsible
            };
            var dataGridViews = new[]
            {
                _dataGridViewEquipment,
                _dataGridViewResponsible
            };


            for (int i = 0; i < 2; i++)
            {
                dataTables[i].Reset();

                // Отпрака запроса
                dataAdapters[i].Fill(dataTables[i]);

                // Связка DataGridView с DataTable
                dataGridViews[i].DataSource = dataTables[i];

                dataGridViews[i].SelectionChanged += GetResponsibilityData;
            }
        }
        finally
        {
            _sqlConnection.Close();
        }

        GetResponsibilityData(_dataGridViewEquipment, null);

        _buttonSave.Click += SaveData;
    }
}
```

Код метода для получения данных из таблицы «Ответственность за оборудование»:

```csharp
/// <summary>
/// Получение данных с таблицы «Ответственность за оборудование»
/// </summary>
private void GetResponsibilityData(object sender, EventArgs e)
{
    _sqlConnection.Open();

    try
    {
        // Создание запроса на получение данных
        string tableJoin = (sender == _dataGridViewEquipment)
            ? @"FROM Equipment
                LEFT OUTER JOIN Responsibility AS R ON R.Equipment = Equipment.InventoryID
                WHERE R.Equipment = @Equipment"
            : @"FROM Responsible
                LEFT OUTER JOIN Responsibility AS R ON R.Responsible = Responsible.PersonnelNumber
                WHERE R.Responsible = @Responsible";
        SqlCommand sqlCommandResponsibility = new(@"SELECT R.Id              AS N'Уникальный номер записи',
                                                           R.Responsible     AS N'Табельный номер ответственного',
                                                           R.Equipment       AS N'Инвентарный ID оборудования',
                                                           R.DateOfReceiving AS N'Дата получения',
                                                           R.ReturnDate      AS N'Дата возврата',
                                                           R.PurposeOfUse    AS N'Цель использования',
                                                           R.ReasonForReturn AS N'Причина возврата'" +
                                                  tableJoin, _sqlConnection);

        _dataAdapterResponsibility = new SqlDataAdapter(sqlCommandResponsibility);

        // Добавление параметра в запрос в зависимости от того, какой DataGridView имеет фокус
        if (sender as DataGridView == _dataGridViewEquipment)
        {
            if (_dataGridViewEquipment.CurrentRow == null) return;
                
            var equipmentId = _dataGridViewEquipment.CurrentRow.Cells[0].Value;
                
            sqlCommandResponsibility.Parameters.Add("@Equipment", SqlDbType.Int);
            sqlCommandResponsibility.Parameters["@Equipment"].Value = equipmentId;
        }
        else
        {
            if (_dataGridViewResponsible.CurrentRow == null) return;
            
            var responsibleId = _dataGridViewResponsible.CurrentRow.Cells[0].Value;
                
            sqlCommandResponsibility.Parameters.Add("@Responsible", SqlDbType.Int);
            sqlCommandResponsibility.Parameters["@Responsible"].Value = responsibleId;
        }

        _dataTableResponsibility.Clear();                                  // Очистка табличного представления
        _dataAdapterResponsibility.Fill(_dataTableResponsibility);         // Отправка запроса
        _dataGridViewResponsibility.DataSource = _dataTableResponsibility; // Связка DataGridView с DataTable
    }
    finally
    {
        _sqlConnection.Close();
    }
}
```

### Подробное описание впервые использованных свойств и методов.

Методы класса `SqlCommand`:

- `CreateCommand()`: возвращает созданный объект класса `SqlCommand` с указанным текстом команды и подключением к БД.

Методы класса `SqlDataAdapter`:

- `CreateParameter()`: возвращает созданный объект класса `SqlParameter`.

Свойства класса `SqlDataAdapter`:

- `Parameters`: возвращает коллекцию класса `SqlParameterCollection`, содержащую параметры, используемые в
  запросе `SqlCommand`.
- `CommandText`: возвращает или задаёт текст команды `SqlCommand`.

Свойства класса `DataGridView`:

- `CurrentRow`: возвращает объект класса `DataGridViewRow`, представляющий текущую строку в `DataGridView`.
- `ReadOnly`: возвращает или задаёт значение, указывающее доступен ли `DataGridView` только для чтения.

## Лабораторная работа №5 «Использование справочников в формах диалога с БД»

### Цель работы

Использование для ввода и корректировки данных значений, представленных справочными таблицами.

### Постановка задачи

1. На пятой вкладке «Лабораторная работа № 5» постройте диалог, демонстрирующий работу с главной таблицей БД задания, в
   которой значение справочного поля выбирается из списка, содержащего значения из справочной таблицы.
2. Проверьте возможность управления данными в полученной форме.
3. Проверьте, как изменение данных справочной таблицы отражается на выборе справочных значений в `DataGridView`.
4. Изучите работу со справочными значениями в отдельных полях. Добавьте в форму элемент `ComboBox` и настройте его
   свойства для выбора значений из справочной таблицы (или запроса):
    - в разделе `DataBinding` установите в свойстве `SelectedValue` связь с полем кода источника
      данных (`BindingSource`) основной таблицы;
    - в свойстве `DataSource` задайте источник (`BindingSource`) справочника данных;
    - в свойстве `DisplayMember` выберите поле для отображения;
    - в свойстве `ValueMember` выберите поле кода из справочника.

### Образы экранных форм в конструкторе и исполняемой программе с пояснениями элементов управления.

![Экранная форма в конструкторе](Images/Image%20№15.png)

![Исполняемая программа](Images/Image%20№21.png)

Лабораторная работа № 5 была сделана на основе лабораторной работы №2. По сравнению с ней было добавлено 2 табличных
представления `DataGridView` (для таблиц справочников), 2 текстовые метки `Label`, а также были изменены свойства у
двух столбцов таблиц «Ответственные» и «Ответственность за оборудование».

![Окно мастера настройки источников данных](Images/Image%20№20.png)

Все необходимые таблицы были добавлены в `dataSetLessonsUrfu` ещё при выполнении лабораторной работы №1.

![Настройка столбцов таблицы-справочника «Поставщики оборудования](Images/Image%20№16.png)

![Настройка столбцов таблицы-справочника «Причина возврата](Images/Image%20№17.png)

Согласно заданию, для таблиц «Поставщики оборудования» и «Причина возврата» были переименованы названия столбцов на
русский язык, с помощью свойства `HeaderText`.

![Настройка подстановки справочных значений в столбец «Поставщик»](Images/Image%20№18.png)

![Настройка подстановки справочных значений в столбец «Причина возврата»](Images/Image%20№19.png)

Для столбцов, связанных с таблицами-справочниками, были настроены подстановки справочных значений. Тем самым, вместо
идентификатора поставщика или причины возврата оборудования, в таблице отображается название.

У данных столбцов был изменён ряд свойств:

- `ColumnType = DataGridViewComboBoxColumn`: переводит столбец в режим выбора значения из списка.
- `DataSource = bindingSource${tableName}`: в качестве источника данных для списка используется источник данных
  таблицы-справочника. `${tableName}`: название таблицы-справочника.
- `DisplayMember = ${columnName}`: в качестве отображаемого значения используется текстовое справочное значение из
  таблицы-справочника.
- `ValueMember = Id`: для сопоставления значений используется числовой идентификатор из исходной таблицы, связанный
  внешним ключом идентификатором из таблицы-справочника.

### Добавленный программный код с пояснениями.

Были изменены методы, отвечающие за обработку событий.

В метод `LoadForm(object, EventArgs)` были добавлены команды для загрузки данных из таблиц-справочников.

```csharp
private void LoadMainForm(object sender, EventArgs e)
{
    tableAdapterSuppliers.Fill(dataSetLessonsUrfu.Suppliers);
    tableAdapterReasonsForReturn.Fill(dataSetLessonsUrfu.ReasonsForReturn);
    tableAdapterResponsibility.Fill(dataSetLessonsUrfu.Responsibility);
    tableAdapterResponsible.Fill(dataSetLessonsUrfu.Responsible);
    tableAdapterEquipment.Fill(dataSetLessonsUrfu.Equipment);
}
```

В метод `SaveItem(object, EventArgs)` были добавлены команды для завершения редактирования данных в таблицах.
Формирование запроса и его отправка на сервер базы данных выполняется в рамках методов, сгенерированных мастером
настройки источников данных.

```csharp
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
```

Для всех табличных преставлений используется один обработчик события `SelectionChanged`. Как и в прошлых лабораторных
работах он выполняет смену источника данных для панели навигации, переключение связанного источника данных
для `bindingSourceResponsibility` (если фокус находится в таблицах «Ответственные» и «Оборудование»), а также
отображения значений текущей строки таблицы-связки «Ответственность за оборудование» в текстовых полях.

Так как таблица-связка «Ответственность за оборудование» имеет внешний ключ, связанный с таблицей-справочником «Причина
возврата», обработчик не выполняет полный перенос значений из исходной таблицы в текстовые поля. Для последнего столбца
выполняется поиск текстового значения методом перебора.

```csharp
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
```

### Подробное описание впервые использованных свойств и методов.

Свойства класса `DataGridViewComboBoxColumn`:

- `ColumnType`: отображает тип столбца, используемый табличным представлением `DataGridView`. Отображается в конструкторе
  формы, как свойство, но представляет собой класс объекта, представляющего собой столбец.
- `DataSource`: возвращает или принимает источник данных, используемый для отображения значений в столбце. Принимает и
  возвращает объект типа `object`.
- `DisplayMember`: возвращает или принимает строку, указывающую на столбец, используемый для получения доступных значений
  для отображения в столбце. Принимает и возвращает объект типа `string`.
- `ValueMember`: возвращает или принимает строку, указывающую на столбец, используемый для получения значений, которые
  будут сопоставляться со значениями  `DisplayMember`. Принимает и возвращает объект типа `string`.