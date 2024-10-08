﻿
using Newtonsoft.Json;

namespace AppData
{
    public class JsonDataRader : IDataReaderElevadorService
    {
        private readonly string _JsonFilePath;

        public JsonDataRader(string jsonFilePath)
        {
            _JsonFilePath = jsonFilePath;
        }
        public IEnumerable<HistoricoUsoElevador?> ReadData()
        {
            using StreamReader streamReader = new StreamReader(_JsonFilePath);
            var json = streamReader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<List<HistoricoUsoElevador>>(json);
            return result;

        }
    }
}
