function setPage() {

    var x = $(window).width();
    var y = $(window).height();
    var basicX = 1280;
    var basicY = 800;
    var resultX = x / basicX;
    var resultY = y / basicY;
    var smallerXY;
    if (x < y) {
        smallerXY = x;
    }
    else if (x > y) {
        smallerXY = y;
    }

    console.log("smaller:" + smallerXY + " resultX:" + resultX + " resultY:" + resultY);

    if (x > basicX || x == basicX) {
        /***Main Bar***/
        var MainBarNameHeight = 80;
        var MainBarNameWidth = 400;
        var TransparentNameHeight = 80;
        var TransparentNameWidth = 400;
        var MainBarHeight = 80;
        var MainBarLeft = MainBarNameWidth - 1;
        var MainBarListTop = 50;
        var MainBarTextSize = 20;
        var MenuArrowSize = 10;

        /***Search***/
        var SearchBoxWidth = 500;
        var SearchBoxHeight = 100;
        var SearchBoxThickness = 15;
        var SearchBoxTop = ((y - MainBarHeight) / 2) - (SearchBoxHeight / 2);
        var SearchBoxLeft = (x / 2) - (SearchBoxWidth / 2);
        var SearchFieldWidth = 520;
        var SearchFieldLeft = (x / 2) - (SearchFieldWidth / 2);
        var SearchFieldTop = MainBarHeight + 10;
        var MoviesResultTop = SearchFieldTop + 30;
        var PeopleResultTop = $("#moviesResult").height() + MoviesResultTop + 30;

        /***Footer***/
        var FooterHeight = 180;
        var FotterTop = 770;
        var CopyrightSize = 12;
    }

    /*else if(x < basicX)
	{
		var MainBarNameHeight = 80 * resultY;
		var MainBarNameWidth = 400 * resultX;
		var TransparentNameHeight = 80 * resultY;
		var TransparentNameWidth = 400 * resultX;
		var MainBarHeight = 80 * resultY;
		var MainBarLeft = (MainBarNameWidth) * resultX;
		var MainBarListTop = 50 * resultY;
		var MainBarTextSize = 20 * smallerXY;
		var MenuArrowSize = 10 * resultY;
		var SearchBoxWidth = 500 * resultX;
		var SearchBoxHeight = 100 * resultY;
		var SearchBoxThickness = 15;
		var SearchBoxTop = ((y - MainBarHeight)/2)-(SearchBoxHeight/2);
		var SearchBoxLeft = ((x/2)-(SearchBoxWidth/2)) * resultX;
		var FooterHeight = 180 * resultY;
		var FotterTop = 770 * resultY;
		var CopyrightSize = 12 * smallerXY;
	}*/

    $("#MainBarNameHeight").css({ "height": MainBarNameHeight, "width": MainBarNameWidth });
    $(".TransparentName").css({ "height": TransparentNameHeight, "width": TransparentNameWidth });
    $("#MainBar").css({ "height": MainBarHeight, "left": MainBarLeft });
    $("#MainBarList").css({ "top": MainBarListTop });
    $("a.MainBarListLink").css({ "font-size": MainBarTextSize });
    $(".MenuArrow").css({ "height": MenuArrowSize, "width": (2 * MenuArrowSize) });

    $("#SearchBox").css({ "height": SearchBoxHeight, "width": SearchBoxWidth, "border-width": SearchBoxThickness, "top": SearchBoxTop, "left": SearchBoxLeft });
    $("#searchField").css({ "width": SearchFieldWidth, "top": SearchFieldTop, "left": SearchFieldLeft });
    $("#moviesResult").css({ "width": SearchFieldWidth, "top": MoviesResultTop, "left": SearchFieldLeft });
    $("#peopleResult").css({ "width": SearchFieldWidth, "top": PeopleResultTop, "left": SearchFieldLeft });

    $(".formFields").css({ "left": centerWidth(".formFields"), "top": centerHeight(".formFields") });

    $(".Footer").css({ "top": FotterTop });
    $("#Copyright").css({ "font-size": CopyrightSize });

    console.log("wykonano");

}

function centerWidth(id) {

    var x = $(window).width();

    var objectLeft = (x / 2) - (($(id).width()) / 2);

    return objectLeft;
}

function centerHeight(id) {

    var y = $(window).height();

    var objectTop = ((y - 80) / 2) - (($(id).height()) / 2);

    console.log("aaaa"+objectTop);

    return objectTop;
}

function writeSize() {

    var x = $(window).width();
    var y = $(window).height();

    console.log(x, y);
}

function prevent() {

    var e = $('#MainBarList');
    var jWindow = $(window);
    var offsetTop = e.offset().top;
    var positionTop = e.position().top;
    console.log("dddd");

    jWindow.resize(function () {
        /* if(jWindow.scrollTop() > offsetTop)
             e.css({'position':'fixed', 'top':0});
         else
             e.css({'position':'relative', 'top':positionTop});
         */

        if ($(window).width() < 930)
            e.css({ 'position': 'relative', 'left': '420px', 'right': '' });
        else
            e.css({ 'position': 'fixed', 'left': '', 'right': '100px;' });

        console.log("f");
    });
}





$(document).ready(function () {
    setPage();
    writeSize();
    //prevent();

    console.log("ff-h: "+centerHeight(".formFields"));
    console.log("ff-w: "+centerWidth(".formFields"));
    $(window).resize(function () {
        setPage();
        writeSize();
    });

});

