using RickNotifications.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickNotifications.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatosView : ContentPage
    {
        ContatoService contatoService = new ContatoService();
        public ContatosView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await ExibeContatos();
            AddContact.IsVisible = false;
        }

        private async Task ExibeContatos()
        {
            var contatos = await contatoService.GetContatos();
            listaContatos.ItemsSource = contatos;
        }

        private async void BtnIncluir_Clicked(object sender, EventArgs e)
        {
            if (AddContact.IsVisible)
            {
                await contatoService.AddContato(Convert.ToInt32(txtId.Text), txtNome.Text, txtEmail.Text);

                txtId.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;

                await DisplayAlert("Sucesso", "Contato incluído com sucesso", "Ok");
                await ExibeContatos();

                AddContact.IsVisible = false;
                btnAtualizar.IsVisible = true;
                btnDeletar.IsVisible = true;
                btnExibir.IsVisible = true;
                btnIncluir.Text = "Incluir";
            }
            else
            {
                AddContact.IsVisible = true;
                btnAtualizar.IsVisible = false;
                btnDeletar.IsVisible = false;
                btnExibir.IsVisible = false;
                btnIncluir.Text = "Salvar";
            }
        }

        private async void BtnExibir_Clicked(object sender, EventArgs e)
        {
            if (AddContact.IsVisible)
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    await DisplayAlert("Erro", "ID do contato inválido", "Ok");
                }
                else
                {
                    try
                    {
                        var contato = await contatoService.GetContato(Convert.ToInt32(txtId.Text));

                        if (contato != null)
                        {
                            txtId.Text = contato.ContatoId.ToString();
                            txtNome.Text = contato.Nome;
                            txtEmail.Text = contato.Email;
                        }
                        else
                        {
                            await DisplayAlert("Erro", "Não existe contato com esse ID", "Ok");
                        }

                        txtEmail.IsVisible = true;
                        txtNome.IsVisible = true;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Erro", "Contato não encontrado " + ex.Message, "Ok");
                    }

                    AddContact.IsVisible = true;
                    btnAtualizar.IsVisible = true;
                    btnDeletar.IsVisible = true;
                    btnIncluir.IsVisible = true;
                    btnExibir.Text = "Exibir";
                }
            }
            else
            {
                AddContact.IsVisible = true;
                txtEmail.IsVisible = false;
                txtNome.IsVisible = false;
                btnIncluir.IsVisible = false;
                btnDeletar.IsVisible = false;
                btnAtualizar.IsVisible = false;
                btnExibir.Text = "Buscar";
            }
        }

        private async void BtnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (AddContact.IsVisible)
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    await DisplayAlert("Erro", "ID do contato inválido", "OK");
                }
                else
                {
                    try
                    {
                        await contatoService.updateContato(Convert.ToInt32(txtId.Text), txtNome.Text, txtEmail.Text);

                        txtId.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtEmail.Text = string.Empty;

                        await DisplayAlert("Sucesso", "Contato atualizado com sucesso", "Ok");

                        await ExibeContatos();
                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("Erro", "Não foi possível atualizar o contato " + ex.Message, "Ok");
                    }
                }

                AddContact.IsVisible = false;
                btnAtualizar.IsVisible = true;
                btnDeletar.IsVisible = true;
                btnExibir.IsVisible = true;
                btnIncluir.IsVisible = true;
            }
            else
            {
                AddContact.IsVisible = true;
                btnIncluir.IsVisible = false;
                btnDeletar.IsVisible = false;
                btnExibir.IsVisible = false;
            }
        }

        private async void BtnDeletar_CLlicked(object sender, EventArgs e)
        {
            if (AddContact.IsVisible)
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    await DisplayAlert("Erro", "ID do contato inválido", "OK");
                }
                else
                {
                    try
                    {
                        await contatoService.DeleteContato(Convert.ToInt32(txtId.Text));

                        txtId.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtEmail.Text = string.Empty;

                        await DisplayAlert("Sucesso", "Contato removido com sucesso", "Ok");

                        await ExibeContatos();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Erro", "Não foi possível remover o contato " + ex.Message, "Ok");
                    }
                }
                AddContact.IsVisible = false;
                btnAtualizar.IsVisible = true;
                btnExibir.IsVisible = true;
                btnIncluir.IsVisible = true;
            }
            else
            {
                AddContact.IsVisible = true;
                txtNome.IsVisible = false;
                txtEmail.IsVisible = false;
                btnIncluir.IsVisible = false;
                btnAtualizar.IsVisible = false;
                btnExibir.IsVisible = false;
            }
        }
    }
}