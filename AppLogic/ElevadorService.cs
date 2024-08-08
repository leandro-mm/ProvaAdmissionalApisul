using ProvaAdmissionalCSharpApisul;
using AppData;
using System.Linq;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace AppLogic
{
    /// <summary>
    /// Classe que utiliza uma List<HistoricoUsoElevador> para processar dados utilizando LINQ 
    /// </summary>
    public class ElevadorService : IElevadorService
    {
        private List<HistoricoUsoElevador> _historicoServices;

        public void LoadData()
        {
            if (_historicoServices == null)
            {
                _historicoServices = new List<HistoricoUsoElevador>();
                //for (int i = 0; i < 100; i++)
                //{
                //    char elevador = 'A'; int andar = 1; char turno = 'M';
                //    this._historicoServices.Add(new HistoricoUsoElevador(elevador, andar, turno));
                //    this._historicoServices.Add(new HistoricoUsoElevador('Z', andar, 'N'));
                //}
                this._historicoServices.Add(new HistoricoUsoElevador('B', 2, 'M'));
                this._historicoServices.Add(new HistoricoUsoElevador('B', 2, 'M'));
                this._historicoServices.Add(new HistoricoUsoElevador('B', 2, 'M'));
                this._historicoServices.Add(new HistoricoUsoElevador('B', 2, 'M'));
                this._historicoServices.Add(new HistoricoUsoElevador('B', 2, 'M'));

                this._historicoServices.Add(new HistoricoUsoElevador('c', 2, 'n'));
                this._historicoServices.Add(new HistoricoUsoElevador('c', 2, 'n'));
                this._historicoServices.Add(new HistoricoUsoElevador('c', 2, 'n'));
                this._historicoServices.Add(new HistoricoUsoElevador('c', 2, 'n'));
                this._historicoServices.Add(new HistoricoUsoElevador('c', 2, 'n'));
            }
        }

        /// <summary>
        /// Busca os andartes dentro do histórico de uso cuja quantidade de uso é igual a menor 
        /// quantidade de uso dentre todos os andares
        /// </summary>
        /// <returns>Deve retornar uma List contendo o(s) andar(es) menos utilizado(s).</returns>
        public async Task<List<int>> andarMenosUtilizado()
        {

            if (_historicoServices == null || !_historicoServices.Any())
                return Enumerable.Empty<int>().ToList();

            //--Verifica a maior quantidade de uso dentre todos os elevadores
            bool pelaMaiorFrequencia = false;
            int frequenciaUso = await VerificarFrequenciaUsoPorGrupo(_historicoServices.GroupBy(g => g.Andar), pelaMaiorFrequencia);
            return BuscarItemPorFrequenciaUso(_historicoServices.GroupBy(g => g.Andar), frequenciaUso);            

        }
        /// <summary>
        /// Verifica dentro do histórico de uso qual a maior ocorrencia de elevador dentre de todo os elevadores do histórico
        /// </summary>
        /// <returns>Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s)</returns>
        public async Task<List<char>> elevadorMaisFrequentado()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return Enumerable.Empty<char>().ToList();

            //--Verifica a maior quantidade de uso dentre todos os elevadores
            bool pelaMaiorFrequencia = true;
            int frequenciaUso = await VerificarFrequenciaUsoPorGrupo(_historicoServices.GroupBy(g => g.Elevador), pelaMaiorFrequencia); 
            return BuscarItemPorFrequenciaUso(_historicoServices.GroupBy(g => g.Elevador),frequenciaUso);
        }

        
        private async Task<int> VerificarFrequenciaUsoPorGrupo(IEnumerable<IGrouping<int, HistoricoUsoElevador>> grupo, bool byMaxValue)
        {
            int value = 0;

            if (_historicoServices == null || !_historicoServices.Any())
                return value;

            value = await Task.Run(() =>
            {
                var keyValuePairs = grupo.ToDictionary(k => k.Key, v => v.Count());

                if (byMaxValue)
                {
                    return keyValuePairs.MaxBy(m => m.Value).Value;
                }
                else
                {
                    return keyValuePairs.MinBy(m => m.Value).Value;
                }
            });            

            return value;
        }

        /// <summary>
        /// Busca os elevadores dentro do histórico de uso cuja quantidade de uso é igual a menor 
        /// quantidade de uso dentre todos os elevadores 
        /// </summary>
        /// <returns></returns>
        public async Task<List<char>> elevadorMenosFrequentado()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return Enumerable.Empty<char>().ToList();

            //--Verifica a maior quantidade de uso dentre todos os elevadores
            bool pelaMaiorFrequencia = false;
            int frequenciaUso = await VerificarFrequenciaUsoPorGrupo(_historicoServices.GroupBy(g => g.Elevador), pelaMaiorFrequencia);
            return BuscarItemPorFrequenciaUso(_historicoServices.GroupBy(g => g.Elevador),frequenciaUso);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados.</returns>
        public float percentualDeUsoElevadorA()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return 0;
            return float.Parse(Math.Round(((double)_historicoServices.Where(e => e.Elevador == 'A').Count() / (double)_historicoServices.Count() * 100), 2).ToString());

        }

        public float percentualDeUsoElevadorB()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return 0;
            return float.Parse(Math.Round(((double)_historicoServices.Where(e => e.Elevador == 'B').Count() / (double)_historicoServices.Count() * 100), 2).ToString());
        }

        public float percentualDeUsoElevadorC()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return 0;
            return float.Parse(Math.Round(((double)_historicoServices.Where(e => e.Elevador == 'C').Count() / (double)_historicoServices.Count() * 100), 2).ToString());
        }

        public float percentualDeUsoElevadorD()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return 0;
            return float.Parse(Math.Round(((double)_historicoServices.Where(e => e.Elevador == 'D').Count() / (double)_historicoServices.Count() * 100), 2).ToString());
        }

        public float percentualDeUsoElevadorE()
        {
            if (_historicoServices == null || !_historicoServices.Any())
                return 0;
            return float.Parse(Math.Round(((double)_historicoServices.Where(e => e.Elevador == 'E').Count() / (double)_historicoServices.Count() * 100), 2).ToString());
        }

       
        public async Task<List<char>> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> listaElevadores = await elevadorMaisFrequentado();

            if(!listaElevadores.Any())
                return Enumerable.Empty<char>().ToList();

            bool peloValorMaximo = true;
            return ObterDadosFluxo(listaElevadores, peloValorMaximo);
        }


        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            //[1] monta uma string contendo todos os dados de uso separados por vírgula, exemplo M,T,N,M,M,T,N
            //[2] monta uma estrutura de dados chave/valor contendo a utilização e a quantidade de vezes que essa utilização foi encontrada na string [1]
            //[3] seleciona a maior ocorrencia com base no valor da estrutura [2] e peloValorMaximo variável

            if (!_historicoServices.Any())
                return Enumerable.Empty<char>().ToList();

            bool peloValorMaximo = true;

            try
            {
                //[1]
                var historicoUsoElevadores =
                    new string(
                        _historicoServices
                           .GroupBy(grouping => grouping.Elevador)//[2]                               
                           .ToDictionary(grouping => grouping.Key, grouping => string.Join(",", grouping.Select(historicoUso => historicoUso.Turno)))//[3]
                           .Values.ToList()
                           .SelectMany(list => list)
                           .ToArray()
                   );

                //[2]            
                var keyValuePairs = AgruparDados(historicoUsoElevadores);
                //[3]
                var resultadoFinal = SelecionarPorValor(keyValuePairs, peloValorMaximo)
                                    .Select(collection => collection.Key)
                                   .SelectMany(listOcorrencias => listOcorrencias)
                                   .Distinct()
                                   .ToList();

                return resultadoFinal;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        public async Task<List<char>> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> listaElevadores = await elevadorMenosFrequentado();

            if (!listaElevadores.Any())
                return Enumerable.Empty<char>().ToList();

            bool peloValorMaximo = false;
            return ObterDadosFluxo(listaElevadores, peloValorMaximo);
        }

        /// <summary>
        /// Recebe uma string que representa um conjunto de dados separados por vírgula
        /// verifica a quantidade de ocorrencias repetidas de cada item
        /// </summary>
        /// <param name="ocorrencias">string com palavras separadas por vírgulada </param>
        /// <returns>um dictionary contento como chave o item da string e como valor a quantidade de vezes que esse item ocorre dentro da string</returns>
        public ImmutableDictionary<string,int> AgruparDados(string ocorrencias)
        {
            return string.IsNullOrEmpty(ocorrencias) ? ImmutableDictionary<string, int>.Empty :
                ocorrencias.Split(',')
                .GroupBy(word => word)
                .ToImmutableDictionary(group => group.Key, group => group.Count());
        }

        /// <summary>
        /// dado uma estrutura de dados do tipo chave/valor verificar todas as ocorrencias que contenham como valor o valor máximo ou mínimo da estrutura de dados
        /// </summary>
        /// <param name="keyValuePairs">a estrutura de dados para processar/verificar</param>
        /// <param name="byMaxValue">se deve ser considerado o valor máximo dentre todas as ocorrencias</param>
        /// <returns></returns>
        public ImmutableDictionary<string, int> SelecionarPorValor(ImmutableDictionary<string, int> keyValuePairs, bool byMaxValue)
        {
            if (keyValuePairs.Count() > 0)
            {
                int valorIdeal = byMaxValue ? keyValuePairs.MaxBy(x => x.Value).Value : keyValuePairs.MinBy(x => x.Value).Value;
                return keyValuePairs.Where(kv => kv.Value == valorIdeal).ToImmutableDictionary();
            }
            return ImmutableDictionary<string, int>.Empty;
        }

        /// <summary>
        /// agrupa ocorrencias de turnos para contabilizar o periodo de maior fluxo
        /// </summary>
        /// <param name="listElevadores">null se todos os elevadores</param>
        /// <param name="peloValorMaximo">indica se é para verificar o maior fluxo de uso dos elevadores</param>
        /// <returns>Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores</returns>
        private List<char> ObterDadosFluxo(List<char> listElevadores, bool peloValorMaximo)
        {
            //[1] busca os dados dos elevadores 
            //[2] agrupa os dados por elevador, resultando em uma estrutura do tipo 1->n
            //[3] agrupa os turnos de cada elevador, exemplo Elevador 1-> N,N,M,M,T,T,N,N
            //[4] agrupa o conjunto de turnos por quantidade de caracter, exemplo N,N,M,M,T,T,T => NN=2, MM=2, TTT=3
            //[5] verifica a quantidade de cada caracter dentro do grupo de turnos extraindo apenas os que correspondem ao valor máximo
            //[6] foreach aninhado entre as lista para juntar os dados
            try
            {
                var maiorFluxoList = _historicoServices
                               .Where(historicoUso => listElevadores.Contains(historicoUso.Elevador)) //[1]                                
                               .GroupBy(grouping => grouping.Elevador)//[2]                               
                               .ToDictionary(grouping => grouping.Key, grouping => string.Join(",", grouping.Select(historicoUso => historicoUso.Turno)))//[3]
                               .Select(KeyValuePair => SelecionarPorValor(AgruparDados(KeyValuePair.Value), peloValorMaximo))//[4,5]
                               .Select(collection => collection.Keys)
                               .SelectMany(listOcorrencias => listOcorrencias)//[6]
                               .Distinct();

                return ListStringToChar(maiorFluxoList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<char> ListStringToChar(IEnumerable<string> listString)
        {
            if(listString.Any())
            {
                try
                {
                    List<char> listChar = new List<char>();
                    foreach (var item in listString)
                    {
                        listChar.Add(Char.Parse(item));
                    }
                    return listChar;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
           
            return Enumerable.Empty<char>().ToList();
            
        }

        /// <summary>
        /// VErifica elevadores que contem frequência de uso semelhante ao valor passado por parametro
        /// </summary>
        /// <param name="frequencia">a frequencia de uso</param>
        /// <returns>lista de elevadores</returns>
        private List<char> BuscarItemPorFrequenciaUso(IEnumerable<IGrouping<char,HistoricoUsoElevador>> grupo, int frequencia)
        {

            if (_historicoServices == null || !_historicoServices.Any())
                return Enumerable.Empty<char>().ToList();

            try
            {
                return grupo
                      .Where(g => g.Count() == frequencia)
                      .Select(g => g.Key)
                      .ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private List<int> BuscarItemPorFrequenciaUso(IEnumerable<IGrouping<int, HistoricoUsoElevador>> grupo, int frequencia)
        {

            if (_historicoServices == null || !_historicoServices.Any())
                return Enumerable.Empty<int>().ToList();

            try
            {
                return grupo
                      .Where(g => g.Count() == frequencia)
                      .Select(g => g.Key)
                      .ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Agrupa dados de frequencia por elevador, então retorna o valor da maior ou menor frequencia de uso
        /// </summary>
        /// <param name="byMaxValue">se deve ser verificado a maior frequencia de uso</param>
        /// <returns>a frequencia de uso</returns>
        private async Task<int> VerificarFrequenciaUsoPorGrupo(IEnumerable<IGrouping<char, HistoricoUsoElevador>> grupo, bool byMaxValue)
        {
            var result = 0;

            if (_historicoServices == null || !_historicoServices.Any())
                return result;

            result = await Task.Run(() =>
            {
                var keyValuePairs = grupo.ToDictionary(k => k.Key, v => v.Count());

                if (byMaxValue)
                {
                    return keyValuePairs.MaxBy(m => m.Value).Value;
                }
                else
                {
                    return keyValuePairs.MinBy(m => m.Value).Value;
                }
            });


            return result;
        }

    }
}
