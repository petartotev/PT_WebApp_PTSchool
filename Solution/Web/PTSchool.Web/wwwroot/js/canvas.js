var myConnectionDraw = new signalR.HubConnectionBuilder().withUrl("/canvashub").build();

var isDrawing;

var myCanvas = document.getElementById("canvas");
myCanvas.width = window.innerWidth * 0.95;
myCanvas.height = window.innerHeight * 0.7;

const canvasContext = myCanvas.getContext("2d");

var linkToSave = document.getElementById("linkSave");
linkToSave.addEventListener("click", (e) => {
    linkToSave.href = myCanvas.toDataURL();
    linkToSave.download = "PTSchoolDrawing.jpg";
}, false);

function getBrushSize() {
    var brushSize = document.getElementById("myColorSizeSlider").value;
    var brushSizeToReturn = brushSize;
    return brushSizeToReturn;
}

function getBrushColor() {
    var brushColor = document.getElementById("color-display").style.backgroundColor;
    return brushColor;
}

function drawCircle(x, y, z, c, color) {
    canvasContext.beginPath();
    canvasContext.arc(x, y, z, c, 2 * Math.PI);
    canvasContext.fillStyle = `${color}`;
    canvasContext.fill();
}

myConnectionDraw.on("SendDrawingToAllJS",
    function (model) {
        drawCircle(model.xCoordinate, model.yCoordinate, model.brushSize, 0, model.brushColor);
    });

myCanvas.addEventListener("mousedown", (e) => {
    isDrawing = true;
    //drawCircle(e.offsetX, e.offsetY, getBrushSize(), 0, getBrushColor());
    var brushSizeThis = getBrushSize();
    var brushColorThis = getBrushColor();
    //debugger;
    myConnectionDraw.invoke("SendDrawingToAllCSharp", e.offsetX, e.offsetY, brushSizeThis, brushColorThis);
    //debugger;
});

myCanvas.addEventListener("mousemove", (e) => {
    if (isDrawing) {
        //drawCircle(e.offsetX, e.offsetY, getBrushSize(), 0, getBrushColor());
        var brushSizeThis = getBrushSize();
        var brushColorThis = getBrushColor();
        myConnectionDraw.invoke("SendDrawingToAllCSharp", e.offsetX, e.offsetY, brushSizeThis, brushColorThis);
    }
});

myCanvas.addEventListener("mouseup", (e) => {
    isDrawing = false;
});

myConnectionDraw.start().catch(function (err) {
    return console.error(err.toString());
});

// PT: To escape HTML injection in chat:
function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

var slider = document.getElementById("myColorSizeSlider");
var output = document.getElementById("demo");
output.innerHTML = slider.value;
slider.oninput = function () {
    output.innerHTML = this.value;
}

// moduled querySelector
function qs(selectEl) {
    return document.querySelector(selectEl);
}

// select RGB inputs
let red = qs('#red'),
green = qs('#green'),
blue = qs('#blue');

// selet num inputs
let redNumVal = qs('#redNum'),
    greenNumVal = qs('#greenNum'),
    blueNumVal = qs('#blueNum');

// select Color Display
let colorDisplay = qs('#color-display');

// select labels
let redLbl = qs('label[for=red]'),
    greenLbl = qs('label[for=green]'),
    blueLbl = qs('label[for=blue]');

// init display Colors
displayColors();
// init Color Vals
colorNumbrVals();
// init ColorSliderVals
initSliderColors();
// init Change Range Val
changeRangeNumVal();
// init Colors controls
colorSliders();

// display colors
function displayColors() {
    colorDisplay.style.backgroundColor = `rgb(${red.value}, ${green.value}, ${blue.value})`;
}

// initial color val when DOM is loaded 
function colorNumbrVals() {
    redNumVal.value = red.value;
    greenNumVal.value = green.value;
    blueNumVal.value = blue.value;
}

// initial colors when DOM is loaded
function initSliderColors() {
    // label bg colors
    redLbl.style.background = `rgb(${red.value},0,0)`;
    greenLbl.style.background = `rgb(0,${green.value},0)`;
    blueLbl.style.background = `rgb(0,0,${blue.value})`;

    // slider bg colors
    sliderFill(red);
    sliderFill(green);
    sliderFill(blue);
}

// Slider Fill offset
function sliderFill(clr) {
    let val = (clr.value - clr.min) / (clr.max - clr.min);
    let percent = val * 100;

    // clr input
    if (clr === red) {
        clr.style.background = `linear-gradient(to right, rgb(${clr.value},0,0) ${percent}%, #cccccc 0%)`;
    } else if (clr === green) {
        clr.style.background = `linear-gradient(to right, rgb(0,${clr.value},0) ${percent}%, #cccccc 0%)`;
    } else if (clr === blue) {
        clr.style.background = `linear-gradient(to right, rgb(0,0,${clr.value}) ${percent}%, #cccccc 0%)`;
    }
}

// change range values by number input
function changeRangeNumVal() {

    // Validate number range
    redNumVal.addEventListener('change', () => {
        // make sure numbers are entered between 0 to 255
        if (redNumVal.value > 255) {
            alert('cannot enter numbers greater than 255');
            redNumVal.value = red.value;
        } else if (redNumVal.value < 0) {
            alert('cannot enter numbers less than 0');
            redNumVal.value = red.value;
        } else if (redNumVal.value == '') {
            alert('cannot leave field empty');
            redNumVal.value = red.value;
            initSliderColors();
            displayColors();
        } else {
            red.value = redNumVal.value;
            initSliderColors();
            displayColors();
        }
    });

    // Validate number range
    greenNumVal.addEventListener('change', () => {
        // make sure numbers are entered between 0 to 255
        if (greenNumVal.value > 255) {
            alert('cannot enter numbers greater than 255');
            greenNumVal.value = green.value;
        } else if (greenNumVal.value < 0) {
            alert('cannot enter numbers less than 0');
            greenNumVal.value = green.value;
        } else if (greenNumVal.value == '') {
            alert('cannot leave field empty');
            greenNumVal.value = green.value;
            initSliderColors();
            displayColors();
        } else {
            green.value = greenNumVal.value;
            initSliderColors();
            displayColors();
        }
    });

    // Validate number range
    blueNumVal.addEventListener('change', () => {
        // make sure numbers are entered between 0 to 255
        if (blueNumVal.value > 255) {
            alert('cannot enter numbers greater than 255');
            blueNumVal.value = blue.value;
        } else if (blueNumVal.value < 0) {
            alert('cannot enter numbers less than 0');
            blueNumVal.value = blue.value;
        } else if (blueNumVal.value == '') {
            alert('cannot leave field empty');
            blueNumVal.value = blue.value;
            initSliderColors();
            displayColors();
        } else {
            blue.value = blueNumVal.value;
            initSliderColors();
            displayColors();
        }
    });
}

// Color Sliders controls
function colorSliders() {
    red.addEventListener('input', () => {
        displayColors();
        initSliderColors();
        changeRangeNumVal();
        colorNumbrVals();
    });

    green.addEventListener('input', () => {
        displayColors();
        initSliderColors();
        changeRangeNumVal();
        colorNumbrVals();
    });

    blue.addEventListener('input', () => {
        displayColors();
        initSliderColors();
        changeRangeNumVal();
        colorNumbrVals();
    });
}
