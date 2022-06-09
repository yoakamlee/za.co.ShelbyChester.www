//mapboxgl.accessToken = 'pk.eyJ1IjoieW9ha2FtbGVlIiwiYSI6ImNsNDZ3dWN6MTBjcjcza21zdzlyZWd4bm4ifQ.uiJttwPPyfnYhqRMILC5dg';

//navigator.geolocation.getCurrentPosition(successLocation, errorLocations, {
//    enableHighAccuracy: true
//})

//function successLocation(postition) {
//    console.log(postition)
//    setUpMap([postition.coords.longitude, postition.coords.latitude])
//}

//function errorLocation() {
//    setUpMap([-2.24, 53.48])
//}


//function setUpMap(center) {
//    var map = new mapboxgl.Map({
//        container: 'map', // container ID
//        style: 'mapbox://styles/mapbox/streets-v11', // style URL
//        center: center, // starting position [lng, lat][-74.5, 40]
//        zoom: 15 // starting zoom
//    });
//}

mapboxgl.accessToken = 'pk.eyJ1IjoieW9ha2FtbGVlIiwiYSI6ImNsNDZ3czNsZzAydTYzY29ieGNpN3ZvcDUifQ.iK_3dLz5L1rdk5RyEgylFg';


navigator.geolocation.getCurrentPosition(successLocation, errorLocation, {
    enableHighAccuracy: true
    
});

function successLocation(position) {
    console.log(position);
    setUpMap([31.007231, -29.851234]);
}

function errorLocation() {
    setUpMap([31.007231, -29.851234]);
}

function setUpMap(center) {
    const map = new mapboxgl.Map({
        container: 'map', // container ID
        style: 'mapbox://styles/mapbox/streets-v11', // style URL
        center: [31.007231, -29.851234], // starting position [lng, lat][31.007231, -29.851234]
        zoom: 15 // starting zoom
    });

    const nav = new mapboxgl.NavigationControl()
    map.addControl(nav)
        var directions = new MapboxDirections({
            accessToken: mapboxgl.accessToken
    })


    map.addControl(directions, 'top-left');

    map.on('load', function () {
        directions.setOrigin([31.007231, -29.851234]); // can be address in form setOrigin("12, Elm Street, NY")
        /*directions.setDestinaion([11, 22]);*/ // can be address
    })

    
}




