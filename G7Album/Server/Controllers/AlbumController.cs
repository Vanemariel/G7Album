using G7Album.Shared.Models;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/Album")]
    public class AlbumController : ControllerBase
    {
        private readonly BDContext context;

        public AlbumController(BDContext context)
        {
            this.context = context;
        }
        /*[HttpGet]
        public async Task<ActionResult<List<Album>>> Get()
        {
            return await context.TablaAlbumes.ToListAsync(); a
        }*/

        /*public async Task<ActionResult<List<Album>>> GetAll(int page)
        {
            if (context.TablaAlbumes == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.TablaAlbumes.Count() / pageResults);

            var album = await context.TablaAlbumes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new Response<string>
            {
                TablaAlbumes = album,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }*/


        /*[HttpGet("{id:int}")]
        public async Task<ActionResult<Album>> GetById(int id)
        {
            var album = await context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (album == null)
            {
                return NotFound($"No existe el Album con Id = {id}");
            }
            return album;
        }*/

        [HttpGet("GetAllPage/{page:int}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<Album>>>>> GetAll(int page)
        {
            ResponseDto<Pagination<List<Album>>> ResponseDto = new ResponseDto<Pagination<List<Album>>>();
            Pagination<List<Album>> Pagination = new Pagination<List<Album>>();
            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaAlbumes.Count() / pageResults);

                List<Album> album = new List<Album>();

                album = await context.TablaAlbumes
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.ListadoImagenes)
                    .ToListAsync();


                Pagination.ListItems = album;
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
        public async Task<ActionResult<ResponseDto<Pagination<List<Album>>>>> GetAll(int page, string? query)
        {
            ResponseDto<Pagination<List<Album>>> ResponseDto = new ResponseDto<Pagination<List<Album>>>();
            Pagination<List<Album>> Pagination = new Pagination<List<Album>>();
            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(
                    context.TablaAlbumes.Where(x => x.Titulo.Contains(query)).Count() 
                    / 
                    pageResults
                );

                List<Album> album = new List<Album>();
                
                album = await context.TablaAlbumes
                    .Where(x => x.Titulo.Contains(query))
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.ListadoImagenes)
                    .ToListAsync();

                Pagination.ListItems = album;
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

        [HttpPost]
        public async Task<ActionResult<ResponseDto<string>>> Post(DataAlbum albumForm)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                Album album = new Album
                {
                    Titulo = albumForm.Titulo,
                    Imagen = albumForm.ImgAlbum,
                    Descripcion = albumForm.Descripcion,
                    CodigoAlbum = albumForm.CodigoAlbum,
                    ColeccionAlbumId = albumForm.IdColeccion,
                    CantidadImagen = albumForm.CantidadImagen,
                    CantidadImpreso = albumForm.CantidadImpreso,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10)
                };

                context.TablaAlbumes.Add(album);
                await context.SaveChangesAsync();

                ResponseDto.Result = "Se ha creado correctamente";
                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error al crear un album: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpPut("{id:int}")]

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<ResponseDto<string>>> Put(int id, [FromBody] DataAlbum albumData)
        {

            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                Album? album = context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefault();

                if (album == null)
                {
                    throw new Exception("No existe el Album a modificar");
                }

                album.Imagen = albumData.ImgAlbum;
                album.Titulo = albumData.Titulo;
                album.CantidadImagen = albumData.CantidadImagen;
                album.CantidadImpreso = albumData.CantidadImpreso;
                album.Descripcion = albumData.Descripcion;
                album.CodigoAlbum = albumData.CodigoAlbum;

                context.TablaAlbumes.Update(album);
                await context.SaveChangesAsync();

                ResponseDto.Result = "Se ha actualizado correctamente";

                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = e.Message;
                return BadRequest(ResponseDto);
            }
        }


        [HttpDelete("{id:int}")]

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<ResponseDto<string>>> Delete(int id)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                var album = context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefault();

                if (album == null)
                {
                    throw new Exception($"El Album {id} no fue encontrado");
                }
                context.TablaAlbumes.Remove(album);
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