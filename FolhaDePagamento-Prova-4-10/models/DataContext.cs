using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    //Classe que define a estrutura do banco de dados
    public class DataContext : DbContext
    {
        // Define quais as classes de modelo servirão
        // para as tabelas no banco de dados

        // Super method 
        // Constructor
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Folha> folhaPagamentos { get; set; }
        

    }
}