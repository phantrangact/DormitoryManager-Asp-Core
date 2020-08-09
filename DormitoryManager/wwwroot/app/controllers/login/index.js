var loginController = function () {
    this.initialize = function () {

        $(document).ready(function () {
            $("#txtUserName").focus();
            registerEvents();
        });
    }

    var registerEvents = function () {
        $('#frmLogin').validate({
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required: true
                },
                password: {
                    required: true
                }
            }
        });

        $('#txtPassword').keypress(function (e) {
            if (e.which === 13) {
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });

        $('#btnLogin').on('click', function (e) {
            if ($('#frmLogin').valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
           
        });
    }

    var login = function (user, pass) {

        if ($('#frmLogin').valid()) {
            if (user == "" || user == null || user == undefined) {
                javi.notify("Chưa nhập tài khoản", "error");
                return false;
            }

            if (pass == null || pass == "" || pass == undefined) {
                javi.notify("Chưa nhập mật khẩu", "error");
                return false;
            }

            $.ajax({
                type: 'POST',
                url: '/Login/Authen',
                data: {
                    UserName: user,
                    Password: pass
                },
                dateType: 'json',
                beforeSend: function () {
                    $('body').addClass('sk-loading');
                },
                success: function (res) {
                    if (res.success) {
                        console.log("SUCCESS")
                        window.location.href = '/Home/Index';
                    }
                    else {
                        javi.notify("Tài khoản hoặc mật khẩu không đúng", 'error');
                    }
                },
                error: function (error) {

                },
                complete: function () {
                    $('body').removeClass('sk-loading');
                }
            })
        }
    }
}