﻿namespace MultiQueueSimulation
{
    partial class InputForm
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
            this.next = new System.Windows.Forms.Button();
            this.selectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfServers = new System.Windows.Forms.TextBox();
            this.stoppingNumber = new System.Windows.Forms.TextBox();
            this.stoppingCriteria = new System.Windows.Forms.ComboBox();
            this.selectionMethod = new System.Windows.Forms.ComboBox();
            this.systemData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(145, 310);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 0;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(135, 281);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(97, 23);
            this.selectFile.TabIndex = 1;
            this.selectFile.Text = "Select from a file";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Servers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stopping Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stopping Criteria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Selection Method";
            // 
            // numberOfServers
            // 
            this.numberOfServers.Location = new System.Drawing.Point(135, 36);
            this.numberOfServers.Name = "numberOfServers";
            this.numberOfServers.Size = new System.Drawing.Size(207, 20);
            this.numberOfServers.TabIndex = 6;
            // 
            // stoppingNumber
            // 
            this.stoppingNumber.Location = new System.Drawing.Point(135, 76);
            this.stoppingNumber.Name = "stoppingNumber";
            this.stoppingNumber.Size = new System.Drawing.Size(207, 20);
            this.stoppingNumber.TabIndex = 7;
            // 
            // stoppingCriteria
            // 
            this.stoppingCriteria.FormattingEnabled = true;
            this.stoppingCriteria.Location = new System.Drawing.Point(135, 118);
            this.stoppingCriteria.Name = "stoppingCriteria";
            this.stoppingCriteria.Size = new System.Drawing.Size(207, 21);
            this.stoppingCriteria.TabIndex = 8;
            // 
            // selectionMethod
            // 
            this.selectionMethod.FormattingEnabled = true;
            this.selectionMethod.Location = new System.Drawing.Point(135, 164);
            this.selectionMethod.Name = "selectionMethod";
            this.selectionMethod.Size = new System.Drawing.Size(207, 21);
            this.selectionMethod.TabIndex = 9;
            // 
            // systemData
            // 
            this.systemData.Location = new System.Drawing.Point(135, 203);
            this.systemData.Multiline = true;
            this.systemData.Name = "systemData";
            this.systemData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.systemData.Size = new System.Drawing.Size(211, 60);
            this.systemData.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Interarrival\r\nDistribution";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 346);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.systemData);
            this.Controls.Add(this.selectionMethod);
            this.Controls.Add(this.stoppingCriteria);
            this.Controls.Add(this.stoppingNumber);
            this.Controls.Add(this.numberOfServers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.next);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InputForm";
            this.Text = "Input Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numberOfServers;
        private System.Windows.Forms.TextBox stoppingNumber;
        private System.Windows.Forms.ComboBox stoppingCriteria;
        private System.Windows.Forms.ComboBox selectionMethod;
        private System.Windows.Forms.TextBox systemData;
        private System.Windows.Forms.Label label5;
    }
}

