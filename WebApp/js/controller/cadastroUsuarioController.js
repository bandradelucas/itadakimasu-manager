(function () {
    angular.module("app").controller("cadastroUsuarioController", function ($scope, $location, $route, usuarioService) {
        $scope.validacao = false;
        $scope.validacaoLogin = true;
        $scope.usuario = {
            Login: undefined,
            Senha: undefined,
            Nome: undefined,
            Email: undefined,
            DataNascimento: undefined,
            CPF: undefined,
            IdFuncao: undefined
        }

        $scope.Funcoes = [
         {
           funcao: "Cozinheiro",
           value: 1
         },
         {
             funcao: "Garçom",
           value: 2
         },
         {
             funcao: "Mesa",
             value: 4
         }
        ];

        $scope.messageLogin = undefined;

        $scope.confirmeSenha = undefined;

        $scope.validaSenha = function () {
            if ($scope.usuario.Senha && $scope.confirmaSenha) {
                if ($scope.usuario.Senha == $scope.confirmaSenha) {
                    $scope.validacao = false;
                } else {
                    $scope.validacao = true;
                }
            }

            if (!$scope.usuario.Senha && $scope.confirmaSenha) {
                $scope.validacao = true;
            }
        }

        $scope.$watch("confirmaSenha", function () {
            if (!$scope.usuario.Senha && !$scope.confirmaSenha) {
                $scope.validacao = false;
            }
            if ($scope.usuario.Senha && !$scope.confirmaSenha) {
                $scope.validacao = false;
            }
        });

        $scope.$watch("usuario.Login", function () {
            if ($scope.usuario.Login) {
                $scope.validacaoLogin = true;
            }

            if (!$scope.usuario.Login && $scope.messageLogin) {
                $scope.validacaoLogin = true;
            }
        });

        $scope.salvaUsuario = function (usuario) {
            if (!$scope.validacao) {
                usuarioService.postUsuario(usuario).success(function () {
                    alert("Cadastrado com sucesso.");
                    $route.reload();
                }).error(function (data) {
                    $scope.messageLogin = data.Message;
                    $scope.validacaoLogin = false;
                });
            }
        }
    });
}());