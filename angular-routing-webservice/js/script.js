
var app = angular.module('Demo', ["ngRoute"]);
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
     .when("/home",     { templateUrl:'/Templates/home.html',controller:'homeController'})
     .when("/courses",  { templateUrl:'/Templates/courses.html',controller:'coursesController'})
     .when("/students", { templateUrl:'/Templates/students.html',controller:'studentsController'})
     .otherwise({redirectTo:"/home"})
      console.log("routed");
      $locationProvider.html5Mode(true);
})

app.controller("homeController",['$location', function ($scope, $location) {
    console.log("1");
    $scope.message = "This is a Home Page";
}]);

app.controller("coursesController",function ($scope, $location) {
          console.log("2");
          $scope.courses = ["C#", "SQL", "Oracle"];
          console.log($scope.courses);
});

//app.controller("studentsController",['$location', function ($scope, $http, $location) {
//    console.log("3");
//    $http({url:"/StudentServiceasmx.asmx/GetAllStudents", method: "GET"}).then(function (response) {
//        $scope.students = response.data;
//    }), function (failed) {console.log("failed to connect")};
//}]);

app.controller("studentsController", function ($scope, $http) {
    $http.get("/StudentServiceasmx.asmx/GetAllStudents").then(function (response) {
          $scope.students = response.data;       
    })
    //$scope.students = ["Leonardo b. Gulmatico", "Seth Ortega Gumatico", "Helen Profunga", "Aura Azarcon", "Mark Verdeflor", "Dani Johnson", "Justine Flor"];
    //console.log($scope.students);
});