namespace Projas
{
    partial class frmIqomah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIqomah));
            this.tmrAzan = new System.Windows.Forms.Timer(this.components);
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.pnlBawah = new System.Windows.Forms.Panel();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.pnlKanan = new System.Windows.Forms.Panel();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.cpProgress = new CircularProgressBar.CircularProgressBar();
            this.lblSholat = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.tmrIqomah = new System.Windows.Forms.Timer(this.components);
            this.tmrBlink = new System.Windows.Forms.Timer(this.components);
            this.pnlTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrAzan
            // 
            this.tmrAzan.Enabled = true;
            this.tmrAzan.Interval = 1000;
            this.tmrAzan.Tick += new System.EventHandler(this.tmrAzan_Tick);
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(800, 45);
            this.pnlAtas.TabIndex = 6;
            // 
            // pnlBawah
            // 
            this.pnlBawah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 405);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(800, 45);
            this.pnlBawah.TabIndex = 7;
            // 
            // pnlKiri
            // 
            this.pnlKiri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 45);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(95, 360);
            this.pnlKiri.TabIndex = 8;
            // 
            // pnlKanan
            // 
            this.pnlKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlKanan.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKanan.Location = new System.Drawing.Point(705, 45);
            this.pnlKanan.Name = "pnlKanan";
            this.pnlKanan.Size = new System.Drawing.Size(95, 360);
            this.pnlKanan.TabIndex = 9;
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.Controls.Add(this.cpProgress);
            this.pnlTemplate.Controls.Add(this.lblSholat);
            this.pnlTemplate.Controls.Add(this.lblTime);
            this.pnlTemplate.Controls.Add(this.lblText);
            this.pnlTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplate.Location = new System.Drawing.Point(95, 45);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(610, 360);
            this.pnlTemplate.TabIndex = 10;
            // 
            // cpProgress
            // 
            this.cpProgress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.CubicEaseInOut;
            this.cpProgress.AnimationSpeed = 500;
            this.cpProgress.BackColor = System.Drawing.Color.Transparent;
            this.cpProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cpProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpProgress.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cpProgress.InnerMargin = 2;
            this.cpProgress.InnerWidth = -1;
            this.cpProgress.Location = new System.Drawing.Point(155, 36);
            this.cpProgress.MarqueeAnimationSpeed = 2000;
            this.cpProgress.Name = "cpProgress";
            this.cpProgress.OuterColor = System.Drawing.Color.Gray;
            this.cpProgress.OuterMargin = -25;
            this.cpProgress.OuterWidth = 26;
            this.cpProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cpProgress.ProgressWidth = 25;
            this.cpProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpProgress.Size = new System.Drawing.Size(320, 320);
            this.cpProgress.StartAngle = 0;
            this.cpProgress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpProgress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpProgress.SubscriptText = "";
            this.cpProgress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpProgress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpProgress.SuperscriptText = "";
            this.cpProgress.TabIndex = 3;
            this.cpProgress.Text = "100";
            this.cpProgress.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpProgress.Value = 100;
            this.cpProgress.Visible = false;
            // 
            // lblSholat
            // 
            this.lblSholat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSholat.Font = new System.Drawing.Font("Niagara Solid", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSholat.ForeColor = System.Drawing.Color.White;
            this.lblSholat.Location = new System.Drawing.Point(0, 125);
            this.lblSholat.Name = "lblSholat";
            this.lblSholat.Size = new System.Drawing.Size(610, 125);
            this.lblSholat.TabIndex = 2;
            this.lblSholat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 170.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblTime.Location = new System.Drawing.Point(-3, 142);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(607, 218);
            this.lblTime.TabIndex = 0;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblText.Font = new System.Drawing.Font("Niagara Solid", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(610, 125);
            this.lblText.TabIndex = 1;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrIqomah
            // 
            this.tmrIqomah.Interval = 1000;
            this.tmrIqomah.Tick += new System.EventHandler(this.tmrIqomah_Tick);
            // 
            // tmrBlink
            // 
            this.tmrBlink.Interval = 1000;
            this.tmrBlink.Tick += new System.EventHandler(this.tmrBlink_Tick);
            // 
            // frmIqomah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlTemplate);
            this.Controls.Add(this.pnlKanan);
            this.Controls.Add(this.pnlKiri);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIqomah";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIqomah";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIqomah_Load);
            this.pnlTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrAzan;
        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.Panel pnlKanan;
        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSholat;
        private System.Windows.Forms.Timer tmrIqomah;
        private System.Windows.Forms.Timer tmrBlink;
        private CircularProgressBar.CircularProgressBar cpProgress;
    }
}