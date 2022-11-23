using G7Album.Shared.DTO_Back;
using G7Album.Shared.Models;
using System.Collections.Generic;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/ColeccionAlbum")]
    public class ColeccionAlbumController : ControllerBase
    {
        private readonly BDContext context;

        public ColeccionAlbumController(BDContext context)
        {
            this.context = context;
        }

        //[HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        //public async Task<ActionResult<ResponseDto<List<ColeccionAlbum>>>> GetAll()
        //{
        //     ResponseDto<List<ColeccionAlbum>> ResponseDto = new ResponseDto<List<ColeccionAlbum>>();

        //    try
        //    {
        //        List<ColeccionAlbum> ListaColeccionAlbumes = await context.TablaColeccionAlbumes.Include(x => x.ListadoAlbum).ToListAsync();

        //        ResponseDto.Result = ListaColeccionAlbumes;

        //        return Ok(ResponseDto); 
        //    }
        //    catch (Exception ex)
        //    {
        //        ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
        //        return BadRequest(ResponseDto);
        //    }
        //}

        [HttpGet("GetAllPage/{page:int}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<ColeccionAlbum>>>>> GetAll(int page)
        {
            ResponseDto<Pagination<List<ColeccionAlbum>>> ResponseDto = new ResponseDto<Pagination<List<ColeccionAlbum>>>();
            Pagination<List<ColeccionAlbum>> Pagination = new Pagination<List<ColeccionAlbum>>();

            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaColeccionAlbumes.Count() / pageResults);

                List<ColeccionAlbum> albumColeccion = await context.TablaColeccionAlbumes
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.ListadoAlbum)
                    .ToListAsync();

                Pagination.ListItems = albumColeccion;
                Pagination.CurrentPage = page;
                Pagination.Pages = (int)pageCount;

                ResponseDto.Result = Pagination;

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put (int id, [FromBody] string TituloColeccion)
        {
            var albumcoleccion = context.TablaColeccionAlbumes.Where(x => x.Id == id).FirstOrDefault();

            if (albumcoleccion == null)
            {
                return NotFound("No existe el Album a modificar");
            }

            albumcoleccion.TituloColeccion = TituloColeccion;

            try
            {
                context.TablaColeccionAlbumes.Update(albumcoleccion);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Los datos no han sido actualizados");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var albumcoleccion = context.TablaColeccionAlbumes.Where(x => x.Id == id).FirstOrDefault();

            if (albumcoleccion == null)
            {
                return NotFound($"El Album {id} no fue encontrado");
            }

            try
            {
                context.TablaColeccionAlbumes.Remove(albumcoleccion);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no se pudieron eliminarse por :{e.Message}");
            }
        }
    }
}
    