
namespace WindowsFormsAppHsv
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
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.labelHue = new System.Windows.Forms.Label();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(815, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "色相(Hue)の回転角";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(820, 72);
            this.hScrollBar1.Maximum = 189;
            this.hScrollBar1.Minimum = -180;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(217, 26);
            this.hScrollBar1.TabIndex = 1;
            // 
            // labelHue
            // 
            this.labelHue.AutoSize = true;
            this.labelHue.Location = new System.Drawing.Point(815, 121);
            this.labelHue.Name = "labelHue";
            this.labelHue.Size = new System.Drawing.Size(222, 30);
            this.labelHue.TabIndex = 2;
            this.labelHue.Text = "色相(Hue)の回転角";
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(815, 281);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(222, 30);
            this.labelSaturation.TabIndex = 5;
            this.labelSaturation.Text = "色相(Hue)の回転角";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.LargeChange = 5;
            this.hScrollBar2.Location = new System.Drawing.Point(820, 232);
            this.hScrollBar2.Maximum = 124;
            this.hScrollBar2.Minimum = 80;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(217, 26);
            this.hScrollBar2.TabIndex = 4;
            this.hScrollBar2.Value = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(815, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "彩度(Saturation)の増減";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(815, 441);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(222, 30);
            this.labelValue.TabIndex = 8;
            this.labelValue.Text = "色相(Hue)の回転角";
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Location = new System.Drawing.Point(820, 392);
            this.hScrollBar3.Maximum = 124;
            this.hScrollBar3.Minimum = 80;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(217, 26);
            this.hScrollBar3.TabIndex = 7;
            this.hScrollBar3.Value = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(815, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "明度(Value)の増減";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(887, 540);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 649);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.hScrollBar3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelHue);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label labelHue;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonReset;
    }
}

