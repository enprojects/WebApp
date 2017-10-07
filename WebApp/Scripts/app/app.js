/// <reference path="C:\Users\Eyal\Desktop\JobIntrwiew\EyalExePluralSight\MvcPrjJobInterview\WebApp\WebApp\Views/Home/DialogHtml.html" />
/// <reference path="C:\Users\Eyal\Desktop\JobIntrwiew\EyalExePluralSight\MvcPrjJobInterview\WebApp\WebApp\Views/Home/DialogHtml.html" />

var app = angular.module('app', ['ui.bootstrap']);

app.controller('mainController', ['$scope', 'studentServise', '$modal', function (scope, studentServise, $modal) {
    scope.students = [];
 
    scope.init = function () {

        studentServise.getStudens()
            .then(function (result) {
                scope.students = result.data;
            });

    };

    scope.init();

    scope.crudOperation = function (student) {

        $modal.open({
            templateUrl: '/HtmlTemplets/DialogHtml.html',
            windowClass: 'modal', // windowClass - additional CSS class(es) to be added to a modal window template
            controller: function ($scope, $modalInstance, student, studentServise) {
                $scope.student = student;

                $scope.deleteStudent = function () {

                        studentServise.deleteStudent($scope.student)

                            .then(function (result) {
                                if (result && result.data) {
                                    if (result.data.Success) {

                                        $modalInstance.close();
                                    } else {
                                        alert('Record has not changed')
                                    }

                                } else {
                                    alert('Fatal Error')
                                }
                            });
                 
                }

                $scope.updateStudent = function () {

                    studentServise.updateStudent($scope.student)

                        .then(function (result) {
                            if (result && result.data) {
                                if (result.data.Success) {

                                    $modalInstance.close();
                                } else {
                                    alert('Record has not changed')
                                }

                            } else {
                                alert('Fatal Error')
                            }
                        });
                }
                $scope.cancel = function () {
                    $modalInstance.dismiss('cancel');
                };
            },
            resolve: {
                student: function () {
                    return student;
                }
            }
        });


    }

}]);
app.factory('studentServise', ['$http', function (http) {

    var httpRequestMgr = function (action, method, data) {
        return http({
            method: method || 'GET',
            url: '/Home/' + action,
            data: data
        });
    }


    var getStudens = function () {

        return httpRequestMgr('GetStudentsData');
    }

    var updateStudent = function (student) {
        return httpRequestMgr('StudentUpdating', 'POST', student);
    }

    var deleteStudent = function (student) {
        return httpRequestMgr('StudentDeletion', 'POST', student);
    }
    return {
        getStudens: getStudens,
        updateStudent: updateStudent,
        deleteStudent: deleteStudent
    }
}])


