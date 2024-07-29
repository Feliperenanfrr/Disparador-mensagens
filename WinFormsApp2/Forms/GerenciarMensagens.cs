namespace Gweb.WhatsApp.Forms
{
    public partial class GerenciarMensagens : Form
    {
        public GerenciarMensagens()
        {
            InitializeComponent();
        }

        private void btnCriarMensagem_Click(object sender, EventArgs e)
        {
            CriarMensagem criarMensagem = new CriarMensagem();
            criarMensagem.Show();
        }

        private void btnListarMensagens_Click(object sender, EventArgs e)
        {
            ListarMensagem listarMensagem = new ListarMensagem();
            listarMensagem.Show();
        }

        private void btnAgendarMensagem_Click(object sender, EventArgs e)
        {
            AgendarMensagens selecionarContatos = new AgendarMensagens();
            selecionarContatos.Show();
        }
    }
}
