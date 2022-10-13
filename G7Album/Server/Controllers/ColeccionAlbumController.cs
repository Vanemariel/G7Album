using G7Album.Shared.Models;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/ColecctionAlbum")]
    public class ColecctionAlbumController : ControllerBase
    {
        private readonly BDContext context;

        public ColecctionAlbumController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<List<ColecctionAlbumController>>> GetAll()
        {
            return await context.TablaColeccionAlbumes.Include(x => x.ListadoAlbum).ToListAsync();
        }

    }