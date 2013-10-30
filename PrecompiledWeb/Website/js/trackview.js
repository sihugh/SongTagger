/// <reference path="../scripts/jquery-1.10.1.js" />
/// <reference path="../scripts/handlebars.js" />

var processTracks = function (data) {
    console.log(data);

    for (var i = 0; i < data.length; i++) {
        console.log(data[i]);
        var html = trackTemplate(data[i]);
        console.log(html);
        $("#trackplaceholder").append(html);
    }

    console.log("In callback");
};

var tracks = $.getJSON("/js/tracks.js", {}, processTracks);

var trackTemplateSource = $("#track-template").html();
var trackTemplate = Handlebars.compile(trackTemplateSource);

console.log("Done something");
