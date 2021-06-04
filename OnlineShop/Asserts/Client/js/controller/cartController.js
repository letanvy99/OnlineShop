var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtquantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(this).val(),
                    Product: {
                        ID: $(item).data('id')
                    }

                });
            });
            $.ajax({
                type: "POST",
                url: "/Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {

                        window.location.href = "/gio-hang";
                    }
                }
            });
        });
        $('#btnDeleteAll').off('click').on('click', function () {
           /* var listProduct = $('.txtquantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(this).val(),
                    Product: {
                        ID: $(item).data('id')
                    }

                });
            });*/
            $.ajax({
                type: "POST",
                url: "/Cart/DeleteAll",
/*                data: { cartModel: JSON.stringify(cartList) },*/
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {

                        window.location.href = "/gio-hang";
                    }
                }
            });
        });
        $('.btn-delete').off('click').on('click', function (e) {

            e.preventDefault();
            $.ajax({
                type: "POST",
                url: "/Cart/Delete",
                data: { id: $(this).data('id') },
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {

                        window.location.href = "/gio-hang";
                    }
                }
            });
        });
    }
}
cart.init();