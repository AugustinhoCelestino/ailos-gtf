using Dapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Application.MovimentacaoContaCorrente;

public class MovimentacaoContaCorrenteHandler : IRequestHandler<MovimentacaoContaCorrenteCommand, MovimentacaoContaCorrenteResult>
{
    //private readonly IDbConnectionFactory _connection;

    public MovimentacaoContaCorrenteHandler()
    {
        //_connection = dbConnection;
    }

    public async Task<MovimentacaoContaCorrenteResult> Handle(MovimentacaoContaCorrenteCommand command, CancellationToken cancellationToken)
    {
        MovimentacaoContaCorrenteCommandValidator validator = new ();
        ValidationResult validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        /*using IDbConnection dbConnection = _connection.CreateOpenConnection();
        const string sqlSelectContaCorrente = "SELECT ativo FROM contacorrente WHERE idcontacorrente == @ContaCorrenteId";

        ContaCorrente? contaCorrente = await dbConnection.QueryFirstOrDefault(
            sqlSelectContaCorrente, new { command.ContaCorrenteId }) 
            ?? throw new ValidationException("INVALID_ACCOUNT");

        if (contaCorrente.Ativo == 0)
        {
            throw new ValidationException("INACTIVE_ACCOUNT");
        }
        if (command.ValorMovimentacao < 0)
        {
            throw new ValidationException("INVALID_VALUE");
        }
        if (!command.TipoMovimentacao.Equals("D") || !command.TipoMovimentacao.Equals("C"))
        {
            throw new ValidationException("INVALID_TYPE");
        }

        const string sqlInsertMovimentacao =
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
                sys_guid(), 
                :ContaCorrenteId,
                sysdate,
                :TipoMovimentacao,
                :ValorMovimentacao
            )
            RETURNING  
                idmovimento 
            INTO 
                :IdInserido

            ";

        DynamicParameters param = new (new
        {
            command.ContaCorrenteId,
            command.TipoMovimentacao,
            command.ValorMovimentacao
            });

        param.Add(name: "IdInserido", dbType: DbType.String, direction: ParameterDirection.Output);

        dbConnection.Execute(sqlInsertMovimentacao, param);

        string IdInserido = param.Get<string>("IdInserido");
        */
        return new MovimentacaoContaCorrenteResult("IdInserido");
    }
}
/*
public interface IDbConnectionFactory
{
    IDbConnection CreateOpenConnection();
}
*/