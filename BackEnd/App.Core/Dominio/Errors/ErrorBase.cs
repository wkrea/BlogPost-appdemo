namespace App.Core.Dominio.Errors
{
    /// <summary>
    /// Estructura de datos para el manejo de errores
    /// A nivel interno de la app
    /// https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
    /// </summary>
    public class ErrorBase
    {
        public int StatusCode { get; }

        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Mensaje { get; set; }
        public ErrorBase(int statusCode, string mensaje = null)
        {
            StatusCode = statusCode;
            Mensaje = mensaje ?? getMensajePersonalizado(statusCode);
        }
        private static string getMensajePersonalizado(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Ok";
                case 201:
                    return "Ok item creado";
                case 202:
                    return "Ok acción procesada";
                case 404:
                    return "Recurso no se encontrado";
                case 500:
                    return "Un error inmanejable en el servidor ha ocurrido";
                default:
                    return null;
            }
        }
    }
}
