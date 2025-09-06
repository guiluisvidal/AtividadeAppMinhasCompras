using SQLite;

namespace AtividadeAppMinhasCompras.Models
{
        public class Produto
        {
        private string _descricao;

        [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Descricao 
            {
                get => _descricao;
                set
                {
                    if (value == null) 
                    { 
                        throw new Exception
                        ("O Campo Descrição Não pode Estar Vazio, Por favor Preencha o campo Descrição!");
                    }
                    _descricao = value;
            }
            }
            public double Preco { get; set; }
            public double Quantidade { get; set; }
            public double Total { get => Quantidade * Preco; }
        }
 }

