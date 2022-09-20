

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/AlbumImagenImpresa")]
    public class AlbumImagenImpresaController: ControllerBase
    {
        private readonly BDContext context;

        public AlbumImagenImpresaController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task <ActionResult<List<AlbumImagenImpresa>>> Get()
        {
            return await context.TablaImagenesImpresas.Include(x => x.AlbumImagenes)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task <ActionResult<AlbumImagenImpresa>> Get(int id)
        {
            var AlbImaImpres = await context.TablaImagenesImpresas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(AlbImaImpres == null)
            {
                return NotFound($"No existe la imagen impresa con Id = {id}");
            }

            return AlbImaImpres;
        }

        [HttpPost]

        public async Task<ActionResult<AlbumImagenImpresa>> Post(AlbumImagenImpresa imag)
        {
            try
            {
                context.TablaImagenesImpresas.Add(imag);
                await context.SaveChangesAsync();
                return imag;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] AlbumImagenImpresa imag)
        {
            if(id != imag.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var imagen = context.TablaImagenesImpresas.Where(x => x.Id == id).FirstOrDefault();

            if(imagen == null)
            {
                return NotFound("No existe la imagen a modificar");
            }

            imagen.CodigoImagenImpresa = imag.CodigoImagenImpresa;
            imagen.PathImagenImpreso = imag.PathImagenImpreso;

            try
            {
                context.TablaImagenesImpresas.Update(imagen);
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
            var imagen = context.TablaImagenesImpresas.Where(x => x.Id == id).FirstOrDefault();

            if(imagen == null)
            {
                return NotFound($"La imagen {id} no fue encontrada");
            }

            try
            {
                context.TablaImagenesImpresas.Remove(imagen);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no se pudieron eliminarse por :{ e.Message}");
            }
        }

    }

    
}
