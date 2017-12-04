(function () {
    'use strict';

    angular.module("app").config(function ($routeProvider) {
        $routeProvider.when("/usuario/new", {
            templateUrl: "templates/cadastroUsuario.html",
            controller: "cadastroUsuarioController"
        });
        $routeProvider.when("/home", {
            templateUrl: "templates/telaPrincipal.html",
            controller: "telaPrincipalController"
        });
        $routeProvider.when("/login", {
            templateUrl: "templates/loginUsuario.html",
            controller: "loginController"
        });
        $routeProvider.when("/usuario/config", {
            templateUrl: "templates/configUsuario.html",
            controller: "configUsuarioController"
        });
        $routeProvider.when("/usuario/esqueci/senha", {
            templateUrl: "templates/esqueciSenha.html",
            controller: "esqueciSenhaController"
        });
        $routeProvider.when("/cadastro/produto", {
            templateUrl: "templates/cadastroProduto.html",
            controller: "cadastroProdutoController"
        });
        $routeProvider.when("/update/produto/:id", {
            templateUrl: "templates/editProduto.html",
            controller: "editProdutoController"
        });
        $routeProvider.when("/produto", {
            templateUrl: "templates/gridProduto.html",
            controller: "gridProdutoController"
        });
        $routeProvider.when("/usuario", {
            templateUrl: "templates/gridUsuario.html",
            controller: "gridUsuarioController"
        });
        $routeProvider.when("/cardapio", {
            templateUrl: "templates/cardapioRestaurante.html",
            controller: "cardapioRestauranteController"
        });
        $routeProvider.when("/painel", {
            templateUrl: "templates/painelCozinha.html",
            controller: "painelCozinhaController"
        });

        $routeProvider.otherwise({ redirectTo: "/home" });

    });
}());