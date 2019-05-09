$(document).ready(function(){
    $("#inform").on("click", function(){
        $("#subscriber").fadeIn("slow");
    });
    $(".subscriber-close").on("click", function (){
        $("#subscriber").fadeOut("slow");
    });

    $("#menu-icon").on("click", function () {
        if(window.innerHeight > window.innerWidth) {
            $("#menu-links").slideToggle("slow");
        }else{
            $("#menu-links").fadeToggle("slow");
        }
    });

    $("#mercedes-logo").on("click", function (){
            let angle = 0;
            setInterval(function () {
                $("#mercedes-logo").css('transform', 'rotate(' + angle + 'deg)');
                angle += 2;
            }, 100);
});
});