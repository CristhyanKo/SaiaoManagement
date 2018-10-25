using Saiao.Domain.Contract.Repositories;
using System;
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

        protected HttpResponseMessage SucessRequestClass(IRepositoryClassBase classe)
        {
            return RequestMessage(HttpStatusCode.OK, classe);
        }

        protected HttpResponseMessage SucessRequestClass(List<IRepositoryClassBase> lista)
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

        private HttpResponseMessage RequestMessage(HttpStatusCode statusType, IRepositoryClassBase classe)
        {
            return Request.CreateResponse(statusType, classe);
        }

        private HttpResponseMessage RequestMessage(HttpStatusCode statusType, List<IRepositoryClassBase> lista)
        {
            return Request.CreateResponse(statusType, lista);
        }

        protected List<IRepositoryClassBase> Buscar(IRepositoryBase repository)
        {
            return repository.Buscar();
        }

        protected IRepositoryClassBase Buscar(IRepositoryBase repository, Guid id)
        {
            return repository.Buscar(id);
        }

        protected IRepositoryClassBase Incluir(IRepositoryBase repository, IRepositoryClassBase classe)
        {
            return repository.Incluir(classe);
        }

        protected IRepositoryClassBase Alterar(IRepositoryBase repository, IRepositoryClassBase classe)
        {
            return repository.Alterar(classe);
        }

        protected void Excluir(IRepositoryBase repository, Guid id)
        {
            repository.Excluir(id);
        }
    }
}