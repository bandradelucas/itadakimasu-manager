(function () {
    'use strict';

    angular.module("app", ['ngRoute', "angularUtils.directives.dirPagination", "uiCpf"]).run(function ($rootScope, $location) {
        //Rotas que necessitam do login
        var rotasQueNaoDevemMostrarNav = ['/login', '/usuario/new', '/usuario/esqueci/senha'];

        $rootScope.$on('$locationChangeStart', function () {
            //iremos chamar essa função sempre que o endereço for alterado
            /*  podemos inserir a logica que quisermos para dar ou não permissão ao usuário.
             Neste caso, vamos usar uma lógica simples. Iremos analisar se o link que o usuário está tentando acessar (location.path())
             está no Array (rotasBloqueadasUsuariosNaoLogados) caso o usuário não esteja logado. Se o usuário estiver logado, iremos
             validar se ele possui permissão para acessar os links no Array de strings 'rotasBloqueadasUsuariosComuns'
             */
            if (localStorage.getItem("local")) {
                $rootScope.showNav = true;
                $rootScope.usuarioLogado = true;
                $rootScope.NomeUsuario = JSON.parse(localStorage.getItem("local")).Nome;
                $rootScope.Permissao = JSON.parse(localStorage.getItem("local")).IdPermissao;
            }


            if (rotasQueNaoDevemMostrarNav.indexOf($location.path()) != -1)
                $rootScope.showNav = false;
            else {
                $rootScope.showNav = true;
            }
            if ($location.path() == '/home' && !$rootScope.usuarioLogado)
                $location.url('/login');

            if (rotasQueNaoDevemMostrarNav.indexOf($location.path()) != -1 && $rootScope.usuarioLogado)
                $location.path('/home');

            if ($location.path() == '/cardapio' && $rootScope.Permissao == 1)
                $location.url('/home');

            if ($location.path() == '/produto' && $rootScope.Permissao != 3)
                $location.url('/home');

            if ($location.path() == '/painel' && ($rootScope.Permissao != 1 && $rootScope.Permissao != 3))
                $location.url('/home');

            if ($location.path() == '/usuario' && $rootScope.Permissao != 3)
                $location.url('/home');

        });
    });
}());