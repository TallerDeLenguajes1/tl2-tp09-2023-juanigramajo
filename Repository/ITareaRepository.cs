public interface ITareaRepository
{
    public Tarea Create(int idTab);
    public void Update(int id, Tarea tarea);
    public Tarea GetById(int id);
    public List<Tarea> ListByUser(int idUser);
    public List<Tarea> List(int idTab);
    public void Remove(int id);
    public void Asignar(int idUser, int idTarea);
}