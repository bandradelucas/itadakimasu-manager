(function () {
    angular.module("app").controller("cadastroProdutoController", function ($scope, $route, $location, produtoService) {

        $scope.produto = {
            Descricao: undefined,
            Custo: undefined,
            Preco: undefined,
            IdCategoria: undefined,
            IdSubCategoria: undefined,
            Tempo: undefined,
            Imagem: undefined,
            Titulo: undefined
        }

        $scope.Categorias = [
         {
             categoria: "Bebidas",
             value: 1
         },
         {
             categoria: "Pratos Frios",
             value: 2
         },
         {
             categoria: "Pratos Quentes",
             value: 3
         },
         {
             categoria: "Entradas",
             value: 4
         },
         {
             categoria: "Especiais",
             value: 5
         },
         {
             categoria: "Sobremesas",
             value: 7
         }
        ];

        $scope.SubCategorias = [
         {
             categoria: "Refrigerantes (350ml)",
             value: 8
         },
         {
             categoria: "Sucos Naturais (Copo 300ml)",
             value: 9
         },
         {
             categoria: "Sucos Polpa (Copo 300ml)",
             value: 10
         },
         {
             categoria: "H2O (500ml)",
             value: 11
         },
         {
             categoria: "Cervejas (600ml)",
             value: 12
         },
         {
             categoria: "Drinks (Copo)",
             value: 13
         },
         {
             categoria: "Água (500ml)",
             value: 14
         }
        ];

        $scope.fileNameChanged = function (arquivo) {
            file = arquivo[0];
        };

        $scope.salvaProduto = function (produto) {
            if (produto.TempoPreparacao)
                produto.Tempo = produto.TempoPreparacao.getHours() + ":" + produto.TempoPreparacao.getMinutes() + ":" + produto.TempoPreparacao.getSeconds();
            produtoService.post(produto, file).success(function () {
                alert("Cadastrado com sucesso.");
                $route.reload();
            }).error(function (data) {
            });
        }
    });
}());