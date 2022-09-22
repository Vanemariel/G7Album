
namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly BDContext context;

        public UsuarioController(BDContext context)
        {
            this.context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Album>>> GetAll()//obtener todo All
        {
            try
            {
                List<Usuario> Usuarios = await context.TablaUsuarios.ToListAsync();
                return Ok(Usuarios); 
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
                Usuario Usuario = await context.TablaUsuarios
                    .Where(Usuario => Usuario.Id == id)
                    .FirstOrDefaultAsync();
 
                if (Usuario == null)
                {
                    throw new Exception($"no existe el Album con id igual a {id}.");
                }

                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateAlbum(Usuario Usuario)
        {
            try
            {
                context.TablaUsuarios.Add(Usuario);
                await context.SaveChangesAsync();
                return Ok("Se ha creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<string>> UpdateAlbum(int id, [FromBody] Usuario NewUsuario)
        {
            try
            {
                Usuario FindUsuario = await context.TablaUsuarios
                    .Where(Usuario => Usuario.Id == id)
                    .FirstOrDefaultAsync();

                if (FindUsuario == null)
                {
                    throw new Exception("No existe el Usuario a modificar.");
                }

                FindUsuario.Nombre = NewUsuario.Nombre;
                FindUsuario.Apellido = NewUsuario.Apellido ;
                FindUsuario.Email = NewUsuario.Email ;
                FindUsuario.Password = NewUsuario.Password ;
               
                context.TablaUsuarios.Update(FindUsuario);

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

                Usuario FindUsuario = await context.TablaUsuarios
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (FindUsuario == null)
                {
                    throw new Exception($"No existe el Usuario con id igual a {id}.");
                }

                context.TablaUsuarios.Remove(FindUsuario);
                await context.SaveChangesAsync();

                return Ok($"El Usuario {FindUsuario.Nombre} ha sido borrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error, {ex.Message}");
            }
        }

    }

}
