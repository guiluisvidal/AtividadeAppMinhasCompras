using AtividadeAppMinhasCompras.Models;
using SQLite;

namespace AtividadeAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _Conn;

        public SQLiteDataBaseHelper(string path)
        {
            _Conn = new SQLiteAsyncConnection(path);

            _Conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> InsertProduto(Produto p) 
        { 
            return _Conn.InsertAsync(p);
        }
        public Task<List<Produto>> UpdateProduto(Produto p) 
        { 
            string sql = "UPDATE Produto SET Descricao =? , Preco =?, Quantidade =? WHERE Id =?";
            return _Conn.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Quantidade, p.Id);
        }
        public Task<int> DeleteProduto(int id) 
        {
            return _Conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() 
        {
           return _Conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto  WHERE Descricao LIKE '%" + q + "%'";

            return _Conn.QueryAsync<Produto>(sql);
        }
    }
}
