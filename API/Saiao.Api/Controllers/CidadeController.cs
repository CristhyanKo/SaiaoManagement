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
    public class CidadeController : ControllerBase
    {
        private CidadeRepository _cidadeRepository { get; set; }
        private SaiaoDataContext _context { get; set; }

        public CidadeController()
        {
            _context = new SaiaoDataContext();
            _cidadeRepository = new CidadeRepository(_context);
        }

        #region "HTTP Methods"

        [Route("cidade")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_cidadeRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("cidade/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(Guid id)
        {
            try
            {
                var result = Buscar(_cidadeRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("cidade")]
        [HttpPost]
        public HttpResponseMessage Post(Cargo cidade)
        {
            try
            {
                var result = Incluir(_cidadeRepository, cidade);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("cidade")]
        [HttpPut]
        public HttpResponseMessage Put(Cargo cidade)
        {
            try
            {
                var result = Alterar(_cidadeRepository, cidade);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("cidade/id")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(_cidadeRepository, id);
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