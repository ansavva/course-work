import { Component } from 'angular2/core';
import { Config } from "./config";
import { PlaylistComponent } from './playlist.component';
import { Video } from './video';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    directives: [PlaylistComponent]
})

export class AppComponent {
    mainHeading = Config.heading;
    videos: Array<Video>;

    constructor() {
        this.videos = [
            new Video(1, "Installing Django", "qgGIqRFvFFk", "How to install Djnago"),
            new Video(2, "Surviving the Wilderness", "Fgwy-UdtyLs", "Bucky goes hiking.")
        ]
    }
}