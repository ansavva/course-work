/// <binding AfterBuild='default' />

var gulp = require('gulp');
var config = require('./gulp.config')();
var del = require('del');
var plumber = require('gulp-plumber');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var tsify = require('tsify');

gulp.task('default', ['copy-lib', 'create-js'], function () {
    log("Default done"); 
});

gulp.task('copy-lib', ['clean-lib'], function () {
    log("Copy files from " + config.node_modules + " to " + config.lib);
    return gulp
        .src(config.libraries, { base: "./node_modules" })
        .pipe(plumber())
        .pipe(gulp.dest(config.lib));
});

gulp.task('clean-lib', function () {
    log("Clean the lib directory under wwwroot");
    return del([config.lib]);
});

gulp.task('create-js', ['copy-app'], function () {
    return browserify({
        basedir: '.',
        debug: false,
        entries: [config.app + '/viewmodel.ts'],
    })
    .plugin(tsify)
    .bundle()
    .pipe(source('main.js'))
    .pipe(gulp.dest(config.approot))
});

gulp.task('copy-app', ['clean-app'], function () {
    log("Copy files from app to " + config.approot);
    return gulp
        .src(config.appfiles)
        .pipe(plumber())
        .pipe(gulp.dest(config.approot));
});

gulp.task('clean-app', function () {
    log("Clean the app directory under wwwroot");
    return (del([config.approot]));
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