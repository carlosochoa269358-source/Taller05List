namespace Taller6_ArchivosPlanos
{
    public class LogService
    {
        private readonly string _logPath = "Log.txt";

        public void Write(string user, string operation)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{user},{operation}";
            File.AppendAllText(_logPath, entry + Environment.NewLine);
        }
    }
}