var BaseController = function () {

    this.initialize = function () {
        //loadAnnouncement();
        //loadEmail();
        //loadReminder();
        registerEvents();
        registerControls();
    };

    //ckediter
    function registerControls() {
      
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtTitle').val('');
        $('#txtContentM').val('');
        $('#txtLink').html('');
        $('#txtTime').val('');
    }

    function resetEmailForm() {
        $('#hidIdM').val(0);
        $('#txtFrom1').val('');
        $('#txtTitle1').val('');
       // CKEDITOR.instances.txtContent1.setData('');
    }

    function registerEvents() {
        // quyda - check active menu       
        var currentLocation = $(location).attr('href');
        //var CURRENT_URL = window.location.href.split('#')[0].split('?')[0];
        //console.log(CURRENT_URL);
        //console.log(currentLocation);
        $("#side-menu a").each(function () {
            if (currentLocation.indexOf($(this).attr('href')) > 0) {
                //console.log($(this).attr('href'));
                if ($(this).attr('href').length > 1) {
                    $(this).parent('li').addClass('active');
                    $(this).parent().parent().parent().addClass('active');
                }
                //$(this).addClass('active');
                //$(this).parent().addClass('active');
                //.find('a[href="' + CURRENT_URL + '"]').parent('li').addClass('current-page');
              
                //$(this).parent().parent().parent().parent().parent().addClass('active');
                //$(this).parent().parent().parent().parent().parent().parent().parent().addClass('active');
            }
        });

        $('body').on('click', '.btn-announcement', function () {
            var that = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/Announcement/MarkAsRead",
                data: { id: that },
                success: function () {
                    loadAnnouncement();
                }
            });
            $.ajax({
                type: "GET",
                url: "/Announcement/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    javi.startLoading();
                },
                success: function (response) {
                    resetFormMaintainance();
                    var data = response;
                    $('#hidIdM1').val(data.Id);
                    $('#txtTitle21').val(data.Title);
                    $('#txtContentM1').val(data.Content);
                    if (data.Link != null) {
                        $('#txtLink1').html('Xem Chi Tiết');
                        $('#txtLink1').prop('href', data.Link);
                    }
                    else {
                        let p = document.getElementById('txtLink1');
                        p.removeAttribute("href");
                    }
                    $('#txtTime1').val(javi.dateTimeFormatJson(data.DateCreated));
                    $('#modal-detail').modal('show');
                    javi.stopLoading();

                },
                error: function () {
                    javi.notify('Có lỗi xảy ra', 'error');
                    javi.stopLoading();
                }
            });
        });

        $('body').on('click', '.btn-email', function () {
            var that = $(this).data('id');
            var emailToId = $(this).data('toid');
            $.ajax({
                type: "POST",
                url: "/Email/MarkAsRead",
                data: { id: emailToId },
                success: function () {
                    loadAnnouncement();
                }
            });
            $.ajax({
                type: "GET",
                url: "/Email/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    javi.startLoading();
                },
                success: function (response) {
                    resetEmailForm();
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtFrom1').val(data.From);
                    $('#txtTitle1').val(data.Title);
                    CKEDITOR.instances.txtContent1.setData(data.Content);
                    $('#email-detail-modal').modal('show');
                    javi.stopLoading();

                },
                error: function () {
                    javi.notify('Có lỗi xảy ra', 'error');
                    javi.stopLoading();
                }
            });
        });

        $('body').on('click', '.btn-reminder', function () {
            var that = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/Reminder/MarkAsRead",
                data: { id: that },
                success: function () {
                    loadReminder();
                }
            });
        });

        $('body').on('click', '.btn-email', function () {
            var that = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/Email/MarkAsRead",
                data: { id: that },
                success: function () {
                    loadEmail();
                }
            });
        });
    };

    //function loadAnnouncement() {
    //    $.ajax({
    //        type: "GET",
    //        url: "/Announcement/GetAllUnReadPaging",
    //        data: {
    //            page: 1,
    //            pageSize: 50
    //        },
    //        dataType: "json",
    //        beforeSend: function () {
    //            javi.startLoading();
    //        },
    //        success: function (response) {
    //            var template = $('#announcement-template').html();
    //            var render = "";
    //            if (response.RowCount > 0) {
    //                $('#announcementArea').show();
    //                $.each(response.Results, function (i, item) {
    //                    render += Mustache.render(template, {
    //                        Link: item.Link !== null ? item.Link : '',
    //                        Title: item.Title,
    //                        Content: item.Content.length < 50 ? item.Content : item.Content.substring(0, 50) + '...',
    //                        Id: item.Id,
    //                        Avatar: item.Avatar !== null ? item.Avatar : '/images/user.jpg',
    //                        DateCreated: javi.dateTimeFormatJson(item.DateCreated)
    //                    });
    //                });
    //                render += $('#announcement-tag-template').html();
    //                $("#totalAnnouncement").text(response.RowCount);
    //                if (render != undefined) {
    //                    $('#annoncementList').html(render);
    //                }
    //            }
    //            else {
    //                $('#announcementArea').hide();
    //                $('#annoncementList').html('');
    //            }
    //            javi.stopLoading();
    //        },
    //        error: function (status) {
    //            console.log(status);
    //        }
    //    });
    //};

    //function loadEmail() {
    //    $.ajax({
    //        type: "GET",
    //        url: "/Email/GetAllByReceiveEmail",
    //        dataType: "json",
    //        beforeSend: function () {
    //            javi.startLoading();
    //        },
    //        success: function (response) {
    //            var template = $('#email-template').html();
    //            var render = "";
               
    //            if (response.length > 0) {
    //                $('#EmailArea').show();
    //                var d = 0;
    //                $.each(response, function (i, item) {
    //                    if (item.HasRead == false)
    //                        d++;

    //                    render += Mustache.render(template, {
    //                        EmailId: item.Id,
    //                        EmailToId: item.EmailToId,
    //                        Sender: item.From,
    //                        EmailDate: javi.dateTimeFormatJson(item.DateCreated),
    //                        IsReaded: item.HasRead ? "" : "unread"
    //                    });
    //                });
    //                render += $('#email-tag-template').html();
    //                $("#totalEmail").text(d);
    //                if (render != undefined) {
    //                    $('#emailList').html(render);
    //                }
    //            }
    //            else {
    //                $('#EmailArea').hide();
    //                $('#emailList').html('');
    //            }
    //            javi.stopLoading();
    //        },
    //        error: function (status) {
    //            console.log(status);
    //        }
    //    });
    //};

    //function loadReminder() {
    //    $.ajax({
    //        type: "GET",
    //        url: "/Reminder/GetAllByUser",
    //        dataType: "json",
    //        beforeSend: function () {
    //            javi.startLoading();
    //        },
    //        success: function (response) {
    //            var template = $('#reminder-template').html();
    //            var render = "";
    //            if (response.length > 0) {
    //                $('#reminderArea').show();
    //                var d = 0;
    //                $.each(response, function (i, item) {
    //                    if (item.HasRead == false)
    //                        d++;
    //                    render += Mustache.render(template, {
    //                        Link: item.Link !== null ? item.Link : '',
    //                        Title: item.Title,
    //                        Content: item.Content.length < 50 ? item.Content : item.Content.substring(0, 50) + '...',
    //                        Id: item.Id,
    //                        Avatar: item.Avatar !== null ? item.Avatar : '/images/user.jpg',
    //                        DateCreated: javi.dateTimeFormatJson(item.DateCreated),
    //                        IsReaded: item.HasRead ? "" : "unread"
    //                    });
    //                });
    //                render += $('#reminder-tag-template').html();
    //                $("#totalReminder").text(d);
    //                if (render != undefined) {
    //                    $('#reminderList').html(render);
    //                }
    //            }
    //            else {
    //                $('#reminderArea').hide();
    //                $('#reminderList').html('');
    //            }
    //            javi.stopLoading();
    //        },
    //        error: function (status) {
    //            console.log(status);
    //        }
    //    });
    //};
}