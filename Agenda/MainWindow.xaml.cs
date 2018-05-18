using Agenda.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            obterDados();

        }

        private void obterDados()
        {
            using (var repo = new ContatoRepository())
            {
                dgvDados.ItemsSource = repo.ObterTodos();
            }
        }

        private void dgvDados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDados.SelectedIndex >= 0)
            {
                var contato = dgvDados.Items[dgvDados.SelectedIndex] as Contato;
                txtId.Text = contato.Id.ToString();
                txtNome.Text = contato.Nome;
                txtEmail.Text = contato.Email;
                txtTel.Text = contato.Telefone;
                txtNome.Focus();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var contato = new Contato();
            contato.Nome = txtNome.Text;
            contato.Email = txtEmail.Text;
            contato.Telefone = txtTel.Text;

            using (var repo = new ContatoRepository())
            {
                if (txtId.Text.Trim() == "")
                {
                    repo.Add(contato);
                }
                else
                {
                    contato.Id = Convert.ToInt32(txtId.Text);
                    repo.Edit(contato);
                }
            }

            obterDados();
            MessageBox.Show("Contato Atualizado");

        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            limparTela();
        }

        private void limparTela()
        {
            txtId.Text = txtNome.Text = txtEmail.Text = txtTel.Text = "";
            txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDados.SelectedIndex >= 0)
            {
                var excluir =
                    MessageBox.Show("Deseja Excluir esse contato?", "Agenda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (excluir == MessageBoxResult.Yes)
                {
                    using (var repo = new ContatoRepository())
                    {
                        var contato = dgvDados.Items[dgvDados.SelectedIndex] as Contato;
                        repo.Del(contato);
                    }

                    obterDados();
                    limparTela();
                }
            }
        }

        bool ir = false;
        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            if (!ir)
            {
                limparTela();
                btnInserir.IsEnabled = btnAlterar.IsEnabled = btnSalvar.IsEnabled =
                        btnExcluir.IsEnabled = false;
                btnLocalizar.Content = "Ir";
                ir = true;
            }
            else
            {

                using (var repo = new ContatoRepository())
                {
                    var data = repo.Buscar(txtNome.Text.Trim(), txtEmail.Text.Trim(), txtTel.Text.Trim());
                    dgvDados.ItemsSource = data;

                }
                btnInserir.IsEnabled = btnAlterar.IsEnabled = btnSalvar.IsEnabled =
                        btnExcluir.IsEnabled = true;
                ir = false;
                btnLocalizar.Content = "Localizar";
            }
        }


    }
}
