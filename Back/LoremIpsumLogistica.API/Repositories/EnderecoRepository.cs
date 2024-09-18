using LoremIpsumLogistica.API.Context;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica.API.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly LoremIpsumLogisticaDBContext _dbContext;

    public EnderecoRepository(LoremIpsumLogisticaDBContext dbContext) => _dbContext = dbContext;

    public async Task<IList<Endereco>> BuscarTodosByIdCadastro(long cadastroId)
    {
        return await _dbContext.Enderecos.AsNoTracking().Where(e => e.CadastroId == cadastroId).ToListAsync();
    }

    public async Task<Endereco?> EnderecoById(long enderecoId)
    {
        return await _dbContext.Enderecos.AsNoTracking().Where(e => e.Id == enderecoId).FirstOrDefaultAsync();
    }

    public async Task<Endereco?> EnderecoByIdAtualizacao(long enderecoId)
    {
        return await _dbContext.Enderecos.Where(e => e.Id == enderecoId).FirstOrDefaultAsync();
    }

    public async Task SalvarEndereco(Endereco endereco)
    {
        await _dbContext.Enderecos.AddAsync(endereco);
        await _dbContext.SaveChangesAsync();
    }

    public void AtualizarEndereco(Endereco endereco)
    {
        _dbContext.Enderecos.Update(endereco);
        _dbContext.SaveChanges();
    }

    public async Task ExcluirEndereco(long enderecoId)
    {
        var endereco = await EnderecoByIdAtualizacao(enderecoId);

        _dbContext.Enderecos.Remove(endereco!);
        await _dbContext.SaveChangesAsync();
    }
}
