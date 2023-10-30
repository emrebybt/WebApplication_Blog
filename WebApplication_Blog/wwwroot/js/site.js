
function AddComment() {
    var data = $("#comment").serialize();
    $.ajax({
        type: "POST",
        url: "/Comment/AddComment",
        data: data,
        success: function (response) {
            $("#comment")[0].reset();
            Swal.fire({
                position: 'bottom-end',
                icon: 'success',
                title: 'Yorumunuz admin onayına gönderildi',
                showConfirmButton: false,
                timer: 1500
            });
        }
    });
}
function AddReplyComment() {
    var data = $("#replycomment").serialize();
    $.ajax({
        type: "POST",
        url: "/Comment/AddReplyComment",
        data: data,
        success: function (response) {
            $("#replycomment")[0].reset();
            Swal.fire({
                position: 'bottom-end',
                icon: 'success',
                title: 'Yorumunuz admin onayına gönderildi',
                showConfirmButton: false,
                timer: 1500
            });
        }
    });
}
