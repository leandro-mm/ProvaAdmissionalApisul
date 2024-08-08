namespace ProvaAdmissionalApisul
{

    using AppLogic;
    using AppService;
    using System.Collections.Generic;
    using System.Reflection;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnExtrairInf_Click(object sender, EventArgs e)
        {
            ClearTextBox(this.textBox1);

            DialogResult dialogResult = this.openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                ElevadorService elevadorService = new ElevadorService();
                elevadorService.LoadData(new AppService(openFileDialog1.FileName));

                if (elevadorService.TotalServicos() > 0)
                {
                    var andarMenosUtilizado = await elevadorService.andarMenosUtilizado();
                    projetarResultado(nameof(andarMenosUtilizado), andarMenosUtilizado);

                    var elevadorMaisFrequentado = await elevadorService.elevadorMaisFrequentado();
                    projetarResultado(nameof(elevadorMaisFrequentado), elevadorMaisFrequentado);

                    var elevadorMenosFrequentado = await elevadorService.elevadorMenosFrequentado();
                    projetarResultado(nameof(elevadorMenosFrequentado), elevadorMenosFrequentado);

                    var percentualDeUsoElevadorA = elevadorService.percentualDeUsoElevadorA();
                    projetarResultado(nameof(percentualDeUsoElevadorA), percentualDeUsoElevadorA);

                    var percentualDeUsoElevadorB = elevadorService.percentualDeUsoElevadorB();
                    projetarResultado(nameof(percentualDeUsoElevadorB), percentualDeUsoElevadorB);

                    var percentualDeUsoElevadorC = elevadorService.percentualDeUsoElevadorC();
                    projetarResultado(nameof(percentualDeUsoElevadorC), percentualDeUsoElevadorC);

                    var percentualDeUsoElevadorD = elevadorService.percentualDeUsoElevadorD();
                    projetarResultado(nameof(percentualDeUsoElevadorD), percentualDeUsoElevadorD);

                    var percentualDeUsoElevadorE = elevadorService.percentualDeUsoElevadorE();
                    projetarResultado(nameof(percentualDeUsoElevadorE), percentualDeUsoElevadorE);

                    var periodoMaiorFluxoElevadorMaisFrequentado = await elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
                    projetarResultado(nameof(periodoMaiorFluxoElevadorMaisFrequentado), periodoMaiorFluxoElevadorMaisFrequentado);

                    var periodoMenorFluxoElevadorMenosFrequentado = await elevadorService.periodoMenorFluxoElevadorMenosFrequentado();
                    projetarResultado(nameof(periodoMenorFluxoElevadorMenosFrequentado), periodoMenorFluxoElevadorMenosFrequentado);

                    var periodoMaiorUtilizacaoConjuntoElevadores = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
                    projetarResultado(nameof(periodoMaiorUtilizacaoConjuntoElevadores), periodoMaiorUtilizacaoConjuntoElevadores);
                }
                else
                {
                    textBox1.Text = "Nenhuma informação para processar";
                }
            }
            

        }

        private void ClearTextBox(TextBox textBox1)
        {
            textBox1.Text= string.Empty;    
        }

        private void projetarResultado(string nomeMetodo, List<int> resultado)
        {
            textBox1.Text += $"{nomeMetodo} => {string.Join(", ", resultado)}";
            textBox1.Text += Environment.NewLine;
        }
        private void projetarResultado(string nomeMetodo, List<char> resultado)
        {
            textBox1.Text += $"{nomeMetodo} => {string.Join(", ", resultado)}";
            textBox1.Text += Environment.NewLine;
        }
        private void projetarResultado(string nomeMetodo, float resultado)
        {
            textBox1.Text += $"{nomeMetodo} => {string.Join(", ", resultado)}";
            textBox1.Text += Environment.NewLine;
        }
    }
}
