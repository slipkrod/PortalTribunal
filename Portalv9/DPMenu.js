function Message() {
    if (confirm("¿Confirma que desea salir del Sistema?")) {
        window.location = 'Logoff.aspx';
    }

    return false;
}

function findPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        do {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop;
        } while (obj = obj.offsetParent);
        return [curleft, curtop];
    }
}

function showSubMenu(subMenuId, header) {
    var subMenu = document.getElementById(subMenuId);

    subMenu.style.display = "block";
    var pos = findPos(header);

    subMenu.style.left = pos[0];
    subMenu.style.top = pos[1] + header.offsetHeight;
}

function hideSubMenu(subMenuId) {
    var subMenu = document.getElementById(subMenuId);

    subMenu.style.display = "none";
}

function keepSubMenu(subMenuId) {
    var subMenu = document.getElementById(subMenuId);

    subMenu.style.display = "block";
}