using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using System.Data;

namespace Questao5.Persistence.Repository;

public class ContaCorrenteRepository : IContaCorrenteRepository
{
    private IDbConnection? _connection;

    private IDbConnection connection
    {
        get { 
            if(_connection != null)
            {
                return _connection;
            }
            string connectionstring = "Data Source=database.sqlite";
            _connection = new SqliteConnection(connectionstring);
            return _connection;
        }
    }

    public async Task<ContaCorrente> GetByIdAsync(string id)
    {
        const string sqlQuery = "SELECT * FROM contacorrente WHERE idcontacorrente == @ContaCorrenteId";

        ContaCorrente contaCorrente = await connection.QueryFirstOrDefaultAsync<ContaCorrente>(sqlQuery, new { ContaCorrenteId = id });

        return contaCorrente;
    }
}
