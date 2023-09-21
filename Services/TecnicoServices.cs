using Microsoft.EntityFrameworkCore;
using Proyecto2.Data;

public class TecnicoServices : ITecnicoServices{
    private readonly ApplicationDbContext _context;

    public TecnicoServices(ApplicationDbContext context){
        _context = context;
    }
    public void Create(Tecnico tec)
    {
        _context.Add(tec);
        _context.SaveChanges();
    }


    public void Delete(Tecnico tec)
    {
    _context.Remove(tec);
    _context.SaveChanges();
    }

    public List<Tecnico> GetAll()
    {
        return _context.Tecnico.Include(r => r.Nombre).ToList();
    }

    public Tecnico? GetById(int id){

        var tecnico =  _context.Tecnico.FirstOrDefault(m=> m.Id == id);
        return tecnico;
    }
    public List<Tecnico> QuerySearch(string str){
        var query = from autor in _context.Tecnico select autor;
            if(!string.IsNullOrEmpty(str)){
                query = query.Where(x => x.Nombre.ToLower().Contains(str.ToLower()) || x.Apellido.ToLower().Contains(str.ToLower()) || x.Edad.ToString() == str);
            }
        return query.ToList();
    }



    public void Update(Tecnico tec)
    {
        _context.Update(tec);
        _context.SaveChanges();
    }
}