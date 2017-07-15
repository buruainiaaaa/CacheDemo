namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ProductId = new System.Windows.Forms.TextBox();
            this.txt_ProductCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OrderCount = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Store = new System.Windows.Forms.TextBox();
            this.txt_Count = new System.Windows.Forms.TextBox();
            this.lbl_StoreCount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 230);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "下单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_ProductId
            // 
            this.txt_ProductId.Location = new System.Drawing.Point(98, 30);
            this.txt_ProductId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_ProductId.Name = "txt_ProductId";
            this.txt_ProductId.Size = new System.Drawing.Size(76, 21);
            this.txt_ProductId.TabIndex = 1;
            this.txt_ProductId.Text = "1";
            // 
            // txt_ProductCount
            // 
            this.txt_ProductCount.Location = new System.Drawing.Point(98, 82);
            this.txt_ProductCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_ProductCount.Name = "txt_ProductCount";
            this.txt_ProductCount.Size = new System.Drawing.Size(76, 21);
            this.txt_ProductCount.TabIndex = 2;
            this.txt_ProductCount.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "产品Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "下单产品数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "订单数量";
            // 
            // txt_OrderCount
            // 
            this.txt_OrderCount.Location = new System.Drawing.Point(98, 143);
            this.txt_OrderCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_OrderCount.Name = "txt_OrderCount";
            this.txt_OrderCount.Size = new System.Drawing.Size(76, 21);
            this.txt_OrderCount.TabIndex = 6;
            this.txt_OrderCount.Text = "10";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 230);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "设置库存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "库存";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "产品Id";
            // 
            // txt_Store
            // 
            this.txt_Store.Location = new System.Drawing.Point(276, 143);
            this.txt_Store.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Store.Name = "txt_Store";
            this.txt_Store.Size = new System.Drawing.Size(76, 21);
            this.txt_Store.TabIndex = 9;
            this.txt_Store.Text = "10";
            // 
            // txt_Count
            // 
            this.txt_Count.Location = new System.Drawing.Point(276, 92);
            this.txt_Count.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Count.Name = "txt_Count";
            this.txt_Count.Size = new System.Drawing.Size(76, 21);
            this.txt_Count.TabIndex = 8;
            this.txt_Count.Text = "1";
            // 
            // lbl_StoreCount
            // 
            this.lbl_StoreCount.AutoSize = true;
            this.lbl_StoreCount.Location = new System.Drawing.Point(70, 317);
            this.lbl_StoreCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_StoreCount.Name = "lbl_StoreCount";
            this.lbl_StoreCount.Size = new System.Drawing.Size(41, 12);
            this.lbl_StoreCount.TabIndex = 12;
            this.lbl_StoreCount.Text = "库存数";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(242, 314);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 31);
            this.button3.TabIndex = 13;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 379);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbl_StoreCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Store);
            this.Controls.Add(this.txt_Count);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_OrderCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ProductCount);
            this.Controls.Add(this.txt_ProductId);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ProductId;
        private System.Windows.Forms.TextBox txt_ProductCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_OrderCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Store;
        private System.Windows.Forms.TextBox txt_Count;
        private System.Windows.Forms.Label lbl_StoreCount;
        private System.Windows.Forms.Button button3;
    }
}

