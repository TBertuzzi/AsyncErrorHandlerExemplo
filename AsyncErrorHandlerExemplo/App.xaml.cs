using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsyncErrorHandlerExemplo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            await SalvarArquivo("VaiDarErro.txt", "Erro");
        }

        public async Task SalvarArquivo(string nomeArquivo, string conteudoArquivo)
        {

            var caminhoPastaPessoal = "Forçar um erro"; // Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoPastaPessoal, nomeArquivo);

            using (var stream = new StreamWriter(caminhoCompleto, false))
            {
                stream.AutoFlush = true;
                await stream.WriteAsync(conteudoArquivo);
            }
        }
    }
}
