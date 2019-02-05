using DataAccess;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DbDataHandler dbDataHandler;
        Word word;
        Boolean IsHungarian = true;

        public Window1()
        {
            InitializeComponent();
            dbDataHandler = new DbDataHandler(new WordDbContexts());
            WordBox1.IsReadOnly = true;
            word = dbDataHandler.SearchWord();
            WordBox1.AppendText(word.HungarianWord);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if(IsHungarian)
                {
                    if (WordBox2.Text == word.SpanishWord)
                    {
                        BoxClearing();
                        WordBox2.Foreground = Brushes.Black;
                        word = dbDataHandler.SearchWord();
                        WordBox1.AppendText(word.HungarianWord);
                    }
                    else
                    {
                        WordBox2.Foreground = Brushes.Red;
                        WordBox2.Text = word.SpanishWord;
                    }
                }
                else
                {
                    if (WordBox2.Text == word.HungarianWord)
                    {
                        BoxClearing();
                        WordBox2.Foreground = Brushes.Black;
                        word = dbDataHandler.SearchWord();
                        WordBox1.AppendText(word.SpanishWord);
                    }
                    else
                    {
                        WordBox2.Foreground = Brushes.Red;
                        WordBox2.Text = word.HungarianWord;
                    }

                }

            }
        }

        private void SpanishFlag_Click(object sender, RoutedEventArgs e)
        {
            BoxClearing();
            IsHungarian = false;
            WordBox2.Foreground = Brushes.Black;
            word = dbDataHandler.SearchWord();
            WordBox1.AppendText(word.SpanishWord);
        }

        private void HungarianFlag_Click(object sender, RoutedEventArgs e)
        {
            BoxClearing();
            IsHungarian = true;
            WordBox2.Foreground = Brushes.Black;
            word = dbDataHandler.SearchWord();
            WordBox1.AppendText(word.HungarianWord);
        }

        private void BoxClearing()
        {
            WordBox1.Clear();
            WordBox2.Clear();
        }

    }
}
