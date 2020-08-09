let ListStudent = function () {
    function loadData(isPageChanged) {
        $.ajax({
            type: "POST",
            url: "/admin/home/GetTopRoom",
            data: {},
            dataType: "json",
            beforeSend: function () {
                eagle.startLoading();
            },
            success: function (response) {
                var template = $('#tbl-room .table-template').html();
                var render = "";
                if (response.rowCount > 0) {
                    $.each(response.results, function (i, item) {
                        render += Mustache.render(template, {
                            RoomName: item.roomName,
                            Id: item.id,
                            Floor: item.floorName,
                            Room: item.roomName,
                            TotalEmtyBed: item.TotalEmtyBed,
                            TotalUsedBed: item.TotalUsedBed,
                            TotalBed: item.TotalBed,
                            Status: eagle.getStatus(item.status)
                        });
                    });
                    if (render !== undefined) {
                        $('#tbl-room .tbl-content').html(render);

                    }
                    wrapPaging(response.rowCount, function () {
                        loadData();
                    }, isPageChanged);


                }
                else {
                    $('#tbl-room .tbl-content').html('');
                }
                eagle.stopLoading();
            },
            error: function (status) {
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
    return {
        init: function () {
            loadData();
            search();
        }
    }
}();
document.addEventListener('DOMContentLoaded', function () {
    ListStudent.init();
});