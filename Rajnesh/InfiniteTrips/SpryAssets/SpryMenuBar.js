var Spry;if(!Spry)Spry={};if(!Spry.Widget)Spry.Widget={};Spry.BrowserSniff=function(){var a=navigator.appName.toString();var b=navigator.platform.toString();var c=navigator.userAgent.toString();this.mozilla=this.ie=this.opera=this.safari=false;var d=/Opera.([0-9\.]*)/i;var e=/MSIE.([0-9\.]*)/i;var f=/gecko/i;var g=/(applewebkit|safari)\/([\d\.]*)/i;var h=false;if(h=c.match(d)){this.opera=true;this.version=parseFloat(h[1])}else if(h=c.match(e)){this.ie=true;this.version=parseFloat(h[1])}else if(h=c.match(g)){this.safari=true;this.version=parseFloat(h[2])}else if(c.match(f)){var i=/rv:\s*([0-9\.]+)/i;h=c.match(i);this.mozilla=true;this.version=parseFloat(h[1])}this.windows=this.mac=this.linux=false;this.Platform=c.match(/windows/i)?"windows":c.match(/linux/i)?"linux":c.match(/mac/i)?"mac":c.match(/unix/i)?"unix":"unknown";this[this.Platform]=true;this.v=this.version;if(this.safari&&this.mac&&this.mozilla){this.mozilla=false}};Spry.is=new Spry.BrowserSniff;Spry.Widget.MenuBar=function(a,b){this.init(a,b)};Spry.Widget.MenuBar.prototype.init=function(a,b){this.element=this.getElement(a);this.currMenu=null;this.showDelay=250;this.hideDelay=600;if(typeof document.getElementById=="undefined"||navigator.vendor=="Apple Computer, Inc."&&typeof window.XMLHttpRequest=="undefined"||Spry.is.ie&&typeof document.uniqueID=="undefined"){return}if(Spry.is.ie&&Spry.is.version<7){try{document.execCommand("BackgroundImageCache",false,true)}catch(c){}}this.upKeyCode=Spry.Widget.MenuBar.KEY_UP;this.downKeyCode=Spry.Widget.MenuBar.KEY_DOWN;this.leftKeyCode=Spry.Widget.MenuBar.KEY_LEFT;this.rightKeyCode=Spry.Widget.MenuBar.KEY_RIGHT;this.escKeyCode=Spry.Widget.MenuBar.KEY_ESC;this.hoverClass="MenuBarItemHover";this.subHoverClass="MenuBarItemSubmenuHover";this.subVisibleClass="MenuBarSubmenuVisible";this.hasSubClass="MenuBarItemSubmenu";this.activeClass="MenuBarActive";this.isieClass="MenuBarItemIE";this.verticalClass="MenuBarVertical";this.horizontalClass="MenuBarHorizontal";this.enableKeyboardNavigation=true;this.hasFocus=false;if(b){for(var d in b){if(typeof this[d]=="undefined"){var e=new Image;e.src=b[d]}}Spry.Widget.MenuBar.setOptions(this,b)}if(Spry.is.safari)this.enableKeyboardNavigation=false;if(this.element){this.currMenu=this.element;var f=this.element.getElementsByTagName("li");for(var g=0;g<f.length;g++){if(g>0&&this.enableKeyboardNavigation)f[g].getElementsByTagName("a")[0].tabIndex="-1";this.initialize(f[g],a);if(Spry.is.ie){this.addClassName(f[g],this.isieClass);f[g].style.position="static"}}if(this.enableKeyboardNavigation){var h=this;this.addEventListener(document,"keydown",function(a){h.keyDown(a)},false)}if(Spry.is.ie){if(this.hasClassName(this.element,this.verticalClass)){this.element.style.position="relative"}var i=this.element.getElementsByTagName("a");for(var g=0;g<i.length;g++){i[g].style.position="relative"}}}};Spry.Widget.MenuBar.KEY_ESC=27;Spry.Widget.MenuBar.KEY_UP=38;Spry.Widget.MenuBar.KEY_DOWN=40;Spry.Widget.MenuBar.KEY_LEFT=37;Spry.Widget.MenuBar.KEY_RIGHT=39;Spry.Widget.MenuBar.prototype.getElement=function(a){if(a&&typeof a=="string")return document.getElementById(a);return a};Spry.Widget.MenuBar.prototype.hasClassName=function(a,b){if(!a||!b||!a.className||a.className.search(new RegExp("\\b"+b+"\\b"))==-1){return false}return true};Spry.Widget.MenuBar.prototype.addClassName=function(a,b){if(!a||!b||this.hasClassName(a,b))return;a.className+=(a.className?" ":"")+b};Spry.Widget.MenuBar.prototype.removeClassName=function(a,b){if(!a||!b||!this.hasClassName(a,b))return;a.className=a.className.replace(new RegExp("\\s*\\b"+b+"\\b","g"),"")};Spry.Widget.MenuBar.prototype.addEventListener=function(a,b,c,d){try{if(a.addEventListener){a.addEventListener(b,c,d)}else if(a.attachEvent){a.attachEvent("on"+b,c)}}catch(e){}};Spry.Widget.MenuBar.prototype.createIframeLayer=function(a){var b=document.createElement("iframe");b.tabIndex="-1";b.src='javascript:""';b.frameBorder="0";b.scrolling="no";a.parentNode.appendChild(b);b.style.left=a.offsetLeft+"px";b.style.top=a.offsetTop+"px";b.style.width=a.offsetWidth+"px";b.style.height=a.offsetHeight+"px"};Spry.Widget.MenuBar.prototype.removeIframeLayer=function(a){var b=(a==this.element?a:a.parentNode).getElementsByTagName("iframe");while(b.length>0){b[0].parentNode.removeChild(b[0])}};Spry.Widget.MenuBar.prototype.clearMenus=function(a){var b=a.getElementsByTagName("ul");for(var c=0;c<b.length;c++)this.hideSubmenu(b[c]);this.removeClassName(this.element,this.activeClass)};Spry.Widget.MenuBar.prototype.bubbledTextEvent=function(){return Spry.is.safari&&(event.target==event.relatedTarget.parentNode||event.eventPhase==3&&event.target.parentNode==event.relatedTarget)};Spry.Widget.MenuBar.prototype.showSubmenu=function(a){if(this.currMenu){this.clearMenus(this.currMenu);this.currMenu=null}if(a){this.addClassName(a,this.subVisibleClass);if(typeof document.all!="undefined"&&!Spry.is.opera&&navigator.vendor!="KDE"){if(!this.hasClassName(this.element,this.horizontalClass)||a.parentNode.parentNode!=this.element){a.style.top=a.parentNode.offsetTop+"px"}}if(Spry.is.ie&&Spry.is.version<7){this.createIframeLayer(a)}}this.addClassName(this.element,this.activeClass)};Spry.Widget.MenuBar.prototype.hideSubmenu=function(a){if(a){this.removeClassName(a,this.subVisibleClass);if(typeof document.all!="undefined"&&!Spry.is.opera&&navigator.vendor!="KDE"){a.style.top="";a.style.left=""}if(Spry.is.ie&&Spry.is.version<7)this.removeIframeLayer(a)}};Spry.Widget.MenuBar.prototype.initialize=function(a,b){var c,d;var e=a.getElementsByTagName("a")[0];var f=a.getElementsByTagName("ul");var g=f.length>0?f[0]:null;if(g)this.addClassName(e,this.hasSubClass);if(!Spry.is.ie){a.contains=function(a){if(a==null)return false;if(a==this)return true;else return this.contains(a.parentNode)}}var h=this;this.addEventListener(a,"mouseover",function(b){h.mouseOver(a,b)},false);this.addEventListener(a,"mouseout",function(b){if(h.enableKeyboardNavigation)h.clearSelection();h.mouseOut(a,b)},false);if(this.enableKeyboardNavigation){this.addEventListener(e,"blur",function(b){h.onBlur(a)},false);this.addEventListener(e,"focus",function(b){h.keyFocus(a,b)},false)}};Spry.Widget.MenuBar.prototype.keyFocus=function(a,b){this.lastOpen=a.getElementsByTagName("a")[0];this.addClassName(this.lastOpen,a.getElementsByTagName("ul").length>0?this.subHoverClass:this.hoverClass);this.hasFocus=true};Spry.Widget.MenuBar.prototype.onBlur=function(a){this.clearSelection(a)};Spry.Widget.MenuBar.prototype.clearSelection=function(a){if(!this.lastOpen)return;if(a){a=a.getElementsByTagName("a")[0];var b=this.lastOpen;while(b!=this.element){var c=a;while(c!=this.element){if(c==b)return;try{c=c.parentNode}catch(d){break}}b=b.parentNode}}var b=this.lastOpen;while(b!=this.element){this.hideSubmenu(b.parentNode);var e=b.getElementsByTagName("a")[0];this.removeClassName(e,this.hoverClass);this.removeClassName(e,this.subHoverClass);b=b.parentNode}this.lastOpen=false};Spry.Widget.MenuBar.prototype.keyDown=function(a){if(!this.hasFocus)return;if(!this.lastOpen){this.hasFocus=false;return}var a=a||event;var b=this.lastOpen.parentNode;var c=this.lastOpen;var d=b.getElementsByTagName("ul");var e=d.length>0?d[0]:null;var f=e?true:false;var g=[b,e,null,this.getSibling(b,"previousSibling"),this.getSibling(b,"nextSibling")];if(!g[3])g[2]=b.parentNode.parentNode.nodeName.toLowerCase()=="li"?b.parentNode.parentNode:null;var h=0;switch(a.keyCode){case this.upKeyCode:h=this.getElementForKey(g,"y",1);break;case this.downKeyCode:h=this.getElementForKey(g,"y",-1);break;case this.leftKeyCode:h=this.getElementForKey(g,"x",1);break;case this.rightKeyCode:h=this.getElementForKey(g,"x",-1);break;case this.escKeyCode:case 9:this.clearSelection();this.hasFocus=false;default:return}switch(h){case 0:return;case 1:this.mouseOver(b,a);break;case 2:this.mouseOut(g[2],a);break;case 3:case 4:this.removeClassName(c,f?this.subHoverClass:this.hoverClass);break}var c=g[h].getElementsByTagName("a")[0];if(g[h].nodeName.toLowerCase()=="ul")g[h]=g[h].getElementsByTagName("li")[0];this.addClassName(c,g[h].getElementsByTagName("ul").length>0?this.subHoverClass:this.hoverClass);this.lastOpen=c;g[h].getElementsByTagName("a")[0].focus();return Spry.Widget.MenuBar.stopPropagation(a)};Spry.Widget.MenuBar.prototype.mouseOver=function(a,b){var c=a.getElementsByTagName("a")[0];var d=a.getElementsByTagName("ul");var e=d.length>0?d[0]:null;var f=e?true:false;if(this.enableKeyboardNavigation)this.clearSelection(a);if(this.bubbledTextEvent()){return}if(a.closetime)clearTimeout(a.closetime);if(this.currMenu==a){this.currMenu=null}if(this.hasFocus)c.focus();this.addClassName(c,f?this.subHoverClass:this.hoverClass);this.lastOpen=c;if(e&&!this.hasClassName(e,this.subHoverClass)){var g=this;a.opentime=window.setTimeout(function(){g.showSubmenu(e)},this.showDelay)}};Spry.Widget.MenuBar.prototype.mouseOut=function(a,b){var c=a.getElementsByTagName("a")[0];var d=a.getElementsByTagName("ul");var e=d.length>0?d[0]:null;var f=e?true:false;if(this.bubbledTextEvent()){return}var g=typeof b.relatedTarget!="undefined"?b.relatedTarget:b.toElement;if(!a.contains(g)){if(a.opentime)clearTimeout(a.opentime);this.currMenu=a;this.removeClassName(c,f?this.subHoverClass:this.hoverClass);if(e){var h=this;a.closetime=window.setTimeout(function(){h.hideSubmenu(e)},this.hideDelay)}if(this.hasFocus)c.blur()}};Spry.Widget.MenuBar.prototype.getSibling=function(a,b){var c=a[b];while(c&&c.nodeName.toLowerCase()!="li")c=c[b];return c};Spry.Widget.MenuBar.prototype.getElementForKey=function(a,b,c){var d=0;var e=Spry.Widget.MenuBar.getPosition;var f=e(a[d]);var g=false;if(a[1]&&!this.hasClassName(a[1],this.MenuBarSubmenuVisible)){a[1].style.visibility="hidden";this.showSubmenu(a[1]);g=true}var h=this.hasClassName(this.element,this.verticalClass);var i=a[0].parentNode.parentNode.nodeName.toLowerCase()=="li"?true:false;for(var j=1;j<a.length;j++){if(b=="y"&&h&&(j==1||j==2)){continue}if(b=="x"&&!h&&!i&&(j==1||j==2)){continue}if(a[j]){var k=e(a[j]);if(c*k[b]<c*f[b]){f=k;d=j}}}if(a[1]&&g){this.hideSubmenu(a[1]);a[1].style.visibility=""}return d};Spry.Widget.MenuBar.camelize=function(a){if(a.indexOf("-")==-1){return a}var b=a.split("-");var c=true;var d="";for(var e=0;e<b.length;e++){if(b[e].length>0){if(c){d=b[e];c=false}else{var f=b[e];d+=f.charAt(0).toUpperCase()+f.substring(1)}}}return d};Spry.Widget.MenuBar.getStyleProp=function(a,b){var c;try{if(a.style)c=a.style[Spry.Widget.MenuBar.camelize(b)];if(!c)if(document.defaultView&&document.defaultView.getComputedStyle){var d=document.defaultView.getComputedStyle(a,null);c=d?d.getPropertyValue(b):null}else if(a.currentStyle){c=a.currentStyle[Spry.Widget.MenuBar.camelize(b)]}}catch(e){}return c=="auto"?null:c};Spry.Widget.MenuBar.getIntProp=function(a,b){var c=parseInt(Spry.Widget.MenuBar.getStyleProp(a,b),10);if(isNaN(c))return 0;return c};Spry.Widget.MenuBar.getPosition=function(a,b){b=b||document;if(typeof a=="string"){a=b.getElementById(a)}if(!a){return false}if(a.parentNode===null||Spry.Widget.MenuBar.getStyleProp(a,"display")=="none"){return false}var c={x:0,y:0};var d=null;var e;if(a.getBoundingClientRect){e=a.getBoundingClientRect();var f=b.documentElement.scrollTop||b.body.scrollTop;var g=b.documentElement.scrollLeft||b.body.scrollLeft;c.x=e.left+g;c.y=e.top+f}else if(b.getBoxObjectFor){e=b.getBoxObjectFor(a);c.x=e.x;c.y=e.y}else{c.x=a.offsetLeft;c.y=a.offsetTop;d=a.offsetParent;if(d!=a){while(d){c.x+=d.offsetLeft;c.y+=d.offsetTop;d=d.offsetParent}}if(Spry.is.opera||Spry.is.safari&&Spry.Widget.MenuBar.getStyleProp(a,"position")=="absolute")c.y-=b.body.offsetTop}if(a.parentNode)d=a.parentNode;else d=null;if(d.nodeName){var h=d.nodeName.toUpperCase();while(d&&h!="BODY"&&h!="HTML"){h=d.nodeName.toUpperCase();c.x-=d.scrollLeft;c.y-=d.scrollTop;if(d.parentNode)d=d.parentNode;else d=null}}return c};Spry.Widget.MenuBar.stopPropagation=function(a){if(a.stopPropagation)a.stopPropagation();else a.cancelBubble=true;if(a.preventDefault)a.preventDefault();else a.returnValue=false};Spry.Widget.MenuBar.setOptions=function(a,b,c){if(!b)return;for(var d in b){if(c&&b[d]==undefined)continue;a[d]=b[d]}}