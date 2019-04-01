$(function () {
    var mapstr = '';
    $(document.body).on('click', '.btn ', function () {
        var x = $(this).attr("data-x");
        var y = $(this).attr("data-y");
        getditu(x, y);
    });
    function getditu(x, y) {
        getmapstr(x, y);
        var opendt = layer.open({
            title: '地图',
            type: 1,
            skin: 'layui-layer-lan', //样式类名
            closeBtn: 0, //不显示关闭按钮
            anim: 2,
            shadeClose: true, //开启遮罩关闭
            content: '<div style="width:100%;height:750px" id="allmap"></div>' + mapstr
        });
        layer.style(opendt, { width: '900px', left: '400px', height: '800px', top: '30px' });

    }
    function getmapstr(x, y) {
        mapstr = '<script type="text/javascript"> var map = new BMap.Map("allmap"); map.centerAndZoom(new BMap.Point(' + x + ',' + y + '), 20); map.addControl(new BMap.MapTypeControl({mapTypes: [BMAP_NORMAL_MAP,BMAP_HYBRID_MAP]}));map.setCurrentCity("上海市");map.enableScrollWheelZoom(false);var marker = new BMap.Marker(new BMap.Point(' + x + ',' + y + '));map.addOverlay(marker);<' + '/script>';
    }
})