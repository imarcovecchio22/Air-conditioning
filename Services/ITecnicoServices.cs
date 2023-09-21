public interface ITecnicoServices{
    void Create(Tecnico tec);
    void Update(Tecnico tec);
    void Delete(Tecnico tec);

    List<Tecnico> QuerySearch(string str);

    List<Tecnico>GetAll();
    Tecnico? GetById(int id);
}