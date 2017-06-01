var Script = function () {

    $.validator.setDefaults({
        submitHandler: function() { alert("submitted!"); }
    });

    $().ready(function() {
        // validate the comment form when it is submitted
        $("#feedback_form").validate();

        // validate signup form on keyup and submit
        
		$("#register-form").validate({
            rules: {
                ten: {
                    required: true,
                    minlength: 5
                },
                ma: {
                    required: true,
                    minlength: 5
                },
                tendangnhap: {
                    required: true,
                    minlength: 5
                },
                matkhau: {
                    required: true,
                    minlength: 5
                },
				sodienthoai: {
                    required: true,
                    minlength: 5
                },
				diachi: {
                    required: true
                },
                confirm_password: {
                    required: true,
                    minlength: 5,
                    equalTo: "#password"
                },
                ngaysinh: {
                    required: true,
                    email: true
                },
				email: {
                    required: true,
                    email: true
                },
                topic: {
                    required: "#newsletter:checked",
                    minlength: 2
                },
                trangthai: "required"
            },
            messages: {                
                ten: {
                    required: "Vui lòng nhập họ tên.",
                    minlength: "Họ tên của bạn phải trên 5 ký tự."
                },
                ma: {
                    required: "Vui lòng nhập mã.",
                    minlength: "Mã phải trên 5 ký tự."
                },
                tendangnhap: {
                    required: "Vui lòng nhập tên đăng nhập.",
                    minlength: "Tên đăng nhập của bạn phải trên 5 ký tự."
                },
                matkhau: {
                    required: "Vui lòng nhập mật khẩu.",
                    minlength: "Mật khẩu của bạn phải trên 5 ký tự."
                },
                confirm_password: {
                    required: "Vui lòng nhập lại mật khẩu.",
                    minlength: "Mật khẩu của bạn phải trên 5 ký tự.",
                    equalTo: "Nhập đúng mật khẩu bạn vừa nhập."
                },
				sodienthoai: {
                    required: "Vui lòng nhập số điện thoại.",
                    minlength: "số điện thoại của bạn phải trên 5 ký tự."
                },
				diachi: {
                    required: "Vui lòng nhập điạ chỉ."
                },
				email: "Vui lòng nhập đúng định dạng email.",
                ngaysinh: "Vui lòng nhập đúng định dạng ngày sinh.",
                trangthai: "Vui lòng chọn trạng thái."
            }
        });
		// end thêm nhân viên

        // propose username by combining first- and lastname
        $("#username").focus(function() {
            var firstname = $("#firstname").val();
            var lastname = $("#lastname").val();
            if(firstname && lastname && !this.value) {
                this.value = firstname + "." + lastname;
            }
        });

        //code to hide topic selection, disable for demo
        var newsletter = $("#newsletter");
        // newsletter topics are optional, hide at first
        var inital = newsletter.is(":checked");
        var topics = $("#newsletter_topics")[inital ? "removeClass" : "addClass"]("gray");
        var topicInputs = topics.find("input").attr("disabled", !inital);
        // show when newsletter is checked
        newsletter.click(function() {
            topics[this.checked ? "removeClass" : "addClass"]("gray");
            topicInputs.attr("disabled", !this.checked);
        });
    });


}();