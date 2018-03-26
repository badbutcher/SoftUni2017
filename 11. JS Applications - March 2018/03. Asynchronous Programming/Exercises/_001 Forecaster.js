function attachEvents() {
    const URL = 'https://judgetests.firebaseio.com';

    let inputLocation = $('#location');
    let forecast = $('#forecast');
    $('#submit').on('click', getForecast);

    let icons = {
        'Sunny': "&#x2600;",
        'Partly sunny': "&#x26C5;",
        'Overcast': "&#x2601;",
        'Rain': "&#x2614;",
        'Degrees': "&#176;"
    };

    function getForecast() {
        $.ajax({
            method: 'GET',
            url: URL + '/locations.json',
            success: forecastAjax,
            error: handleError
        });
    }

    function forecastAjax(res) {
        try {
            let data = res.filter(a => a.name === inputLocation.val())[0];
            let getToday = $.ajax({
                method: 'GET',
                url: URL + `/forecast/today/${data.code}.json `,
                //success: getTodayData,
                //error: handleError
            });

            let getThreeDays = $.ajax({
                method: 'GET',
                url: URL + `/forecast/upcoming/${data.code}.json `,
                //success: getUpcomingData,
                //error: handleError
            });

            Promise.all([getToday, getThreeDays])
                .then(displayCondition)
                .catch(handleError);

        } catch (err) {
            handleError();
        }

        function displayCondition([getToday, getThreeDays]) {
            getTodayData();
            getUpcomingData();

            function getTodayData() {
                let townName = getToday.name;
                let condition = getToday.forecast.condition;
                let high = getToday.forecast.high;
                let low = getToday.forecast.low;

                $('#current')
                    .append($('<span>').addClass("condition symbol").html(icons[condition]))
                    .append($('<span>').addClass("condition")
                        .append($('<span>').addClass("forecast-data").text(townName))
                        .append($('<span>').addClass("forecast-data").html(`${low}${icons.Degrees}/${high}${icons.Degrees}`))
                        .append($('<span>').addClass("forecast-data").text(condition)));
            }

            function getUpcomingData() {
                for (let obj of getThreeDays.forecast) {
                    let condition = obj.condition;
                    let high = obj.high;
                    let low = obj.low;
                    $('#upcoming')
                        .append($('<span>').addClass('upcoming')
                            .append($('<span>').addClass('symbol').html(icons[condition]))
                            .append($('<span>').addClass("forecast-data").html(`${low}${icons.Degrees}/${high}${icons.Degrees}`))
                            .append($('<span>').addClass("forecast-data").text(condition)));
                }
            }

            forecast.css('display', 'block');
        }
    }

    function handleError() {
        forecast.html("Error");
        forecast.css("display", "block");
    }
}


// function attachEvents() {
//     const URL = 'https://judgetests.firebaseio.com';
//
//     let button = $('#submit').on('click', getForecast);
//     let forecast = $('#forecast');
//
//     let icons = {
//         ['Sunny']: "&#x2600;",
//         ['Partly sunny']: "&#x26C5;",
//         ['Overcast']: "&#x2601;",
//         ['Rain']: "&#x2614;",
//         ['Degrees']: "&#176;"
//     };
//
//     async function getForecast() {
//         let inputLocation = $('#location');
//         $.ajax({
//             method: 'GET',
//             url: URL + '/locations.json',
//             success: forecastAjax,
//             error: handleError
//         });
//
//         function forecastAjax(res) {
//             try {
//                 let data = res.filter(a => a.name === inputLocation.val())[0];
//                 $.ajax({
//                     method: 'GET',
//                     url: URL + `/forecast/today/${data.code}.json `,
//                     success:  getTodayData,
//                     error: handleError
//                 });
//
//                 $.ajax({
//                     method: 'GET',
//                     url: URL + `/forecast/upcoming/${data.code}.json `,
//                     success: getUpcomingData,
//                     error: handleError
//                 });
//             } catch (err) {
//                 handleError();
//             }
//
//             function getTodayData(res) {
//                 let townName = res.name;
//                 let condition = res.forecast.condition;
//                 let high = res.forecast.high;
//                 let low = res.forecast.low;
//
//                 $('#current')
//                     .append($('<span>').addClass("condition symbol").html(icons[condition]))
//                     .append($('<span>').addClass("condition")
//                         .append($('<span>').addClass("forecast-data").text(townName))
//                         .append($('<span>').addClass("forecast-data").html(`${low}${icons.Degrees}/${high}${icons.Degrees}`))
//                         .append($('<span>').addClass("forecast-data").text(condition)));
//             }
//
//             function getUpcomingData(res) {
//                 for (let obj of res.forecast) {
//                     let condition = obj.condition;
//                     let high = obj.high;
//                     let low = obj.low;
//                     $('#upcoming')
//                         .append($('<span>').addClass('upcoming')
//                             .append($('<span>').addClass('symbol').html(icons[condition]))
//                             .append($('<span>').addClass("forecast-data").html(`${low}${icons.Degrees}/${high}${icons.Degrees}`))
//                             .append($('<span>').addClass("forecast-data").text(condition)));
//                 }
//             }
//
//             forecast.css('display', 'block');
//         }
//     }
//
//     function handleError() {
//         forecast.html("Error");
//         forecast.css("display", "block");
//     }
// }