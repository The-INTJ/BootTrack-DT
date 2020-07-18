$(document).ready(function () {



    /* Checks and unchecks checkboxes */
    $("img").click(function () {
        if ($(this).attr("src") === "/Images/square.svg") {
            $(this).attr("id", "Checked");
            $(this).attr("src", "/Images/check-square.svg");
        } else {
            $(this).attr("id", "Unchecked");
            $(this).attr("src", "/Images/square.svg");
        }
    })
})