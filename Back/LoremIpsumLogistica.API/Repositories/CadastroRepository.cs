using LoremIpsumLogistica.API.Context;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica.API.Repositories;

public sealed class CadastroRepository : ICadastroRepository
{
    private readonly LoremIpsumLogisticaDBContext _dbContext;

    public CadastroRepository(LoremIpsumLogisticaDBContext dbContext) => _dbContext = dbContext;

    public async Task<Cadastro?> CadastroById(long cadastroId)
    {
        return await _dbContext.Cadastros.AsNoTracking().Where(c => c.Id == cadastroId).FirstOrDefaultAsync();
    }

    public async Task<Cadastro?> CadastroByIdAtualizacao(long cadastroId)
    {
        return await _dbContext.Cadastros.Where(c => c.Id == cadastroId).FirstOrDefaultAsync();
    }

    public async Task<IList<Cadastro>> BuscarTodos()
    {
        return await _dbContext.Cadastros.ToListAsync();
    }

    public async Task SalvarCadastro(Cadastro cadastro)
    {
        await _dbContext.Cadastros.AddAsync(cadastro);
        await _dbContext.SaveChangesAsync();
    }

    public void AtualizarCadastro(Models.Cadastro cadastro)
    {
        _dbContext.Cadastros.Update(cadastro);
        _dbContext.SaveChanges();
    }

    public async Task ExcluirCadastro(long cadastroId)
    {
        var cadastro = await CadastroByIdAtualizacao(cadastroId);

        _dbContext.Cadastros.Remove(cadastro!);
        await _dbContext.SaveChangesAsync();
    }
}
