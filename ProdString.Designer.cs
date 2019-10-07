namespace Assignment1
{
    partial class ProdString
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
            this.Btn_GetProduct_String = new System.Windows.Forms.Button();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_GetProduct_String
            // 
            this.Btn_GetProduct_String.Location = new System.Drawing.Point(69, 56);
            this.Btn_GetProduct_String.Name = "Btn_GetProduct_String";
            this.Btn_GetProduct_String.Size = new System.Drawing.Size(150, 55);
            this.Btn_GetProduct_String.TabIndex = 5;
            this.Btn_GetProduct_String.Text = "Get Product Details";
            this.Btn_GetProduct_String.UseVisualStyleBackColor = true;
            this.Btn_GetProduct_String.Click += new System.EventHandler(this.Btn_GetProduct_String_Click);
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(98, 15);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(173, 20);
            this.txtProdId.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product ID";
            // 
            // ProdString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.Btn_GetProduct_String);
            this.Controls.Add(this.txtProdId);
            this.Controls.Add(this.label1);
            this.Name = "ProdString";
            this.Text = "ProdString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_GetProduct_String;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.Label label1;
    }
}