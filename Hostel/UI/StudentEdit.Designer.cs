namespace Hostel.UI
{
    partial class StudentEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbSName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPatronymic = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFaculty = new System.Windows.Forms.ComboBox();
            this.btEditFaculty = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbContractBudget = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudContractNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRoom = new System.Windows.Forms.TextBox();
            this.btAccept = new System.Windows.Forms.Button();
            this.btAcceptMore = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.chbRemoved = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSpeciality = new System.Windows.Forms.ComboBox();
            this.btEditSpeciality = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContractNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // tbSName
            // 
            this.tbSName.Location = new System.Drawing.Point(15, 25);
            this.tbSName.MaxLength = 200;
            this.tbSName.Name = "tbSName";
            this.tbSName.Size = new System.Drawing.Size(261, 20);
            this.tbSName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Имя";
            // 
            // tbFName
            // 
            this.tbFName.Location = new System.Drawing.Point(15, 64);
            this.tbFName.MaxLength = 200;
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(261, 20);
            this.tbFName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Отчество";
            // 
            // tbPatronymic
            // 
            this.tbPatronymic.Location = new System.Drawing.Point(15, 103);
            this.tbPatronymic.MaxLength = 200;
            this.tbPatronymic.Name = "tbPatronymic";
            this.tbPatronymic.Size = new System.Drawing.Size(261, 20);
            this.tbPatronymic.TabIndex = 2;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(288, 39);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpBirthDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата рождения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Паспортные данные";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(288, 78);
            this.tbAddress.MaxLength = 1000;
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAddress.Size = new System.Drawing.Size(261, 56);
            this.tbAddress.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Факультет";
            // 
            // cbFaculty
            // 
            this.cbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaculty.FormattingEnabled = true;
            this.cbFaculty.Location = new System.Drawing.Point(15, 152);
            this.cbFaculty.Name = "cbFaculty";
            this.cbFaculty.Size = new System.Drawing.Size(230, 21);
            this.cbFaculty.TabIndex = 5;
            this.cbFaculty.SelectedValueChanged += new System.EventHandler(this.cbFaculty_SelectedValueChanged);
            // 
            // btEditFaculty
            // 
            this.btEditFaculty.Location = new System.Drawing.Point(251, 152);
            this.btEditFaculty.Name = "btEditFaculty";
            this.btEditFaculty.Size = new System.Drawing.Size(25, 21);
            this.btEditFaculty.TabIndex = 13;
            this.btEditFaculty.Text = "...";
            this.btEditFaculty.UseVisualStyleBackColor = true;
            this.btEditFaculty.Click += new System.EventHandler(this.btEditFaculty_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Договор / бюджет";
            // 
            // cbContractBudget
            // 
            this.cbContractBudget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContractBudget.FormattingEnabled = true;
            this.cbContractBudget.Items.AddRange(new object[] {
            "Договор",
            "Бюджет"});
            this.cbContractBudget.Location = new System.Drawing.Point(15, 236);
            this.cbContractBudget.Name = "cbContractBudget";
            this.cbContractBudget.Size = new System.Drawing.Size(118, 21);
            this.cbContractBudget.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Курс";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(139, 236);
            this.nudYear.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(68, 20);
            this.nudYear.TabIndex = 7;
            this.nudYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Номер договора";
            // 
            // nudContractNum
            // 
            this.nudContractNum.Location = new System.Drawing.Point(15, 277);
            this.nudContractNum.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudContractNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContractNum.Name = "nudContractNum";
            this.nudContractNum.Size = new System.Drawing.Size(118, 20);
            this.nudContractNum.TabIndex = 8;
            this.nudContractNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Комната";
            // 
            // tbRoom
            // 
            this.tbRoom.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbRoom.Location = new System.Drawing.Point(15, 316);
            this.tbRoom.MaxLength = 5;
            this.tbRoom.Name = "tbRoom";
            this.tbRoom.Size = new System.Drawing.Size(68, 20);
            this.tbRoom.TabIndex = 9;
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAccept.Location = new System.Drawing.Point(378, 318);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(75, 23);
            this.btAccept.TabIndex = 11;
            this.btAccept.Text = "Добавить";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // btAcceptMore
            // 
            this.btAcceptMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAcceptMore.Location = new System.Drawing.Point(459, 318);
            this.btAcceptMore.Name = "btAcceptMore";
            this.btAcceptMore.Size = new System.Drawing.Size(103, 23);
            this.btAcceptMore.TabIndex = 10;
            this.btAcceptMore.Text = "Добавить еще >";
            this.btAcceptMore.UseVisualStyleBackColor = true;
            this.btAcceptMore.Click += new System.EventHandler(this.btAcceptMore_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(304, 318);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(68, 23);
            this.btCancel.TabIndex = 12;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Location = new System.Drawing.Point(200, 301);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(69, 17);
            this.chbIsActive.TabIndex = 14;
            this.chbIsActive.Text = "Заселен";
            this.chbIsActive.UseVisualStyleBackColor = true;
            this.chbIsActive.CheckedChanged += new System.EventHandler(this.chbIsActive_CheckedChanged);
            // 
            // chbRemoved
            // 
            this.chbRemoved.AutoSize = true;
            this.chbRemoved.Location = new System.Drawing.Point(200, 325);
            this.chbRemoved.Name = "chbRemoved";
            this.chbRemoved.Size = new System.Drawing.Size(71, 17);
            this.chbRemoved.TabIndex = 15;
            this.chbRemoved.Text = "Выселен";
            this.chbRemoved.UseVisualStyleBackColor = true;
            this.chbRemoved.CheckedChanged += new System.EventHandler(this.chbRemoved_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Специальность";
            // 
            // cbSpeciality
            // 
            this.cbSpeciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeciality.FormattingEnabled = true;
            this.cbSpeciality.Location = new System.Drawing.Point(15, 195);
            this.cbSpeciality.Name = "cbSpeciality";
            this.cbSpeciality.Size = new System.Drawing.Size(230, 21);
            this.cbSpeciality.TabIndex = 5;
            // 
            // btEditSpeciality
            // 
            this.btEditSpeciality.Location = new System.Drawing.Point(251, 195);
            this.btEditSpeciality.Name = "btEditSpeciality";
            this.btEditSpeciality.Size = new System.Drawing.Size(25, 21);
            this.btEditSpeciality.TabIndex = 13;
            this.btEditSpeciality.Text = "...";
            this.btEditSpeciality.UseVisualStyleBackColor = true;
            this.btEditSpeciality.Click += new System.EventHandler(this.btEditSpeciality_Click);
            // 
            // StudentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(577, 353);
            this.Controls.Add(this.chbRemoved);
            this.Controls.Add(this.chbIsActive);
            this.Controls.Add(this.btAcceptMore);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.nudContractNum);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.btEditSpeciality);
            this.Controls.Add(this.btEditFaculty);
            this.Controls.Add(this.cbContractBudget);
            this.Controls.Add(this.cbSpeciality);
            this.Controls.Add(this.cbFaculty);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbRoom);
            this.Controls.Add(this.tbPatronymic);
            this.Controls.Add(this.tbFName);
            this.Controls.Add(this.tbSName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentEdit";
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContractNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPatronymic;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFaculty;
        private System.Windows.Forms.Button btEditFaculty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbContractBudget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudContractNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbRoom;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.Button btAcceptMore;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.CheckBox chbRemoved;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbSpeciality;
        private System.Windows.Forms.Button btEditSpeciality;
    }
}