using G7Album.Shared.Models;
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

        //[HttpGet()]
        //public async Task<Response<PagedData<List<AlbumImagenes>>>> GetAll(int Page = 1)
        //{
        //    var query = new QueryProperty<AlbumImagenes>(Page, 10);
        //    var paged = new PagedData<List<AlbumImagenes>>(
        //        await context.TablaImagenes.ToListAsync(), CountElements(), Page, 10, "AlbumImagenes");
        //    var response = new Response<PagedData<List<AlbumImagenes>>>(paged);
        //    //count element es un metodo

        //    if (response.Data == null)
        //    {
        //        response.Succeeded = false;
        //        response.Message = ResponseMessage.NotFound;
        //        response.Errors = new string[] { "404" };
        //    }

        //    return response;
        //}
        ////true viene del manejo del try catch--
        //private int CountElements() => context.TablaAlbumes.Count();

        // [HttpGet("{page:int}")]
        /*public async Task<ActionResult<List<AlbumImagenes>>> GetAll(int page)
        {
            if (context.TablaImagenes == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaImagenes.Count() / pageResults);

                var albumimagen = await context.TablaImagenes
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .ToListAsync();

                var response = new Response<string>
                {
                    TablaImagenes = albumimagen,
                    CurrentPage = page,
                    Pages = (int)pageCount
                };
                return Ok(response);
        }*/

        [HttpGet("GetAllPage/{page:int}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<AlbumImagenes>>>>> GetAll(int page)
        {
            ResponseDto<Pagination<List<AlbumImagenes>>> ResponseDto = new ResponseDto<Pagination<List<AlbumImagenes>>>();
            Pagination<List<AlbumImagenes>> Pagination = new Pagination<List<AlbumImagenes>>();

            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaImagenes.Count() / pageResults);

                List<AlbumImagenes> albumImagenes = await context.TablaImagenes
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.Album)
                    .ToListAsync();

                Pagination.ListItems = albumImagenes;
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


        // [HttpGet("GetAllPage/{page:int}/{query}")]
        // public async Task<ActionResult<ResponseDto<Pagination<List<AlbumImagenes>>>>> GetAll(int page, string? query)
        // {
        //     ResponseDto<Pagination<List<AlbumImagenes>>> ResponseDto = new ResponseDto<Pagination<List<AlbumImagenes>>>();
        //     Pagination<List<AlbumImagenes>> Pagination = new Pagination<List<AlbumImagenes>>();

        //     try
        //     {
        //         var pageResults = 3f;
        //         var pageCount = Math.Ceiling(context.TablaImagenes.Count() / pageResults);

        //         List<AlbumImagenes> albumImagenes = await context.TablaImagenes
        //             .Skip((page - 1) * (int)pageResults)
        //             .Take((int)pageResults)
        //              .Where(x => x.Titulo.Contains(query))
        //             .Include(x => x.Album)
        //             .ToListAsync();

        //         Pagination.ListItems = albumImagenes;
        //         Pagination.CurrentPage = page;
        //         Pagination.Pages = (int)pageCount;

        //         ResponseDto.Result = Pagination;


        //         return Ok(ResponseDto);
        //     }
        //     catch (Exception ex)
        //     {
        //         ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
        //         return BadRequest(ResponseDto);
        //     }
        // }



        /*[HttpGet("GetAll")]
        //metodo que me muestra la lista completa  
        public async Task<ActionResult<List<AlbumImagenes>>> GetAll()
        {
            return await context.TablaImagenes.Include(x => x.Album).ToListAsync();
        }*/

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
        public async Task<ActionResult<ResponseDto<string>>> AgregarAlbum(AlbumImagenes albumImg)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                context.TablaImagenes.Add(albumImg);
                await context.SaveChangesAsync();

                ResponseDto.Result = "Se ha creado correctamente";
                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error al crear una figurita: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseDto<string>>> UpdataAlbum(int id, [FromBody] AlbumImagenes img)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                AlbumImagenes AlbumImgs = await context.TablaImagenes.Where(x => x.Id == id).FirstOrDefaultAsync();
                //si mi id es null no existe 
                if (AlbumImgs == null)
                {
                    throw new Exception("no existe el AlbumUsuario a modificar.");
                }
                //si es correcto puedo modificar todo lo q sigue
                AlbumImgs.NumeroImagen = img.NumeroImagen;
                AlbumImgs.CodigoImagenOriginal = img.CodigoImagenOriginal;
                AlbumImgs.CantidadImpresa = img.CantidadImpresa;
                AlbumImgs.Imagen = img.Imagen;
                //AlbumImgs.Descripcion = img.Descripcion;
                AlbumImgs.Titulo = img.Titulo;


                context.TablaImagenes.Update(AlbumImgs);
                await context.SaveChangesAsync();

                ResponseDto.Result = "Se ha actualizado correctamente";

                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = e.Message;
                return BadRequest(ResponseDto);
            }
        }


        //public async Task<int> CountElements() => await context.TablaImagenes(); 
        //public async Task<int> CountElements() => await context.Set<AlbumImagenes>().CountAsync();
        //count async devuelve de manera asincrona el n de elementos de una tabla,
        //osea la cantidad de registro.

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDto<string>>> Delete(int id)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                var album = context.TablaImagenes.Where(x => x.Id == id).FirstOrDefault();

                if (album == null)
                {
                    throw new Exception($"La figurita {id} no fue encontrado");
                }
                context.TablaImagenes.Remove(album);
                context.SaveChanges();
                ResponseDto.Result = "Se ha borrado correctamente";

                return Ok(ResponseDto);
            }
            catch (Exception e)
            {
                ResponseDto.MessageError = $"Error al eliminar la figurita: {e.Message}";
                return BadRequest(ResponseDto);
            }
        }
    }
}
