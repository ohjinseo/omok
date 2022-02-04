
namespace omok
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.게임모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pvp모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aI모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.돌선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑돌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.백돌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 539);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.게임모드ToolStripMenuItem,
            this.돌선택ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 게임모드ToolStripMenuItem
            // 
            this.게임모드ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pvp모드ToolStripMenuItem,
            this.aI모드ToolStripMenuItem});
            this.게임모드ToolStripMenuItem.Name = "게임모드ToolStripMenuItem";
            this.게임모드ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.게임모드ToolStripMenuItem.Text = "게임 모드";
            // 
            // pvp모드ToolStripMenuItem
            // 
            this.pvp모드ToolStripMenuItem.Name = "pvp모드ToolStripMenuItem";
            this.pvp모드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pvp모드ToolStripMenuItem.Text = "pvp 모드";
            this.pvp모드ToolStripMenuItem.Click += new System.EventHandler(this.Click_PVP);
            // 
            // aI모드ToolStripMenuItem
            // 
            this.aI모드ToolStripMenuItem.Name = "aI모드ToolStripMenuItem";
            this.aI모드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aI모드ToolStripMenuItem.Text = "AI 모드";
            this.aI모드ToolStripMenuItem.Click += new System.EventHandler(this.Click_AI);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // 돌선택ToolStripMenuItem
            // 
            this.돌선택ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.흑돌ToolStripMenuItem,
            this.백돌ToolStripMenuItem});
            this.돌선택ToolStripMenuItem.Name = "돌선택ToolStripMenuItem";
            this.돌선택ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.돌선택ToolStripMenuItem.Text = "돌 선택";
            // 
            // 흑돌ToolStripMenuItem
            // 
            this.흑돌ToolStripMenuItem.Name = "흑돌ToolStripMenuItem";
            this.흑돌ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.흑돌ToolStripMenuItem.Text = "흑돌";
            this.흑돌ToolStripMenuItem.Click += new System.EventHandler(this.black_Click);
            // 
            // 백돌ToolStripMenuItem
            // 
            this.백돌ToolStripMenuItem.Name = "백돌ToolStripMenuItem";
            this.백돌ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.백돌ToolStripMenuItem.Text = "백돌";
            this.백돌ToolStripMenuItem.Click += new System.EventHandler(this.white_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 게임모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pvp모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aI모드ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 돌선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 흑돌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 백돌ToolStripMenuItem;
    }
}

