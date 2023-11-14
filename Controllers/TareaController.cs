using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private ITareaRepository repositorioTarea;

    private readonly ILogger<UsuarioController> _logger;
    public TareaController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        repositorioTarea = new TareaRepository();
    }
    

    [HttpPost("Create")]
    public ActionResult<Tarea> Create(int idTab, Tarea Tarea)
    {
        repositorioTarea.Create(idTab, Tarea);
        return Ok();
    }


    [HttpPut("UpdateTarea")]
    public ActionResult<Tarea> UpdateTarea(int id, Tarea tarea)
    {
        repositorioTarea.Update(id, tarea);
        return Ok();
    }


    [HttpPut("UpdateEstado")]
    public ActionResult<Tarea> UpdateEstado(int id, EstadoTarea estado)
    {
        Tarea tarea = repositorioTarea.GetById(id);
        tarea.Estado = estado;
        repositorioTarea.Update(id, tarea);
        return Ok();
    }


    [HttpDelete("Remove")]
    public IActionResult Remove(int id)
    {
        repositorioTarea.Remove(id);
        return Ok();
    }

    // FALTA LOGICA
    [HttpGet("CantTareasEstado")]
    public ActionResult<int> CantTareasEstado(EstadoTarea estado)
    {
        List<Tarea> ListadoTareas = repositorioTarea.ListByEstado(estado);
        
        if (ListadoTareas != null)
        {
            return Ok(ListadoTareas.Count());
        }
        else
        {
            return BadRequest();
        }
    }

    
    [HttpGet("ListByUser")]
    public ActionResult<List<Tarea>> ListByUser(int id)
    {
        List<Tarea> ListadoTareas = repositorioTarea.ListByUser(id);
        
        if (ListadoTareas != null)
        {
            return Ok(ListadoTareas);
        }
        else
        {
            return BadRequest();
        }
    }

    
    [HttpGet("ListByTablero")]
    public ActionResult<List<Tarea>> ListByTablero(int id)
    {
        List<Tarea> ListadoTareas = repositorioTarea.ListByTablero(id);
        if (ListadoTareas != null)
        {
            return Ok(ListadoTareas);
        }
        else
        {
            return BadRequest();
        }
    }
}