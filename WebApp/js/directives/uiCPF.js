angular.module("uiCpf", []).directive("uiCpf", function ($filter, validacaoService) {
    return {
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _formatCpf = function (cpf) {
                cpf = cpf.replace(/[^0-9]+/g, "");
                if (cpf.length > 3) {
                    cpf = cpf.substring(0, 3) + "." + cpf.substring(3);
                }
                if (cpf.length > 7) {
                    cpf = cpf.substring(0, 7) + "." + cpf.substring(7);
                }

                if (cpf.length > 7) {
                    cpf = cpf.substring(0, 11) + "-" + cpf.substring(11, 13);
                }
                return cpf;
            };          
           
            element.bind("keyup", function () {
             
                
                ctrl.$setViewValue(_formatCpf(ctrl.$viewValue));
                ctrl.$render();
            });

            element.on("blur", function () {

                ctrl.$setPristine();
                ctrl.$setUntouched();

                if (validacaoService.validaCPF(ctrl.$viewValue) == false) {
                    ctrl.$setValidity('invalidCPF', false);
                } else
                    ctrl.$setValidity('invalidCPF', true);
            });
        }
    };
});