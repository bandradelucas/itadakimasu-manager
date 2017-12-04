(function () {
    'use strict';

    angular.module("app").factory("usuarioService", function ($http, config) {

        var _validaUsuario = function (usuario) {
            return $http.post(config.baseUrl + "usuario/validausuario", usuario);
        }

        var _localUsuario = function (data) {
            localStorage.clear();
            sessionStorage.clear();
            localStorage.setItem("local", JSON.stringify(data));
        }

        var _postEmail = function (usuario) {
            return $http.post(config.baseUrl + "usuario/email", usuario);
        }

        var _desativar = function (id) {
            return $http.put(config.baseUrl + "usuario/desativar/" + id);
        }

        var _ativar = function (id) {
            return $http.put(config.baseUrl + "usuario/ativar/" + id);
        }

        var _getById = function (id) {
            return $http.get(config.baseUrl + "usuario/" + id);
        }
        var _putUsuario = function (usuario, id) {
            return $http.put(config.baseUrl + "usuario/" + id, usuario);
        }

        var _postUsuario = function (usuario) {
            return $http.post(config.baseUrl + "usuario", usuario);
        }

        var _getByLogin = function (filtro) {
            return $http.get(config.baseUrl + "usuario/getbylogin/" + filtro);
        }

        var _getall = function () {
            return $http.get(config.baseUrl + "usuario/getall");
        }

        var _delete = function (id) {
            return $http.delete(config.baseUrl + "usuario/" + id);
        }

        return {
            putUsuario: _putUsuario,
            postEmail: _postEmail,
            getById: _getById,
            postUsuario: _postUsuario,
            localUsuario: _localUsuario,
            validaUsuario: _validaUsuario,
            deleteUsuario: _delete,
            desativar: _desativar,
            ativar: _ativar,
            getByLogin: _getByLogin,
            getall: _getall
        }

    });

}());