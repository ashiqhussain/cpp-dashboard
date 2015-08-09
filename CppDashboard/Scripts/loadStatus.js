angular.module("customerPaymentsDashboard", [])
        .controller("statusController", function ($scope, $http, $interval) {

            var systemLoad = function () {
                var system = $http.get(window.loadSystemUri);
                system.success(function (data) {
                    $scope.systemData = {};
                    $scope.systemData.errorSummary = data;
                    $scope.systemData.noErrors = '';
                    for (var s in data) {
                        if (data[s].ErrorCount == 0) {
                            $scope.systemData.noErrors += data[s].Service + ', ';
                        }
                    }
                });
            };

            var doPageFunc = function () {
                var offlineStatus = $http.get(window.loadUrl);

                offlineStatus.success(function (data, status, headers, config) {
                    $scope.isOffline = data.IsSystemOnline;
                    $scope.systemMessage = data.IsSystemOnline === true ? 'ONLINE' : 'OFFLINE';
                    $scope.logs = data.Logs;
                    $scope.throughput = data.Throughput;
                    $scope.current = data.Current;
                    $scope.paymentInfo = {};
                    $scope.paymentInfo.success = data.SuccessPayments;
                    $scope.paymentInfo.declines = data.DeclinedPayments;
                    $scope.paymentInfo.cancellations = data.CancellationsDueToGhosts;
                    $scope.paymentInfo.commsFaiures = data.CommsFaliures;
                    $scope.paymentInfo.mkGatewayFailures = data.GatewayMkFaliures;
                    $scope.paymentInfo.mkAdyenFailures = data.AdyenMkFaliures;
                });


            };
            doPageFunc();
            systemLoad();
            
            $interval(function () {
                systemLoad();
            }, 10000 * 6); // every min.

            $interval(function () {
                $http.get(window.updateUrl);
                doPageFunc();
            }, 10000); // every 10s.

        });