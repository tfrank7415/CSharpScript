window.cSharpScript = {

    hideById: function (selector) {
        var elementToHide = document.getElementById(selector);
        elementToHide.style.display = "none";
    },

    hideByClass: function (selector) {
        var elementsToHide = document.getElementsByClassName(selector);
        console.log(elementsToHide);
        Array.from(elementsToHide).forEach((element) => {
            element.style.display = "none";
        });
        
    },

    showById: function (selector) {
        var elementToShow = document.getElementById(selector);
        elementToShow.style.display = "";
    },

    showByClass: function (selector) {
        var elementsToShow = document.getElementsByClassName(selector);
        Array.from(elementsToShow).forEach((element) => {
            element.style.display = "";
        });
    },

    showByName: function (selector) {
        var elementsToShow = document.getElementsByName(selector);
        Array.from(elementsToShow).forEach((element) => {
            element.style.display = "";
        });
    },

    hideByName: function (selector) {
        var elementsToHide = document.getElementsByName(selector);
        Array.from(elementsToHide).forEach((element) => {
            element.style.display = "none";
        });
    },

    showByTagName: function (selector) {
        var elementsToShow = document.getElementsByTagName(selector);
        Array.from(elementsToShow).forEach((element) => {
            element.style.display = "";
        });
    },

    hideByTagName: function (selector) {
        var elementsToHide = document.getElementsByTagName(selector);
        Array.from(elementsToHide).forEach((element) => {
            element.style.display = "none";
        });
    },
}