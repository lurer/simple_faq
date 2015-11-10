var App = angular.module("App", []);

console.log("Opening faq_controller");

App.controller("faq_controller", function ($scope, $http) {

    function getAllQuestions() {
        var url = "/api/Faq";
        $http.get(url).
          success(function (questions) {
              relevant = [];
              for (var i = 0; i < questions.length; i++) {
                  if (questions[i].RelevanceScore >= 5) {
                      relevant.push(questions[i]);
                  }
              }
              $scope.relevant_list = relevant;
              $scope.all_questions = questions;
              console.log("Questions loaded successfully");
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    function getAllCategoriesForFilter() {
        var url = "/api/Category";

        $http.get(url).
          success(function (categories) {
              $scope.loadingData = false;
              $scope.category_list = categories;
              console.log("Categories loaded successfully");
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.loadingData = true;
    $scope.showCategoryIcons = true;
    $scope.displayRelevantAnswer = false;
    $scope.information = true;
    getAllQuestions();
    getAllCategoriesForFilter();
    


    $scope.showRelevantFaqItems = function () {
        var numItemsToShow = 5;

    };


    $scope.showCategoryIcons = function () {
        
        alert("InShowCategories");
    };


    $scope.showFaqItems = function () {

    };


    $scope.filterCategories = function(id){
        //alert("Filtering on: " + id);
    };


    $scope.clearFilter = function () {
        getAllCategoriesForFilter();
    };

    $scope.displayRelevantAnswer = function (relevant) {
        $scope.information = false;
        $scope.relevantBody = relevant.Body;
        $scope.relevantAnswer = relevant.Answer;
        
    };
    
});