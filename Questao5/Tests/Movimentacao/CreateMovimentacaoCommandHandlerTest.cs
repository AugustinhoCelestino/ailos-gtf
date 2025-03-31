using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Questao5.Application.Movimentacao.Commands;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Xunit;

namespace Questao5.Tests.Movimentacao;

public class CreateMovimentacaoCommandHandlerTest
{
    private readonly IContaCorrenteRepository _contacorrenteRepositoryMock;
    private readonly IMovimentacaoRepository _movimentacaoRepositoryMock;
    private readonly CreateMovimentacaoCommandHandler _commandHandler;

    public CreateMovimentacaoCommandHandlerTest()
    {
        _contacorrenteRepositoryMock = Substitute.For<IContaCorrenteRepository>();
        _movimentacaoRepositoryMock = Substitute.For<IMovimentacaoRepository>();
        _commandHandler = new CreateMovimentacaoCommandHandler(_contacorrenteRepositoryMock, _movimentacaoRepositoryMock);
    }
    [Fact]
    public async Task CreateMovimentacaoCommandHandler_Should_ReturnError_WhenInvalidAccount()
    {
        // Arrange
        var command = new CreateMovimentacaoCommand("", "INVALID_ACCOUNT_ID", 0, "D");
        _contacorrenteRepositoryMock.GetByIdAsync("INVALID_ACCOUNT_ID").ReturnsNull();

        // Act
        var result = await _commandHandler.Handle(command, default);

        // Assert
        result.Error.Code.Should().Be("INVALID_ACCOUNT");
    }
    [Fact]
    public async Task CreateMovimentacaoCommandHandler_Should_ReturnError_WhenInactiveAccount()
    {
        // Arrange
        var command = new CreateMovimentacaoCommand("", "ACCOUNT_ID", 0, "D");
        _contacorrenteRepositoryMock.GetByIdAsync("ACCOUNT_ID").Returns(new ContaCorrente());

        // Act
        var result = await _commandHandler.Handle(command, default);

        // Assert
        result.Error.Code.Should().Be("INACTIVE_ACCOUNT");
    }
    [Fact]
    public async Task CreateMovimentacaoCommandHandler_Should_ReturnError_WhenInvalidValue()
    {
        // Arrange
        var command = new CreateMovimentacaoCommand("", "ACCOUNT_ID", 0, "D");
        var conta = new ContaCorrente();
        conta.Ativo = 1;
        _contacorrenteRepositoryMock.GetByIdAsync("ACCOUNT_ID").Returns(conta);

        // Act
        var result = await _commandHandler.Handle(command, default);

        // Assert
        result.Error.Code.Should().Be("INVALID_VALUE");
    }
    [Fact]
    public async Task CreateMovimentacaoCommandHandler_Should_ReturnError_WhenInvalidType()
    {
        // Arrange
        var command = new CreateMovimentacaoCommand("", "ACCOUNT_ID", 1, "Z");
        var conta = new ContaCorrente();
        conta.Ativo = 1;
        _contacorrenteRepositoryMock.GetByIdAsync("ACCOUNT_ID").Returns(conta);

        // Act
        var result = await _commandHandler.Handle(command, default);

        // Assert
        result.Error.Code.Should().Be("INVALID_TYPE");
    }
    [Fact]
    public async Task CreateMovimentacaoCommandHandler_Should_ReturnSuccess()
    {
        // Arrange
        var command = new CreateMovimentacaoCommand("", "ACCOUNT_ID", 1, "D");
        var conta = new ContaCorrente();
        conta.Ativo = 1;
        _contacorrenteRepositoryMock.GetByIdAsync("ACCOUNT_ID").Returns(conta);

        var movimentacao = new Domain.Entities.Movimentacao();
        _movimentacaoRepositoryMock.Add(movimentacao).Returns(movimentacao);

        // Act
        var result = await _commandHandler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}
