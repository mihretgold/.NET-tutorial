/* 
 We use Entity Framework instead of specific db because Entity Framework is an Object-Relational Mapping (ORM) framework that is used to interact with databases in C#.
It provides a way to map database tables to C# classes, and allows developers to work with the database using C# code instead of writing SQL statements directly.
One of the key differences between Entity Framework and SQL statements is that Entity Framework provides a high-level abstraction over the database, which can 
simplify the process of interacting with the database. Instead of writing complex SQL queries, developers can use LINQ (Language Integrated Query) to query the 
database using C# syntax.Another advantage of Entity Framework is that it provides a level of abstraction that allows developers to work with different databases 
without having to change their code. This is because Entity Framework can be used to work with different database providers, including Microsoft SQL Server, Oracle,
MySQL, and PostgreSQL, among others.
 */

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/*
 Data annotations are a set of attributes that can be used in C# to provide metadata about data elements, such as classes, properties, and fields. 
 Data annotations can be used to specify validation rules, data formatting, and other metadata that can be used by various components of an application.
 */

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        //Create columns(properties) of the category table
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1 and 100!")]
        public int DisplayOrder { get; set; }

        //DateTime.Now equivalent to current time stamp
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
