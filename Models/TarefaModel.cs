using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PIM_VIII.Models
{
    public class TarefaModel
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "O nome da tarefa pode ter no máximo 50 caracteres")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data Entrega")]
        [DataType(DataType.Date)]
        public DateTime Vencimento{ get; set; }
    }

    public class TarefaDBContext : DbContext
    {
        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}