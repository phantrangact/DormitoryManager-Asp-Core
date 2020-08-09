let ListStudent = function () {
    function loadData(isPageChanged) {
        $.ajax({
            type: "POST",
            url: "/admin/home/GetTopStudent",
            data: {},
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
                            FullName: item.studentName,
                            Id: item.id,
                            StudentIdentify: item.studentIdentify,
                            Class: item.class,
                            DateCreated: eagle.dateTimeFormatJson(item.dateCreated),
                            Birthday: eagle.dateFormatJson(item.birthDay),
                            Floor: item.floorName,
                            Room: item.roomName,
                            Status: eagle.getStatus(item.status)
                        });
                    });
                    $("#lbl-total-records").text(response.rowCount);
                    if (render !== undefined) {
                        $('#tbl-student .tbl-content').html(render);

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
    function search() {
        $('#txt-search-keyword').keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData();
            }
        });
        $("#btn-search").on('click', function () {
            loadData();
        });
        $("#ddl-show-page").on('change', function () {
            eagle.configs.pageSize = $(this).val();
            eagle.configs.pageIndex = 1;
            loadData(true);
        });
    }
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