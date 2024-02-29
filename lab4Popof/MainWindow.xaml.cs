using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4Popof
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Worker[]? Monsters { get; set; } = null;
        private bool isYearSort = true;
        private bool isPositionSort = true;
        public MainWindow()
        {
            InitializeComponent();
            mmCopy.IsEnabled = false;
            mmCreate.IsEnabled = false;
            tbCreate.IsEnabled = false;
            tbCopy.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbCount.Text.Length != 0)
            {
                Monsters = null;
                Monsters = new Worker[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + Monsters.Length + " элемента создан");
                Worker.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                workerList.ItemsSource = null;
                stCount.Content = "Создано " + Worker.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void mmCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }
        void GridViewColumnHeaderClickedHandler(object sender,
                                        RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked!.Content.ToString() == "Должность")
            {
                if (isPositionSort)
                {
                    Array.Sort(Monsters!);
                }
                else
                {
                    Monsters = Monsters!.OrderByDescending(p => p.Position).ToArray();
                }
                isPositionSort = !isPositionSort;
            }
            else if (headerClicked.Content.ToString() == "Патроны")
            {
                if (isYearSort)
                {
                    Array.Sort(Monsters!, new WorkerComparer());
                }
                else
                {
                    Monsters = Monsters!.OrderByDescending(p => p.YearOfEmployment).ToArray();
                }
                isYearSort = !isYearSort;
            }
            workerList.ItemsSource = null;
            workerList.ItemsSource = Monsters;
        }

        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Copy()
        {
            if (workerList.SelectedItems.Count != 0)
            {
                Worker? monster = workerList.SelectedItem as Worker;
                Monsters![Worker.Count] = (Worker)monster!.Clone();
                workerList.ItemsSource = null;
                workerList.ItemsSource = Monsters;
                Worker.Count++;
                stCount.Content = "Создано " + Worker.Count + " из " + tbCount.Text;
            }
        }
        private void Add()
        {
            if (Monsters!.Length > Worker.Count)
            {
                AddWorker add = new AddWorker();
                if (add.ShowDialog() == true)
                {
                    Monsters[Worker.Count] = new Worker();
                    Monsters[Worker.Count].Id = add.ID;
                    Monsters[Worker.Count].Name = add.Name;
                    Monsters[Worker.Count].Position = add.Position;
                    Monsters[Worker.Count].YearOfEmployment = add.YearOfEmployment;
                    Worker.Count++;
                }
                workerList.ItemsSource = null;
                workerList.ItemsSource = Monsters;
                stCount.Content = "Создано " + Worker.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }
}
