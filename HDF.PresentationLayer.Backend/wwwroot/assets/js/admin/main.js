(function ($) {
    "use strict";

    //// Spinner
    //var spinner = function () {
    //    setTimeout(function () {
    //        if ($('#spinner').length > 0) {
    //            $('#spinner').removeClass('show');
    //        }
    //    }, 1);
    //};
    //spinner();
    
    
    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Sidebar Toggler
    $('.sidebar-toggler').click(function () {
        $('.sidebar, .content').toggleClass("open");
        return false;
    });


    // Progress Bar
    $('.pg-bar').waypoint(function () {
        $('.progress .progress-bar').each(function () {
            $(this).css("width", $(this).attr("aria-valuenow") + '%');
        });
    }, {offset: '80%'});


    // Calender
    $('#calender').datetimepicker({
        inline: true,
        format: 'L'
    });


    // Testimonials carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        items: 1,
        dots: true,
        loop: true,
        nav : false
    });


    // Chart Global Color
    Chart.defaults.color = "#6C7293";
    Chart.defaults.borderColor = "#000000";


    // Worldwide Sales Chart
    var ctx1 = $("#worldwide-sales").get(0)?.getContext("2d");
    var myChart1 = new Chart(ctx1, {
        type: "bar",
        data: {
            labels: ["2016", "2017", "2018", "2019", "2020", "2021", "2022"],
            datasets: [{
                    label: "USA",
                    data: [15, 30, 55, 65, 60, 80, 95],
                    backgroundColor: "rgba(235, 22, 22, .7)"
                },
                {
                    label: "UK",
                    data: [8, 35, 40, 60, 70, 55, 75],
                    backgroundColor: "rgba(235, 22, 22, .5)"
                },
                {
                    label: "AU",
                    data: [12, 25, 45, 55, 65, 70, 60],
                    backgroundColor: "rgba(235, 22, 22, .3)"
                }
            ]
            },
        options: {
            responsive: true
        }
    });


    // Salse & Revenue Chart
    var ctx2 = $("#salse-revenue").get(0)?.getContext("2d");
    var myChart2 = new Chart(ctx2, {
        type: "line",
        data: {
            labels: ["2016", "2017", "2018", "2019", "2020", "2021", "2022"],
            datasets: [{
                    label: "Salse",
                    data: [15, 30, 55, 45, 70, 65, 85],
                    backgroundColor: "rgba(235, 22, 22, .7)",
                    fill: true
                },
                {
                    label: "Revenue",
                    data: [99, 135, 170, 130, 190, 180, 270],
                    backgroundColor: "rgba(235, 22, 22, .5)",
                    fill: true
                }
            ]
            },
        options: {
            responsive: true
        }
    });
    


    // Single Line Chart
    var ctx3 = $("#line-chart").get(0)?.getContext("2d");
    var myChart3 = new Chart(ctx3, {
        type: "line",
        data: {
            labels: [50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150],
            datasets: [{
                label: "Salse",
                fill: false,
                backgroundColor: "rgba(235, 22, 22, .7)",
                data: [7, 8, 8, 9, 9, 9, 10, 11, 14, 14, 15]
            }]
        },
        options: {
            responsive: true
        }
    });


    // Single Bar Chart
    var ctx4 = $("#bar-chart").get(0)?.getContext("2d");
    var myChart4 = new Chart(ctx4, {
        type: "bar",
        data: {
            labels: ["Italy", "France", "Spain", "USA", "Argentina"],
            datasets: [{
                backgroundColor: [
                    "rgba(235, 22, 22, .7)",
                    "rgba(235, 22, 22, .6)",
                    "rgba(235, 22, 22, .5)",
                    "rgba(235, 22, 22, .4)",
                    "rgba(235, 22, 22, .3)"
                ],
                data: [55, 49, 44, 24, 15]
            }]
        },
        options: {
            responsive: true
        }
    });


    // Pie Chart
    var ctx5 = $("#pie-chart").get(0)?.getContext("2d");
    var myChart5 = new Chart(ctx5, {
        type: "pie",
        data: {
            labels: ["Italy", "France", "Spain", "USA", "Argentina"],
            datasets: [{
                backgroundColor: [
                    "rgba(235, 22, 22, .7)",
                    "rgba(235, 22, 22, .6)",
                    "rgba(235, 22, 22, .5)",
                    "rgba(235, 22, 22, .4)",
                    "rgba(235, 22, 22, .3)"
                ],
                data: [55, 49, 44, 24, 15]
            }]
        },
        options: {
            responsive: true
        }
    });


    // Doughnut Chart
    var ctx6 = $("#doughnut-chart").get(0)?.getContext("2d");
    var myChart6 = new Chart(ctx6, {
        type: "doughnut",
        data: {
            labels: ["Italy", "France", "Spain", "USA", "Argentina"],
            datasets: [{
                backgroundColor: [
                    "rgba(235, 22, 22, .7)",
                    "rgba(235, 22, 22, .6)",
                    "rgba(235, 22, 22, .5)",
                    "rgba(235, 22, 22, .4)",
                    "rgba(235, 22, 22, .3)"
                ],
                data: [55, 49, 44, 24, 15]
            }]
        },
        options: {
            responsive: true
        }
    });

    let movieCount = 0;
    let languageCount = 0;
    let kindCount = 0;
    let castCount = 0;

    $(".options .alert").click(function (e) {
        e.preventDefault();
        let element = $(this.parentElement).children(".form-select")[0].options[$(this).prev().val()];       
        $(element).removeAttr("disabled");
        Remove(this);       
    });
    //function Add(movId,subId,list) {
    //    //let subId = selectedValue;
    //    //let movId = $(element).prev().attr('data-list');
    //    //let list = $(element).prev().attr('data-list');


    //    $.ajax({
    //        url: `/Movie/AddSub?movId=${movId}&id=${id}&list=${list}`,
    //        type: "Get",
    //        success: function (response) {
    //            $(`.options #${list}`).append(response);

    //        }
    //    })
    //}

    function Remove(element) {
        let subId = $(element).prev().val();
        let movId = $("#movie").attr('data');
        let list = $(element).prev().attr('data-list');
        $(element).prev().remove();
        $(element).remove();
        $.ajax({
            url: `/Movie/RemoveSub?first=${movId}&second=${subId}&list=${list}`,
            type: "Get",
            success: function (response) {
                /*$(this.parentElement).append(response);*/

            }
        })
    }
    function CreateSpecialElement(list, count,element) {
        var selectedValue = $(element).val();
        var selectedText = element.options[element.selectedIndex].text;
        if (selectedValue >= 0) {
            let alert = document.createElement("a");
            element.options[element.selectedIndex].setAttribute("disabled", "true");
            alert.classList.add("alert", "alert-info", "d-inline-block", "m-2", "p-2");
            alert.setAttribute("href", `#`);
            alert.textContent = selectedText;
            $(element).after(alert);

            let input = document.createElement("input");
            input.classList.add("d-none");            
            input.setAttribute("data-list", list);            
            input.setAttribute("value", selectedValue);
            $(input).val(selectedValue);

            $(alert).click(function (e) {
                e.preventDefault();
                Remove(alert);
                $(alert).remove();
                $(input).remove();
                element.options[element.selectedIndex].removeAttribute("disabled");
            });

            let id = selectedValue;
            let movId = $("#movie").attr('data');

            $.ajax({
                url: `/Movie/AddSub?first=${movId}&second=${id}&list=${list}`,
                type: "Get",
                success: function (response) {
                    /*$(this.parentElement).append(response);*/
                }
            })
           
            $(element).after(input);
            count++;   
        }
        return count;       
        
    }

    $(".form-floating #category").change(function (e) {
        console.log("Hello");
       movieCount = CreateSpecialElement("category", movieCount, this);
    });
    $(".form-floating #language").change(function (e) {
        languageCount = CreateSpecialElement("language", languageCount, this);
    });

    $(".form-floating #kind").change(function (e) {
        kindCount = CreateSpecialElement("kind", kindCount, this);
    });  
    $(".form-floating #cast").change(function (e) {
        castCount = CreateSpecialElement("cast", castCount, this);
    });    
    
})(jQuery);
