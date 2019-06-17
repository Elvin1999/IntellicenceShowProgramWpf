using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace IntellicenceProgramInWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataViewModel dataViewModel;
        public MainWindow()
        {
            InitializeComponent();
            dataViewModel = new DataViewModel();

            //var words = File.ReadAllText(@"\\STHQ01DC01\dfr$\Jama_yw17\Desktop\Word\words.txt").Split('\n');
            //int i = 0;
            //foreach (var item in words)
            //{
            //    Data data = new Data();
            //    data.Text = item;
            //    data.No = ++i;
            //    dataViewModel.AllDatas.Add(data);
            //}
            Helper helper = new Helper();
            if (!File.Exists("words.json"))
            {
                helper.Datas = new List<Data>();

                helper.SeriailizeEndatasToJson();
            }
            else
            {
                helper.Datas = helper.DeserializeEnDatasFromJson();
            }

            dataViewModel.AllDatas = new ObservableCollection<Data>(helper.Datas);
            DataCopies = helper.Datas;
            DataContext = dataViewModel;

        }
        public string word;
        public List<Data> DataCopies { get; set; }
        public void SearchWord(object word1)
        {
            try
            {

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    var items = DataCopies.Where(x => x.Text.Contains(word)).ToList();
                    dataViewModel.AllDatas = new ObservableCollection<Data>(items);
                
                });
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            word = Search.Text;
            ThreadPool.QueueUserWorkItem(new WaitCallback(SearchWord));
          
        }
      
     
        
    }
}
