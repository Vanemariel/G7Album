


namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly BDContext context;

        public AlbumController(BDContext context)
        {
            this.context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Album>>> GetAll()//obtener todo All
        {
            try
            {
                List<Album> Albumes = await context.TablaAlbumes.ToListAsync();
                return Ok(Albumes); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpGet("GetOne/{id:int}")]
        public async Task<ActionResult<Album>> GetById(int id)
        {

            try
            {
                Album Album = await context.TablaAlbumes
                    .Where(Album => Album.Id == id)
                    .FirstOrDefaultAsync();

                if (Album == null)
                {
                    throw new Exception($"no existe el Album con id igual a {id}.");
                }

                return Ok(Album);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateAlbum(Album Album)
        {
            try
            {
                context.TablaAlbumes.Add(Album);
                await context.SaveChangesAsync();
                return Ok("Se ha creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<string>> UpdateAlbum(int id, [FromBody] Album NewAlbum)
        {
            try
            {
                Album FindAlbum = await context.TablaAlbumes
                    .Where(Album => Album.Id == id)
                    .FirstOrDefaultAsync();

                if (FindAlbum == null)
                {
                    throw new Exception("No existe el Album a modificar.");
                }

                FindAlbum.Id = FindAlbum.Id;
                FindAlbum.CodigoAlbum = NewAlbum.CodigoAlbum;
                FindAlbum.Titulo = NewAlbum.Titulo;
                FindAlbum.Descripcion = NewAlbum.Descripcion;
                FindAlbum.CantidadImagen = NewAlbum.CantidadImagen;
                FindAlbum.CantidadImpreso = NewAlbum.CantidadImpreso;
                FindAlbum.Desde = NewAlbum.Desde;
                FindAlbum.Hasta = NewAlbum.Hasta;

                context.TablaAlbumes.Update(FindAlbum);

                await context.SaveChangesAsync();

                return Ok("Los datos han sido actualizados correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("El Id ingresado no es valido.");
                }

                Album FindAlbum = await context.TablaAlbumes
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (FindAlbum == null)
                {
                    throw new Exception($"No existe el Album con id igual a {id}.");
                }

                context.TablaAlbumes.Remove(FindAlbum);
                await context.SaveChangesAsync();

                return Ok($"El Album {FindAlbum.Titulo} ha sido borrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }

    }
}

