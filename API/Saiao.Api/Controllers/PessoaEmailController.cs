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
    public class PessoaEmailController : ControllerBase
    {
        private PessoaEmailRepository _pessoaEmailRepository { get; set; }
        private SaiaoDataContext _context { get; set; }

        public PessoaEmailController()
        {
            _context = new SaiaoDataContext();
            _pessoaEmailRepository = new PessoaEmailRepository(_context);
        }

        #region "HTTP Methods"

        [Route("pessoaEmail")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_pessoaEmailRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("pessoaEmail/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(Guid id)
        {
            try
            {
                var result = Buscar(_pessoaEmailRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("pessoaEmail")]
        [HttpPost]
        public HttpResponseMessage Post(PessoaEmail pessoaEmail)
        {
            try
            {
                var result = Incluir(_pessoaEmailRepository, pessoaEmail);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("pessoaEmail")]
        [HttpPut]
        public HttpResponseMessage Put(PessoaEmail pessoaEmail)
        {
            try
            {
                var result = Alterar(_pessoaEmailRepository, pessoaEmail);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("pessoaEmail/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(_pessoaEmailRepository, id);
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