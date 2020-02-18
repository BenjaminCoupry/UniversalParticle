namespace UniversalParticle
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.screen = new System.Windows.Forms.PictureBox();
            this.OfLeft = new System.Windows.Forms.Button();
            this.OfUp = new System.Windows.Forms.Button();
            this.OfDown = new System.Windows.Forms.Button();
            this.OfRight = new System.Windows.Forms.Button();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.LstFrm = new System.Windows.Forms.Button();
            this.NxtFrm = new System.Windows.Forms.Button();
            this.TimeReal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MoveScale = new System.Windows.Forms.TrackBar();
            this.Xoff = new System.Windows.Forms.Label();
            this.zm = new System.Windows.Forms.Label();
            this.Yoff = new System.Windows.Forms.Label();
            this.LogView = new System.Windows.Forms.CheckBox();
            this.ply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveScale)).BeginInit();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.Location = new System.Drawing.Point(13, 13);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(570, 450);
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // OfLeft
            // 
            this.OfLeft.Location = new System.Drawing.Point(607, 94);
            this.OfLeft.Name = "OfLeft";
            this.OfLeft.Size = new System.Drawing.Size(75, 23);
            this.OfLeft.TabIndex = 1;
            this.OfLeft.Text = "<";
            this.OfLeft.UseVisualStyleBackColor = true;
            this.OfLeft.Click += new System.EventHandler(this.OfLeft_Click);
            // 
            // OfUp
            // 
            this.OfUp.Location = new System.Drawing.Point(681, 65);
            this.OfUp.Name = "OfUp";
            this.OfUp.Size = new System.Drawing.Size(75, 23);
            this.OfUp.TabIndex = 2;
            this.OfUp.Text = "/\\";
            this.OfUp.UseVisualStyleBackColor = true;
            this.OfUp.Click += new System.EventHandler(this.OfUp_Click);
            // 
            // OfDown
            // 
            this.OfDown.Location = new System.Drawing.Point(681, 124);
            this.OfDown.Name = "OfDown";
            this.OfDown.Size = new System.Drawing.Size(75, 23);
            this.OfDown.TabIndex = 3;
            this.OfDown.Text = "\\/";
            this.OfDown.UseVisualStyleBackColor = true;
            this.OfDown.Click += new System.EventHandler(this.OfDown_Click);
            // 
            // OfRight
            // 
            this.OfRight.Location = new System.Drawing.Point(752, 94);
            this.OfRight.Name = "OfRight";
            this.OfRight.Size = new System.Drawing.Size(75, 23);
            this.OfRight.TabIndex = 4;
            this.OfRight.Text = ">";
            this.OfRight.UseVisualStyleBackColor = true;
            this.OfRight.Click += new System.EventHandler(this.OfRight_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(681, 201);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(75, 23);
            this.ZoomIn.TabIndex = 5;
            this.ZoomIn.Text = "x1.5";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Location = new System.Drawing.Point(681, 231);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(75, 23);
            this.ZoomOut.TabIndex = 6;
            this.ZoomOut.Text = "x0.5";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // LstFrm
            // 
            this.LstFrm.Location = new System.Drawing.Point(646, 295);
            this.LstFrm.Name = "LstFrm";
            this.LstFrm.Size = new System.Drawing.Size(75, 23);
            this.LstFrm.TabIndex = 7;
            this.LstFrm.Text = "<<<";
            this.LstFrm.UseVisualStyleBackColor = true;
            this.LstFrm.Click += new System.EventHandler(this.LstFrm_Click);
            // 
            // NxtFrm
            // 
            this.NxtFrm.Location = new System.Drawing.Point(727, 295);
            this.NxtFrm.Name = "NxtFrm";
            this.NxtFrm.Size = new System.Drawing.Size(75, 23);
            this.NxtFrm.TabIndex = 8;
            this.NxtFrm.Text = ">>>";
            this.NxtFrm.UseVisualStyleBackColor = true;
            this.NxtFrm.Click += new System.EventHandler(this.NxtFrm_Click);
            // 
            // TimeReal
            // 
            this.TimeReal.AutoSize = true;
            this.TimeReal.Location = new System.Drawing.Point(643, 379);
            this.TimeReal.Name = "TimeReal";
            this.TimeReal.Size = new System.Drawing.Size(45, 13);
            this.TimeReal.TabIndex = 10;
            this.TimeReal.Text = "Time : 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "//////////";
            // 
            // MoveScale
            // 
            this.MoveScale.LargeChange = 3;
            this.MoveScale.Location = new System.Drawing.Point(607, 13);
            this.MoveScale.Maximum = 100;
            this.MoveScale.Minimum = 1;
            this.MoveScale.Name = "MoveScale";
            this.MoveScale.Size = new System.Drawing.Size(220, 45);
            this.MoveScale.TabIndex = 12;
            this.MoveScale.TickFrequency = 5;
            this.MoveScale.Value = 1;
            // 
            // Xoff
            // 
            this.Xoff.AutoSize = true;
            this.Xoff.Location = new System.Drawing.Point(643, 405);
            this.Xoff.Name = "Xoff";
            this.Xoff.Size = new System.Drawing.Size(55, 13);
            this.Xoff.TabIndex = 13;
            this.Xoff.Text = "Xoffset : 0";
            // 
            // zm
            // 
            this.zm.AutoSize = true;
            this.zm.Location = new System.Drawing.Point(643, 392);
            this.zm.Name = "zm";
            this.zm.Size = new System.Drawing.Size(54, 13);
            this.zm.TabIndex = 14;
            this.zm.Text = "Zoom : 1x";
            // 
            // Yoff
            // 
            this.Yoff.AutoSize = true;
            this.Yoff.Location = new System.Drawing.Point(643, 418);
            this.Yoff.Name = "Yoff";
            this.Yoff.Size = new System.Drawing.Size(55, 13);
            this.Yoff.TabIndex = 15;
            this.Yoff.Text = "Yoffset : 0";
            // 
            // LogView
            // 
            this.LogView.AutoSize = true;
            this.LogView.Location = new System.Drawing.Point(681, 178);
            this.LogView.Name = "LogView";
            this.LogView.Size = new System.Drawing.Size(74, 17);
            this.LogView.TabIndex = 16;
            this.LogView.Text = "Log Scale";
            this.LogView.UseVisualStyleBackColor = true;
            // 
            // ply
            // 
            this.ply.Location = new System.Drawing.Point(681, 324);
            this.ply.Name = "ply";
            this.ply.Size = new System.Drawing.Size(75, 23);
            this.ply.TabIndex = 17;
            this.ply.Text = "Play";
            this.ply.UseVisualStyleBackColor = true;
            this.ply.Click += new System.EventHandler(this.ply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 505);
            this.Controls.Add(this.ply);
            this.Controls.Add(this.LogView);
            this.Controls.Add(this.Yoff);
            this.Controls.Add(this.zm);
            this.Controls.Add(this.Xoff);
            this.Controls.Add(this.MoveScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeReal);
            this.Controls.Add(this.NxtFrm);
            this.Controls.Add(this.LstFrm);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.OfRight);
            this.Controls.Add(this.OfDown);
            this.Controls.Add(this.OfUp);
            this.Controls.Add(this.OfLeft);
            this.Controls.Add(this.screen);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Button OfLeft;
        private System.Windows.Forms.Button OfUp;
        private System.Windows.Forms.Button OfDown;
        private System.Windows.Forms.Button OfRight;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.Button LstFrm;
        private System.Windows.Forms.Button NxtFrm;
        private System.Windows.Forms.Label TimeReal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar MoveScale;
        private System.Windows.Forms.Label Xoff;
        private System.Windows.Forms.Label zm;
        private System.Windows.Forms.Label Yoff;
        private System.Windows.Forms.CheckBox LogView;
        private System.Windows.Forms.Button ply;
    }
}

