var Spotify = require('node-spotify-api');
var 
var spotify = new Spotify({
    id: "c75a9f8a7d7c479aaf0a88496e4a5711",
    secret: "ef393695fcff479390c288dcd69a1a8b" >
    });
spotify
    .search({ type: 'track', query: 'All the Small Things' })
    .then(function (response) {
        console.log(response);
    })
    .catch(function (err) {
        console.log(err);
    });
spotify
    .request('https://api.spotify.com/v1/tracks/7yCPwWs66K8Ba5lFuU2bcx')
    .then(function (data) {
        console.log(data);
    })
    .catch(function (err) {
        console.error('Error occurred: ' + err);
    });