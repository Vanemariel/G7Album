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

        [HttpGet("GetAllColecction")]
        // metodo que me muestra la lista completa  
        public async Task<ActionResult<ResponseDto<List<ColeccionData>>>> GetAll()
        {
            ResponseDto<List<ColeccionData>> ResponseDto = new ResponseDto<List<ColeccionData>>();
            List<ColeccionData> ListColeccion = new List<ColeccionData>();
            try
            {
                List<ColeccionAlbum> ListaColeccionAlbumes = await context.TablaColeccionAlbumes.Include(x => x.ListadoAlbum).ToListAsync();

                foreach (ColeccionAlbum coleccion in ListaColeccionAlbumes)
                {
                    ListColeccion.Add(new ColeccionData
                    {
                        Id = coleccion.Id,
                        NombreCompleto = coleccion.TituloColeccion
                    });
                }

                ResponseDto.Result = ListColeccion;

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }

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


        [HttpGet("GetAllPage/{page:int}/{query}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<ColeccionAlbum>>>>> GetAll(int page,  string? query)
        {
            ResponseDto<Pagination<List<ColeccionAlbum>>> ResponseDto = new ResponseDto<Pagination<List<ColeccionAlbum>>>();
            Pagination<List<ColeccionAlbum>> Pagination = new Pagination<List<ColeccionAlbum>>();

            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(
                    context.TablaColeccionAlbumes.Where(x => x.TituloColeccion.Contains(query)).Count() 
                    / 
                    pageResults
                );

                List<ColeccionAlbum> albumColeccion = await context.TablaColeccionAlbumes
                    .Where(x => x.TituloColeccion.Contains(query))
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
        public async Task<ActionResult<ResponseDto<string>>> Put(int id, [FromBody] DataColeccion Coleccion)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                var albumcoleccion = context.TablaColeccionAlbumes.Where(x => x.Id == id).FirstOrDefault();

                if (albumcoleccion == null)
                {
                    throw new Exception("No existe el Album a modificar");
                }

                albumcoleccion.TituloColeccion = Coleccion.Titulo;

                context.TablaColeccionAlbumes.Update(albumcoleccion);
                context.SaveChanges();

                ResponseDto.Result = "Se ha actualizado correctamente";

                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Error al actualizar: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseDto<string>>> Post(DataColeccion coleccionForm)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                ColeccionAlbum coleccion = new ColeccionAlbum
                {
                    TituloColeccion = coleccionForm.Titulo
                };

                context.TablaColeccionAlbumes.Add(coleccion);
                await context.SaveChangesAsync();

                ResponseDto.Result = "Se ha creado correctamente";
                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error al crear una Coleccion: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDto<string>>> Delete(int id)
        {

            ResponseDto<string> ResponseDto = new ResponseDto<string>();

            try
            {
                var albumcoleccion = context.TablaColeccionAlbumes.Where(x => x.Id == id).FirstOrDefault();

                if (albumcoleccion == null)
                {
                    throw new Exception($"La coleccion {id} no fue encontrado");
                }

                context.TablaColeccionAlbumes.Remove(albumcoleccion);
                context.SaveChanges();
                ResponseDto.Result = "Se ha borrado correctamente";

                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Error al eliminar un Album: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }
    }
}
