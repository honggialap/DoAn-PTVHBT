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
                        var date = new Date(item.Ngay.match(/\d+/)[0] * 1);
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Ngay: date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear(),
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