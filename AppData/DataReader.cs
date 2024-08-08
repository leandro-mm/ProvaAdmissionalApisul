using Newtonsoft.Json;


namespace AppData
{
    internal class JsonReader : IDataReaderElevadorService
    {
        private readonly string _JsonFilePath;

        public JsonReader(string jsonFilePath)
        {
            _JsonFilePath=jsonFilePath; 
        }
        public IEnumerable<HistoricoUsoElevador?> Read()
        {
            using StreamReader streamReader = new StreamReader(_JsonFilePath);
            var json = streamReader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<List<HistoricoUsoElevador>>(json);
            return result;

        }
    }
}
