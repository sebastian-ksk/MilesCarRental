namespace MilesCarRental.API.Utils
{
    public static class EnvironmentConfig
    {
        public static string GetEnvironmentVariable(string variableName)
        {
   
            string value = Environment.GetEnvironmentVariable(variableName);
            if (value == null)
            {
                throw new ArgumentException($"The '{variableName}' is not defined! .");
            }

            return value;
        }
    }
}
