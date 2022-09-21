using G7Album.Shared.Models;
using G7Album.Shared.Models.ModelsDTO;
using G7Album.Shared.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AlbumImagenesController : ControllerBase
    {
        private readonly BDContext context;

        public AlbumImagenesController(BDContext context)
        {
            this.context = context;
        }
        
        /*[HttpGet]

        public async Task<Response<PagedData<List<AlbumImagenes>>>> Get(int Page = 1)
        {
            var query = new QueryProperty<AlbumImagenes>(Page, 10);
            var paged = new PagedData<List<AlbumImagenes>>(
                await context.TablaImagenes.ToListAsync(), await CountElements(), Page, 10, "AlbumImagenes");
            var response = new Response<PagedData<List<AlbumImagenes>>>(paged);

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFound;
                response.Errors = new string[] { "404" };
            }

            return response;
        }*/

        [HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<List<AlbumImagenes>>> GetAll()
        {
            return await context.TablaImagenes.Include(x => x.Album).ToListAsync();
        }

        [HttpGet("Get/one/{id:int}")]
        public async Task<ActionResult<AlbumImagenes>> GetById(int id)
        {
            AlbumImagenes usua = await context.TablaImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro donde esta el id 
            if (usua == null)
            {
                return NotFound($"No existe el AlbumImagen usuario con id igual a {id}.");
            }
            return usua;

        }

        [HttpPost]
        //verbo es el http post, pero a la base de datos ingresa como un insert
        public async Task<ActionResult<AlbumImagenes>> Insert(AlbumImagenes albumImg)
        {
            try
            {
                context.TablaImagenes.Add(albumImg);
                await context.SaveChangesAsync();
                return albumImg;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        //metodo que sirve para modificar resultados 
        public async Task<ActionResult> Modified(int id, [FromBody] AlbumImagenes img)
        {
            AlbumImagenes AlbumImgs = await context.TablaImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (AlbumImgs == null)
            {
                return NotFound("no existe el AlbumUsuario a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            AlbumImgs.NumeroImagen = img.NumeroImagen;
            AlbumImgs.CodigoImagenOriginal = img.CodigoImagenOriginal;
            AlbumImgs.CantidadImpresa = img.CantidadImpresa;
            AlbumImgs.PathModeloImagen = img.PathModeloImagen;
            AlbumImgs.Descripcion = img.Descripcion;

            try
            {
                context.TablaImagenes.Update(AlbumImgs);
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
            AlbumImagenes albunUsuario = await context.TablaImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (albunUsuario == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el AlbumUsuario con id igual a {id}.");//retorna error
            }
            try
            {
                context.TablaImagenes.Remove(albunUsuario);
                await context.SaveChangesAsync();//busca el dato guardado

                return Ok($"El AlbumUsuario {albunUsuario} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }       
        }
        public async Task<int> CountElements() => await context.SaveChangesAsync(); 
        //public async Task<int> CountElements() => await _unitOfWork.CategoriesRepository.CountElements();
    }
}
