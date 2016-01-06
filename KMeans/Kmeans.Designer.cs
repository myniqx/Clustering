namespace KMeans
{
    partial class Kmeans
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.kmean_start = new System.Windows.Forms.Button();
            this.AnimTimer = new System.Windows.Forms.Timer(this.components);
            this.animatecheck = new System.Windows.Forms.CheckBox();
            this.fcm_start = new System.Windows.Forms.Button();
            this.t_err = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_iteration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t_item = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_cluster = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_fuzzy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(382, 385);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // kmean_start
            // 
            this.kmean_start.Location = new System.Drawing.Point(6, 19);
            this.kmean_start.Name = "kmean_start";
            this.kmean_start.Size = new System.Drawing.Size(75, 23);
            this.kmean_start.TabIndex = 1;
            this.kmean_start.Text = "K-Means";
            this.kmean_start.UseVisualStyleBackColor = true;
            this.kmean_start.Click += new System.EventHandler(this.start_Click);
            // 
            // AnimTimer
            // 
            this.AnimTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // animatecheck
            // 
            this.animatecheck.AutoSize = true;
            this.animatecheck.Location = new System.Drawing.Point(22, 48);
            this.animatecheck.Name = "animatecheck";
            this.animatecheck.Size = new System.Drawing.Size(71, 19);
            this.animatecheck.TabIndex = 2;
            this.animatecheck.Text = "Animate";
            this.animatecheck.UseVisualStyleBackColor = true;
            this.animatecheck.CheckedChanged += new System.EventHandler(this.Animate_CheckedChanged);
            // 
            // fcm_start
            // 
            this.fcm_start.Location = new System.Drawing.Point(87, 19);
            this.fcm_start.Name = "fcm_start";
            this.fcm_start.Size = new System.Drawing.Size(75, 23);
            this.fcm_start.TabIndex = 1;
            this.fcm_start.Text = "FCM";
            this.fcm_start.UseVisualStyleBackColor = true;
            this.fcm_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // t_err
            // 
            this.t_err.Location = new System.Drawing.Point(7, 109);
            this.t_err.Name = "t_err";
            this.t_err.Size = new System.Drawing.Size(155, 20);
            this.t_err.TabIndex = 3;
            this.t_err.Text = "0,5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Error Threshold :";
            // 
            // t_iteration
            // 
            this.t_iteration.Location = new System.Drawing.Point(7, 172);
            this.t_iteration.Name = "t_iteration";
            this.t_iteration.Size = new System.Drawing.Size(155, 20);
            this.t_iteration.TabIndex = 3;
            this.t_iteration.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Iteration Count :";
            // 
            // t_item
            // 
            this.t_item.Location = new System.Drawing.Point(7, 236);
            this.t_item.Name = "t_item";
            this.t_item.Size = new System.Drawing.Size(155, 20);
            this.t_item.TabIndex = 3;
            this.t_item.Text = "500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Count :";
            // 
            // t_cluster
            // 
            this.t_cluster.Location = new System.Drawing.Point(7, 301);
            this.t_cluster.Name = "t_cluster";
            this.t_cluster.Size = new System.Drawing.Size(155, 20);
            this.t_cluster.TabIndex = 3;
            this.t_cluster.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Clouster Count :";
            // 
            // t_fuzzy
            // 
            this.t_fuzzy.Location = new System.Drawing.Point(7, 360);
            this.t_fuzzy.Name = "t_fuzzy";
            this.t_fuzzy.Size = new System.Drawing.Size(155, 20);
            this.t_fuzzy.TabIndex = 3;
            this.t_fuzzy.Text = "1,7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fuzziness Factor :";
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.kmean_start);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.fcm_start);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.animatecheck);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.t_err);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.t_iteration);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.t_item);
            this.groupBox.Controls.Add(this.t_fuzzy);
            this.groupBox.Controls.Add(this.t_cluster);
            this.groupBox.Location = new System.Drawing.Point(403, 5);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 391);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // Kmeans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 405);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Kmeans";
            this.Text = "Clustering";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button kmean_start;
        private System.Windows.Forms.Timer AnimTimer;
        private System.Windows.Forms.CheckBox animatecheck;
        private System.Windows.Forms.Button fcm_start;
        private System.Windows.Forms.TextBox t_err;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_iteration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_item;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_cluster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_fuzzy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox;
    }
}

