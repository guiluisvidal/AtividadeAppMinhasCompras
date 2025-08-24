using AtividadeAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace AtividadeAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_Quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};
			await App.Db.InsertProduto(p);
			await DisplayAlert("Sucesso!", "Registro inserido", "OK");

		}
		catch (Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}