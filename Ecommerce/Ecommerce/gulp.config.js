module.exports = function() {
    var base = {
        wwwroot: "./wwwroot/",
        node_modules: "./node_modules/"
    };

    var config = {
        node_modules: base.node_modules,
        lib: base.wwwroot + "lib",
        libraries: [
            base.node_modules + "angular2/**/*.js",
            base.node_modules + "es6-shim/**/*.js",
            base.node_modules + "systemjs/**/*.js",
            base.node_modules + "rxjs/**/*.js",
            base.node_modules + "bootstrap/**/*",
            base.node_modules + "jquery/**/*"
        ],
        approot: base.wwwroot + 'app',
        app: ['./app/**/*.{html,css,png,jpg}']
    };

    return config;         
};