let SudentList = function () {
    let _StudentList = function () {
        function loadData(isPageChanged) {
            $.ajax({
                type: "POST",
                url: "/admin/home/GetTopStudent",
                data: {
                    page: 0,
                    pageSize: 10
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
                        if (render !== undefined) {
                            $('#tbl-student .tbl-content').html(render);

                        }
                        wrapPaging(response.rowCount, function () {
                            loadData();
                        }, isPageChanged);


                    }
                    else {
                        $('#tbl-student .tbl-content').html('');
                    }
                    eagle.stopLoading();
                },
                error: function (status) {
                    console.log(status);
                }
            });
        };
    }
    return {
        init: function () {
            _StudentList();
        }
    }
}();
document.addEventListener('DOMContentLoaded', function () {
    SudentList.init();
});
