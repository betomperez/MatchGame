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
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text +=" - Jogar denovo?";
            }
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
            // Procura cada TextBlock na grade principal e repete os seguintes comandos para cada uma delas
            {
                
                if(textBlock.Name != "timeTextBlock")
                // Ignora o último campo de texto TextBlock, uma vez que ele não receberá emoji
                {
                    textBlock.Visibility = Visibility.Visible;
                    // Configura o TextBlock como visível
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

            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        /* Se o clique for no primeiro animal,
         * mantenha a memória de qual TextBlock
         * foi clicado e faça o animal desaparecer.
         * Se o clique for no segundo, ou o faça
         * desaparecer (se for um par) ou faça
         * com que o primeiro reapareça ( caso não
         * seja um par).
         */
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }


        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
