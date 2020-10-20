using App.Core.Dominio.Errors;
public class ApiOkResponse : ErrorBase
{
    public object response { get; }
    public ApiOkResponse(object resultado) : base(200)
    {
        response = resultado;
    }
}