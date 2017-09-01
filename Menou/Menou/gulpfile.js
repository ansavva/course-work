var gulp = require('gulp');
var config = require('./gulp.config')();
var del = require('del');
var plumber = require('gulp-plumber');

gulp.task('default', ['clean-lib', 'copy-html'], function () {
    log("Copy files from " + config.node_modules + " to " + config.lib);
    return gulp
        .src(config.libraries, {base:"./node_modules"})
        .pipe(plumber())
        .pipe(gulp.dest(config.lib));
});

gulp.task('copy-html', function () {
    log("Copy files from " + config.app + " to " + config.approot);
    return gulp
        .src(config.app)
        .pipe(plumber())
        .pipe(gulp.dest(config.approot));
});

gulp.task('clean-lib', function() {
    log("Clean the lib directory under wwwroot");
    return del([config.lib]);
});

// Log messages to the Task Runner Explorer Gulp console.
function log(message) {
    if (typeof(message) === "object") {
        for (var item in message) {
            if (message.hasOwnProperty(item)) {
                console.log(message[item]);
            }
        } 
    }
    else {
        console.log(message);
    }
}