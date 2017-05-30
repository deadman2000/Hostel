namespace Hostel.UI
{
    partial class FormHostel
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem tsmiOperations;
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDBImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRandomize = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvHostel = new System.Windows.Forms.DataGridView();
            this.colSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsStudents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEditStud = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveStud = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteStud = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFaculties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.поЭтажуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevel1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevel2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevel3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevel4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevel5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFacReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRepFacYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGraduatesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbMode = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiSettlingReport = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOperations = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHostel)).BeginInit();
            this.cmsStudents.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiOperations
            // 
            tsmiOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmiEditStudent,
            this.tsmiDeleteStudent,
            this.tsmiRemove,
            this.tsmiAddYear,
            this.tsmiDBImport,
            this.tsmiRandomize});
            tsmiOperations.Name = "tsmiOperations";
            tsmiOperations.Size = new System.Drawing.Size(75, 23);
            tsmiOperations.Text = "Операции";
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(245, 22);
            this.tsmiAddStudent.Text = "Добавить";
            this.tsmiAddStudent.Click += new System.EventHandler(this.tsmiAddStudent_Click);
            // 
            // tsmiEditStudent
            // 
            this.tsmiEditStudent.Name = "tsmiEditStudent";
            this.tsmiEditStudent.Size = new System.Drawing.Size(245, 22);
            this.tsmiEditStudent.Text = "Редактировать";
            this.tsmiEditStudent.Click += new System.EventHandler(this.tsmiEditStudent_Click);
            // 
            // tsmiDeleteStudent
            // 
            this.tsmiDeleteStudent.Name = "tsmiDeleteStudent";
            this.tsmiDeleteStudent.Size = new System.Drawing.Size(245, 22);
            this.tsmiDeleteStudent.Text = "Удалить";
            this.tsmiDeleteStudent.Click += new System.EventHandler(this.tsmiRemoveStudent_Click);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(245, 22);
            this.tsmiRemove.Text = "Выселить";
            this.tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // tsmiAddYear
            // 
            this.tsmiAddYear.Name = "tsmiAddYear";
            this.tsmiAddYear.Size = new System.Drawing.Size(245, 22);
            this.tsmiAddYear.Text = "Перевести на следующий курс";
            this.tsmiAddYear.Click += new System.EventHandler(this.tsmiAddYear_Click);
            // 
            // tsmiDBImport
            // 
            this.tsmiDBImport.Name = "tsmiDBImport";
            this.tsmiDBImport.Size = new System.Drawing.Size(245, 22);
            this.tsmiDBImport.Text = "Импорт";
            this.tsmiDBImport.Click += new System.EventHandler(this.tsmiDBImport_Click);
            // 
            // tsmiRandomize
            // 
            this.tsmiRandomize.Name = "tsmiRandomize";
            this.tsmiRandomize.Size = new System.Drawing.Size(245, 22);
            this.tsmiRandomize.Text = "Перемешать";
            this.tsmiRandomize.Visible = false;
            this.tsmiRandomize.Click += new System.EventHandler(this.tsmiRandomize_Click);
            // 
            // dgvHostel
            // 
            this.dgvHostel.AllowUserToAddRows = false;
            this.dgvHostel.AllowUserToDeleteRows = false;
            this.dgvHostel.AllowUserToResizeRows = false;
            this.dgvHostel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvHostel.BackgroundColor = System.Drawing.Color.White;
            this.dgvHostel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHostel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHostel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHostel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHostel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSName,
            this.colFName,
            this.colPatronymic,
            this.colRoom});
            this.dgvHostel.ContextMenuStrip = this.cmsStudents;
            this.dgvHostel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHostel.Location = new System.Drawing.Point(0, 27);
            this.dgvHostel.MultiSelect = false;
            this.dgvHostel.Name = "dgvHostel";
            this.dgvHostel.ReadOnly = true;
            this.dgvHostel.RowHeadersVisible = false;
            this.dgvHostel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHostel.Size = new System.Drawing.Size(748, 524);
            this.dgvHostel.TabIndex = 0;
            this.dgvHostel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHostel_CellDoubleClick);
            // 
            // colSName
            // 
            this.colSName.DataPropertyName = "SecondName";
            this.colSName.HeaderText = "Фамилия";
            this.colSName.Name = "colSName";
            this.colSName.ReadOnly = true;
            this.colSName.Width = 150;
            // 
            // colFName
            // 
            this.colFName.DataPropertyName = "FirstName";
            this.colFName.HeaderText = "Имя";
            this.colFName.Name = "colFName";
            this.colFName.ReadOnly = true;
            this.colFName.Width = 150;
            // 
            // colPatronymic
            // 
            this.colPatronymic.DataPropertyName = "Patronymic";
            this.colPatronymic.HeaderText = "Отчество";
            this.colPatronymic.Name = "colPatronymic";
            this.colPatronymic.ReadOnly = true;
            this.colPatronymic.Width = 150;
            // 
            // colRoom
            // 
            this.colRoom.HeaderText = "Комната";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            // 
            // cmsStudents
            // 
            this.cmsStudents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditStud,
            this.tsmRemoveStud,
            this.toolStripMenuItem1,
            this.tsmiDeleteStud});
            this.cmsStudents.Name = "cmsStudents";
            this.cmsStudents.Size = new System.Drawing.Size(133, 88);
            // 
            // tsmEditStud
            // 
            this.tsmEditStud.Image = global::Hostel.Properties.Resources.pencil;
            this.tsmEditStud.Name = "tsmEditStud";
            this.tsmEditStud.Size = new System.Drawing.Size(132, 26);
            this.tsmEditStud.Text = "Изменить";
            this.tsmEditStud.Click += new System.EventHandler(this.tsmEditStud_Click);
            // 
            // tsmRemoveStud
            // 
            this.tsmRemoveStud.Name = "tsmRemoveStud";
            this.tsmRemoveStud.Size = new System.Drawing.Size(132, 26);
            this.tsmRemoveStud.Text = "Выселить";
            this.tsmRemoveStud.Click += new System.EventHandler(this.tsmRemoveStud_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // tsmiDeleteStud
            // 
            this.tsmiDeleteStud.Image = global::Hostel.Properties.Resources.delete;
            this.tsmiDeleteStud.Name = "tsmiDeleteStud";
            this.tsmiDeleteStud.Size = new System.Drawing.Size(132, 26);
            this.tsmiDeleteStud.Text = "Удалить";
            this.tsmiDeleteStud.Click += new System.EventHandler(this.tsmiDeleteStud_Click);
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsmiOperations,
            this.tsmiFaculties,
            this.tsmiReports,
            this.tscbMode});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(748, 27);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFaculties
            // 
            this.tsmiFaculties.Name = "tsmiFaculties";
            this.tsmiFaculties.Size = new System.Drawing.Size(84, 23);
            this.tsmiFaculties.Text = "Факультеты";
            this.tsmiFaculties.Click += new System.EventHandler(this.tsmiFaculties_Click);
            // 
            // tsmiReports
            // 
            this.tsmiReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportRooms,
            this.поЭтажуToolStripMenuItem,
            this.tsmiFacReport,
            this.tsmiRepFacYear,
            this.tsmiGraduatesReport,
            this.tsmiSettlingReport});
            this.tsmiReports.Name = "tsmiReports";
            this.tsmiReports.Size = new System.Drawing.Size(60, 23);
            this.tsmiReports.Text = "Отчеты";
            // 
            // tsmiReportRooms
            // 
            this.tsmiReportRooms.Name = "tsmiReportRooms";
            this.tsmiReportRooms.Size = new System.Drawing.Size(190, 22);
            this.tsmiReportRooms.Text = "По комнатам";
            this.tsmiReportRooms.Click += new System.EventHandler(this.tsmiReportRooms_Click);
            // 
            // поЭтажуToolStripMenuItem
            // 
            this.поЭтажуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLevel1,
            this.tsmiLevel2,
            this.tsmiLevel3,
            this.tsmiLevel4,
            this.tsmiLevel5});
            this.поЭтажуToolStripMenuItem.Name = "поЭтажуToolStripMenuItem";
            this.поЭтажуToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.поЭтажуToolStripMenuItem.Text = "По этажу";
            // 
            // tsmiLevel1
            // 
            this.tsmiLevel1.Name = "tsmiLevel1";
            this.tsmiLevel1.Size = new System.Drawing.Size(109, 22);
            this.tsmiLevel1.Text = "1 этаж";
            this.tsmiLevel1.Click += new System.EventHandler(this.tsmiLevel1_Click);
            // 
            // tsmiLevel2
            // 
            this.tsmiLevel2.Name = "tsmiLevel2";
            this.tsmiLevel2.Size = new System.Drawing.Size(109, 22);
            this.tsmiLevel2.Text = "2 этаж";
            this.tsmiLevel2.Click += new System.EventHandler(this.tsmiLevel2_Click);
            // 
            // tsmiLevel3
            // 
            this.tsmiLevel3.Name = "tsmiLevel3";
            this.tsmiLevel3.Size = new System.Drawing.Size(109, 22);
            this.tsmiLevel3.Text = "3 этаж";
            this.tsmiLevel3.Click += new System.EventHandler(this.tsmiLevel3_Click);
            // 
            // tsmiLevel4
            // 
            this.tsmiLevel4.Name = "tsmiLevel4";
            this.tsmiLevel4.Size = new System.Drawing.Size(109, 22);
            this.tsmiLevel4.Text = "4 этаж";
            this.tsmiLevel4.Click += new System.EventHandler(this.tsmiLevel4_Click);
            // 
            // tsmiLevel5
            // 
            this.tsmiLevel5.Name = "tsmiLevel5";
            this.tsmiLevel5.Size = new System.Drawing.Size(109, 22);
            this.tsmiLevel5.Text = "5 этаж";
            this.tsmiLevel5.Click += new System.EventHandler(this.tsmiLevel5_Click);
            // 
            // tsmiFacReport
            // 
            this.tsmiFacReport.Name = "tsmiFacReport";
            this.tsmiFacReport.Size = new System.Drawing.Size(190, 22);
            this.tsmiFacReport.Text = "По факультетам";
            this.tsmiFacReport.Click += new System.EventHandler(this.tsmiFacReport_Click);
            // 
            // tsmiRepFacYear
            // 
            this.tsmiRepFacYear.Name = "tsmiRepFacYear";
            this.tsmiRepFacYear.Size = new System.Drawing.Size(190, 22);
            this.tsmiRepFacYear.Text = "Факультет по курсам";
            this.tsmiRepFacYear.Click += new System.EventHandler(this.tsmiRepFacYear_Click);
            // 
            // tsmiGraduatesReport
            // 
            this.tsmiGraduatesReport.Name = "tsmiGraduatesReport";
            this.tsmiGraduatesReport.Size = new System.Drawing.Size(190, 22);
            this.tsmiGraduatesReport.Text = "Выпускники";
            this.tsmiGraduatesReport.Click += new System.EventHandler(this.tsmiGraduatesReport_Click);
            // 
            // tscbMode
            // 
            this.tscbMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbMode.Items.AddRange(new object[] {
            "Заселенные",
            "Незаселенные",
            "Выселенные"});
            this.tscbMode.Name = "tscbMode";
            this.tscbMode.Size = new System.Drawing.Size(121, 23);
            this.tscbMode.SelectedIndexChanged += new System.EventHandler(this.tscbMode_SelectedIndexChanged);
            // 
            // tsmiSettlingReport
            // 
            this.tsmiSettlingReport.Name = "tsmiSettlingReport";
            this.tsmiSettlingReport.Size = new System.Drawing.Size(190, 22);
            this.tsmiSettlingReport.Text = "Списки на вселение";
            this.tsmiSettlingReport.Click += new System.EventHandler(this.tsmiSettlingReport_Click);
            // 
            // FormHostel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 551);
            this.Controls.Add(this.dgvHostel);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "FormHostel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Общежитие";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHostel)).EndInit();
            this.cmsStudents.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHostel;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddYear;
        private System.Windows.Forms.ToolStripMenuItem tsmiFaculties;
        private System.Windows.Forms.ToolStripMenuItem tsmiReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportRooms;
        private System.Windows.Forms.ToolStripMenuItem поЭтажуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevel3;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevel4;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevel5;
        private System.Windows.Forms.ToolStripMenuItem tsmiFacReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.ToolStripComboBox tscbMode;
        private System.Windows.Forms.ContextMenuStrip cmsStudents;
        private System.Windows.Forms.ToolStripMenuItem tsmEditStud;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveStud;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteStud;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDBImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiRepFacYear;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevel2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRandomize;
        private System.Windows.Forms.ToolStripMenuItem tsmiGraduatesReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettlingReport;
    }
}

