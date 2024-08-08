using AppData;
using System.Collections.Immutable;


namespace AppLogic
{
    internal interface IDadosService
    {
        public Task<int> VerificarFrequenciaUsoPorGrupo(IEnumerable<IGrouping<char, HistoricoUsoElevador>> grupo, bool byMaxValue);
        public List<int> BuscarItemPorFrequenciaUso(IEnumerable<IGrouping<int, HistoricoUsoElevador>> grupo, int frequencia);
        public List<char> BuscarItemPorFrequenciaUso(IEnumerable<IGrouping<char, HistoricoUsoElevador>> grupo, int frequencia);
        public List<char> ListStringToChar(IEnumerable<string> listString);
        public ImmutableDictionary<string, int> SelecionarPorValor(ImmutableDictionary<string, int> keyValuePairs, bool byMaxValue);
        public ImmutableDictionary<string, int> AgruparDados(string ocorrencias);

        public List<char> ObterDadosFluxo(List<char> listElevadores, bool peloValorMaximo);
        
    }
}
