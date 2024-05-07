using ABI.Microsoft.UI.Xaml.Media;

namespace MAUIdumbArray
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnArrayCreateClick(object sender, EventArgs e)
        {
            //обработчик кнопки создания массива

            ArrayModel.RowCount = (uint)RowsStep.Value;
            ArrayModel.ColCount = (uint)ColsStep.Value;
            ArrayModel.Matrix = new double[ArrayModel.RowCount, ArrayModel.ColCount];
            OnArrayShowClick(sender, e);
        }
        public void OnArrayShowClick(object sender, EventArgs e)
        {
            //обработчик кнопки отображения массива

            //на всякий случай удалим всё, что показывается сейчас
            ArrayGrid.RowDefinitions.Clear();
            ArrayGrid.ColumnDefinitions.Clear();
            ArrayGrid.Children.Clear();

            //создаём набор строк и столбцов
            for (int i = 0; i < ArrayModel.RowCount; i++)
                ArrayGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            for (int j = 0; j < ArrayModel.ColCount; j++)
                ArrayGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));

            //выводим все ячейки матрицы
            for (int i = 0; i < ArrayModel.RowCount; i++)
                for (int j = 0; j < ArrayModel.ColCount; j++)
                {
                    Entry entry = new Entry();
                    entry.Text = ArrayModel.Matrix[i, j].ToString();
                    ArrayGrid.Add(entry, j, i);
                }
        }
        public void OnArrayInputClick(object sender, EventArgs e)
        {
            //обработчик кнопки переноса введённых пользователем данных в массив
            
            //Grid не поддерживает получение ячейки по координатам, поэтому перебираем все ячейки подряд
            foreach(Entry cell in ArrayGrid.Children)
            {
                double cellValue;
                if(!double.TryParse(cell.Text, out cellValue)) cellValue = 0;
                //и получаем методами GetRow и GetColumn номер строки и столбца, где они находятся
                ArrayModel.Matrix[ArrayGrid.GetRow(cell), ArrayGrid.GetColumn(cell)] = cellValue;
            }
            OnArrayShowClick(sender, e);
        }
        public void OnArrayRandomClick(object sender, EventArgs e)
        {
            //обработчик кнопки заполнения массива случайными числами

            Random rnd = new Random();
            for (int i = 0; i < ArrayModel.RowCount; i++)
                for (int j = 0; j < ArrayModel.ColCount; j++)
                    ArrayModel.Matrix[i, j] = rnd.Next(1, 1001); //от 1 до 1000
            OnArrayShowClick(sender, e);
        }
    }

}
