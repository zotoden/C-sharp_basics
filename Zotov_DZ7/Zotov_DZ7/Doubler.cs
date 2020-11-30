using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
//   Игрок должен постараться получить это число за минимальное количество ходов.
//в) *Добавить кнопку «Отменить», которая отменяет последние ходы.

namespace Zotov_DZ7
{
    public partial class Doubler : Form
    {
        int numb;
        Random random = new Random();
        int commands;
        int currNumb;
        Stack<bool> history = new Stack<bool>();

        public Doubler()
        {
            InitializeComponent();
            this.Text = "Удвоитель";
            Await();
        }

        private void buttonInc_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (++currNumb).ToString();
            history.Push(true);
            back.Enabled = true;
            moves.Text = $"Сделано ходов: {++commands}";
            check();

        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (currNumb*=2).ToString();
            history.Push(false);
            back.Enabled = true;
            moves.Text = $"Сделано ходов: {++commands}";
            check();
        }

        private void buttonReb_Click(object sender, EventArgs e)
        {
            currNumb = 0;
            lblNumber.Text = "0";
            commands = 0;
            moves.Text = $"Сделано ходов: {commands}";
        }

        private void check ()
        {
            if (currNumb > numb)
            {
                MessageBox.Show("Вы проиграли!");
                Await();
            }
            else
                if (currNumb == numb)
            {
                MessageBox.Show($"Поздравляю, Вы выиграли! Вам потребовалось {commands} ходов.");
                Await();
            }
        }
        private void Await ()
        {
            buttonInc.Enabled = false;
            buttonMult.Enabled = false;
            buttonReb.Enabled = false;
            back.Enabled = false;
            moves.Text = "";
            goal.Text = "";
            lblNumber.Text = "0";
            history.Clear();
            numb = 0;
            commands = 0;
            currNumb = 0;

        }
        private void play_Click(object sender, EventArgs e)
        {
            numb = random.Next(200);
            commands = 0;
            goal.Text = $"Наберите число {numb}";
            buttonInc.Enabled = true;
            buttonMult.Enabled = true;
            buttonReb.Enabled = true;
            moves.Text = "Сделано ходов: 0";
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (history.Pop())
                lblNumber.Text = (--currNumb).ToString();
            else
                lblNumber.Text = (currNumb /= 2).ToString();
            moves.Text = $"Сделано ходов: {--commands}";
            if (commands == 0)
                back.Enabled = false;
        }
    }
}
