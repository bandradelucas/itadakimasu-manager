(function () {
    angular.module("app").controller("cardapioRestauranteController", function ($scope, $route, produtoService) {

        $scope.pedidos = [];
        $scope.pratosFrios = [];
        $scope.pratosQuentes = [];
        $scope.entradas = [];
        $scope.especiais = [];
        $scope.rodizios = [];
        $scope.sobremesas = [];
        $scope.cervejas = [];
        $scope.refrigerantes = [];
        $scope.h2o = [];
        $scope.sucoNatural = [];
        $scope.sucoPolpa = [];
        $scope.drinks = [];
        $scope.aguas = [];
        $scope.bebidas = [];

        $scope.showPedido = false;

        function load() {
            produtoService.getAll().success(function (data) {

                angular.forEach(data, function (item) {
                    if (item.IdCategoria == 2)
                        $scope.pratosFrios.push(item);
                    else if (item.IdCategoria == 8)
                        $scope.refrigerantes.push(item);
                    else if (item.IdCategoria == 9)
                        $scope.sucoNatural.push(item);
                    else if (item.IdCategoria == 10)
                        $scope.sucoPolpa.push(item);
                    else if (item.IdCategoria == 11)
                        $scope.h2o.push(item);
                    else if (item.IdCategoria == 12)
                        $scope.cervejas.push(item);
                    else if (item.IdCategoria == 13)
                        $scope.drinks.push(item);
                    else if (item.IdCategoria == 14)
                        $scope.aguas.push(item);
                    else if (item.IdCategoria == 3)
                        $scope.pratosQuentes.push(item);
                    else if (item.IdCategoria == 4)
                        $scope.entradas.push(item);
                    else if (item.IdCategoria == 5)
                        $scope.especiais.push(item);
                    else
                        $scope.sobremesas.push(item);


                    if (item.IdSubCategoria == 1)
                        $scope.bebidas.push(item);
                });
            });
        };

        $scope.setPristine = function (item) {
            if (item.Pedido == false) {
                item.Quantidade = undefined;
                item.Requisacao = undefined;
                $scope.showPedido = false;
            } else {
                $scope.showPedido = true;
            }
        };

        $scope.save = function () {
            angular.forEach($scope.pratosFrios, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.cervejas, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.refrigerantes, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.h2o, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.sucoNatural, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.sucoPolpa, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.drinks, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.aguas, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.pratosQuentes, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.entradas, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.especiais, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            angular.forEach($scope.sobremesas, function (item) {
                if (item.Pedido == true) {
                    item.UserId = JSON.parse(localStorage.getItem("local")).Login;
                    $scope.pedidos.push(item);
                }
            });

            produtoService.postpedido($scope.pedidos).success(function (data) {
                alert("Pedido realizado com sucesso.");

                angular.forEach($scope.pratosFrios, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.cervejas, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.refrigerantes, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.h2o, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.sucoNatural, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.sucoPolpa, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.drinks, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.aguas, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.pratosQuentes, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.especiais, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.entradas, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });

                angular.forEach($scope.sobremesas, function (item) {
                    item.Quantidade = undefined;
                    item.Requisacao = undefined;
                    item.Pedido = undefined;
                });
                $scope.pedidos = [];
                $scope.showPedido = false;
            });

        }

        load();
    });
}());