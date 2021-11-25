namespace COPLab1
{
    partial class FormMain
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
            this.buttonAddItems = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonAddToInput = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.customListBox = new CustomWinFormsComponents.Components.CustomListBox();
            this.customInput = new CustomWinFormsComponents.Components.CustomInput();
            this.customGrid1 = new CustomWinFormsComponents.Components.CustomGrid();
            this.buttonAddColumns = new System.Windows.Forms.Button();
            this.buttonAddWorkers = new System.Windows.Forms.Button();
            this.buttonGetWorker = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSetValue = new System.Windows.Forms.Button();
            this.customPdfTableV21 = new CustomNoVisualComponents.Components.CustomPdfTableV2(this.components);
            this.btnCreatePdf = new System.Windows.Forms.Button();
            this.buttonTestPdf2 = new System.Windows.Forms.Button();
            this.buttonTestPdf3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddItems
            // 
            this.buttonAddItems.Location = new System.Drawing.Point(185, 12);
            this.buttonAddItems.Name = "buttonAddItems";
            this.buttonAddItems.Size = new System.Drawing.Size(112, 23);
            this.buttonAddItems.TabIndex = 1;
            this.buttonAddItems.Text = "Добавить список";
            this.buttonAddItems.UseVisualStyleBackColor = true;
            this.buttonAddItems.Click += new System.EventHandler(this.buttonAddItems_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(185, 93);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(220, 23);
            this.buttonAddItem.TabIndex = 3;
            this.buttonAddItem.Text = "Добавить элемент";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonAddToInput
            // 
            this.buttonAddToInput.Location = new System.Drawing.Point(330, 145);
            this.buttonAddToInput.Name = "buttonAddToInput";
            this.buttonAddToInput.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToInput.TabIndex = 4;
            this.buttonAddToInput.Text = "Добавить";
            this.buttonAddToInput.UseVisualStyleBackColor = true;
            this.buttonAddToInput.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(185, 147);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(139, 20);
            this.textBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Добавить значение в компонет ввода";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // customListBox
            // 
            this.customListBox.Location = new System.Drawing.Point(12, 12);
            this.customListBox.Name = "customListBox";
            this.customListBox.SelectedItem = "";
            this.customListBox.Size = new System.Drawing.Size(150, 150);
            this.customListBox.TabIndex = 8;
            // 
            // customInput
            // 
            this.customInput.Location = new System.Drawing.Point(185, 52);
            this.customInput.Name = "customInput";
            this.customInput.Number = 0;
            this.customInput.Size = new System.Drawing.Size(220, 22);
            this.customInput.TabIndex = 7;
            // 
            // customGrid1
            // 
            this.customGrid1.Location = new System.Drawing.Point(12, 174);
            this.customGrid1.Name = "customGrid1";
            this.customGrid1.SelectedRow = -1;
            this.customGrid1.Size = new System.Drawing.Size(424, 304);
            this.customGrid1.TabIndex = 9;
            // 
            // buttonAddColumns
            // 
            this.buttonAddColumns.Location = new System.Drawing.Point(469, 174);
            this.buttonAddColumns.Name = "buttonAddColumns";
            this.buttonAddColumns.Size = new System.Drawing.Size(131, 23);
            this.buttonAddColumns.TabIndex = 10;
            this.buttonAddColumns.Text = "Add columns";
            this.buttonAddColumns.UseVisualStyleBackColor = true;
            this.buttonAddColumns.Click += new System.EventHandler(this.buttonAddColumns_Click);
            // 
            // buttonAddWorkers
            // 
            this.buttonAddWorkers.Location = new System.Drawing.Point(469, 215);
            this.buttonAddWorkers.Name = "buttonAddWorkers";
            this.buttonAddWorkers.Size = new System.Drawing.Size(131, 23);
            this.buttonAddWorkers.TabIndex = 11;
            this.buttonAddWorkers.Text = "Add workers";
            this.buttonAddWorkers.UseVisualStyleBackColor = true;
            this.buttonAddWorkers.Click += new System.EventHandler(this.buttonAddWorkers_Click);
            // 
            // buttonGetWorker
            // 
            this.buttonGetWorker.Location = new System.Drawing.Point(469, 258);
            this.buttonGetWorker.Name = "buttonGetWorker";
            this.buttonGetWorker.Size = new System.Drawing.Size(131, 23);
            this.buttonGetWorker.TabIndex = 12;
            this.buttonGetWorker.Text = "Get worker";
            this.buttonGetWorker.UseVisualStyleBackColor = true;
            this.buttonGetWorker.Click += new System.EventHandler(this.buttonGetWorker_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(469, 303);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(131, 23);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSetValue
            // 
            this.buttonSetValue.Location = new System.Drawing.Point(305, 12);
            this.buttonSetValue.Name = "buttonSetValue";
            this.buttonSetValue.Size = new System.Drawing.Size(100, 23);
            this.buttonSetValue.TabIndex = 14;
            this.buttonSetValue.Text = "Set value";
            this.buttonSetValue.UseVisualStyleBackColor = true;
            this.buttonSetValue.Click += new System.EventHandler(this.buttonSetValue_Click);
            // 
            // btnCreatePdf
            // 
            this.btnCreatePdf.Location = new System.Drawing.Point(637, 174);
            this.btnCreatePdf.Name = "btnCreatePdf";
            this.btnCreatePdf.Size = new System.Drawing.Size(131, 23);
            this.btnCreatePdf.TabIndex = 15;
            this.btnCreatePdf.Text = "Test pdf";
            this.btnCreatePdf.UseVisualStyleBackColor = true;
            this.btnCreatePdf.Click += new System.EventHandler(this.btnCreatePdf_Click);
            // 
            // buttonTestPdf2
            // 
            this.buttonTestPdf2.Location = new System.Drawing.Point(637, 220);
            this.buttonTestPdf2.Name = "buttonTestPdf2";
            this.buttonTestPdf2.Size = new System.Drawing.Size(131, 23);
            this.buttonTestPdf2.TabIndex = 16;
            this.buttonTestPdf2.Text = "Test pdf 2";
            this.buttonTestPdf2.UseVisualStyleBackColor = true;
            this.buttonTestPdf2.Click += new System.EventHandler(this.buttonTestPdf2_Click);
            // 
            // buttonTestPdf3
            // 
            this.buttonTestPdf3.Location = new System.Drawing.Point(637, 261);
            this.buttonTestPdf3.Name = "buttonTestPdf3";
            this.buttonTestPdf3.Size = new System.Drawing.Size(131, 23);
            this.buttonTestPdf3.TabIndex = 17;
            this.buttonTestPdf3.Text = "Test pdf 3";
            this.buttonTestPdf3.UseVisualStyleBackColor = true;
            this.buttonTestPdf3.Click += new System.EventHandler(this.buttonTestPdf3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "lab 2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonTestPdf3);
            this.Controls.Add(this.buttonTestPdf2);
            this.Controls.Add(this.btnCreatePdf);
            this.Controls.Add(this.buttonSetValue);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonGetWorker);
            this.Controls.Add(this.buttonAddWorkers);
            this.Controls.Add(this.buttonAddColumns);
            this.Controls.Add(this.customGrid1);
            this.Controls.Add(this.customListBox);
            this.Controls.Add(this.customInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonAddToInput);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonAddItems);
            this.Name = "FormMain";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddItems;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonAddToInput;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private CustomWinFormsComponents.Components.CustomInput customInput;
        private CustomWinFormsComponents.Components.CustomListBox customListBox;
        private CustomWinFormsComponents.Components.CustomGrid customGrid1;
        private System.Windows.Forms.Button buttonAddColumns;
        private System.Windows.Forms.Button buttonAddWorkers;
        private System.Windows.Forms.Button buttonGetWorker;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSetValue;
        private CustomNoVisualComponents.Components.CustomPdfTableV2 customPdfTableV21;
        private System.Windows.Forms.Button btnCreatePdf;
        private System.Windows.Forms.Button buttonTestPdf2;
        private System.Windows.Forms.Button buttonTestPdf3;
        private System.Windows.Forms.Label label2;
    }
}

