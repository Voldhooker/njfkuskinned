// adds the resource to umbraco.resources module:
angular.module('umbraco.resources').factory('customMemberResource',
    function ($q, $http, umbRequestHelper) {
        // the factory object returned
        return {
            // this calls the ApiController we setup earlier
            getAll: function (memberGroup) {
                return umbRequestHelper.resourcePromise(
                    $http.get(" /Umbraco/api/CustomMemberApi/GetMembers?memberGroup="+memberGroup),
                    "Failed to retrieve all memberdata");
            }
        };
    }
); 