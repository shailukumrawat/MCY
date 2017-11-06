jQuery(document).ready(function ($) {
    $(".animsition").animsition({
        inClass: 'fade-in',
        outClass: 'fade-out',
        inDuration: 1500,
        outDuration: 800,
        linkElement: '.animsition-link',
        // e.g. linkElement: 'a:not([target="_blank"]):not([href^=#])'
        loading: true,
        loadingParentElement: 'body', //animsition wrapper element
        loadingClass: 'animsition-loading',
        loadingInner: '', // e.g '<img src="loading.svg" />'
        timeout: false,
        timeoutCountdown: 5000,
        onLoadEvent: true,
        browser: ['animation-duration', '-webkit-animation-duration'],
        // "browser" option allows you to disable the "animsition" in case the css property in the array is not supported by your browser.
        // The default setting is to disable the "animsition" in a browser that does not support "animation-duration".
        overlay: false,
        overlayClass: 'animsition-overlay-slide',
        overlayParentElement: 'body',
        transition: function (url) { window.location.href = url; }
    });
    /*car_detail slider */
    $('#car_detail').owlCarousel({
        loop: true,
        margin: 0,
        nav: false,
        pagination: true,
        //autoplay: true,
        items: 1,
        autoHeight: true,
    });
    /***************** */
    $('.car_detail').owlCarousel({
        loop: true,
        margin: 0,
        //autoplay: true,
        nav: false,
        pagination: true,
        autoHeight: true,
    });
    // $(".car_detail").slick({
    //     dots: true,
    //     infinite: true,
    // cycle: true
    //     centerMode: true,
    //     slidesToShow: 1,
    //     slidesToScroll: 1,
    //      autoHeight:false,
    //     autoplay:false,
    //     arrows:false,
    //   });


    $(".frgt_pass").click(function () {
        $("#login_modal").removeClass("in");
        $(".modal-backdrop .fade").removeClass("in");
    })
    $(".leftb_head").click(function () {
        $(".left_bar").toggleClass("open_sidebar");
        $('body').toggleClass("body_over");
    })
    /*********tab bar********** */
    $('a[href="#events"]').click(function (e) {
        e.preventDefault()
        $('#search_car').removeClass('in active');
        $('#search_event').addClass('in active');
        $('#lisearchevent').addClass('active');
        $('#lisearchcar').removeClass('active');
    });

    $('a[href="#dealers"]').click(function (e) {
        e.preventDefault()
        $('#search_car').addClass('in active');
        $('#lisearchcar').addClass('active');
        $('#search_event').removeClass('in active');
        $('#lisearchevent').removeClass('active');
    });

    $('.srch_btn').click(function () {
        $('.mobile_search').toggle('slow');
    });
    /*  $('a[href="#dealers"]').on('show.bs.tab', function (e) {
          e.target // newly activated tab
          console.log(e.target);
          e.relatedTarget // previous active tab
           /*car_detail slider 1*/
    /* $('#car_detailr').owlCarousel({
         loop: true,
         margin: 0,
         nav: false,
         pagination: true,
         items: 1,
 
     });
         })*/

    /*** manage yad start ***/

    $("a.star_button").click(function () {
        $(this).toggleClass('goldn');
    });
    $("a#star_rat").click(function () {
        $(this).toggleClass('star_gold');
    });

       $(".my_fmg").closest(".col-sm-6").addClass("myfmgfull");  
      
   
});

