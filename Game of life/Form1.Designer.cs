
namespace Game_of_life
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.butAnt = new System.Windows.Forms.Button();
            this.butManualStart = new System.Windows.Forms.Button();
            this.butManualMode = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDensity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudResolution = new System.Windows.Forms.NumericUpDown();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerAnt = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.butAnt);
            this.splitContainer1.Panel1.Controls.Add(this.butManualStart);
            this.splitContainer1.Panel1.Controls.Add(this.butManualMode);
            this.splitContainer1.Panel1.Controls.Add(this.butStop);
            this.splitContainer1.Panel1.Controls.Add(this.butStart);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.nudDensity);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.nudResolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(771, 447);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 0;
            // 
            // butAnt
            // 
            this.butAnt.Location = new System.Drawing.Point(4, 342);
            this.butAnt.Name = "butAnt";
            this.butAnt.Size = new System.Drawing.Size(148, 23);
            this.butAnt.TabIndex = 8;
            this.butAnt.Text = "Запуск Муравья";
            this.butAnt.UseVisualStyleBackColor = true;
            this.butAnt.Click += new System.EventHandler(this.butAnt_Click);
            // 
            // butManualStart
            // 
            this.butManualStart.Location = new System.Drawing.Point(4, 278);
            this.butManualStart.Name = "butManualStart";
            this.butManualStart.Size = new System.Drawing.Size(153, 23);
            this.butManualStart.TabIndex = 7;
            this.butManualStart.Text = "Старт";
            this.butManualStart.UseVisualStyleBackColor = true;
            this.butManualStart.Click += new System.EventHandler(this.butManualStartClick);
            // 
            // butManualMode
            // 
            this.butManualMode.Location = new System.Drawing.Point(4, 248);
            this.butManualMode.Name = "butManualMode";
            this.butManualMode.Size = new System.Drawing.Size(153, 23);
            this.butManualMode.TabIndex = 6;
            this.butManualMode.Text = "Режим Рисования";
            this.butManualMode.UseVisualStyleBackColor = true;
            this.butManualMode.Click += new System.EventHandler(this.butManualModeClick);
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(3, 158);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(149, 23);
            this.butStop.TabIndex = 5;
            this.butStop.Text = "Пауза/Продолжить";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStopClick);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(40, 129);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 4;
            this.butStart.Text = "Старт";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStartClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Плотность";
            // 
            // nudDensity
            // 
            this.nudDensity.Location = new System.Drawing.Point(10, 88);
            this.nudDensity.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDensity.Name = "nudDensity";
            this.nudDensity.Size = new System.Drawing.Size(120, 20);
            this.nudDensity.TabIndex = 2;
            this.nudDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDensity.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Разрешение";
            // 
            // nudResolution
            // 
            this.nudResolution.Location = new System.Drawing.Point(10, 36);
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new System.Drawing.Size(120, 20);
            this.nudResolution.TabIndex = 0;
            this.nudResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudResolution.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(604, 443);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timerTick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1Tick);
            // 
            // timerAnt
            // 
            this.timerAnt.Interval = 1;
            this.timerAnt.Tick += new System.EventHandler(this.timerAnt_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 447);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudResolution;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button butManualMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button butManualStart;
        private System.Windows.Forms.Button butAnt;
        private System.Windows.Forms.Timer timerAnt;
    }
}

