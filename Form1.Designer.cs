
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxKeys2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKeys1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxResult_Key1 = new System.Windows.Forms.RichTextBox();
            this.buttonCopyText_Key1 = new System.Windows.Forms.Button();
            this.buttonCopyKey_Key1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCopyText_Key2 = new System.Windows.Forms.Button();
            this.richTextBoxResult_Key2 = new System.Windows.Forms.RichTextBox();
            this.buttonCopyKey_Key2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(82, 98);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сравнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.textBoxKeys2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxKeys1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 82);
            this.panel1.TabIndex = 1;
            // 
            // textBoxKeys2
            // 
            this.textBoxKeys2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeys2.Location = new System.Drawing.Point(61, 46);
            this.textBoxKeys2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKeys2.Name = "textBoxKeys2";
            this.textBoxKeys2.Size = new System.Drawing.Size(545, 23);
            this.textBoxKeys2.TabIndex = 3;
            this.textBoxKeys2.Text = "--enable-features=\"featureA<x\" --force-fieldtrials=x/1 --force-fieldtrial-params=" +
    "\"x.1:write/true/console/false\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key 2";
            // 
            // textBoxKeys1
            // 
            this.textBoxKeys1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeys1.Location = new System.Drawing.Point(61, 6);
            this.textBoxKeys1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKeys1.Name = "textBoxKeys1";
            this.textBoxKeys1.Size = new System.Drawing.Size(545, 23);
            this.textBoxKeys1.TabIndex = 1;
            this.textBoxKeys1.Text = "--enable-features=\"featureA<x\" --force-fieldtrials=x/1 --force-fieldtrial-params=" +
    "\"x.1:write/true/console/false\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key 1";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 18);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(605, 70);
            this.richTextBoxLog.TabIndex = 2;
            this.richTextBoxLog.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(611, 339);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxResult_Key1);
            this.groupBox2.Controls.Add(this.buttonCopyText_Key1);
            this.groupBox2.Controls.Add(this.buttonCopyKey_Key1);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 339);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отличия от ключа 2";
            // 
            // richTextBoxResult_Key1
            // 
            this.richTextBoxResult_Key1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult_Key1.Location = new System.Drawing.Point(3, 54);
            this.richTextBoxResult_Key1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxResult_Key1.Name = "richTextBoxResult_Key1";
            this.richTextBoxResult_Key1.ReadOnly = true;
            this.richTextBoxResult_Key1.Size = new System.Drawing.Size(288, 282);
            this.richTextBoxResult_Key1.TabIndex = 0;
            this.richTextBoxResult_Key1.Text = "";
            // 
            // buttonCopyText_Key1
            // 
            this.buttonCopyText_Key1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyText_Key1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCopyText_Key1.Location = new System.Drawing.Point(158, 19);
            this.buttonCopyText_Key1.Name = "buttonCopyText_Key1";
            this.buttonCopyText_Key1.Size = new System.Drawing.Size(130, 30);
            this.buttonCopyText_Key1.TabIndex = 10;
            this.buttonCopyText_Key1.Text = "Скопировать текст";
            this.buttonCopyText_Key1.UseVisualStyleBackColor = true;
            // 
            // buttonCopyKey_Key1
            // 
            this.buttonCopyKey_Key1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCopyKey_Key1.Location = new System.Drawing.Point(6, 19);
            this.buttonCopyKey_Key1.Name = "buttonCopyKey_Key1";
            this.buttonCopyKey_Key1.Size = new System.Drawing.Size(130, 30);
            this.buttonCopyKey_Key1.TabIndex = 9;
            this.buttonCopyKey_Key1.Text = "Скопировать ключ";
            this.buttonCopyKey_Key1.UseVisualStyleBackColor = true;
            this.buttonCopyKey_Key1.Click += new System.EventHandler(this.buttonCopyKey_Key1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCopyText_Key2);
            this.groupBox3.Controls.Add(this.richTextBoxResult_Key2);
            this.groupBox3.Controls.Add(this.buttonCopyKey_Key2);
            this.groupBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 339);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отличия от ключа 1";
            // 
            // buttonCopyText_Key2
            // 
            this.buttonCopyText_Key2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyText_Key2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCopyText_Key2.Location = new System.Drawing.Point(177, 19);
            this.buttonCopyText_Key2.Name = "buttonCopyText_Key2";
            this.buttonCopyText_Key2.Size = new System.Drawing.Size(130, 30);
            this.buttonCopyText_Key2.TabIndex = 11;
            this.buttonCopyText_Key2.Text = "Скопировать текст";
            this.buttonCopyText_Key2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxResult_Key2
            // 
            this.richTextBoxResult_Key2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult_Key2.Location = new System.Drawing.Point(3, 54);
            this.richTextBoxResult_Key2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxResult_Key2.Name = "richTextBoxResult_Key2";
            this.richTextBoxResult_Key2.ReadOnly = true;
            this.richTextBoxResult_Key2.Size = new System.Drawing.Size(307, 282);
            this.richTextBoxResult_Key2.TabIndex = 0;
            this.richTextBoxResult_Key2.Text = "";
            // 
            // buttonCopyKey_Key2
            // 
            this.buttonCopyKey_Key2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCopyKey_Key2.Location = new System.Drawing.Point(6, 19);
            this.buttonCopyKey_Key2.Name = "buttonCopyKey_Key2";
            this.buttonCopyKey_Key2.Size = new System.Drawing.Size(147, 30);
            this.buttonCopyKey_Key2.TabIndex = 8;
            this.buttonCopyKey_Key2.Text = "Скопировать ключ";
            this.buttonCopyKey_Key2.UseVisualStyleBackColor = true;
            this.buttonCopyKey_Key2.Click += new System.EventHandler(this.buttonCopyKey_Key2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(611, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(10, 134);
            this.splitContainer2.MinimumSize = new System.Drawing.Size(610, 430);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(611, 433);
            this.splitContainer2.SplitterDistance = 90;
            this.splitContainer2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 578);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxKeys2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKeys1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxResult_Key1;
        private System.Windows.Forms.RichTextBox richTextBoxResult_Key2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCopyKey_Key2;
        private System.Windows.Forms.Button buttonCopyKey_Key1;
        private System.Windows.Forms.Button buttonCopyText_Key1;
        private System.Windows.Forms.Button buttonCopyText_Key2;
    }
}

