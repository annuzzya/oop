using DormitoryLab.Models;
using DormitoryLab.Services;
using System.Collections.ObjectModel;

namespace DormitoryLab
{
    public partial class MainPage : ContentPage
    {
        private Dorm _dorm;
        private readonly JsonFileManager _jsonManager;
        private readonly SearchService _searchService;
        private string _currentFilePath;

        // ObservableCollection автоматично оновлює інтерфейс при зміні списку
        public ObservableCollection<Resident> DisplayedResidents { get; set; }

        public MainPage()
        {
            InitializeComponent();

            _dorm = new Dorm();
            _jsonManager = new JsonFileManager();
            _searchService = new SearchService();
            DisplayedResidents = new ObservableCollection<Resident>();

            ResidentsCollection.ItemsSource = DisplayedResidents;
        }

        // 1. Відкриття файлу
        private async void OnOpenFileClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Оберіть JSON файл",
                    FileTypes = customFileType // Визначити тип файлу нижче
                });

                if (result != null)
                {
                    _currentFilePath = result.FullPath;
                    _dorm = _jsonManager.Load(_currentFilePath);
                    RefreshList();
                    await DisplayAlert("Успіх", "Дані успішно завантажено!", "ОК");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка", $"Не вдалося відкрити файл: {ex.Message}", "ОК");
            }
        }

        // 2. Збереження файлу
        private async void OnSaveFileClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                // У реальному MAUI для "Save As" потрібен специфічний код платформи,
                // для лабораторної збережемо у локальну папку програми, якщо шлях не вибрано
                string fileName = Path.Combine(FileSystem.AppDataDirectory, "dormitory.json");
                _jsonManager.Save(fileName, _dorm);
                await DisplayAlert("Збережено", $"Файл збережено: {fileName}", "ОК");
            }
            else
            {
                _jsonManager.Save(_currentFilePath, _dorm);
                await DisplayAlert("Збережено", "Зміни збережено у поточний файл.", "ОК");
            }
        }

        // 3. Додавання
        private async void OnAddClicked(object sender, EventArgs e)
        {
            var addPage = new AddEditPage();
            addPage.OnSave += (resident) =>
            {
                _dorm.AddResident(resident);
                RefreshList();
            };
            await Navigation.PushAsync(addPage);
        }

        // 4. Редагування
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var selected = ResidentsCollection.SelectedItem as Resident;
            if (selected == null)
            {
                await DisplayAlert("Увага", "Оберіть студента для редагування", "ОК");
                return;
            }

            var editPage = new AddEditPage(selected);
            editPage.OnSave += (updatedResident) =>
            {
                _dorm.EditResident(selected, updatedResident);
                RefreshList();
            };
            await Navigation.PushAsync(editPage);
        }

        // 5. Видалення
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var selected = ResidentsCollection.SelectedItem as Resident;
            if (selected == null) return;

            bool answer = await DisplayAlert("Підтвердження", $"Видалити {selected.LastName}?", "Так", "Ні");
            if (answer)
            {
                _dorm.RemoveResident(selected);
                RefreshList();
            }
        }

        // 6. Пошук (LINQ)
        private void OnSearchClicked(object sender, EventArgs e)
        {
            string query = SearchEntry.Text;
            if (string.IsNullOrWhiteSpace(query)) return;

            List<Resident> results = new List<Resident>();
            string criteria = SearchCriteriaPicker.SelectedItem.ToString();

            switch (criteria)
            {
                case "Прізвище":
                    results = _searchService.SearchBySurname(_dorm.Residents, query);
                    break;
                case "Кімната":
                    if (int.TryParse(query, out int room))
                        results = _searchService.SearchByRoom(_dorm.Residents, room);
                    break;
                case "Факультет":
                    results = _searchService.SearchByFaculty(_dorm.Residents, query);
                    break;
            }

            UpdateDisplay(results);
        }

        private void OnResetFilterClicked(object sender, EventArgs e)
        {
            SearchEntry.Text = "";
            RefreshList();
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private void RefreshList()
        {
            UpdateDisplay(_dorm.Residents);
        }

        private void UpdateDisplay(List<Resident> list)
        {
            DisplayedResidents.Clear();
            foreach (var item in list)
            {
                DisplayedResidents.Add(item);
            }
        }

        // Хелпер для типу файлів JSON (для FilePicker)
        FilePickerFileType customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".json" } },
                    { DevicePlatform.Android, new[] { "application/json" } },
                });
    }
}