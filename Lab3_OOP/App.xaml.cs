// Додай ці простори імен, якщо їх немає
#if WINDOWS
using Microsoft.UI.Windowing;
#endif

namespace DormitoryLab;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);


#if WINDOWS
        window.Created += (s, e) =>
        {
            // Отримуємо доступ до "рідного" вікна Windows
            var handle = WinRT.Interop.WindowNative.GetWindowHandle(window.Handler.PlatformView);
            var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);

            // Підписуємося на подію натискання "Хрестика"
            appWindow.Closing += async (sender, args) =>
            {
                // 1. Скасовуємо миттєве закриття (спочатку "Ні")
                args.Cancel = true;

                // 2. Запитуємо користувача
                bool result = await MainPage.DisplayAlert(
                    "Підтвердження", 
                    "Ви дійсно хочете закрити програму?", 
                    "Так", 
                    "Ні");

                // 3. Якщо користувач натиснув "Так" - закриваємо програму примусово
                if (result)
                {
                    Application.Current.Quit();
                }
            };
        };
#endif
        return window;
    }
}