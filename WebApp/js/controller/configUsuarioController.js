(function () {
    angular.module("app").controller("configUsuarioController", function ($scope, usuarioService, $location) {

        $scope.validacao = false;
        $scope.valida = false;

        $scope.confirmaSenha = undefined;

        $scope.usuario = {
            Nome: undefined,
            Email: undefined,
            Login: undefined,
            Senha: undefined,
            CPF: undefined,
            DataNascimento: undefined,
            NovaSenha: undefined,
            Id: JSON.parse(localStorage.getItem("local")).Id
        }

        $scope.load = function () {
            usuarioService.getById($scope.usuario.Id).success(function (data) {
                $scope.usuario = data;
                $scope.usuario.DataNascimento = new Date(data.DataNascimento);
            });
        }

        $scope.validaSenha = function () {
            if ($scope.usuario.NovaSenha && $scope.confirmaSenha) {
                if ($scope.usuario.NovaSenha == $scope.confirmaSenha) {
                    $scope.validacao = false;
                } else {
                    $scope.validacao = true;
                }
            }

            if (!$scope.usuario.NovaSenha && $scope.confirmaSenha) {
                $scope.validacao = true;
            }
        }

        $scope.$watch("confirmaSenha", function () {
            if (!$scope.usuario.NovaSenha && !$scope.confirmaSenha) {
                $scope.validacao = false;
            }
            if ($scope.usuario.NovaSenha && !$scope.confirmaSenha) {
                $scope.validacao = false;
            }
        });

        $scope.$watch("usuario.Senha", function () {
            if (!$scope.usuario.Senha) {
                $scope.valida = false;
            }
            if ($scope.usuario.Senha) {
                $scope.valida = false;
            }
        });


        $scope.update = function () {
            usuarioService.putUsuario($scope.usuario, $scope.usuario.Id).success(function (data) {
                alert("Alterado com sucesso.");
                $location.path("#/home");
            }).error(function (data) {
                $scope.senhaAntiga = data.Message;
                $scope.valida = true;
            });
        }

        $scope.load();
    });
}());