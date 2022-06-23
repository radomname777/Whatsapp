using Bogus;
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

namespace Whatsapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isok { get; set; } = true;
        public List<Human> People { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            People = new Faker<Human>()
                .RuleFor(h => h.Nickname, f => f.Person.FirstName)
                .RuleFor(h=> h.ImageUrl,f=>f.Person.Avatar)
                .Generate(1);
        }
        private Label Label()
        {
            Label lbl = new Label();
            lbl.FontSize = 18;
            lbl.Content = TXTBOX.Text;
            lbl.Foreground = new SolidColorBrush(Colors.White);
            return lbl;
        }
        private void AddMessage()
        {
            int num = 10;
            if (isok)
            {
                Label lv = new Label();
                num = 0;
                Border BB = new Border();
                isok = false;
                lv.FontSize = 16;
                lv.Content = DateTime.Now;
                lv.Foreground = new SolidColorBrush(Colors.White);
                BB.Child = lv;
                BB.Background = new SolidColorBrush(Color.FromRgb(16, 17, 27));
                BB.HorizontalAlignment = HorizontalAlignment.Center;
                BB.Child = lv;
                BB.CornerRadius = new CornerRadius(10, 10, 10, 10);
                MSGR.Children.Add(BB);
            }
            Border B = new Border();
            B.CornerRadius = new CornerRadius(12,0,20,12);
            B.HorizontalAlignment = HorizontalAlignment.Right;
            B.Margin = new Thickness(num, num, 10, 0);
            B.Background = new SolidColorBrush(Color.FromRgb(37, 211, 102));
            B.Child = Label();
            MSGR.Children.Add(B);
            SV.ScrollToBottom();
            Fun();
            
            
            
        }
        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            
            
        }
         private bool isokay = true;
        private void Fun2()
        {
            TXTBOX.Text = "";
            TXTBOX.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void TXTBOX_MouseEnter(object sender, MouseEventArgs e) { Fun2(); }
        private void Fun()
        {
                TXTBOX.Text = "Type a message";
                TXTBOX.Foreground = new SolidColorBrush(Color.FromRgb(197, 197, 197));
                isokay = true;
        }
        private void TXTBOX_MouseLeave(object sender, MouseEventArgs e){ Fun(); }
        private void TXTBOX_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (isokay) { TXTBOX.Text = ""; isokay = false; }
            else if (e.Key == Key.Enter && TXTBOX.Text.Length > 0) AddMessage();
           
        }
    }
}
