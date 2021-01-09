(function ($) {
    var _communityService = abp.services.app.community,
        l = abp.localization.getSource('McSaas'),
        _$modal = $('#CommunityEditModal'),
        _$form = _$modal.find('form');

    var re = /^[0-9]+$/;

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var community = _$form.serializeFormToObject();

        if (re.test(community.BuildingNumber) && re.test(community.HouseNumber)) {

            abp.ui.setBusy(_$form);
            _communityService.update(community).done(function () {
                _$modal.modal('hide');
                abp.notify.info(l('SavedSuccessfully'));
                abp.event.trigger('community.edited', community);
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            abp.notify.error(l('NumberError'));
        }
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
