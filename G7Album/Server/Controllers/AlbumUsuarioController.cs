
namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AlbumUsuarioController : ControllerBase
    {
        private readonly BDContext context;

        public AlbumUsuarioController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<List<AlbumUsuario>>> GetAll()
        {
            return await context.TablaAlbumesUsuarios.Include(x => x.Album)
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        [HttpGet("Get/one{id:int}")]
        public async Task<ActionResult<AlbumUsuario>> GetById(int id)
        {
            AlbumUsuario usua = await context.TablaAlbumesUsuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (usua == null)
            {
                return NotFound($"No existe el Albumusuario con id igual a {id}.");
            }
            return usua;
        }

        [HttpPost]
        //verbo es el http post, pero a la base de datos ingresa como un insert
        public async Task<ActionResult<AlbumUsuario>> Insert(AlbumUsuario albumusuario)
        {
            try
            {
                context.TablaAlbumesUsuarios.Add(albumusuario);
                await context.SaveChangesAsync();
                return Ok("Se ha creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }

        [HttpPut]
        //metodo que sirve para modificar resultados 
        public async Task<ActionResult> Modified(int id, [FromBody] AlbumUsuario persona)
        {
            AlbumUsuario Albumpersona = await context.TablaAlbumesUsuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (Albumpersona == null)
            {
                return NotFound("no existe el AlbumUsuario a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            Albumpersona.CodigoAlbumUsuario = persona.CodigoAlbumUsuario;

            try
            {
                context.TablaAlbumesUsuarios.Update(Albumpersona);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            AlbumUsuario albumUsuario = await context.TablaAlbumesUsuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (albumUsuario == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el AlbumUsuario con id igual a {id}.");//retorna error
            }
            try
            {
                context.TablaAlbumesUsuarios.Remove(albumUsuario);
                await context.SaveChangesAsync();//busca el dato guardado

                return Ok($"El AlbumUsuario {albumUsuario} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

