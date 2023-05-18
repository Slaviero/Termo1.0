using System.Drawing.Text;

namespace Termo1._0
{
    public partial class Form1 : Form
    {

        private Palavra jogoSorteada;
        private string palavraChute = "";
        private Panel paineisPalavras;
        private int contadorPaineis = 0;
        private char caractereCorreto;
        private int contadorChances = 5;
        private int contadorDeAcertos = 0;
        public Form1()
        {
            InitializeComponent();
            jogoSorteada = new Palavra();

            paineisPalavras = pnl0;
            ObterRegistro();
        }
        private void ObterRegistro()
        {
            foreach (Button btn in pnlTeclado.Controls)
            {
                btn.Click += ChutarLetra;
            }
        }
        private void ChutarLetra(object? sender, EventArgs e)
        {
            Button btnTeclado = (Button)sender;

            foreach (Button btn in paineisPalavras.Controls)
            {
                if (btn.Text == "" && btnTeclado.Text != "Enter")
                {
                    palavraChute = palavraChute + btnTeclado.Text;
                    btn.Text = btnTeclado.Text;
                    break;
                }
            }
        }

        private void AtualizarPainel()
        {
            switch (contadorPaineis)
            {
                case 1: paineisPalavras = pnl1; break;
                case 2: paineisPalavras = pnl2; break;
                case 3: paineisPalavras = pnl3; break;
                case 4: paineisPalavras = pnl4; break;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (palavraChute.Length < 5)
            {
                lblMensagem.Text = "A palavra chute deve ter 5 letras para continuar o jogo!";
            }
            else
            {
                VerificarAcerto();

                lblMensagem.Text = "";

                contadorChances--;
                contadorPaineis++;

                AtualizarPainel();

                palavraChute = "";

                if (contadorDeAcertos == 5)
                {
                    lblMensagem.Text = $"Você acertou a Palavra!.";
                    lblMensagem.ForeColor = Color.DarkGreen;

                }
                if (contadorChances == 0)
                {
                    lblMensagem.Text = $"Suas tentativas acabaram, a palávra era {jogoSorteada.palavraSecreta}.";
                }
            }

        }

        private void VerificarAcerto()
        {
            AvaliacaoLetra[] avaliacoes = jogoSorteada.Avaliar(palavraChute);

            for (int i = 0; i < avaliacoes.Length; i++)
            {
                Button btn = (Button)paineisPalavras.Controls[i];

                switch (avaliacoes[i])
                {
                    case AvaliacaoLetra.Correta:
                        btn.BackColor = Color.Green;
                        contadorDeAcertos++;
                        break;
                    case AvaliacaoLetra.PosicaoIncorreta:
                        btn.BackColor = Color.Yellow;
                        contadorDeAcertos = 0;
                        break;
                    case AvaliacaoLetra.NaoExistente:
                        btn.BackColor = Color.Black;
                        contadorDeAcertos = 0;
                        break;
                }
            }
        }
    }
}