/**
 * 深海时代主题功能中心
 * @copyright = DeepTimes Technology
 * @author    = Michael
 * @since     = 2016/5/31 20:38:02
 * @version   = 1.0.0
 */

// 图标轮播
  $('#icon-carousel').carousel({
    interval: 5000
  });

// 提示框
  $('[data-toggle="popover"]').popover();
  $('[data-toggle="tooltip"]').tooltip();

// 复制到剪贴板
var client = new ZeroClipboard($(".btn-clipboard2"));
d = $("#global-zeroclipboard-html-bridge");
client.on("ready", function() {
  d.data("placement", "top").attr("title", "复制到剪贴板").tooltip(),
    client.on("aftercopy", function() {
      d.attr("title", "复制成功！").tooltip("fixTitle").tooltip("show").attr("title", "复制到剪贴板").tooltip("fixTitle")
    })
}),
client.on("error", function() {
  $(".zero-clipboard").remove(), ZeroClipboard.destroy(), b()
});


// 自动选中指定文字
function selectElement(element) {
    if (window.getSelection) {
        var sel = window.getSelection();
        sel.removeAllRanges();
        var range = document.createRange();
        range.selectNodeContents(element);
        sel.addRange(range);
    } else if (document.selection) {
        var textRange = document.body.createTextRange();
        textRange.moveToElementText(element);
        textRange.select();
    }
}
// http://www.zhangxinxu.com/wordpress/tag/%E6%96%87%E5%AD%97%E9%80%89%E4%B8%AD/
$('.single_info').mouseenter(function(){
    selectElement($('i#hover').get(0));
});
$('.single_info').mouseleave(function(){
    selectElement($('i#hover').get(1));
});


// 弹层
$(".fancybox").fancybox({
  minWidth: 500,
  autoCenter: true,
  padding: 0,
  openEasing: 'swing',
  openMethod: 'zoomIn',
  openEffect: 'fade',
  openSpeed: 250,

  closeEffect: 'fade',
  closeSpeed: 250,

  helpers: {
    overlay: {
      speedOut: 300,
      showEarly: true,
      css: {'background': 'rgba(255,255,255,0.9)'},
      locked: true
    }
  },
  ajax: {
    dataType: 'html',
    headers: {
      'X-fancyBox': true
    }
  },
  closeClick: false
});