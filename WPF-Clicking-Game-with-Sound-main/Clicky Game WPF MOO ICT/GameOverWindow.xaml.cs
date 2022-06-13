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
using Clicky_Game_WPF_MOO_ICT.Entities;

namespace Clicky_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        private readonly ClickyGameDbContext _dbContext;
        private int score;

        public GameOverWindow(ClickyGameDbContext dbContext, int score)
        {
            InitializeComponent();
            _dbContext = dbContext;
            ScoreTextBlock.Text = score.ToString();
            this.score = score;
            var scoresList = new List<Score>();
            scoresList = dbContext.Scores.ToList();
            HighscoresListView.ItemsSource = scoresList.OrderByDescending(s => s.Points);
        }

        private void GameOverButton_OnClick(object sender, RoutedEventArgs e)
        {
            _dbContext.Add(new Score() {Nickname = NicknameTextBox.Text, Points = score});
            _dbContext.SaveChanges();
            Close();
        }
    }
}
