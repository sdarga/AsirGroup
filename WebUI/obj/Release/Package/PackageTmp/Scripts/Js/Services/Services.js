//-------------
// Author: gterdem@sakarya.edu.tr
// basvuruService Factory (Angular Ogrenci Servisi) 
// v1.2a - Angular basvuruService factory
var islemFactory = angular.module('islemFactory', []);
//Personel Factory
islemFactory.factory('islemService', ['$http', "$q", function (http, q) {
    var islemService = {};
    islemService.getPersonelData = function (kullaniciID) {
        return http.get(routes.GetPersonelBilgisiByokJson, { params: { KullaniciID: kullaniciID } });
    };
    islemService.getPersonelServiceData = function (kullaniciID) {
        return http.get(routes.GetPersonelBilgisiJson, { params: { KullaniciID: kullaniciID } });
    };
    islemService.saveApplication = function (model) {
        return http.post(routes.SaveIslemByObjectJson, model);
    }
    islemService.getIslemByID = function (islemID) {
        if (islemID == null) islemID = 0;
        return http.post(routes.GetIslemByIDJson, { params: { islemID: islemID } });
    }
    islemService.getTumBirimlerByJson = function () {
        return http.post(routes.GetTumBirimlerByJson, { params: { islemID: 0 } });
    }
    islemService.getSikayetKonulariByJson = function () {
        return http.post(routes.GetSikayetKonulariByJson, { params: { islemID: 0 } });
    }

    islemService.UploadFile = function (file, description) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);

        var defer = $q.defer();
        $http.post("/Islem/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Dosya Yüklemede Hata!");
        });

        return defer.promise;

    }
    return islemService;
}]);

