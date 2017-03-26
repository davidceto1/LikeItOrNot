angular.module('requestImage', [])
    .controller('requestImageCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.showImage = false;

        $scope.getImage = function() {

            $http({
                method: 'GET',
                url: '/ImageModels'
            }).then(function successCallback(response)
                {
                var images = response.data;

                    var im=Math.floor(Math.random() * images.length);
                    $scope.imagePath = '/images/' + images[im].Number + '.JPG';
                    $scope.currentImage = images[im];
                    $scope.showImage = true;
                },
                function errorCallback(response)
                {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });

        }

        $scope.likeImage = function (number) {

            var imgObj = {};
            imgObj.Number = number; 
            $http({
                method: 'POST',
                url: '/Users/LikeImage/',
                data: $scope.currentImage
            }).then(function successCallback(response) {
                $scope.getImage();
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }

        $scope.dislikeImage = function (number) {

            var imgObj = {};
            imgObj.Number = number;
            $http({
                method: 'POST',
                url: '/Users/DislikeImage/',
                data: $scope.currentImage
            }).then(function successCallback(response) {
                $scope.getImage();
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }

        //$scope.likeImage = function() {

        //}
        


        $scope.listLikedImages = function ()
        {
            $http({
                method: 'GET',
                url: '/Users/ListLikedImages'
            }).then(function successCallback(response) {
                var images = response.data;
                $scope.likedImages = images;
                $scope.dislikedImages = null;
                $scope.showImage = false;
                if (images.length === 0) {
                    $scope.nolikedimages = true;
                } else {
                    $scope.nolikedimages = false;
                }
            },
                function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
        }

        $scope.listDislikedImages = function () {
            $http({
                method: 'GET',
                url: '/Users/ListDislikedImages'
            }).then(function successCallback(response) {
                var images = response.data;
                $scope.dislikedImages = images;
                $scope.likedImages = null;
                $scope.showImage = false;
                if (images.length === 0) {
                    $scope.nodislikedimages = true;
                } else {
                    $scope.nodislikedimages = false;
                }
            },
                function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    alert(response);
                });
        }

    }]);