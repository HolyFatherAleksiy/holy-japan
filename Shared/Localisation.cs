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
    }
    public class Localisation
    {
        public readonly static Dictionary<InterfaceElements, string> DefaultText = new()
        {
            [InterfaceElements.Yes] = "Yes", //Да
            [InterfaceElements.No] = "No", //Нет
            [InterfaceElements.ConfirmTitle] = "Confirm the action", // Подтвердите действие
            [InterfaceElements.ExitQuestion] = "Do you really want to leave", // Вы действительно хотите выйти?
            [InterfaceElements.JsonSerializeError] = "Failed to retrieve data from JSON.", // Не удалось получить данные из JSON
            [InterfaceElements.EmptyFile] = "File is empty", // Файл пустой 
            [InterfaceElements.LargeFile] = "File is large", // Файл слишком большой
            [InterfaceElements.ErrorText] = "Error", // Ошибка
            [InterfaceElements.CloseText] = "Close", // Закрыть
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