var PhieuNhapController = {
    init: function () {
        PhieuNhapController.registerEvent();
        
    },
    registerEvent: function () {
        PhieuNhapController.loadData();
    },
    loadData: function () {
        $.ajax({
            url: '/Admin/PhieuNhap/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        debugger;
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Ngay: item.Ngay,
                            NhaCungCapTen: item.NhaCungCapTen,
                            TongChi: item.TongChi,
                            GhiChu: item.GhiChu
                        })
                    })
                    $('#tblData').html(html);
                }
                
            }
        })
    }
}
PhieuNhapController.init();