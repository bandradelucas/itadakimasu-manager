(function () {

    angular.module("app").controller("gridProdutoController", function (produtoService, $scope) {
        $scope.pagination = {
            current: 1
        };


        $scope.tables = [];
        $scope.filtro = undefined;

        $scope.delete = function (id) {
            var decisao = confirm("Deseja realmente deletar esse produto?");
            if (decisao) {
                produtoService.deleteProduto(id).success(function (data) {
                    $scope.pesquisar();
                }).error(function () {
                });
            }
        };

        $scope.pesquisar = function () {
            $scope.error = undefined;
            if($scope.filtro){
            produtoService.getByDescricao($scope.filtro).success(function (data) {
                if (data.length > 0) {
                    $scope.tables = data;
                }
                else {
                    $scope.tables = [];
                    $scope.error = "Não foi possível encontrar resultados.";
                }
            });
            } else {
                produtoService.getAll().success(function (data) {
                    if (data.length > 0) {
                        $scope.tables = data;
                    }
                    else {
                        $scope.tables = [];
                        $scope.error = "Não foi possível encontrar resultados.";
                    }
                });
            }
        };
    });

}());