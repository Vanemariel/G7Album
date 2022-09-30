using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

using G7Album.Shared.DTO_Back;
using G7Album.Shared.DTO_Front;

namespace G7Album.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly BDContext _context;
        private readonly IConfiguration _configuration;


        public UsuarioController(BDContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetAll()
        {
            ResponseDto<List<User>> ResponseDto = new ResponseDto<List<User>>();

            try
            {
                List<Usuario> Usuarios = await this._context.TablaUsuarios.ToListAsync();

                List<User> ListUserMapper = new List<User> {};

                Usuarios.ForEach(Usuario => {
                    ListUserMapper.Add( new User {
                        Email = Usuario.Email,
                        Id = Usuario.Id,
                        NombreCompleto = Usuario.NombreCompleto
                    });
                });

                ResponseDto.Result = ListUserMapper;

                return Ok(ResponseDto); 
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpGet("GetOne/{id:int}")]
        public async Task<ActionResult<ResponseDto<User>>> GetById(int id)
        {
            ResponseDto<User> ResponseDto = new ResponseDto<User>();

            try
            {
                Usuario? Usuario = await this._context.TablaUsuarios
                    .Where(Usuario => Usuario.Id == id)
                    .FirstOrDefaultAsync();
 
                if (Usuario == null)
                {
                    throw new Exception($"no existe el Usuario con id igual a {id}.");
                }

                User UserMapper = new User {
                    Email = Usuario.Email,
                    Id = Usuario.Id,
                    NombreCompleto = Usuario.NombreCompleto
                };

                ResponseDto.Result = UserMapper;

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpPost("Create")]
        public async Task<ActionResult<ResponseDto<string>>> Register(DataRegisterForm newUsuario)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
             
            try
            {

                if (newUsuario.EmailRegister == null || newUsuario.EmailRegister == string.Empty)
                {
                    throw new Exception("Email requerido");
                }

                if (newUsuario.NombreCompleto == null || newUsuario.NombreCompleto == string.Empty)
                {
                    throw new Exception("Nombre de usuario requerido");
                }

                if (newUsuario.PasswordRegister == null || newUsuario.PasswordRegister == string.Empty)
                {
                    throw new Exception("Contraseña requerida");
                }

                if (newUsuario.PasswordRegister != newUsuario.ConfirmPassword)
                {
                    throw new Exception("La contraseñas deben coincidir.");
                }

                Usuario? UserBD = await this._context.TablaUsuarios.FirstOrDefaultAsync(
                    Usuario => Usuario.Email == newUsuario.EmailRegister
                );

                if (UserBD != null)
                {
                    throw new Exception("Ya existe un usuario con este email. Intentelo nuevamente.");
                }

                var (passwordHash, passwordSalt) = CreatePasswordHash(newUsuario.PasswordRegister);

                this._context.TablaUsuarios.Add(new Usuario
                {
                    Email = newUsuario.EmailRegister,
                    NombreCompleto = newUsuario.NombreCompleto,
                    Password = passwordHash,
                    PasswordSalt = passwordSalt
                });

                await this._context.SaveChangesAsync();

                ResponseDto.Result = "!Se ha registrado correctamente! Ahora inicie sesión!.";

                return Ok(ResponseDto);

            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = ex.Message;
                return BadRequest(ResponseDto);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseDto<AuthData>>> Login(DataLoginForm UsuarioData)
        {
            ResponseDto<AuthData> ResponseDto = new ResponseDto<AuthData>();

            try
            {
                if (UsuarioData.Email == null || UsuarioData.Email == string.Empty)
                {
                    throw new Exception("Email incorrecto");
                }

                if (UsuarioData.Password == null || UsuarioData.Password == string.Empty)
                {
                    throw new Exception("Contraseña incorrecta");
                }

                Usuario? UserBD = await this._context.TablaUsuarios.FirstOrDefaultAsync(Usuario => Usuario.Email == UsuarioData.Email);

                if (UserBD == null)
                {
                    throw new Exception("Email ingresado es incorrecto");
                }
                
                if (!this.VerifyPasswordHash(UsuarioData.Password, UserBD.Password ,UserBD.PasswordSalt))
                {
                    throw new Exception("Contraseña incorrecta");
                }

                ResponseDto.Result = new AuthData
                {
                    Token = CreateToken(UserBD), //Creamos un nuevo metodo y obtiene usuario
                    User = new User
                    {
                        Email = UserBD.Email,
                        Id = UserBD.Id,
                        NombreCompleto = UserBD.NombreCompleto
                    },
                };
              
                return Ok(ResponseDto);

            }
            catch (Exception ex)
            { 
                ResponseDto.MessageError = ex.Message; 
                return BadRequest(ResponseDto);
            }      
        }


        [HttpPut("Edit/{id:int}")]
        public async Task<ActionResult<ResponseDto<string>>> UpdateAlbum(int id, [FromBody] Usuario NewUsuario)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();
            try
            {
                Usuario? FindUsuario = await this._context.TablaUsuarios
                    .Where(Usuario => Usuario.Id == id)
                    .FirstOrDefaultAsync();

                if (FindUsuario == null)
                {
                    throw new Exception("No existe el Usuario a modificar.");
                }

                FindUsuario.NombreCompleto = NewUsuario.NombreCompleto;
                FindUsuario.Email = NewUsuario.Email ;
                FindUsuario.Password = NewUsuario.Password ;

                this._context.TablaUsuarios.Update(FindUsuario);

                await this._context.SaveChangesAsync();


                ResponseDto.Result = "Los datos han sido actualizados correctamente.";
                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }


        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult<ResponseDto<string>>> Delete(int id)
        {
            ResponseDto<string> ResponseDto = new ResponseDto<string>();

            try
            {
                if (id <= 0)
                {
                    throw new Exception("El Id ingresado no es valido.");
                }

                Usuario? FindUsuario = await this._context.TablaUsuarios
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (FindUsuario == null)
                {
                    throw new Exception($"No existe el Usuario con id igual a {id}.");
                }

                this._context.TablaUsuarios.Remove(FindUsuario);
                await this._context.SaveChangesAsync();

                ResponseDto.Result = $"El Usuario {FindUsuario.NombreCompleto} ha sido borrado.";
                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.MessageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }
        }



        #region Metodos complementarios

        private (byte[], byte[]) CreatePasswordHash(string password)
        {
            byte[] passwordHash; 
            byte[] passwordSalt; 

            using (var hmac = new HMACSHA512()) //Algoritmo de firma 
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }

            return (passwordHash, passwordSalt);
        }

        private string CreateToken(Usuario user) 
        {
            //Permisos para describir la informacion del usuario
            List<Claim> claims = new List<Claim> 
            {
               new Claim(ClaimTypes.Email, user.Email) //Permiso de seguridad
            };
            
            //Clave simetrica
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(
                 this._configuration.GetSection("AppSettings:Token").Value // Obtenemos dato de appSettings para crear Token
                )
            ); 

                                   
            //Definimos la configuracion del token 
            var Credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);//Credenciales de firma 

            //Defino la carga del token 
            JwtSecurityToken token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.Now.AddHours(2),
               signingCredentials: Credencial
            ); 

            //Defino la cadena de token que quiero que retorne 
            var jwt = new JwtSecurityTokenHandler().WriteToken(token); 

            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        #endregion

    }

}