using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Customer;
using Domain.DTO.Produto;
using Domain.DTO;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace Domain.ApplicationService
{
    public class ProdutoApplicationService
    {
        public Produto Post(ProdutoDTO produtoDTO)
        {
            return new Produto()
            {
                Custo = produtoDTO.Custo,
                DataCriacao = DateTime.Now,
                Descricao = produtoDTO.Descricao,
                IdCategoria = produtoDTO.IdSubCategoria != null ? (int)produtoDTO.IdSubCategoria : produtoDTO.IdCategoria,
                Preco = produtoDTO.Preco,
                Imagem = produtoDTO.Imagem,
                TempoPreparacao = TimeSpan.Parse(produtoDTO.Tempo),
                Id = produtoDTO.Id,
                Titulo = produtoDTO.Titulo
            };
        }

        public List<ProdutoDTO> ConvertDbToDto(List<Produto> produtos)
        {
            var listaDTO = new List<ProdutoDTO>();

            foreach (var data in produtos)
            {
                    var dto = new ProdutoDTO()
                    {

                        Preco = data.Preco,
                        DataInclusao = data.DataCriacao,
                        Descricao = data.Descricao,
                        Imagem = data.Imagem,
                        Id = data.Id,
                        Titulo = data.Titulo,
                        IdCategoria = data.IdCategoria,
                        IdSubCategoria = data.CategoriaProduto.Parent,
                        DescricaoSubCategoria = data.CategoriaProduto.Descricao
                    };

                    listaDTO.Add(dto);
            }

            return listaDTO;
        }

        public List<OrdenacaoPedido> PostPedido(List<PedidoDTO> list)
        {
            var listDB = new List<OrdenacaoPedido>();
            foreach (var item in list)
            {
                var db = new OrdenacaoPedido();
                db.DataCriacao = DateTime.Now;
                db.Quantidade = item.Quantidade;
                db.IdProduto = item.Id;
                db.Requisicao = item.Requisicao;
                db.OrdenacaoStatus = new OrdenacaoStatus()
                {
                    Descricao = "Fazendo"
                };
                db.UserId = item.UserId;
                listDB.Add(db);
            };

            return listDB;
        }

        public ProdutoDTO ConvertDbToDto(Produto produto)
        {
            var dto = new ProdutoDTO()
            {
                Preco = produto.Preco,
                DataInclusao = produto.DataCriacao,
                Descricao = produto.Descricao,
                Id = produto.Id,
                Custo = produto.Custo,
                IdCategoria = produto.CategoriaProduto.Parent != null ? (int)produto.CategoriaProduto.Parent : produto.IdCategoria,
                IdSubCategoria = produto.CategoriaProduto.Parent != null ? (int?)produto.IdCategoria : null,
                Imagem = produto.Imagem,
                Titulo = produto.Titulo,
                TempoPreparacao = produto.TempoPreparacao
            };

            return dto;
        }

        public void Put(Produto produto, ProdutoDTO produtoDTO)
        {
            produto.IdCategoria = produtoDTO.IdCategoria;
            produto.Imagem = produtoDTO.Imagem != null? produtoDTO.Imagem : produto.Imagem;
            produto.Preco = produtoDTO.Preco;
            produto.TempoPreparacao = TimeSpan.Parse(produtoDTO.Tempo);
            produto.Custo = produtoDTO.Custo;
            produto.DataAlteracao = DateTime.Now;
            produto.Descricao = produtoDTO.Descricao;
        }

        public List<PedidoDTO> ConvertDbToDtoPedido(List<OrdenacaoPedido> pedido)
        {
            var list = new List<PedidoDTO>();
            foreach (var item in pedido)
            {
                var dto = new PedidoDTO();
                dto.Id = item.Id;
                dto.Quantidade = item.Quantidade;
                dto.Requisicao = item.Requisicao;
                dto.UserId = item.UserId;
                dto.Produto = new ProdutoDTO()
                {
                    Descricao = item.Produto.Descricao,
                    Titulo = item.Produto.Titulo
                };

                list.Add(dto);
            }

            return list;
        }

        public void Delete(OrdenacaoPedido pedido)
        {
            pedido.DataDelecao = DateTime.Now;
            pedido.OrdenacaoStatus.Descricao = "Prato pronto.";
        }
    }
}
