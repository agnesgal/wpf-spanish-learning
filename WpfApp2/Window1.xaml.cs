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

        public Window1()
        {
            InitializeComponent();
            dbDataHandler = new DbDataHandler(new WordDbContexts());
            WordBox1.IsReadOnly = true;
            word = dbDataHandler.SearchHungarianWord();
            WordBox1.AppendText(word.HungarianWord);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WordBox1.Clear();
            WordBox1.AppendText(dbDataHandler.SearchHungarianWord().HungarianWord);
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if(WordBox2.Text == word.SpanishWord)
                {
                    WordBox1.Clear();
                    WordBox2.Clear();
                    word = dbDataHandler.SearchHungarianWord();
                    WordBox1.AppendText(word.HungarianWord);
                }
                else
                {
                    Foreground = Brushes.Red;

                    WordBox2.Text = word.SpanishWord;
                }

            }
        }

    }
}
