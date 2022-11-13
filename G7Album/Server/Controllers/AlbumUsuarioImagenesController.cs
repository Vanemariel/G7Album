using G7Album.Shared.Models;

namespace G7Album.Server.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]


    // es la clase que nos proporciona WebApi para que hereden nuestros controladores
  //  Por lo que al querer pegarle a este controller, desde el front  deberemos utilizar algun metodo HTTP dirigido hacia "api/SuperHero", como por ejemplo:
    
   //  await Http.GetFromJsonAsync<SuperHero[]>("api/SuperHero");


    public class AlbumUsuarioImagenesController : ControllerBase
    {
        // variable privada y de solo lectura (llamada a la bd)
        private readonly BDContext context; 

        public AlbumUsuarioImagenesController(BDContext context)
        {
            this.context = context; // para acceso a base de datos
        }

        /*[HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
            public async Task<ActionResult<List<AlbumUsuarioImagenes>>> GetAll()
            {
            
                return await context.TablaUsuarioImagenes
                .Include(x => x.AlbumUsuario)
                    .Include(x => x.AlbumImagenImpresa)
                    .ToListAsync();
            }*/

        /*public async Task<ActionResult<List<AlbumUsuarioImagenes>>> GetAll(int page)
        {
            if (context.TablaUsuarioImagenes == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.TablaUsuarioImagenes.Count() / pageResults);

            var albumusuarioimagen = await context.TablaUsuarioImagenes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new Response<string>
            {
                TablaUsuarioImagenes = albumusuarioimagen,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }*/
        [HttpGet("GetAllPage/{page:int}/{idUsuario:int}/{idAlbum:int}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<AlbumUsuarioImagenes>>>>> GetAll(int page, int idUsuario, int idAlbum)
        {
            ResponseDto<Pagination<List<AlbumUsuarioImagenes>>> ResponseDto = new ResponseDto<Pagination<List<AlbumUsuarioImagenes>>>();
            Pagination<List<AlbumUsuarioImagenes>> Pagination = new Pagination<List<AlbumUsuarioImagenes>>();
            try
            {
                var pageResults = 3f;

                List<AlbumUsuarioImagenes> FigusUsuario = await context.TablaUsuarioImagenes
                    .Where(x => x.UsuarioId == idUsuario)
                    .Where(x => x.AlbumId == idAlbum)
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.AlbumImagenes)
                    .Include(x => x.AlbumImagenes.Album)
                    .ToListAsync();


                var pageCount = Math.Ceiling(FigusUsuario.Count() / pageResults);

                Pagination.ListItems = FigusUsuario;
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

        [HttpGet("GetOne/{id:int}")]
        public async Task<ActionResult<AlbumUsuarioImagenes>> GetById(int id)
        {
            //'await' para asegurarse de que se hayan completado todas las operaciones asincrónicas antes de llamar a otro método
            AlbumUsuarioImagenes? usua = await context.TablaUsuarioImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();  //Devuelve de forma asincrónica el primer elemento 
            //x=>x.id x seria el registro donde esta el id 
            if (usua == null)
            {
                return NotFound($"No existe el Albumusuario con id igual a {id}.");
            }
            return usua;
        }

        [HttpPost("buy/figus")]
        //verbo es el http post, pero a la base de datos ingresa como un insert
        public async Task<ActionResult<string>> buyFigus(ImagenesFiguritasBuy CompraFigus)
        //imagenesf es el tipo de dato y el otro es el objeto
        {

            ResponseDto<string> ResponseDto = new ResponseDto<string>();

            try
            {
                //cuando envio el dato numerico el vallor x defecto es 0 por lo que entonces el dato no fue enviado
                //aca se aplkica la excepcion de error
                if (CompraFigus.IdUsuario == 0 || CompraFigus.IdAlbumImagen == 0)
                {
                    throw new Exception("debe enviar todos los datos requeridos");
                }

                
                //? significa que posiblemente puede ser nulo
                Usuario? Usuario = await this.context.TablaUsuarios//busco el usuario x id
                    .Where(Usuario => Usuario.Id == CompraFigus.IdUsuario)//valido
                    .FirstOrDefaultAsync();
                //valido si el usuario existe 
                if (Usuario == null )
                {
                    throw new Exception($"no existe el Usuario con id igual a {CompraFigus.IdUsuario}.");
                }

                    //LOGICA DE NEGOCIO
                
                AlbumUsuario? AlbumComprado = await this.context.TablaAlbumesUsuarios
                    .Where(x => x.AlbumId == CompraFigus.IdAlbum)
                    .Where(Usuario => Usuario.Id == CompraFigus.IdUsuario)
                    .FirstOrDefaultAsync();

                if (AlbumComprado == null)
                {
                    throw new Exception($"para comprar esta figura, debe tener primero, su respectivo Album");
                }

                //valido si ya lo compre para no adquirir la misma figus
                AlbumUsuarioImagenes? FiguritaComprada = await context.TablaUsuarioImagenes //imagen comprada es lo 
                //q me devuelve la base de datos
                    .Where(Figuritas => Figuritas.AlbumImagenesId == CompraFigus.IdAlbumImagen) //lo llamo unitario
                    .Where(Figuritas => Figuritas.UsuarioId == CompraFigus.IdUsuario)
                    .FirstOrDefaultAsync();

                if (FiguritaComprada != null)
                {
                    throw new Exception("ya compraste esta figurita!");
                }
                
                
                AlbumUsuarioImagenes AlbumCompra = new AlbumUsuarioImagenes {
                    AlbumImagenesId = CompraFigus.IdAlbumImagen,
                    UsuarioId = CompraFigus.IdUsuario,
                    AlbumId = CompraFigus.IdAlbum
                };

                context.TablaUsuarioImagenes.Add(AlbumCompra);
                
                await this.context.SaveChangesAsync();

                ResponseDto.Result = "Se ha comprado esta figurita correctamente"; 

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpPost]
        //verbo es el http post, pero a la base de datos ingresa como un insert //llamada de accion
        public async Task<ActionResult<AlbumUsuarioImagenes>> Insert(AlbumUsuarioImagenes nuevodato)
        {
            try
            {
                context.TablaUsuarioImagenes.Add(nuevodato);
                await context.SaveChangesAsync();
                return nuevodato;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        //metodo que sirve para modificar resultados 
        public async Task<ActionResult> Modified(int id, [FromBody] AlbumUsuarioImagenes persona)
        {
            //Albumpersona
            AlbumUsuarioImagenes? Albumpersona = await context.TablaUsuarioImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (Albumpersona == null)
            {
                return NotFound("no existe el AlbumUsuario a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            // Albumpersona.AlbumUsuarioId = persona.AlbumUsuarioId;

            try
            {
                context.TablaUsuarioImagenes.Update(Albumpersona);
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
            AlbumUsuarioImagenes? albumUsuario = await context.TablaUsuarioImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (albumUsuario == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el AlbumUsuario con id igual a {id}.");//retorna error
            }
            try //señala un bloque de instrucciones a intentar (try), y especifica una respuesta si se produce una excepción (catch).
            {
                context.TablaUsuarioImagenes.Remove(albumUsuario);
                await context.SaveChangesAsync();//busca el dato guardado

                return Ok($"El Usuario {id} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
