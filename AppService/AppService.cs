using AppData;
using Newtonsoft.Json;

namespace AppService
{
    public class AppService : IDataReaderElevadorService
    {
        private readonly string _JsonFilePath;

        public AppService(string jsonFilePath)
        {
            _JsonFilePath = jsonFilePath;
        }
        public IEnumerable<HistoricoUsoElevador?> ReadData()
        {
            try
            {
                using StreamReader streamReader = new StreamReader(_JsonFilePath);
                var json = streamReader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<HistoricoUsoElevador>>(json);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
