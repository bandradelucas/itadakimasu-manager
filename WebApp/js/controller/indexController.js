(function () {

    angular.module("app").controller("indexController", function ($scope, $location, $rootScope, produtoService) {

        $scope.deslogar = function () {
            localStorage.clear();
            $rootScope.NomeUsuario = undefined;
            $rootScope.showNav = false;
            $rootScope.usuarioLogado = false;
            $location.path("/login");
        }
    });

}());