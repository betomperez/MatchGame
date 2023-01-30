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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🐡", "🐡",
                "🐘", "🐘",
                "🐳", "🐳",
                "🐪", "🐪",
                "🐊", "🐊",
                "🦘", "🦘",
                "🦔", "🦔",
            };

            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            // Procura cada TextBlock na grade principal a repete os seguintes comandos para cada um deles
            {
                int index = random.Next(animalEmoji.Count); 
                // Pega um número aleatório entre 0 e o número de emojis sobrando nas lista e o chame de "index"
                string nextEmoji = animalEmoji[index]; 
                // Usa o número aleatório chamado "index" para escolher um emoji aleatório da lista
                textBlock.Text = nextEmoji; 
                // Atualiza o texto do TextBlock com o emoji aleatório da lista
                animalEmoji.RemoveAt(index);
                // Remove o emoji aleatório da lista
            }
        }
    }
}
