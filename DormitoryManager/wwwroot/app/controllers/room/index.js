var roomController = function () {
    this.initialize = function () {

        $(document).ready(function () {
            $("#txtUserName").focus();
            registerEvents();
        });
    }

    var registerEvents = function () {
        $("#btn-create").on('click', function () {
            getAllFloor();
            $('#modal-add-edit').modal('show');
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Room/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    eagle.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidId').val(data.id);
                    $('#txtRoomName').val(data.roomName);
                    $('#txtRoomHeight').val(data.roomHeight);
                    $('#txtRoomWidth').val(data.roomWidth);
                    $('#txtElectricityPrice').val(data.electricityPrice);
                    $('#txtWaterPrice').val(data.waterPrice);
                    $('#txtInternetPrice').val(data.internetPrice);
                    $('#txtTotalBed').val(totalBed);
                    $('#txtTotalEmtyBed').val(totalEmtyBed);

                    disableFieldEdit(true);
                    $('#modal-add-edit').modal('show');
                    eagle.stopLoading();


                },
                error: function () {
                    eagle.notify('Có lỗi xảy ra', 'error');
                    eagle.stopLoading();
                }
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmRoom').valid()) {
                e.preventDefault();

                let id = ($('#hidId').val()) ? $('#hidId').val() : 0;
                let roomName = $('#txtRoomName').val();
                let roomHeight = $('#txtRoomHeight').val();
                let roomWidth = $('#txtRoomWidth').val();
                let electricityPrice = $('#txtElectricityPrice').val();
                let waterPrice = $('#txtWaterPrice').val();
                let internetPrice = $('#txtInternetPrice').val();
                let totalBed = $('#txtTotalBed').val();
                let totalEmtyBed = $('#txtTotalEmtyBed').val();
                $.ajax({
                    type: "POST",
                    url: "/Admin/Room/SaveEntity",
                    data: {
                        Id: id,
                        RoomName: roomName,
                        RoomHeight: roomHeight,
                        RoomWidth: roomWidth,
                        ElectricityPrice: electricityPrice,
                        WaterPrice: waterPrice,
                        InternetPrice: internetPrice,
                        TotalBed: totalBed,
                        TotalEmtyBed: totalEmtyBed,
                        FloorId: $('#lst-data-floor').val()
                    },
                    dataType: "json",
                    beforeSend: function () {
                        eagle.startLoading();
                    },
                    success: function () {
                        eagle.notify('Save user succesful', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormMaintainance();

                        eagle.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        eagle.notify('Has an error', 'error');
                        eagle.stopLoading();
                    }
                });
            }
            return false;
        });

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            eagle.confirm('Bạn chắc chắn muốn xóa bản ghi này?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Room/Delete",
                    data: { id: that },
                    beforeSend: function () {
                        eagle.startLoading();
                    },
                    success: function () {
                        eagle.notify('Delete successful', 'success');
                        eagle.stopLoading();
                        loadData();
                    },
                    error: function () {
                        eagle.notify('Has an error', 'error');
                        eagle.stopLoading();
                    }
                });
            });
        });
    }

    function loadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/Admin/Room/GetAllPaging",
            data: {
                textSearch: $('#txt-search-keyword').val(),
                page: eagle.configs.pageIndex,
                pageSize: eagle.configs.pageSize,
            },
            dataType: "json",
            beforeSend: function () {
                eagle.startLoading();
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                if (response.rowCount > 0) {
                    $.each(response.results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.id,
                            RoomName: roomName,
                            RoomHeight: roomHeight,
                            RoomWidth: roomWidth,
                            ElectricityPrice: electricityPrice,
                            WaterPrice: waterPrice,
                            InternetPrice: internetPrice,
                            TotalBed: totalBed,
                            TotalEmtyBed: totalEmtyBed
                        });
                    });
                    $("#lbl-total-records").text(response.rowCount);
                    if (render !== undefined) {
                        $('#tbl-content').html(render);

                    }
                    wrapPaging(response.rowCount, function () {
                        loadData();
                    }, isPageChanged);


                }
                else {
                    $('#tbl-content').html('');
                }
                eagle.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    };

    function getAllFloor(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/Admin/Floor/GetAll",
            data: {
                filter: $('#txt-search-keyword').val()
            },
            dataType: "json",
            beforeSend: function () {
                eagle.startLoading();
            },
            success: function (response) {
                var template = $('#result-data-floor').html();
                var render = '<option value="" disabled selected >- Chọn tầng -</option>';
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.floorName,
                        Id: item.id
                    });
                });

                if (render != undefined) {
                    $('#lst-data-floor').html(render);
                }

                eagle.stopLoading();
            },
            error: function (status) {
                eagle.notify('error', 'error');
                console.log(status);
            }
        });
    };


    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / eagle.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                eagle.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

    function resetFormMaintainance() {
        disableFieldEdit(false);
        $('#hidId').val('');
    }

    function disableFieldEdit(disabled) {

    }
}