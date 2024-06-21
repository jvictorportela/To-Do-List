using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models;

public class TaskTD
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Preencha a descrição")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preencha a Data de vencimento")]
    public DateTime? ExpirationDate { get; set; } //Data de vencimento

    [Required(ErrorMessage = "Selecione uma categoria")]
    public string CategoryId { get; set; } = string.Empty; //Relacionamento Category and Task -- cada tarefa possui uma categoria e uma categoria pode conter várias tarefas
    [ValidateNever]
    public Category Category { get; set; }

    [Required(ErrorMessage = "Selecione um Status")]
    public string StatusId { get; set; } = string.Empty;
    [ValidateNever]
    public Status Status { get; set; }

    public bool Late => StatusId == "aberto" && ExpirationDate < DateTime.Today; //Atrasado
}
