(function () {
    $(document).on('submit', '.search-form', function (e) {
        e.preventDefault();

        var form = $(this);
        var method = form.attr('method');
        var url = form.attr('action');

        $.ajax({
            method: method,
            url: url,
            data: form.serialize()
        }).done(function (data) {
            form.closest('.modal-body')
                .find('.search-results')
                .html(data);
        });
    });

    $(document).on('click', '.search-reset', function (e) {
        var button = $(this);
        var form = button.closest('.search-form');

        form.find('.select2-element')
            .val(null)
            .trigger('change');

        form.trigger('reset');
        form.submit();
    });

    $(document).on('show.bs.modal', '.search-modal', function (e) {
        var modal = $(this);

        modal.find('.search-form').submit();
    });
})();