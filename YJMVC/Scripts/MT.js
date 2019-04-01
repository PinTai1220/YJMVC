function londmap(x, y) {
    var map = new BMap.Map("Bmap"); map.centerAndZoom(new BMap.Point(x,y), 20); map.addControl(new BMap.MapTypeControl({mapTypes: [BMAP_NORMAL_MAP,BMAP_HYBRID_MAP]}));map.setCurrentCity("上海市");map.enableScrollWheelZoom(false);var marker = new BMap.Marker(new BMap.Point(x,y));map.addOverlay(marker);
}