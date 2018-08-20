var SC = require('soundcloud');

SC.initialize({
    client_id: 'ssurbancic',
    redirect_uri: 'http://example.com/callback'
});

SC.get('users/turkishchrist').then(function (user) { console.log('turkishchrist', user); });
SC.get('tracks/drunktextingyou-prod-by-mikerobsears').then(function (user) { console.log('DrunkTextingYou [Prod. By MikeRobSears]', user); }).catch();
SC.get('tracks/drunktextingyou-prod-by-mikerobsears').then(function (user) { console.log('DrunkTextingYou [Prod. By MikeRobSears]', user); }).catch(function (error) {
    console.log('catch', error);
});
var connect = function () {
    SC.connect().then(function (options) { console.log('success', options); }).catch(function (op) { console.log('error', op); })
};
document.getElementById('connect').addEventListener('click', connect);
var oembedElement = document.getElementById('oembed');
SC.oEmbed('https://soundcloud.com/turkishchrist/daydreamingaboutus-prod-by-mikerobsears', { element: oembedElement }).then(function (result) {
    console.log('oembed', result);
}).catch(function (err) {
    console.log('oembed err', err);
    });

SC.connect().then(function () {
    return SC.put('/me/followings/183');
}).then(function (user) {
    alert('You are now following ' + user.username);
}).catch(function (error) {
    alert('Error: ' + error.message);
    });

SC.put('/me', {
    user: { description: 'I am using the SoundCloud API!' }
}).then(function () {
    return SC.get('/me');
}).then(function (me) {
    console.log(me.description);
}).catch(function (error) {
    alert('Error: ' + error.message);
    });

SC.stream('/tracks/293').then(function (player) {
    player.play();
});