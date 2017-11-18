// Enable sidebar tree view controls
$(() => {
    "use strict";

    var animationSpeed: number = 200;
    var menu: string = ".sidebar";

    $(document).off('click', menu + ' li a').on('click', menu + ' li a', (event: JQueryEventObject) => {
        // Get the next elements
        var checkElement: JQuery = $(event.target).next();

        // If the next element is a menu
        if (checkElement.is('.treeview-menu')) {
            // If the next element is visible
            if (checkElement.is(':visible')) {
                // Close the menu
                checkElement.slideUp(animationSpeed, () => {
                    checkElement.removeClass('menu-open');
                });
                checkElement.parent("li").removeClass("active");
            }
            // If the next element is not visible
            else {
                // Get the parent menu
                var parent: JQuery = $(event.target).parents('ul').first();
                // Close all open menus within the parent
                var ul: JQuery = parent.find('ul:visible').slideUp(animationSpeed);
                // Remove the menu-open class from the parent
                ul.removeClass('menu-open');
                // Get the parent li
                var parent_li: JQuery = $(event.target).parent("li");

                // Open the target menu and add the menu-open class
                checkElement.slideDown(animationSpeed, () => {
                    //Add the class active to the parent li
                    checkElement.addClass('menu-open');
                    parent.find('li.active').removeClass('active');
                    parent_li.addClass('active');
                });
            }
        }

        // If this isn't a link, prevent the page from being redirected
        if (checkElement.is('.treeview-menu')) {
            event.preventDefault();
        }
    });
});