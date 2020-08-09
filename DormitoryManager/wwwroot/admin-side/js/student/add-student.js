let AddStudent = function () {
    function registerEvents() {
        //Init validation
        $('#frmStudentInfor').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                StudentIdentify: { required: true },
                Birthday: { required: true },
                Class: { required: true, },
                Address: {required: true, }
            }
        });

        $("#btn-create").on('click', function () {
            resetFormAddStudent();
            $('#modal-add-edit').modal('show');

        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var studentId = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Student/GetById",
                data: { id: studentId },
                dataType: "json",
                beforeSend: function () {
                    eagle.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#ckStatus').prop('checked', data.status === 1);
                    $('#hidId').val(data.id);
                    $('#txtStudentName').val(data.studentName);
                    $('#txtSudentId').val(data.studentIdentify);
                    $('#txtClass').val(data.class);
                    $('#txtBirthday').val(new Date(data.birthDay).toISOString().substring(0,10));
                    $('#txtAddress').val(data.address);
                    $('#selFloor').val(data.floorId);
                    getAllRoomOfFloor(data.floorId);
                    $('#selRoom').val(data.roomId);
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
            if ($('#frmStudentInfor').valid()) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "/Admin/Student/SaveEntity",
                    data: $('#frmStudentInfor').serialize(),
                    dataType: "json",
                    beforeSend: function () {
                        eagle.startLoading();
                    },
                    success: function () {
                        eagle.notify('Save user succesful', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormAddStudent();
                        eagle.stopLoading();
                        ListStudent.loadData(false);
                    },
                    error: function () {
                        eagle.notify('Has an error', 'error');
                        eagle.stopLoading();
                    }
                });
            }
            return false;
        });

        $('#selFloor').on('change', function () {
            let floorId = $(this).val();
            floorId = Number(floorId);
            getAllRoomOfFloor(floorId);
        });

        let getAllRoomOfFloor = (floorId) => {
            $.ajax({
                type: "POST",
                url: "/Admin/Student/GetListRoom",
                data: {floorId},
                dataType: "json",
                beforeSend: function () {
                    eagle.startLoading();
                },
                success: function (result) {
                    eagle.stopLoading();
                    const rooms = result;
                    $('#selRoom').empty();
                    rooms.map((room) => {
                        let newOption = `<option value="${room.id}">${room.roomName}</option>`;
                        $('#selRoom').append(newOption);

                    })
                },
                error: function () {
                    eagle.notify('Has an error', 'error');
                    eagle.stopLoading();
                }
            });
        }

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var studentId = $(this).data('id');
            eagle.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Student/Delete",
                    data: { id: studentId },
                    beforeSend: function () {
                        eagle.startLoading();
                    },
                    success: function () {
                        eagle.notify('Delete successful', 'success');
                        eagle.stopLoading();
                        ListStudent.loadData(false);
                    },
                    error: function () {
                        eagle.notify('Has an error', 'error');
                        eagle.stopLoading();
                    }
                });
            });
        });

    };
    function disableFieldEdit(disabled) {
        $('#txtStudentName').prop('disabled', disabled);
        $('#txtSudentId').prop('disabled', disabled);

    }
    function resetFormAddStudent() {
        disableFieldEdit(false);
        $('#hidId').val('');
        $('#txtStudentName').val('');
        $('#txtSudentId').val('');
        $('#txtClass').val('');
        $('#txtBirthday').val('');
        $('#txtAddress').val('');
    }
    return {
        init: function () {
            registerEvents();
        }
    }
}();
document.addEventListener('DOMContentLoaded', function () {
    AddStudent.init();
});
