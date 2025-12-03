using DormitoryLab.Models;
using DormitoryLab.Services;

namespace DormitoryLab
{
    public partial class AddEditPage : ContentPage
    {
        public Action<Resident> OnSave;
        private ValidationService _validator;

        public AddEditPage(Resident resident = null)
        {
            InitializeComponent();
            _validator = new ValidationService();

            if (resident != null)
            {
                EntryLastName.Text = resident.LastName;
                EntryFirstName.Text = resident.FirstName;
                EntryRoom.Text = resident.RoomNumber.ToString();
                EntryFaculty.Text = resident.Faculty;
                EntryCourse.Text = resident.Course.ToString();
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var resident = new Resident
            {
                LastName = EntryLastName.Text,
                FirstName = EntryFirstName.Text,
                Faculty = EntryFaculty.Text
            };

            int.TryParse(EntryRoom.Text, out int room);
            resident.RoomNumber = room;

            int.TryParse(EntryCourse.Text, out int course);
            resident.Course = course;

            if (_validator.ValidateResident(resident, out string error))
            {
                OnSave?.Invoke(resident); 
                await Navigation.PopAsync(); 
            }
            else
            {
                await DisplayAlert("Помилка валідації", error, "ОК");
            }
        }
    }
}