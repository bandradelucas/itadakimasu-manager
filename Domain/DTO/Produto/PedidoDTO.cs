using System;
using System.Collections.Generic;

namespace Domain.DTO.Produto
{
    public class PedidoDTO
    {
        public string UserId { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataDelecao { get; set; }
        public int Id { get; set; }
        public string Requisicao { get; set; }
        public ProdutoDTO Produto { get; set; }
    }
}
