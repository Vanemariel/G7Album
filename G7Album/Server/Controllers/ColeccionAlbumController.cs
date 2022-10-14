using G7Album.Shared.DTO_Back;
using G7Album.Shared.Models;

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

        [HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<ResponseDto<List<ColeccionAlbum>>>> GetAll()
        {
             ResponseDto<List<ColeccionAlbum>> ResponseDto = new ResponseDto<List<ColeccionAlbum>>();

            try
            {
                List<ColeccionAlbum> ListaColeccionAlbumes = await context.TablaColeccionAlbumes.Include(x => x.ListadoAlbum).ToListAsync();

                ResponseDto.Result = ListaColeccionAlbumes;

                return Ok(ResponseDto); 
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }
    }
}