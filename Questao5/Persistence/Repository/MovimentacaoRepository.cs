using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using System.Data;

namespace Questao5.Persistence.Repository;

public class MovimentacaoRepository : IMovimentacaoRepository
{
    private IDbConnection? _connection;

    private IDbConnection connection
    {
        get
        {
            if (_connection != null)
            {
                return _connection;
            }
            var connectionstring = "Data Source=database.sqlite";
            _connection = new SqliteConnection(connectionstring);
            return _connection;
        }
    }
    public async Task<Movimentacao> Add(Movimentacao movimentacao)
    {
        const string sqlQuery =
            @"
            INSERT INTO 

            movimento (
                idmovimento,
                idcontacorrente,
                datamovimento,
                tipomovimento,
                valor 
            ) 

            VALUES (
                  lower(
                    hex(randomblob(4)) || '-' || hex(randomblob(2)) || '-' || '4' || 
                    substr(hex( randomblob(2)), 2) || '-' || 
                    substr('AB89', 1 + (abs(random()) % 4) , 1)  ||
                    substr(hex(randomblob(2)), 2) || '-' || 
                    hex(randomblob(6))
                  ), 
                @IdContacorrente,
                date('now'),
                @TipoMovimento,
                @Valor
            )
            ";

        DynamicParameters param = new(new
        {
            movimentacao.IdContacorrente,
            movimentacao.TipoMovimento,
            movimentacao.Valor,
            movimentacao.DataMovimento
        });

        int rowid = await connection.ExecuteAsync(sqlQuery, param);

        return movimentacao;
    }

    public async Task<List<Movimentacao>> FindAllByAccountId (string id)
    {
        const string sqlQuery = @"SELECT * FROM movimento WHERE idcontacorrente = @ContaCorrenteId";

        IEnumerable<Movimentacao> movimentacaos = await connection.QueryAsync<Movimentacao>(sqlQuery, new { ContaCorrenteId = id });

        List<Movimentacao> listaMovimentacaos = movimentacaos.ToList<Movimentacao>();

        return listaMovimentacaos;
    }
}
