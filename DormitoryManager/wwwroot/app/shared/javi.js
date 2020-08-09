var javi = {
    configs: {
        pageSize: 50,
        pageIndex: 1
    },
    notify: function (message, type) {
        $.notify(message, {
            // whether to hide the notification on click
            clickToHide: true,
            // whether to auto-hide the notification
            autoHide: true,
            // if autoHide, hide after milliseconds
            autoHideDelay: 8000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: 'top right',
            // default positions
            elementPosition: 'top right',
            globalPosition: 'top right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: type,
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 2
        });
    },
    confirm: function (message, okCallback) {
        bootbox.confirm({
            message: message,
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-primary'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    okCallback();
                }
            }
        });
    },
    convertDateJS: function (datetime) {
        if (datetime === null || datetime === '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return month + "/" + day + "/" + year;
    },
    dateFormatJson: function (datetime) {
        if (datetime === null || datetime === '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },
    dateFormatJson2: function (datetime) {
        if (datetime === null || datetime === '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;

        switch (month) {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            case 3:
                month = "March";
                break;
            case 4:
                month = "April";
                break;
            case 5:
                month = "May";
                break;
            case 6:
                month = "June";
                break;
            case 7:
                month = "July";
                break;
            case 8:
                month = "August";
                break;
            case 9:
                month = "September";
                break;
            case 10:
                month = "October";
                break;
            case 11:
                month = "November";
                break;
            case 12:
                month = "December";
                break;

        }

        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },
    dateTimeFormatJson: function (datetime) {
        if (datetime === null || datetime === '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },
    timeFormatJson: function (datetime) {
        if (datetime === null || datetime === '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return hh + ":" + mm + ":" + ss;
    },
    startLoading: function () {
        //if ($('.dv-loading').length > 0)
        //    $('.dv-loading').removeClass('hide');
        $('#page-wrapper').addClass('sk-loading');
    },
    stopLoading: function () {
        //if ($('.dv-loading').length > 0)
        //    $('.dv-loading')
        //        .addClass('hide');
        $('#page-wrapper').removeClass('sk-loading');
    },
    getStatus: function (status) {
        if (status === 1)
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Kích hoạt</span>';
        else
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Khoá</span>';
    },
    getStatus2: function (status) {
        if (status === 0)
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Chưa Xong</span>';
        else
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Hoàn Thành</span>';
    },
    getStatus3: function (status) {
        if (status === 0)
            return '<span class="badge" style="background-color:#ed5565; color:#fff; width:68px">Nghỉ việc</span>';
        else if (status === 1)
            return '<span class="badge" style="background-color:#fff814; color:#DC0000; width:68px">Hết hạn</span>';
        else if (status === 2)
            return '<span class="badge" style="background-color:#1ab394; color:#fff; width:68px">Hoạt động</span>';

    },
    getStatus4: function (status) {
        if (status === 2)
            return '<span class="badge" style="background-color:#1ab394; color:#fff; width:68px">Còn hạn</span>';
        else if (status === 1)
            return '<span class="badge" style="background-color:#fff814; color:#DC0000; width:68px">Hết hạn</span>';
        else if (status === 0) {
            return '<span class="badge" style="background-color:#ed5565; color:#fff; width:68px">Đã xóa</span>';
        }
    },
    getDocumentStatus: function (status) {
        if (status === 1)
            return '<span class="badge" style="background-color:#f90909; color:#fff; width:auto">Chưa đưa hồ sơ</span>';
        else if (status === 2)
            return '<span class="badge" style="background-color:#ff9900; color:#fff; width:auto">Đã đưa lên</span>';
        else if (status === 3)
            return '<span class="badge" style="background-color:#00ff0c; color:#fff; width:auto">Quản lý chấp nhận</span>';
        else if (status === 4)
            return '<span class="badge" style="background-color:#6f6f6f; color:#fff; width:auto">Không áp dụng</span>';
    },
    getConfirm: function (status) {
        if (status == null)
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Chưa Duyệt</span>';
        if (status == 1)
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Đã Duyệt</span>';
        else if (status == 0)
            return '<span class="badge" style="background-color:#ff0000; color:#fff">Không Duyệt</span>';
    },
    getConfirm2: function (plCheck, mCheck) {
        if (plCheck == 0 || mCheck == 0)
            return '<span class="badge" style="background-color:#ff0000; color:#fff">Không Duyệt</span>';
        else if (plCheck == null && mCheck == null)
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Chưa Duyệt</span>';
        else
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Đã Duyệt</span>';
    },
    getTaskStatus: function (status) {
        if (status == 1)
            return '<span class="badge" style="background-color:#c4bebe; color:#fff">Chưa xử lý</span>';
        else if (status == 2)
            return '<span class="badge" style="background-color:#e6b41d; color:#fff">Đang xử lý</span>';
        else if (status == 3)
            return '<span class="badge" style="background-color:#27ae60; color:#fff">Đã xử lý</span>';
        else if (status == 4)
            return '<span class="badge" style="background-color:#ff0000; color:#fff">Chờ duyệt</span>';

    },
    getOnline: function (status) {
        if (status === 1)
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Online</span>';
        else
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Offline</span>';
    },
    getHasRead: function (hasRead) {
        if (hasRead === true)
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Đã Xem</span>';
        else
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Chưa Xem</span>';
    },
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
        return a.join('.');
    },
    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    },
    getGioiTinh: function (GioiTinh) {
        if (GioiTinh === 1)
            return '<span class="badge" style="background-color:#1ab394; color:#fff">Nam</span>';
        else
            return '<span class="badge" style="background-color:#ed5565; color:#fff">Nữ</span>';
    }
}

$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() === "POST" || options.type.toUpperCase() === "PUT") {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});