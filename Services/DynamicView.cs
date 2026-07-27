namespace INFASS.Services
{
    public class DynamicView
    {
        public static string FormatViewData<T>(T model)
        {
            if (model == null)
            {
                return "No data received.";
            }

            Type type = typeof(T);
            string tableName = type.Name;

            return "SELECT * FROM " + tableName + ";";
        }
    }
}
