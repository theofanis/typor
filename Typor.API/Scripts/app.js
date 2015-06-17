var ViewModel = function () {
    var self = this;
    self.detail = ko.observable();
    self.shoppingCarts = ko.observableArray();
    self.error = ko.observable();

    var shoppingCartsUri = 'api/shoppingcarts/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllShoppingCarts() {
        ajaxHelper(shoppingCartsUri, 'GET').done(function (data) {
            self.shoppingCarts(data);
        });
    }

    self.getShoppingCartDetail = function (item) {
        ajaxHelper(shoppingCartsUri + item.id, 'GET').done(function (data) {
            self.detail(data);
        })
    }

    // Fetch the initial data.
    getAllShoppingCarts();
};

ko.applyBindings(new ViewModel());