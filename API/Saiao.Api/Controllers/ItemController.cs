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
    public class ItemController : ControllerBase
    {
        private ItemRepository _itemRepository { get; set; }
        private SaiaoDataContext _context { get; set; }

        public ItemController()
        {
            _context = new SaiaoDataContext();
            _itemRepository = new ItemRepository(_context);
        }

        #region "HTTP Methods"

        [Route("item")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_itemRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("item/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(Guid id)
        {
            try
            {
                var result = Buscar(_itemRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("item")]
        [HttpPost]
        public HttpResponseMessage Post(Item item)
        {
            try
            {
                var result = Incluir(_itemRepository, item);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("item")]
        [HttpPut]
        public HttpResponseMessage Put(Item item)
        {
            try
            {
                var result = Alterar(_itemRepository, item);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("item/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(_itemRepository, id);
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