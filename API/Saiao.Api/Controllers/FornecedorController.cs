using Saiao.Common.Exception;
using Saiao.Common.Resources;
using Saiao.Data.DataContext;
using Saiao.Data.Repositories;
using Saiao.Domain.Model;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Saiao.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class FornecedorController : ControllerBase
    {
        private FornecedorRepository _fornecedorRepository { get; set; }
        private SaiaoDataContext _context { get; set; }

        public FornecedorController()
        {
            _context = new SaiaoDataContext();
            _fornecedorRepository = new FornecedorRepository(_context);
        }

        #region "HTTP Methods"

        [Route("fornecedor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_fornecedorRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("fornecedor/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(Guid id)
        {
            try
            {
                var result = Buscar(_fornecedorRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("fornecedor")]
        [HttpPost]
        public HttpResponseMessage Post(Cargo fornecedor)
        {
            try
            {
                var result = Incluir(_fornecedorRepository, fornecedor);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("fornecedor")]
        [HttpPut]
        public HttpResponseMessage Put(Cargo fornecedor)
        {
            try
            {
                var result = Alterar(_fornecedorRepository, fornecedor);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("fornecedor/id")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(_fornecedorRepository, id);
                return SucessRequestMessage(SucessMessage.RegistroIncluido);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.RegistroIncluido);
            }
        }

        #endregion
    }


}