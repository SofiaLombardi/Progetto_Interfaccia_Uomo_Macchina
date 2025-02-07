// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
    $('.select2-element').each(function () {
        var select = $(this);
        var url = select.data('url');
        var theme = select.data('theme');
        var searchable = select.data('searchable');

        if (typeof searchable === 'undefined') searchable = true;

        var options = {
            theme: theme
        };

        if (searchable) {
            options.ajax = {
                url: url
            };
        } else {
            options.minimumResultsForSearch = Infinity;
        }

        select.select2(options);
    });
})();
