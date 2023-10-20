public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    //----------------------------------WHERE----------------------------------
    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expresion

        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    //----------------------------------ALL----------------------------------
    //NOS DEVUELVE TRUE OR FALSE

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SiAlgunLibroFuePublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    //----------------------------------CONTAINS----------------------------------

    // retornar los elementos que pertenezcan a la categoria de Python
    public IEnumerable<Book> LibrosdePython()
    {
        //extension method
        return librosCollection.Where(p => p.Categories.Contains("Python"));

        //// query expression
        //return from b in librosCollection where b.Categories.Contains("Python") select b;
    }

    //----------------------------------ORDER BY----------------------------------

    // retornar los elementos que pertenezcan a la categoria de Java ordenados de forma ascendente
    public IEnumerable<Book> LibrosdeJava()
    {
        return librosCollection.Where(b=> b.Categories.Contains("Java")).OrderBy(b=> b.Title);
    }

    // retornar los elementos que pertenezcan a la categoria de Java ordenados de forma descente
    public IEnumerable<Book> Librosde450pag()
    {
        return librosCollection.Where(b=> b.PageCount > 450).OrderByDescending(b=> b.PageCount); 
    }
}