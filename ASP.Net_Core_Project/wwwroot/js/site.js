
$(document).ready(function () {
    $(".page-link").click(function (e) {
        e.preventDefault();
        var uri = this.attributes["href"].value;
        $("#pagedList").load(uri);
        $(".active").removeClass("active disabled");
        $(this).parent().addClass("active");
        history.pushState(null, null, uri);
    });
});