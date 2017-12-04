(function () {
    angular.module("app").controller("loginController", function ($scope, $location, $rootScope, usuarioService) {

        $scope.usuario = {
            Login: undefined,
            Senha: undefined
        };

        $scope.login = function (usuario) {
            usuarioService.validaUsuario(usuario).success(function (data) {
                usuarioService.localUsuario(data);
                $rootScope.usuarioLogado = true;
                $rootScope.NomeUsuario = data.Nome;
                $rootScope.Permissao = data.IdPermissao;
                $location.path("#/home");
            }).error(function (data) {
                alert(data.Message);
            });
        };
    });
}());