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
    public class CargoController : ControllerBase
    {
        private CargoRepository _cargoRepository { get; set; }

        public CargoController()
        {
            var context = new SaiaoDataContext();
            _cargoRepository = new CargoRepository(context);
        }

        #region "HTTP Methods"

        [Route("cargo")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Buscar(_cargoRepository);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistros);
            }
        }

        [Route("cargo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFromId(int id)
        {
            try
            {
                var result = Buscar(_cargoRepository, id);
                return SucessRequestClass(result);
            }
            catch (Exception)
            {
                return BadRequestMessage(ErrorMessage.BuscarRegistro);
            }
        }

        [Route("cargo")]
        [HttpPost]
        public HttpResponseMessage Post(Cargo cargo)
        {
            try
            {
                var result = Incluir(_cargoRepository, cargo);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("cargo")]
        [HttpPut]
        public HttpResponseMessage Put(Cargo cargo)
        {
            try
            {
                var result = Alterar(_cargoRepository, cargo);
                return SucessRequestClass(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is DuplicidadeRegistroException)
                    return BadRequestMessage(ex.Message);

                return BadRequestMessage(ErrorMessage.RegistroAlterado);
            }
        }

        [Route("cargo/id")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Excluir(_cargoRepository, id);
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