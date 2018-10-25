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
    public class EstadoController : ControllerBase
    {
        private EstadoRepository _estadoRepository { get; set; }
        private SaiaoDataContext _context { get; set; }

        public EstadoController()
        {
            _context = new SaiaoDataContext();
            _estadoRepository = new EstadoRepository(_context);
        }

        #region "HTTP Methods"

        [Route("estado")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_estadoRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("estado/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(Guid id)
        {
            try
            {
                var result = Buscar(_estadoRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("estado")]
        [HttpPost]
        public HttpResponseMessage Post(Cargo cidade)
        {
            try
            {
                var result = Incluir(_estadoRepository, cidade);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("estado")]
        [HttpPut]
        public HttpResponseMessage Put(Cargo cidade)
        {
            try
            {
                var result = Alterar(_estadoRepository, cidade);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("estado/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(_estadoRepository, id);
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