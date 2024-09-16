using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для Resaults.xaml
    /// </summary>
    public partial class ResaultsWindow : Window
    {
        List<User> userList = new List<User>();
        public string path = @"C:\Users\User\source\repos\WpfApp8\WpfApp8\users.json";
        public ResaultsWindow(int score)
        {
            InitializeComponent();
            userList = GetUsersFull(path);
            scoreValue.Content = score;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Бажаєте закрити гру?", "Попередження", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result==MessageBoxResult.Yes)
            {
                Close();
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }

        }

        private void userChange_Click(object sender, RoutedEventArgs e)
        {
            UserNameWindow newUser = new UserNameWindow();
            Close();
            newUser.ShowDialog();
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            Close();
            game.ShowDialog();
        }
        private List<User> GetUsersFull(string filePath)
        {
            List<User> users = new List<User>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    User user = new User(); // Створюємо новий екземпляр User для кожного рядка JSON
                    LoadFromJSON(line);
                    users.Add(user);
                }
                return users;
            }
            //else
            //{
            //    MessageBox.Show("Наразі немає даних для виведення!");
            //}

            return users;

        }
        public void LoadFromJSON(string line)
        {

            using (JsonDocument document = JsonDocument.Parse(line))
            {
                JsonElement root = document.RootElement;

                string userName = root.GetProperty("Name").GetString();
                int score = root.GetProperty("Score").GetInt32();
                User usser = new User(userName, score);
                
                UserList.Items.Add(usser);
            }


        }
    }
}
