using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Используя Windows Forms, разработать игру «Угадай число». 
//Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Для ввода данных от человека используется элемент TextBox.

namespace Zotov_DZ7
{
    public partial class Guess : Form
    {
        int numb;
        int tries;
        int currNumb;
        public Guess()
        {
            InitializeComponent();
            this.Text = "Угадай число";
            Await();
            info.Text = "";
        }

        private void play_Click(object sender, EventArgs e)
        {
            numb = new Random().Next(101);
            info.Text = "";
            triesText.Text = "Попыток: 0";
            label1.Visible = true;
            textBox1.Enabled = true;
            textBox1.Focus();
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (int.TryParse(textBox1.Text, out currNumb))
                {
                    triesText.Text = $"Попыток: {++tries}";
                    Check();
                }
                textBox1.Text = "";
            }
        }

        private void Check ()
        {
            if (numb < currNumb)
                info.Text = $"Загаданное число меньше, чем {currNumb}";
            else
                if (numb > currNumb)
                info.Text = $"Загаданное число больше, чем {currNumb}";
            else
            {
                info.Text = $"Вы выиграли! Вам потребовалось {tries} попыток.";
                Await();
            }
        }
        
        public void Await ()
        {
            label1.Visible = false;
            tries = 0;
            triesText.Text = "";
            textBox1.Enabled = false;
        }
    }
}
