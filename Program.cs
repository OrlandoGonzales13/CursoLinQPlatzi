﻿LinqQueries queries = new LinqQueries();

//Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

////----------------------------------WHERE----------------------------------

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
//ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());

////----------------------------------ALL / ANY----------------------------------

//Todos los libros tienen Status
//Console.WriteLine($" Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($" Algun libro fue publicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}");

////---------------------------------- CONTAINS----------------------------------

//Libros de python
//ImprimirValores(queries.LibrosdePython());

////---------------------------------- ORDER BY----------------------------------
//Libros de java ordenados por nombre
//ImprimirValores(queries.LibrosdeJava());

//Libros con mas de 450 paginas ordenados por numero de paginas descendente
ImprimirValores(queries.Librosde450pag());


//PARA IMPRIMIR EN CONSOLA-----------------------------------------------------------------------

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}