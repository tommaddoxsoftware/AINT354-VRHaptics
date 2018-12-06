
jQuery(document).ready(function() {
	$('a[href*="#"]').on('click', function(e) {
		e.preventDefault();


		$("html,body").animate({ scrollTo: $($(this).attr("href"))}, "slow");

		console.log("Height: " + $($(this).attr("href")).offset().top);
	});

	// toggle "navbar-no-bg" class
	$('.intro .text').waypoint(function() {
		$('nav').toggleClass('navbar-no-bg');
	});

    /*
        Background slideshow
    */
    $('.intro').backstretch("assets/img/backgrounds/1.jpg");

    /*
        Wow
    */
    new WOW().init();

});
