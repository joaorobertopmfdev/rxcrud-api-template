using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using RXCrud.Domain.Dto;

namespace RXCrud.Api.Configuracoes
{
    public class EdmModelConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<UsuarioDto>("Usuario");
            odataBuilder.EntitySet<CidadeDto>("Cidade");
            odataBuilder.EntitySet<EstadoDto>("Estado");

            return odataBuilder.GetEdmModel();
        }
    }
}