(function () {
    'use strict';

    angular.module("app").factory("produtoService", function ($http, config) {


        var _post = function (dto, file) {
            var data = {
                model: dto,
                files: file
            };
            return $http.post(config.baseUrl + 'produto', data, {
                transformRequest: function (data) {
                    var formData = new FormData();
                    formData.append('model', angular.toJson(data.model));
                    formData.append('file', data.files);
                    return formData;
                },
                headers: { 'Content-Type': undefined }
            });
        }

        var _put = function (dto, id, file) {
            var data = {
                model: dto,
                files: file
            };
            return $http.put(config.baseUrl + 'produto/' + id, data, {
                transformRequest: function (data) {
                    var formData = new FormData();
                    formData.append('model', angular.toJson(data.model));
                    formData.append('file', data.files);
                    return formData;
                },
                headers: { 'Content-Type': undefined }
            });
        }

        var _getAll = function () {
            return $http.get(config.baseUrl + "produto/getall");
        }

        var _deleteProduto = function (id) {
            return $http.delete(config.baseUrl + "produto/" + id);
        }

        var _getByDescricao = function (descricao) {
            return $http.get(config.baseUrl + "produto/getbydescricao/" + descricao);
        }

        var _getById = function (id) {
            return $http.get(config.baseUrl + "produto/getbyid/" + id);
        }
        var _postpedido = function (pedidos) {
            return $http.post(config.baseUrl + "produto/pedido", pedidos);
        }

        var _getallpedido = function () {
            return $http.get(config.baseUrl + "produto/getallpedido");
        }

        var _deletepedido = function (id) {
            return $http.get(config.baseUrl + "produto/deletepedido/" + id);
        }
        var _cancelarpedido = function (id) {
            return $http.get(config.baseUrl + "produto/cancelarpedido/" + id);
        }

        var _job = function (id) {
            return $http.get(config.baseUrl + "produto/job");
        }

        return {
            post: _post,
            getAll: _getAll,
            deleteProduto: _deleteProduto,
            getByDescricao: _getByDescricao,
            getById: _getById,
            put: _put,
            cancelarPedido: _cancelarpedido,
            postpedido: _postpedido,
            getallpedido: _getallpedido,
            deletepedido: _deletepedido,
            job: _job
        }

    });

}());