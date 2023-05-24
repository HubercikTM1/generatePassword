using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace generujHaslo
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        public static string GetRandomPassword(int length, string chars)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            MessageBox.Show("lower " + sb.ToString());
            return sb.ToString();
        }


        static string ChangeRandomLetterUpper(string input)
            {
                Random random = new Random();
                int index = random.Next(0, input.Length/3);

                char selectedChar = input[index];

                if (Char.IsLetter(selectedChar))
                {
                    char newChar = Char.ToUpper(selectedChar);

                    input = input.Remove(index, 1).Insert(index, newChar.ToString());
                }
                MessageBox.Show("upper " + input);
                return input;
            }

        static string ChangeRandomLetterNumber(string input)
            {
                Random random = new Random();
                int index = random.Next(input.Length/3+1, input.Length/3+input.Length/3);

                char selectedChar = input[index];

                if (Char.IsLetter(selectedChar))
                {
                    int newChar = random.Next(0,9);

                    input = input.Remove(index, 1).Insert(index, newChar.ToString());
                }
                MessageBox.Show("numbers " + input);
                return input;
            }

        static string ChangeRandomLetterSymbol(string input)
            {
                Random random = new Random();
                int index = random.Next(input.Length/3+input.Length/3+1, input.Length);

                char selectedChar = input[index];
                string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
                char[] specialArray = SpecialCharacters.ToCharArray();

                if (Char.IsLetter(selectedChar))
                {
                    char newChar = specialArray[index];

                    input = input.Remove(index, 1).Insert(index, newChar.ToString());
                }
                MessageBox.Show("chars  " + input);
                return input;
            }

        string newPass = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
            
        {
            bool Big = bigC.IsChecked == true;
            bool Nums = nums.IsChecked == true;
            bool SpecialDigits = specialDigits.IsChecked == true;
            int passLength = Int32.Parse(ileZnakow.Text);
            
            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            

            if (Big==false && Nums==false && SpecialDigits == false) {
                newPass = GetRandomPassword(passLength ,SmallLetters);
                MessageBox.Show(newPass);
            }
            else if (Big==true && Nums==false && SpecialDigits==false) {
                newPass = ChangeRandomLetterUpper(GetRandomPassword(passLength ,SmallLetters));
                MessageBox.Show(newPass);
            }
            else if (Big == true && Nums == true && SpecialDigits == false) {
                newPass = ChangeRandomLetterNumber(ChangeRandomLetterUpper(GetRandomPassword(passLength ,SmallLetters)));
                MessageBox.Show(newPass);
            }
            else if (Big == true && Nums == false && SpecialDigits == true) {
                newPass = ChangeRandomLetterSymbol(ChangeRandomLetterUpper(GetRandomPassword(passLength ,SmallLetters)));
                MessageBox.Show(newPass);
            }
            else if (Big == false && Nums == true && SpecialDigits == true) {
                newPass = ChangeRandomLetterSymbol(ChangeRandomLetterNumber(GetRandomPassword(passLength ,SmallLetters)));
                MessageBox.Show(newPass);
            }
            else if (Big == true && Nums == true && SpecialDigits == true) {
                newPass = ChangeRandomLetterSymbol(ChangeRandomLetterNumber(ChangeRandomLetterUpper(GetRandomPassword(passLength ,SmallLetters))));
                MessageBox.Show(newPass);
            }
            else if (Big == false && Nums == true && SpecialDigits == false)
            {
                newPass = ChangeRandomLetterNumber(GetRandomPassword(passLength ,SmallLetters));
                MessageBox.Show(newPass);
            }
            else if (Big == false && Nums == false && SpecialDigits == true)
            {
                newPass = ChangeRandomLetterSymbol(GetRandomPassword(passLength ,SmallLetters));
                MessageBox.Show(newPass);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imie = imieInput.Text;
            string nazwisko = nazwiskoInput.Text;
            string stanowisko = stanowiskoInput.Text;


            MessageBox.Show(imie + " " + nazwisko + " " + stanowisko + " Hasło: " + newPass);
        }

    
    }
}
