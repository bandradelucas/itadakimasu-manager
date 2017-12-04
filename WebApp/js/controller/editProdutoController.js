(function () {
    angular.module("app").controller("editProdutoController", function ($scope, $route, $location, produtoService) {

        $scope.produto = {
            Descricao: undefined,
            Custo: undefined,
            Preco: undefined,
            IdCategoria: undefined,
            TempoPreparacao: undefined,
            Imagem: undefined
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

        $scope.load = function () {
            produtoService.getById($route.current.params.id).success(function (data) {
                $scope.produto.Descricao = data.Descricao;
                $scope.produto.Titulo = data.Titulo;
                $scope.produto.Custo = data.Custo;
                $scope.produto.Preco = data.Preco;
                $scope.produto.IdCategoria = data.IdCategoria;
                $scope.produto.IdSubCategoria = data.IdSubCategoria;
                var item = data.TempoPreparacao.split(':');
                $scope.produto.TempoPreparacao = new Date(0);
                $scope.produto.TempoPreparacao.setHours(parseInt(item[0]));
                $scope.produto.TempoPreparacao.setMinutes(parseInt(item[1]));
                $scope.produto.Imagem = data.Imagem;
            }).error(function (data) {
            });
        };

        $scope.fileNameChanged = function (arquivo) {
            file = arquivo[0];
        };

        $scope.update = function (produto) {
            if (produto.TempoPreparacao)
                produto.Tempo = produto.TempoPreparacao.getHours() + ":" + produto.TempoPreparacao.getMinutes() + ":" + produto.TempoPreparacao.getSeconds();
            produtoService.put(produto, $route.current.params.id, file).success(function () {
                alert("Alterado com sucesso.");
                $location.path("/produto");
            }).error(function (data) {
            });
        }

        $scope.load();
    });
}());