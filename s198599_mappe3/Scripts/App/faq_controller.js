var App = angular.module("App", []);

console.log("Opening faq_controller");

App.controller("faq_controller", function ($scope, $http) {

    function getAllQuestions() {
        var url = "/api/Faq";
        $http.get(url).
          success(function (questions) {
              relevant = [];
              displayFiltered = [];
              for (var i = 0; i < questions.length; i++) {
                  if (questions[i].RelevanceScore >= 5) {
                      relevant.push(questions[i]);
                  }
                  angular.forEach($scope.category_list, function (value) {
                      
                      if(value.CategoryID == questions[i].CategoryID && value.IsChecked){
                          displayFiltered.push(questions[i]);
                      }
                  });

              }
              $scope.relevant_list = relevant;
              if (displayFiltered.length == 0)
                  $scope.all_questions = questions;

              else
                  $scope.all_questions = displayFiltered;


              $scope.showFaqItems = true;
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
              if ($scope.resettingFilterBool == true) {
                  getAllQuestions();
                  $scope.resettingFilterBool = false;
              }
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.selectedCategory = 0;
    $scope.showFaqForm = false;
   
    $scope.loadingData = true;
    $scope.showCategoryIcons = true;
    $scope.displayRelevantAnswer = false;
    $scope.information = true;
    
    $scope.resettingFilterBool = false;
    getAllQuestions();
    getAllCategoriesForFilter();
    


    $scope.showRelevantFaqItems = function () {
        var numItemsToShow = 5;

    };

    $scope.filterCategories = function(){

        getAllQuestions();
    };


    $scope.clearFilter = function () {
        $scope.resettingFilterBool = true;
        $scope.selectedCategory = 0;
        $scope.showFaqForm = false;
        getAllCategoriesForFilter();
        
    };

    $scope.displayRelevantAnswer = function (relevant) {
        $scope.information = false;
        $scope.relevantBody = relevant.Body;
        $scope.relevantAnswer = relevant.Answer;
        
    };


    $scope.emptyFaqForm = function () {
        $scope.showFaqForm = true;
        $scope.showFaqItems = false;
        
        $scope.formHeading = "";
        $scope.formBody = "";
        $scope.formRespondEmail = "";
        $scope.selectedCategory = 0;
    };
    
    $scope.registerNewQuestion = function(){
        var question = {
            Heading: $scope.formHeading,
            Body: $scope.formBody,
            Email: $scope.formRespondEmail,
            CategoryID: $scope.selectedCategory
        };

        $http.post("/api/Faq", question).
         success(function (data) {
             
             getAllQuestions();
             getAllCategoriesForFilter();
             $scope.showFaqForm = false;
             $scope.showFaqItems = true;
         }).
         error(function (data, status) {
             console.log(status + data);
         });
        
    };

    $scope.test = function () {
        //console.log($scope.selectedCategory);
    };
});