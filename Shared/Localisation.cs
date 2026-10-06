using System.ComponentModel.Design.Serialization;

namespace Shared
{
    public enum InterfaceElements{
        Yes,
        No,
        ConfirmTitle,
        ExitQuestion,
        JsonSerializeError,
        EmptyFile,
        LargeFile,
        ErrorText,
        CloseText,
        KeyNotFound,
        KeyFound,
        UserDataText,
        ExitPageTitle,
        ImportedLessonsPageTitle,
        MyLessonsPageTitle,
        LearnLessonPageTitle,
        SettingsPageTitle,
        StartPageTitle,
        RegistrationPageTitle,
        NeedEnterNickname,
        NeedSelectLanguage,
        CanChooseAvatar,
        UseSchedule,
        Next,
        ExampleText,
        AppendLanguage,
    }
    public class Localisation
    {
        public const string DefaultCode = "en-US";
        public readonly static Dictionary<InterfaceElements, string> DefaultText = new()
        {
            { InterfaceElements.Yes, "Yes" },
            { InterfaceElements.No, "No" },
            { InterfaceElements.ConfirmTitle, "Confirm action" },
            { InterfaceElements.ExitQuestion, "Are you sure you want to exit?" },
            { InterfaceElements.JsonSerializeError, "Failed to get data from JSON" },
            { InterfaceElements.EmptyFile, "File is empty" },
            { InterfaceElements.LargeFile, "File is too large" },
            { InterfaceElements.ErrorText, "Error" },
            { InterfaceElements.CloseText, "Close" },
            { InterfaceElements.KeyNotFound, "Not found" },
            { InterfaceElements.KeyFound, "Already exists" },
            { InterfaceElements.UserDataText, "User profile data" },
            //Заголовки страниц
            { InterfaceElements.ExitPageTitle, "Exit" },
            { InterfaceElements.ImportedLessonsPageTitle, "Imported lessons" },
            { InterfaceElements.MyLessonsPageTitle, "My lessons" },
            { InterfaceElements.LearnLessonPageTitle, "To study a lesson" },
            { InterfaceElements.SettingsPageTitle, "Settings" },
            { InterfaceElements.StartPageTitle, "Start page" },
            //Форма регистрации
            { InterfaceElements.RegistrationPageTitle, "Registration" },
            { InterfaceElements.NeedEnterNickname, "You need to enter a pseudonym." },
            { InterfaceElements.NeedSelectLanguage, "You need to choose a interface language or upload your own." },
            { InterfaceElements.CanChooseAvatar, "You can choose an avatar." },
            { InterfaceElements.UseSchedule, "Do you want to use the notification schedule?" },
            { InterfaceElements.Next, "Next" },
            { InterfaceElements.ExampleText, "Selected english language" },
            { InterfaceElements.AppendLanguage, "Add custom language" },
        }; 

        public static Dictionary<InterfaceElements, string> Text { get; set; } = []; 

        public static string GetValue(InterfaceElements key)
        {
            if(Text.TryGetValue(key, out var result))
            {
                return result;
            }
            else
            {
                return DefaultText[key];
            }
        }
    }
}