namespace RCPortalConsultor.Core.Services;

public abstract class Services
{
    private readonly object _service;

    protected Services(object service)
    {
        _service = service;
    }

    public abstract void salvar();

    public abstract void atualizar();

}