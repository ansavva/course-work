module.exports = function() {
    var base = {
        wwwroot: "./wwwroot/",
        node_modules: "./node_modules/",
        app: "./App"
    };

    var config = {
        node_modules: base.node_modules,
        lib: base.wwwroot + "lib",
        libraries: [
            base.node_modules + "knockout/**/*",
            base.node_modules + "knockout-mapping/**/*",
            base.node_modules + "knockout.validation/**/*",
            base.node_modules + "bootstrap/**/*",
            base.node_modules + "jquery/**/*"
        ],
        approot: base.wwwroot + base.app,
        app: base.app,
        appfiles: [ base.app + '/**/*.{html,css,jpg,png}']
    };

    return config;         
};