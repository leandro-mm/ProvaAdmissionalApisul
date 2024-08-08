namespace AppData
{
    public class HistoricoUsoElevador
    {
        public HistoricoUsoElevador(char elevador, int andar, char turno)
        {
            this.Elevador = elevador;
            this.Andar = andar;
            this.Turno = turno;
        }
        public char Elevador { get; set; }
        public int Andar { get; set; }
        public char Turno { get; set; }
    }
}