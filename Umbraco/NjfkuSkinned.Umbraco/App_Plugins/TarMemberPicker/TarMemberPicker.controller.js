angular.module("umbraco")
    .controller("TarSoft.MemberPicker", function ($scope, customMemberResource) {
        var res = '';
        if ($scope.model.config.filterGroup !== undefined && $scope.model.config.filterGroup !== '') {
            res = $scope.model.config.filterGroup;
        }
        customMemberResource.getAll(res).then(function (response) {
            $scope.members = response;
            $scope.selectedMembers = [];
            $scope.selectedDropdown = null;
        });

        $scope.add = function () {
            console.log('Selected dropdown is: |' + $scope.selectedDropdown+'|');
            if ($scope.selectedDropdown !== null && !$scope.selectedMembers.filter(e => e.Id === $scope.selectedDropdown.Id).length > 0) {
            
                $scope.selectedMembers.push($scope.selectedDropdown);
            }
        };
        $scope.remove = function (item) {
            console.log('Removing item with id  ' + item.Id);
            if ($scope.selectedMembers.filter(e => e.Id === item.Id).length > 0) {
                var index = $scope.selectedMembers.indexOf(item);
                $scope.selectedMembers.splice(index, 1); 
            }
        };
        //$scope.selectedMembers = [];
        //$scope.update = function (id) {
        //    id = event.target.id;
        //    $scope.model.value = id;
        //};
        $scope.onChange = function (deviceValue) {
            console.log(deviceValue);
            $scope.model.value = deviceValue;
        };
    });

//angular.module("umbraco").controller("TarSoft.MemberPicker",
//    //inject umbracos assetsService
//    function ($scope, notificationsService, assetsService, angularHelper, $element) {
//        //setup the default config
//        //var config = {
//        //    pickDate: false,
//        //    pickTime: true,
//        //    useSeconds: false,
//        //    format: "HH:mm",
//        //    icons: {
//        //        time: "icon-time",
//        //        date: "icon-calendar",
//        //        up: "icon-chevron-up",
//        //        down: "icon-chevron-down"
//        //    }

//        //};
//        //$scope.change = function () {
//        //    console.log('change!');
//        //};
//        //map the user config
//        $scope.model.config = angular.extend(config, $scope.model.config);

//        //var filesToLoad = ["/Umbraco/lib/moment/moment-with-locales.js",
//        //    "/Umbraco/lib/datetimepicker/bootstrap-datetimepicker.js"];

//        //plugin folder
//        assetsService
//            //.load(filesToLoad)
//            .then(function () {
//                //var element = $element;


//                //// Open the datepicker and add a changeDate eventlistener
//                //element.datetimepicker(angular.extend({ useCurrent: false }, $scope.model.config));
//                //element.bind("blur", function () {
//                //    //console.log('blur');
//                //    //console.log(element.val());
//                //    console.log($scope.model.value);
//                //    $scope.model.value = element.val();
//                //    console.log($scope.model.value);
//                //});
//                ////Ensure to remove the event handler when this instance is destroyted
//                //$scope.$on('$destroy', function () {
//                //    element.unbind("blur");
//                //    element.datetimepicker("destroy");
//                //});
//            });

//        //load the seperat css for the editor to avoid it blocking our js loading
//        //assetsService.loadCss('/Umbraco/lib/datetimepicker/bootstrap-datetimepicker.min.css');
//    });