using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class UsuarioController : ControllerBase
{
    private IUsuarioRepository repositorioUsuario;

    private readonly ILogger<UsuarioController> _logger;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        repositorioUsuario = new UsuarioRepository();
    }



    [HttpPost("Create")]
    public ActionResult<Usuario> Create(Usuario user)
    {
        repositorioUsuario.Create(user);
        return Ok();
    }


    [HttpGet("List")]
    public ActionResult<List<Usuario>> List()
    {
        List<Usuario> ListadoUsuarios = repositorioUsuario.List();

        if (ListadoUsuarios != null)
        {
            return Ok(ListadoUsuarios);
        }
        else
        {
            return BadRequest();
        }
    }


    [HttpGet("GetById")]
    public ActionResult<Usuario> GetById(int id)
    {
        Usuario user = repositorioUsuario.GetById(id);

        if (user != null)
        {
            return Ok(user);
        }
        else
        {
            return BadRequest();
        }
    }


    [HttpPut("Update")]
    public ActionResult<Usuario> Update(int id, Usuario user)
    {
        repositorioUsuario.Update(id, user);
        return Ok();
    }
}