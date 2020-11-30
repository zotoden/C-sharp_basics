namespace Zotov_DZ7
{
    partial class Doubler
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonInc = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonMult = new System.Windows.Forms.Button();
            this.buttonReb = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.goal = new System.Windows.Forms.Label();
            this.moves = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInc
            // 
            this.buttonInc.Location = new System.Drawing.Point(583, 143);
            this.buttonInc.Name = "buttonInc";
            this.buttonInc.Size = new System.Drawing.Size(109, 41);
            this.buttonInc.TabIndex = 0;
            this.buttonInc.Text = "+1";
            this.buttonInc.UseVisualStyleBackColor = true;
            this.buttonInc.Click += new System.EventHandler(this.buttonInc_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(348, 194);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(73, 25);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "Число";
            // 
            // buttonMult
            // 
            this.buttonMult.Location = new System.Drawing.Point(583, 217);
            this.buttonMult.Name = "buttonMult";
            this.buttonMult.Size = new System.Drawing.Size(109, 43);
            this.buttonMult.TabIndex = 2;
            this.buttonMult.Text = "x2";
            this.buttonMult.UseVisualStyleBackColor = true;
            this.buttonMult.Click += new System.EventHandler(this.buttonMult_Click);
            // 
            // buttonReb
            // 
            this.buttonReb.Location = new System.Drawing.Point(583, 352);
            this.buttonReb.Name = "buttonReb";
            this.buttonReb.Size = new System.Drawing.Size(109, 46);
            this.buttonReb.TabIndex = 3;
            this.buttonReb.Text = "Сброс";
            this.buttonReb.UseVisualStyleBackColor = true;
            this.buttonReb.Click += new System.EventHandler(this.buttonReb_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(570, 31);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(135, 64);
            this.play.TabIndex = 4;
            this.play.Text = "Играть";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // goal
            // 
            this.goal.AutoSize = true;
            this.goal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goal.Location = new System.Drawing.Point(60, 110);
            this.goal.Name = "goal";
            this.goal.Size = new System.Drawing.Size(63, 25);
            this.goal.TabIndex = 5;
            this.goal.Text = "Цель";
            // 
            // moves
            // 
            this.moves.AutoSize = true;
            this.moves.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moves.Location = new System.Drawing.Point(60, 292);
            this.moves.Name = "moves";
            this.moves.Size = new System.Drawing.Size(187, 25);
            this.moves.TabIndex = 6;
            this.moves.Text = "Сделано ходов: 0";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(583, 285);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(109, 43);
            this.back.TabIndex = 7;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Doubler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.moves);
            this.Controls.Add(this.goal);
            this.Controls.Add(this.play);
            this.Controls.Add(this.buttonReb);
            this.Controls.Add(this.buttonMult);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.buttonInc);
            this.Name = "Doubler";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInc;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMult;
        private System.Windows.Forms.Button buttonReb;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label goal;
        private System.Windows.Forms.Label moves;
        private System.Windows.Forms.Button back;
    }
}

