namespace Client
{
    partial class Camera
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
            this.cmb_Camrea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.btn_Grap = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_Camrea
            // 
            this.cmb_Camrea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmb_Camrea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Camrea.FormattingEnabled = true;
            this.cmb_Camrea.Location = new System.Drawing.Point(276, 32);
            this.cmb_Camrea.Name = "cmb_Camrea";
            this.cmb_Camrea.Size = new System.Drawing.Size(196, 20);
            this.cmb_Camrea.TabIndex = 0;
            this.cmb_Camrea.SelectedIndexChanged += new System.EventHandler(this.cmb_Camrea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(145, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择摄像头";
            // 
            // videoPlayer
            // 
            this.videoPlayer.BackColor = System.Drawing.Color.Snow;
            this.videoPlayer.Location = new System.Drawing.Point(49, 72);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(540, 400);
            this.videoPlayer.TabIndex = 2;
            this.videoPlayer.TabStop = false;
            this.videoPlayer.VideoSource = null;
            // 
            // btn_Grap
            // 
            this.btn_Grap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Grap.Location = new System.Drawing.Point(123, 496);
            this.btn_Grap.Name = "btn_Grap";
            this.btn_Grap.Size = new System.Drawing.Size(85, 51);
            this.btn_Grap.TabIndex = 3;
            this.btn_Grap.Text = "抓图";
            this.btn_Grap.UseVisualStyleBackColor = false;
            this.btn_Grap.Click += new System.EventHandler(this.btn_Grap_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Cancel.Location = new System.Drawing.Point(410, 496);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(85, 51);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(646, 559);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Grap);
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Camrea);
            this.MaximizeBox = false;
            this.Name = "Camera";
            this.Text = "Camera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Camrea;
        private System.Windows.Forms.Label label1;
        private AForge.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.Button btn_Grap;
        private System.Windows.Forms.Button btn_Cancel;
    }
}