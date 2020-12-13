
namespace WindowsFormsApp2_5
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonSpline = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClearLine = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(12, 17);
            this.buttonLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(87, 29);
            this.buttonLine.TabIndex = 0;
            this.buttonLine.Text = "直線";
            this.buttonLine.UseVisualStyleBackColor = true;
            // 
            // buttonSpline
            // 
            this.buttonSpline.Location = new System.Drawing.Point(149, 17);
            this.buttonSpline.Name = "buttonSpline";
            this.buttonSpline.Size = new System.Drawing.Size(70, 29);
            this.buttonSpline.TabIndex = 1;
            this.buttonSpline.Text = "スプライン";
            this.buttonSpline.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // buttonClearLine
            // 
            this.buttonClearLine.Location = new System.Drawing.Point(392, 16);
            this.buttonClearLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClearLine.Name = "buttonClearLine";
            this.buttonClearLine.Size = new System.Drawing.Size(87, 29);
            this.buttonClearLine.TabIndex = 3;
            this.buttonClearLine.Text = "補間消去";
            this.buttonClearLine.UseVisualStyleBackColor = true;
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(526, 17);
            this.buttonClearAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(87, 29);
            this.buttonClearAll.TabIndex = 4;
            this.buttonClearAll.Text = "全消去";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 649);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonClearLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSpline);
            this.Controls.Add(this.buttonLine);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonSpline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClearLine;
        private System.Windows.Forms.Button buttonClearAll;
    }
}

