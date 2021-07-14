using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    public class Filme
    {
        [Key] // Define como chave primária.
        public int Id { get; set; }

        // Annotation com 1 atributo.
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        // Annotation com 2 atributo.
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O titulo pecisa ter entre 3 e 60 caracteres.")]
        public string Titulo { get; set; } // Propriedade da Model

        [Required(ErrorMessage = "O campo Data Lançamento é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto.")]
        [Display(Name = "Data de Lançamento")] // Usado para exibir um nome formatado, ao invés da propriedade
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$"), Required(ErrorMessage = "Este campo é obrigatório")] // Sobrecarga de Annotation
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 1000, ErrorMessage = "Valor deve ser entre 1 e 1000")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        [Column(TypeName = "decimal(18,2)")] // Define as especicações no banco de dados.
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Avaliação")]
        [Display(Name = "Avaliação")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números")]
        public int Avaliacao { get; set; }

    }
}
