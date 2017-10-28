namespace Client
{
    partial class Welcome
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Single = new System.Windows.Forms.Button();
            this.btn_Network1 = new System.Windows.Forms.Button();
            this.btn_Network2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Single
            // 
            this.btn_Single.BackColor = System.Drawing.Color.Transparent;
            this.btn_Single.FlatAppearance.BorderSize = 0;
            this.btn_Single.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Single.Image = global::Client.Properties.Resources.w1;
            this.btn_Single.Location = new System.Drawing.Point(77, 34);
            this.btn_Single.Name = "btn_Single";
            this.btn_Single.Size = new System.Drawing.Size(105, 27);
            this.btn_Single.TabIndex = 0;
            this.btn_Single.UseVisualStyleBackColor = false;
            this.btn_Single.Click += new System.EventHandler(this.Single);
            // 
            // btn_Network1
            // 
            this.btn_Network1.BackColor = System.Drawing.Color.Transparent;
            this.btn_Network1.FlatAppearance.BorderSize = 0;
            this.btn_Network1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Network1.Image = global::Client.Properties.Resources.w2;
            this.btn_Network1.Location = new System.Drawing.Point(77, 77);
            this.btn_Network1.Name = "btn_Network1";
            this.btn_Network1.Size = new System.Drawing.Size(105, 27);
            this.btn_Network1.TabIndex = 1;
            this.btn_Network1.UseVisualStyleBackColor = false;
            this.btn_Network1.Click += new System.EventHandler(this.Network);
            // 
            // btn_Network2
            // 
            this.btn_Network2.BackColor = System.Drawing.Color.Transparent;
            this.btn_Network2.FlatAppearance.BorderSize = 0;
            this.btn_Network2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Network2.Image = global::Client.Properties.Resources.w3;
            this.btn_Network2.Location = new System.Drawing.Point(77, 123);
            this.btn_Network2.Name = "btn_Network2";
            this.btn_Network2.Size = new System.Drawing.Size(105, 27);
            this.btn_Network2.TabIndex = 2;
            this.btn_Network2.UseVisualStyleBackColor = false;
            this.btn_Network2.Click += new System.EventHandler(this.Network);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(269, 228);
            this.Controls.Add(this.btn_Network2);
            this.Controls.Add(this.btn_Network1);
            this.Controls.Add(this.btn_Single);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Single;
        private System.Windows.Forms.Button btn_Network1;
        private System.Windows.Forms.Button btn_Network2;
    }
}

