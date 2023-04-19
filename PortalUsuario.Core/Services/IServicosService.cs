namespace PortalUsuario.Core.Services;

public interface IServicosService
{
    Task Salvar();
    Task Buscar();
    Task Editar();
    Task Deletar();
}