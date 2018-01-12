namespace driver
{
    partial class owner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.申请号牌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.补办号牌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驾照查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驾照补换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.申请号牌ToolStripMenuItem,
            this.补办号牌ToolStripMenuItem,
            this.驾照查询ToolStripMenuItem,
            this.驾照补换ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(310, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 申请号牌ToolStripMenuItem
            // 
            this.申请号牌ToolStripMenuItem.Name = "申请号牌ToolStripMenuItem";
            this.申请号牌ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.申请号牌ToolStripMenuItem.Text = "申请号牌";
            this.申请号牌ToolStripMenuItem.Click += new System.EventHandler(this.申请号牌ToolStripMenuItem_Click);
            // 
            // 补办号牌ToolStripMenuItem
            // 
            this.补办号牌ToolStripMenuItem.Name = "补办号牌ToolStripMenuItem";
            this.补办号牌ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.补办号牌ToolStripMenuItem.Text = "补办号牌";
            this.补办号牌ToolStripMenuItem.Click += new System.EventHandler(this.补办号牌ToolStripMenuItem_Click);
            // 
            // 驾照查询ToolStripMenuItem
            // 
            this.驾照查询ToolStripMenuItem.Name = "驾照查询ToolStripMenuItem";
            this.驾照查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.驾照查询ToolStripMenuItem.Text = "驾照查询";
            this.驾照查询ToolStripMenuItem.Click += new System.EventHandler(this.驾照查询ToolStripMenuItem_Click);
            // 
            // 驾照补换ToolStripMenuItem
            // 
            this.驾照补换ToolStripMenuItem.Name = "驾照补换ToolStripMenuItem";
            this.驾照补换ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.驾照补换ToolStripMenuItem.Text = "驾照补换";
            this.驾照补换ToolStripMenuItem.Click += new System.EventHandler(this.驾照补换ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "更改密码";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(310, 192);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // owner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 261);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "owner";
            this.Text = "车辆信息管理系统-司机";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 申请号牌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 补办号牌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 驾照查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 驾照补换ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
    }
}

