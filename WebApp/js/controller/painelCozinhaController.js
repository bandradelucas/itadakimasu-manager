(function () {
    angular.module("app").controller("painelCozinhaController", function ($scope, $route, $location, $interval, produtoService) {

        $scope.pedidos = undefined;

        function load() {
            produtoService.getallpedido().success(function (list) {
                $scope.pedidos = list;
            });
        }

        $interval(function load() {
            produtoService.getallpedido().success(function (list) {
                $scope.pedidos = list;
            });
        }, 1000);

        $scope.finalizarPedido = function (index, id) {
            produtoService.deletepedido(id).success(function () {
                $scope.pedidos.splice(index, 1);
                alert("Pedido finalizado com sucesso.");
            });
        };

        $scope.cancelarPedido = function (index, id) {
            produtoService.cancelarPedido(id).success(function () {
                $scope.pedidos.splice(index, 1);
                alert("Pedido cancelado com sucesso.");
            });
        };

        load();
    });
}());