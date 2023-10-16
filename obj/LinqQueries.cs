public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JJsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000(){
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expression
        return from l in librosCollection  where l.PublishedDate.Year >2000 select l;
    }

    public IEnumerable<Book> LibrosConMasDe250pagConPalabrasInAction()
    {
        //extemsion methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"))

        //query expression
        return from l in librosCollection where l.PageCount >250 && l.Title.Contains("in Action") select l;
    }
}