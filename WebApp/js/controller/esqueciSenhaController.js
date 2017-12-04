(function () {
    angular.module("app").controller("esqueciSenhaController", function ($scope,$route, usuarioService) {

        $scope.usuario = {
            Email: undefined,
            Login: undefined
        }

        $scope.confirmeEmail = "";

        $scope.validaEmail = function () {
            if ($scope.usuario.Email && $scope.confirmeEmail) {
                if ($scope.usuario.Email == $scope.confirmeEmail) {
                    $scope.validacao = false;
                } else {
                    $scope.validacao = true;
                }
            }

            if (!$scope.usuario.Email && $scope.confirmeEmail) {
                $scope.validacao = true;
            }
        }

        $scope.$watch("confirmeEmail", function () {
            if (!$scope.usuario.Email && !$scope.confirmeEmail) {
                $scope.validacao = false;
            }
            if ($scope.usuario.Email && !$scope.confirmeEmail) {
                $scope.validacao = false;
            }
        });

        $scope.enviaEmail = function (usuario) {
            usuarioService.postEmail(usuario).success(function (data) {
                alert("Senha enviado para o e-mail com sucesso.");
                $route.reload();
            });
        };
    });
}());