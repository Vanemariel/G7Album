
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

        [HttpGet("GetAllPage/{page:int}/{idUsuario:int}")]

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<ResponseDto<List<AlbumUsuario>>>> GetAll(int page, int idUsuario)
        {
            ResponseDto<Pagination<List<AlbumUsuario>>> ResponseDto = new ResponseDto<Pagination<List<AlbumUsuario>>>();
            Pagination<List<AlbumUsuario>> Pagination = new Pagination<List<AlbumUsuario>>();
           
            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaAlbumesUsuarios.Where(x => x.UsuarioId == idUsuario).Count() / pageResults);

                List<AlbumUsuario> ListadoMisAlbumes = await context.TablaAlbumesUsuarios
                    .Where(x => x.UsuarioId == idUsuario)
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.Album)
                    .Include(x => x.Usuario)
                    .ToListAsync();


                Pagination.ListItems = ListadoMisAlbumes;
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

        [HttpGet("Get/one{id:int}")]
        public async Task<ActionResult<AlbumUsuario>> GetById(int idAlbum)
        {
            AlbumUsuario usua = await context.TablaAlbumesUsuarios.Where(x => x.Id == idAlbum).FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (usua == null)
            {
                return NotFound($"No existe el Albumusuario con id igual a {idAlbum}.");
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

        [HttpPost("BuyAlbum")]
        //verbo es el http post, pero a la base de datos ingresa como un insert
        public async Task<ActionResult<string>> BuyAlbum(DataAlbumSend DataAlbumSend)
        {

            ResponseDto<string> ResponseDto = new ResponseDto<string>();

            try
            {
                if (DataAlbumSend.IdUsuario == 0 || DataAlbumSend.IdAlbum == 0)
                {
                    throw new Exception("debe enviar todos los datos requeridos");
                }

                Usuario? Usuario = await this.context.TablaUsuarios
                    .Where(Usuario => Usuario.Id == DataAlbumSend.IdUsuario)
                    .FirstOrDefaultAsync();


                if (Usuario == null )
                {
                    throw new Exception($"no existe el Usuario con id igual a {DataAlbumSend.IdUsuario}.");
                }

                Album? Album = await this.context.TablaAlbumes
                    .Where(Album => Album.Id == DataAlbumSend.IdAlbum)
                    .FirstOrDefaultAsync();

                if (Album == null)
                {
                    throw new Exception($"no existe el Album con id igual a {DataAlbumSend.IdAlbum}.");
                }

                
                AlbumUsuario? AlbumComprado = await context.TablaAlbumesUsuarios
                    .Where(AlbumComprado => AlbumComprado.AlbumId == DataAlbumSend.IdAlbum)
                    .Where(AlbumComprado => AlbumComprado.UsuarioId == DataAlbumSend.IdUsuario)
                    .FirstOrDefaultAsync();


                if (AlbumComprado != null)
                {
                    throw new Exception("ya has comprado este Album!");
                }

                AlbumUsuario AlbumCompra = new AlbumUsuario {
                    AlbumId = DataAlbumSend.IdAlbum,
                    UsuarioId = DataAlbumSend.IdUsuario
                };

                context.TablaAlbumesUsuarios.Add(AlbumCompra);
                
                await this.context.SaveChangesAsync();

                ResponseDto.Result = "Se ha comprado un Album correctamente"; 

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }

        [HttpPut]
        //metodo que sirve para modificar resultados 
        public async Task<ActionResult> UodateAlbumUsuario(int id, [FromBody] AlbumUsuario persona)
        {

            try
            {
                AlbumUsuario Albumpersona = await context.TablaAlbumesUsuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                //si mi id es null no existe 
                if (Albumpersona == null)
                {
                    return NotFound("no existe el AlbumUsuario a modificar.");
                }

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

