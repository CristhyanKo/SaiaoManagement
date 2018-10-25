using Saiao.Domain.Contract.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Saiao.Api.Controllers
{
    public class ControllerBase : ApiController
    {
        protected HttpResponseMessage SucessRequestMessage(string message)
        {
            return RequestMessage(HttpStatusCode.OK, message);
        }

        protected HttpResponseMessage SucessRequestClass(IRepositoryClass classe)
        {
            return RequestMessage(HttpStatusCode.OK, classe);
        }

        protected HttpResponseMessage SucessRequestClass(List<IRepositoryClass> lista)
        {
            return RequestMessage(HttpStatusCode.OK, lista);
        }

        protected HttpResponseMessage BadRequestMessage(string message)
        {
            return RequestMessage(HttpStatusCode.BadRequest, message);
        }

        private HttpResponseMessage RequestMessage(HttpStatusCode statusType, string message)
        {
            var response = Request.CreateResponse(statusType);
            var content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain");
            response.Content = content;

            return response;
        }

        private HttpResponseMessage RequestMessage(HttpStatusCode statusType, IRepositoryClass classe)
        {
            return Request.CreateResponse(statusType, classe);
        }

        private HttpResponseMessage RequestMessage(HttpStatusCode statusType, List<IRepositoryClass> lista)
        {
            return Request.CreateResponse(statusType, lista);
        }

        protected List<IRepositoryClass> Buscar(IRepositoryDefault repository)
        {
            return repository.Buscar();
        }

        protected IRepositoryClass Buscar(IRepositoryDefault repository, int id)
        {
            return repository.Buscar(id);
        }

        protected IRepositoryClass Incluir(IRepositoryDefault repository, IRepositoryClass classe)
        {
            return repository.Incluir(classe);
        }

        protected IRepositoryClass Alterar(IRepositoryDefault repository, IRepositoryClass classe)
        {
            return repository.Alterar(classe);
        }

        protected void Excluir(IRepositoryDefault repository, int id)
        {
            repository.Excluir(id);
        }
    }
}