using System;
using System.Collections.Generic;

namespace Domain.DTO.Produto
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public decimal Preco { get; set; }
        public decimal Custo { get; set; }
        public int IdCategoria { get; set; }
        public int? IdSubCategoria { get; set; }
        public dynamic TempoPreparacao { get; set; }
        public dynamic Tempo { get; set; }
        public string Imagem { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string DescricaoSubCategoria { get; set; }
    }
}
