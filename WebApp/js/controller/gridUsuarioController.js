(function () {

    angular.module("app").controller("gridUsuarioController", function (usuarioService, $scope) {
        $scope.pagination = {
            current: 1
        };


        $scope.tables = [];
        $scope.filtro = undefined;

        $scope.delete = function (id) {
            var decisao = confirm("Deseja realmente deletar esse usuário?");
            if (decisao) {
                usuarioService.deleteUsuario(id).success(function (data) {
                    $scope.pesquisar();
                }).error(function () {
                });
            }
        };

        $scope.desativar = function (id) {
            var decisao = confirm("Deseja realmente desativar esse usuário?");
            if (decisao) {
                usuarioService.desativar(id).success(function (data) {
                    $scope.pesquisar();
                }).error(function () {
                });
            }
        };

        $scope.ativar = function (id) {
            var decisao = confirm("Deseja realmente ativar esse usuário?");
            if (decisao) {
                usuarioService.ativar(id).success(function (data) {
                    $scope.pesquisar();
                }).error(function () {
                });
            }
        };

        $scope.pesquisar = function () {
            $scope.error = "";
            if ($scope.filtro) {
                usuarioService.getByLogin($scope.filtro).success(function (data) {
                    if (data.length > 0) {
                        $scope.tables = data;
                    }
                    else {
                        $scope.tables = [];
                        $scope.error = "Não foi possível encontrar resultados.";
                    }
                });
            } else {
                usuarioService.getall().success(function (data) {
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