using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class TableroController : ControllerBase
{
    private readonly ITableroRepository repositorioTablero;

    private readonly ILogger<UsuarioController> _logger;
    public TableroController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        repositorioTablero = new TableroRepository();
    }

    [HttpPost("Create")]
    public ActionResult<Tablero> Create(Tablero tablero)
    {
        repositorioTablero.Create(tablero);
        return Ok();
    }

    [HttpGet("List")]
    public ActionResult<List<Tablero>> List()
    {
        List<Tablero> ListadoTableros = repositorioTablero.List();
        if (ListadoTableros != null)
        {
            return Ok(ListadoTableros);
        }
        else
        {
            return BadRequest();
        }
    }
}