using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// а - первый операнд
        /// b - второй операнд
        /// </summary>
        double a = 0, b;
        /// <summary>
        /// Номер операции
        /// </summary>
        int count;
        /// <summary>
        /// Текст для смены запятой на точку
        /// </summary>
        string text_coma;
        /// <summary>
        /// Тип класса "Операции"
        /// </summary>
        Operations operations = new Operations();
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Нажатие на клавишу в поле текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_dig_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (TextBox_dig.Text == "NaN" && (e.Key != Key.Back || e.Key != Key.Delete))
            {
                e.Handled = true;
                return;
            }
            if (((e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.OemPeriod && e.Key != Key.OemPlus && e.Key != Key.OemMinus) || 
                (e.Key == Key.OemPeriod && (TextBox_dig.Text.IndexOf('.') > 0 || (TextBox_dig.CaretIndex == 1 && 
                (TextBox_dig.Text.IndexOf('+') >= 0 || TextBox_dig.Text.IndexOf('-') >= 0)) || TextBox_dig.CaretIndex == 0)) || 
                ((e.Key == Key.OemPlus || e.Key == Key.OemMinus) && (TextBox_dig.Text.IndexOf('+') >= 0 || TextBox_dig.Text.IndexOf('-') >= 0 || TextBox_dig.CaretIndex != 0)))
                e.Handled = true;
        }
        /// <summary>
        /// Нажатие на кнопку "С"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox_dig.Text.IndexOf("NaN") >=0)
            {
                button_0.IsEnabled = true;
                button_1.IsEnabled = true;
                button_2.IsEnabled = true;
                button_3.IsEnabled = true;
                button_4.IsEnabled = true;
                button_5.IsEnabled = true;
                button_6.IsEnabled = true;
                button_7.IsEnabled = true;
                button_8.IsEnabled = true;
                button_9.IsEnabled = true;
                button_plus_minus.IsEnabled = true;
                button_coma.IsEnabled = true;
                button_add.IsEnabled = true;
                button_sub.IsEnabled = true;
                button_mul.IsEnabled = true;
                button_div.IsEnabled = true;
                button_back.IsEnabled = true;
                button_sqrt.IsEnabled = true;
                button_fact.IsEnabled = true;
                button_cos.IsEnabled = true;
            }
            a = 0;
            TextBox_dig.Clear();
            Label_operand.Content = "";
        }
        /// <summary>
        /// Нажатие на кнопку "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "NaN")
                return;
            if (TextBox_dig.Text.IndexOf("E") == -1)
            {
                int lenght = TextBox_dig.Text.Length - 1;
                string text = TextBox_dig.Text;
                TextBox_dig.Clear();
                for (int i = 0; i < lenght; i++)
                {
                    TextBox_dig.Text = TextBox_dig.Text + text[i];
                }
            }
        }
        /// <summary>
        /// Нажатие на кнопку "7"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 7;
        }
        /// <summary>
        /// Нажатие на кнопку "8"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 8;
        }
        /// <summary>
        /// Нажатие на кнопку "9"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 9;
        }
        /// <summary>
        /// Нажатие на кнопку "4"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 4;
        }
        /// <summary>
        /// Нажатие на кнопку "5"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 5;
        }
        /// <summary>
        /// Нажатие на кнопку "6"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 6;
        }
        /// <summary>
        /// Нажатие на кнопку "1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 1;
        }
        /// <summary>
        /// Нажатие на кнопку "2"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 2;
        }
        /// <summary>
        /// Нажатие на кнопку "3"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 3;
        }
        /// <summary>
        /// Нажатие на кнопку "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            TextBox_dig.Text += 0;
        }
        /// <summary>
        /// Нажатие на кнопку "Точка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_coma_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBox_dig.Text.IndexOf('.') > 0 || (TextBox_dig.Text == "+" || TextBox_dig.Text == "-")) ||
                TextBox_dig.Text == "" || TextBox_dig.Text == "NaN")
                return;
            else
                TextBox_dig.Text = TextBox_dig.Text + ".";
        }
        /// <summary>
        /// Нажатие на кнопку "Плюс-Минус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_plus_minus_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "" || TextBox_dig.Text == "NaN")
                return;
            if (TextBox_dig.Text[0] == '-')
                TextBox_dig.Text = TextBox_dig.Text.Remove(0, 1);
            else
                TextBox_dig.Text = "-" + TextBox_dig.Text;
        }
        /// <summary>
        /// Нажатие на кнопку "Поделить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "" || TextBox_dig.Text == "NaN" || TextBox_dig.Text == "-" || TextBox_dig.Text == "+")
                return;
            text_coma = TextBox_dig.Text.Replace(".", ",");
            if (Convert.ToDouble(text_coma) != 0)
            {
                if (a != 0)
                    button_result_Click(sender, e);
                a = double.Parse(text_coma);
                TextBox_dig.Clear();
                count = 4;
                Label_operand.Content = a.ToString().Replace(",", ".") + " /";
            }
            TextBox_dig.Focus();
        }
        /// <summary>
        /// Нажатие на кнопку "="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_result_Click(object sender, RoutedEventArgs e)
        {
            text_coma = TextBox_dig.Text.Replace(".", ",");
            switch (count)
            {
                case 1:
                    if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-")
                    {
                        TextBox_dig.Text = Convert.ToInt64(operations.add(a, double.Parse(text_coma))).ToString("G6").Replace(",", ".");
                        Label_operand.Content = "Результат:";
                    }
                    else Label_operand.Content = "Введите второе число!";
                    break;
                case 2:
                    if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-")
                    {
                        TextBox_dig.Text = Convert.ToInt64(operations.sub(a, double.Parse(text_coma))).ToString("G6").Replace(",", ".");
                        Label_operand.Content = "Результат:";
                    }
                    else Label_operand.Content = "Введите второе число!";
                    break;
                case 3:
                    if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-")
                    {
                        TextBox_dig.Text = Convert.ToInt64(operations.mul(a, double.Parse(text_coma))).ToString("G6").Replace(",", ".");
                        Label_operand.Content = "Результат:";
                    }
                    else Label_operand.Content = "Введите второе число!";
                    break;
                case 4:
                    if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-")
                    {
                        if (Convert.ToDouble(text_coma) == 0)
                        {
                            TextBox_dig.Text = "NaN";
                            Label_operand.Content = "Деление на ноль невозможно!";
                            button_0.IsEnabled = false;
                            button_1.IsEnabled = false;
                            button_2.IsEnabled = false;
                            button_3.IsEnabled = false;
                            button_4.IsEnabled = false;
                            button_5.IsEnabled = false;
                            button_6.IsEnabled = false;
                            button_7.IsEnabled = false;
                            button_8.IsEnabled = false;
                            button_9.IsEnabled = false;
                            button_plus_minus.IsEnabled = false;
                            button_coma.IsEnabled = false;
                            button_add.IsEnabled = false;
                            button_sub.IsEnabled = false;
                            button_mul.IsEnabled = false;
                            button_div.IsEnabled = false;
                            button_back.IsEnabled = false;
                            button_sqrt.IsEnabled = false;
                            button_fact.IsEnabled = false;
                            button_cos.IsEnabled = false;
                        }
                        else
                        {
                            TextBox_dig.Text = Convert.ToInt64(operations.div(a, double.Parse(text_coma))).ToString("G6").Replace(",", ".");
                            Label_operand.Content = "Результат:";
                        }
                    }
                    else Label_operand.Content = "Введите второе число!";
                    break;
                default:
                    break;
            }
            a = 0;
        }
        /// <summary>
        /// Нажатие на кнопку "Умножить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_mul_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-" && TextBox_dig.Text != "+")
            {
                if (a != 0)
                    button_result_Click(sender, e);
                text_coma = TextBox_dig.Text.Replace(".", ",");
                a = double.Parse(text_coma);
                TextBox_dig.Clear();
                count = 3;
                Label_operand.Content = a.ToString().Replace(",", ".") + " *";
            }
            TextBox_dig.Focus();
        }
        /// <summary>
        /// Нажатие на кнопку "Отнять"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-" && TextBox_dig.Text != "+")
            {
                if (a != 0)
                    button_result_Click(sender, e);
                text_coma = TextBox_dig.Text.Replace(".", ",");
                a = double.Parse(text_coma);
                TextBox_dig.Clear();
                count = 2;
                Label_operand.Content = a.ToString().Replace(",", ".") + " -";
            }
            TextBox_dig.Focus();
        }
        /// <summary>
        /// Нажатие на кнопку "Прибавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text != "" && TextBox_dig.Text != "NaN" && TextBox_dig.Text != "-" && TextBox_dig.Text != "+")
            {
                if (a != 0)
                    button_result_Click(sender, e);
                text_coma = TextBox_dig.Text.Replace(".", ",");
                a = double.Parse(text_coma);
                TextBox_dig.Clear();
                count = 1;
                Label_operand.Content = a.ToString().Replace(",", ".") + " +";
            }
            TextBox_dig.Focus();
        }
        /// <summary>
        /// Нажатие на кнопку "Квадратный корень"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "" || TextBox_dig.Text == "NaN" || TextBox_dig.Text == "-" || TextBox_dig.Text == "+")
                return;
            text_coma = TextBox_dig.Text.Replace(".", ",");
            b = Convert.ToInt64(operations.sqr(double.Parse(text_coma)));
            if (b == -1)
            {
                TextBox_dig.Text = "NaN";
                button_0.IsEnabled = false;
                button_1.IsEnabled = false;
                button_2.IsEnabled = false;
                button_3.IsEnabled = false;
                button_4.IsEnabled = false;
                button_5.IsEnabled = false;
                button_6.IsEnabled = false;
                button_7.IsEnabled = false;
                button_8.IsEnabled = false;
                button_9.IsEnabled = false;
                button_plus_minus.IsEnabled = false;
                button_coma.IsEnabled = false;
                button_add.IsEnabled = false;
                button_sub.IsEnabled = false;
                button_mul.IsEnabled = false;
                button_div.IsEnabled = false;
                button_back.IsEnabled = false;
                button_sqrt.IsEnabled = false;
                button_fact.IsEnabled = false;
                button_cos.IsEnabled = false;
                Label_operand.Content = "Корень от отрицательного числа неопределён!";
            }
            else
            {
                TextBox_dig.Text = b.ToString("G6").Replace(",", ".");
                Label_operand.Content = "Результат:";
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Косинус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cos_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "" || TextBox_dig.Text == "NaN" || TextBox_dig.Text == "-" || TextBox_dig.Text == "+")
                return;
            text_coma = TextBox_dig.Text.Replace(".", ",");
            TextBox_dig.Text = Convert.ToInt64(operations.cos(double.Parse(text_coma))).ToString("G6").Replace(",", ".");
            Label_operand.Content = "Результат:";
        }
        /// <summary>
        /// Нажатие на кнопку "Факториал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_fact_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_dig.Text == "" || TextBox_dig.Text == "NaN" || TextBox_dig.Text == "-" || TextBox_dig.Text == "+")
                return;
            text_coma = TextBox_dig.Text.Replace(".", ",");
            long x = Convert.ToInt64(operations.factorial(double.Parse(text_coma)));
            if (x == -1)
            {
                TextBox_dig.Text = "NaN";
                button_0.IsEnabled = false;
                button_1.IsEnabled = false;
                button_2.IsEnabled = false;
                button_3.IsEnabled = false;
                button_4.IsEnabled = false;
                button_5.IsEnabled = false;
                button_6.IsEnabled = false;
                button_7.IsEnabled = false;
                button_8.IsEnabled = false;
                button_9.IsEnabled = false;
                button_plus_minus.IsEnabled = false;
                button_coma.IsEnabled = false;
                button_add.IsEnabled = false;
                button_sub.IsEnabled = false;
                button_mul.IsEnabled = false;
                button_div.IsEnabled = false;
                button_back.IsEnabled = false;
                button_sqrt.IsEnabled = false;
                button_fact.IsEnabled = false;
                button_cos.IsEnabled = false;
                Label_operand.Content = "Факториал от отрицательного числа неопределён!";
            }
            else
            {
                TextBox_dig.Text = x.ToString("G6").Replace(",", ".");
                Label_operand.Content = "Результат:";
            }
        }
        /// <summary>
        /// Изменение в поле ввода текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_dig_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s1 = TextBox_dig.Text.Replace('.',',');
            int index = TextBox_dig.CaretIndex;
            try
            {
                if (Convert.ToDouble(s1) > 500000 || Convert.ToDouble(s1) < -300000 || 
                    (TextBox_dig.Text.IndexOf(".") > 0 && TextBox_dig.Text.Length - TextBox_dig.Text.IndexOf(".") > 3))
                {
                    string s = "", text = TextBox_dig.Text;
                    for (int i = 0; i < TextBox_dig.Text.Length - 1; i++)
                    {
                        s += text[i];
                        s1 = s;
                    }
                    TextBox_dig.Text = s1.Replace(',','.');
                }
            }
            catch(Exception)
            {}
            TextBox_dig.CaretIndex = index;            
        }
    }
    /// <summary>
    /// Класс с операциями
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Операция Плюс
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double add(double a, double b)
        {
            return a + b;
        }
        /// <summary>
        /// Операция Минус
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double sub(double a, double b)
        {
            return a - b;
        }
        /// <summary>
        /// Операция Умножить
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double mul(double a, double b)
        {
            return a * b;
        }
        /// <summary>
        /// Операция Поделить
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double div(double a, double b)
        {
            return a / b;
        }
        /// <summary>
        /// Операция Квадратный корень
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double sqr(double a)
        {
            if (a < 0)
                return -1;
            return Math.Sqrt(a);
        }
        /// <summary>
        /// Операция Факториал
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double factorial(double a)
        {
            if (a < 0)
                return -1;
            int factorial = 1;   // значение факториала
            for (int i = 2; i <= a; i++) // цикл начинаем с 2, т.к. нет смысла начинать с 1
            {
                factorial = factorial * i;
            }
            return factorial;
        }
        /// <summary>
        /// Операция Косинус
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double cos(double a)
        {
            return Math.Cos(a);
        }
    }
}
