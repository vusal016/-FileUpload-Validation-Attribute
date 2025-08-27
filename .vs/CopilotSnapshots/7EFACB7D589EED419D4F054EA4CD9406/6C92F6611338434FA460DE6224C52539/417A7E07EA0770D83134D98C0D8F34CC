$(document).ready(function () {
    $(".bookModal").click(function (ev) {
        ev.preventDefault();
        let url = $(this).attr("href");

        fetch(url)
            .then(response => response.text())
            .then(data => {
                $("#quickModal  .modal-dialog").html(data);
                $("quickModal").show();
         
    });
});
