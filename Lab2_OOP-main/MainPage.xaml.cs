using System.Xml.Linq;

namespace DormitoryApp;

public partial class MainPage : ContentPage
{
    // Словник для зберігання наших стратегій
    private readonly Dictionary<string, IResidentSearchStrategy> _searchStrategies;
    private readonly HtmlGenerator _htmlGenerator;

    private string _xmlFilePath;
    private string _xslFilePath;
    private List<Resident> _lastSearchResults;

    public MainPage()
    {
        InitializeComponent();

        // Ініціалізуємо наші стратегії
        _searchStrategies = new Dictionary<string, IResidentSearchStrategy>
        {
            { "DOM", new DomSearchStrategy() },
            { "SAX", new SaxSearchStrategy() },
            { "LINQ to XML", new LinqSearchStrategy() }
        };
        _htmlGenerator = new HtmlGenerator();
        _lastSearchResults = new List<Resident>();
    }

    private async void OnLoadXmlClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Оберіть XML-файл гуртожитку",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".xml" } },
                    { DevicePlatform.macOS, new[] { "xml" } },
                })
            });

            if (result != null)
            {
                _xmlFilePath = result.FullPath;
                LblXmlFile.Text = result.FileName;

                // Ми завантажуємо XML і заповнюємо Picker факультетів
                LoadFacultiesFromXml(_xmlFilePath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Помилка", $"Не вдалося завантажити XML: {ex.Message}", "OK");
        }
    }

    private void LoadFacultiesFromXml(string xmlPath)
    {
        try
        {
            // Найшвидше це зробити через LINQ to XML
            var doc = XDocument.Load(xmlPath);
            var faculties = doc.Descendants("Resident")
                               .Attributes("Faculty")
                               .Select(attr => attr.Value)
                               .Distinct()
                               .OrderBy(f => f)
                               .ToList();

            // "Всі" - це опція за замовчуванням
            faculties.Insert(0, "Всі");
            PickerFaculty.ItemsSource = faculties;
            PickerFaculty.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            DisplayAlert("Помилка парсингу", $"Не вдалося зчитати факультети з XML: {ex.Message}", "OK");
        }
    }

    private async void OnLoadXslClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Оберіть XSLT-файл для звіту",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".xsl" } },
                    { DevicePlatform.macOS, new[] { "xsl" } },
                })
            });

            if (result != null)
            {
                _xslFilePath = result.FullPath;
                LblXslFile.Text = result.FileName;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Помилка", $"Не вдалося завантажити XSL: {ex.Message}", "OK");
        }
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_xmlFilePath))
        {
            DisplayAlert("Помилка", "Будь ласка, спочатку оберіть XML-файл.", "OK");
            return;
        }

        // 1. Збираємо критерії пошуку з UI
        var criteria = new SearchCriteria
        {
            Name = EntryName.Text,
            Faculty = PickerFaculty.SelectedItem as string,
            Department = EntryDepartment.Text,
            Course = int.TryParse(EntryCourse.Text, out int course) ? course : null,
            Room = EntryRoom.Text
        };

        try
        {
            // 2. Обираємо СТРАТЕГІЮ на основі вибору в Picker
            string selectedStrategyName = PickerStrategy.SelectedItem as string;
            IResidentSearchStrategy selectedStrategy = _searchStrategies[selectedStrategyName];

            // 3. Виконуємо пошук
            _lastSearchResults = selectedStrategy.Search(_xmlFilePath, criteria);

            // 4. Відображаємо результати
            ResultsView.ItemsSource = _lastSearchResults;
            if (_lastSearchResults.Count == 0)
            {
                DisplayAlert("Пошук завершено", "Мешканців за вашими критеріями не знайдено.", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Помилка пошуку", $"Під час пошуку сталася помилка: {ex.Message}", "OK");
        }
    }

    private async void OnGenerateHtmlClicked(object sender, EventArgs e)
    {
        if (_lastSearchResults.Count == 0)
        {
            await DisplayAlert("Помилка", "Немає результатів для генерації звіту. Спочатку виконайте пошук.", "OK");
            return;
        }
        if (string.IsNullOrEmpty(_xslFilePath))
        {
            await DisplayAlert("Помилка", "Будь ласка, спочатку оберіть XSL-файл.", "OK");
            return;
        }

        try
        {
            // Отримуємо шлях до Робочого столу
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Поєднуємо його з назвою нашого файлу
            string outputPath = Path.Combine(desktopPath, "DormitoryReport.html");

            // Використовуємо наш HtmlGenerator
            _htmlGenerator.GenerateHtml(_lastSearchResults, _xslFilePath, outputPath);

            await DisplayAlert("Успіх", $"HTML-звіт успішно згенеровано!\nФайл збережено тут: {outputPath}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Помилка генерації", $"Під час створення HTML сталася помилка: {ex.Message}", "OK");
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        EntryName.Text = string.Empty;
        EntryDepartment.Text = string.Empty;
        EntryCourse.Text = string.Empty;
        EntryRoom.Text = string.Empty;
        PickerFaculty.SelectedIndex = 0;
        PickerStrategy.SelectedIndex = 0;

        _lastSearchResults.Clear();
        ResultsView.ItemsSource = null; // Очищуємо список результатів

        DisplayAlert("Очищено", "Параметри пошуку та результати скинуто.", "OK");
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Підтвердження",
            "Чи дійсно ви хочете завершити роботу з програмою?",
            "Так", "Ні");

        if (answer)
        {
            Application.Current.Quit();
        }
    }
}