$(document).ready(function () {
    $(".bookModal").click(function (ev) {
        ev.preventDefault();
        let url = $(this).attr("href");

        if (!url) {
            console.error('No URL found for modal');
            return;
        }

        fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.text();
            })  
            .then(data => {
                $("#quickModal .modal-dialog").html(data);
                
                // Initialize slick sliders if they exist
                if ($('.product-details-slider').length) {
                    $('.product-details-slider').slick({
                        "slidesToShow": 1,
                        "arrows": false,
                        "fade": true,
                        "draggable": false,
                        "swipe": false,
                        "asNavFor": ".product-slider-nav"
                    });
                }
                
                if ($('.product-slider-nav').length) {
                    $('.product-slider-nav').slick({
                        "infinite": true,
                        "autoplay": true,
                        "autoplaySpeed": 8000,
                        "slidesToShow": 4,
                        "arrows": true,
                        "prevArrow": {"buttonClass": "slick-prev", "iconClass": "fa fa-chevron-left"},
                        "nextArrow": {"buttonClass": "slick-next", "iconClass": "fa fa-chevron-right"},
                        "asNavFor": ".product-details-slider",
                        "focusOnSelect": true
                    });
                }
          
              
                $("#quickModal").modal('show');
            })
    });
});

