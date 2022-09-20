
namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly BDContext context;

        public UsuarioController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.TablaUsuarios.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usu = await context.TablaUsuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (usu == null)
            {
                return NotFound($"No existe el Usuario con Id = {id}");
            }
            return usu;
        }

        [HttpPost]

        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                context.TablaUsuarios.Add(usuario);
                await context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, [FromBody] Usuario usu)
        {
            if (id != usu.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var usuario = context.TablaUsuarios.Where(x => x.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound("No existe el usuario a modificar");
            }

            usuario.Email = usu.Email;
            usuario.Password = usu.Password;
            usuario.Nombre = usu.Nombre;
            usuario.Apellido = usu.Apellido;

            try
            {
                context.TablaUsuarios.Update(usuario);
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
            var usuario = context.TablaUsuarios.Where(x => x.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound($"El usuario {id} no fue encontrado");
            }

            try
            {
                context.TablaUsuarios.Remove(usuario);
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
