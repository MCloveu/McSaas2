(function ($) {
    var _communityService = abp.services.app.community,
        l = abp.localization.getSource('McSaas'),
        _$modal = $('#CommunityCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CommunitysTable');

    var re = /^[0-9]+$/;

    var _$communitysTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#CommunitysSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _communityService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$communitysTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'address',
                sortable: false
            },
            {
                targets: 3,
                data: 'area',
                sortable: false
            },
            {
                targets: 4,
                data: 'buildingNumber',
                sortable: false
            },
            {
                targets: 5,
                data: 'houseNumber',
                sortable: false
            },
            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-community" data-community-id="${row.id}" data-toggle="modal" data-target="#CommunityEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-community" data-community-id="${row.id}" data-community-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var community = _$form.serializeFormToObject();

        //正整数判断
        if (re.test(community.BuildingNumber) && re.test(community.HouseNumber) ) {

            abp.ui.setBusy(_$modal);

            _communityService
                .create(community)
                .done(function () {
                    _$modal.modal('hide');
                    _$form[0].reset();
                    abp.notify.info(l('SavedSuccessfully'));
                    _$communitysTable.ajax.reload();
                })
                .always(function () {
                    abp.ui.clearBusy(_$modal);
                });
        }
        else {
            abp.notify.error(l('NumberError'));
        }
    });

    $(document).on('click', '.delete-community', function () {
        var communityId = $(this).attr('data-community-id');
        var communityName = $(this).attr('data-community-name');

        deleteCommunity(communityId, communityName);
    });

    $(document).on('click', '.edit-community', function (e) {
        var communityId = $(this).attr('data-community-id');

        abp.ajax({
            url: abp.appPath + 'Communitys/EditModal?communityId=' + communityId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CommunityEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('community.edited', (data) => {
        _$communitysTable.ajax.reload();
    });

    function deleteCommunity(communityId, communityName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                communityName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _communityService
                        .delete({
                            id: communityId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$communitysTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$communitysTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$communitysTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$communitysTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
