namespace NEAPrint
{
    partial class PrintMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintMain));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NEA打印服务MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppIsAutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.退出MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NEA打印服务MenuItem,
            this.AppIsAutoRun,
            this.退出MenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // NEA打印服务MenuItem
            // 
            this.NEA打印服务MenuItem.Name = "NEA打印服务MenuItem";
            this.NEA打印服务MenuItem.Size = new System.Drawing.Size(152, 22);
            this.NEA打印服务MenuItem.Text = "NEA打印服务";
            this.NEA打印服务MenuItem.Click += new System.EventHandler(this.NEA打印服务MenuItem_Click);
            // 
            // AppIsAutoRun
            // 
            this.AppIsAutoRun.Name = "AppIsAutoRun";
            this.AppIsAutoRun.Size = new System.Drawing.Size(152, 22);
            this.AppIsAutoRun.Text = "开机启动";
            this.AppIsAutoRun.Click += new System.EventHandler(this.AppIsAutoRun_Click);
            // 
            // 退出MenuItem
            // 
            this.退出MenuItem.Name = "退出MenuItem";
            this.退出MenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出MenuItem.Text = "退出";
            this.退出MenuItem.Click += new System.EventHandler(this.退出MenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "NEA打印服务";
            this.notifyIcon1.Visible = true;
            // 
            // PrintMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintMain";
            this.ShowInTaskbar = false;
            this.Text = "NEA打印服务";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NEA打印服务MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出MenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem AppIsAutoRun;
    }
}

