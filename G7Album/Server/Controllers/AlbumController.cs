﻿using G7Album.Shared.Models;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/Album")]
    public class AlbumController : ControllerBase
    {
        private readonly BDContext context;

        public AlbumController(BDContext context)
        {
            this.context = context;
        }
        /*[HttpGet]
        public async Task<ActionResult<List<Album>>> Get()
        {
            return await context.TablaAlbumes.ToListAsync(); a
        }*/

        /*public async Task<ActionResult<List<Album>>> GetAll(int page)
        {
            if (context.TablaAlbumes == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.TablaAlbumes.Count() / pageResults);

            var album = await context.TablaAlbumes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new Response<string>
            {
                TablaAlbumes = album,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }*/


        /*[HttpGet("{id:int}")]
        public async Task<ActionResult<Album>> GetById(int id)
        {
            var album = await context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (album == null)
            {
                return NotFound($"No existe el Album con Id = {id}");
            }
            return album;
        }*/

        [HttpGet("GetAllPage/{page:int}")]
        public async Task<ActionResult<ResponseDto<Pagination<List<Album>>>>> GetAll(int page)
        {
            ResponseDto<Pagination<List<Album>>> ResponseDto = new ResponseDto<Pagination<List<Album>>>();
            Pagination<List<Album>> Pagination = new Pagination<List<Album>>();
            try
            {
                var pageResults = 3f;
                var pageCount = Math.Ceiling(context.TablaAlbumes.Count() / pageResults);

                List<Album> album = await context.TablaAlbumes
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .Include(x => x.ListadoImagenes)
                    .ToListAsync();

                Pagination.ListItems = album;
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


        [HttpPost]
        public async Task<ActionResult<Album>> Post (Album album)
        {
            try
            {
                context.TablaAlbumes.Add(album);
                await context.SaveChangesAsync();
                return album;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        // public ActionResult Put (int id, [FromBody] Album alb)
        public ActionResult Put (int id, [FromBody] string titulo)
        {
            // if (id != alb.Id)
            // {
            //     return BadRequest("Datos incorrectos");
            // }

            var album = context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefault();

            if (album == null)
            {
                return NotFound("No existe el Album a modificar");
            }

            // album.CantidadImagen = alb.CantidadImagen;
            // album.CantidadImpreso = alb.CantidadImpreso;
            // album.CodigoAlbum = alb.CodigoAlbum;
            // album.Descripcion = alb.Descripcion;
            // album.Desde = alb.Desde;
            // album.Hasta = alb.Hasta;
            album.Titulo = titulo;

            try
            {
                context.TablaAlbumes.Update(album);
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
            var album = context.TablaAlbumes.Where(x => x.Id == id).FirstOrDefault();

            if (album == null)
            {
                return NotFound($"El Album {id} no fue encontrado");
            }

            try
            {
                context.TablaAlbumes.Remove(album);
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