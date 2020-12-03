var isStageEnemyKilled = false;
var isTrue = true;
var pointsWon = 0;
var targetsTotal = 12;
var gunValue = 5;
var healthValue = 3;
var difficultyBySize = 100;
var difficultyByTime = 50;


var headingTargetsRemaining = document.getElementById("targetsRemaining");

var gun = document.getElementById("myGun");
var health = document.getElementById("myHealth");

var buttonStart = document.getElementById("buttonStart");

var shooterCanvas = document.getElementById("shooterCanvas");
shooterCanvas.width = 1280;
shooterCanvas.height = 720;
shooterCanvas.style.cursor = "crosshair";

var ctx = shooterCanvas.getContext("2d");


function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function decreaseHealth() {
    new Audio("/sounds/shooter/sound_shooter_injury.mp3").play();
    ctx.rect(0, 0, 1280, 720);
    ctx.fillStyle = "red";
    ctx.fill();
    await sleep(375);
    ctx.clearRect(0, 0, 1280, 720);
    ctx.fillStyle = "black";
    healthValue--;
    if (healthValue === 2) {
        health.setAttribute("src", "/images/shooter/health_2.png");
    }
    else if (healthValue === 1) {
        health.setAttribute("src", "/images/shooter/health_1.png");
    }
    else if (healthValue === 0) {
        health.setAttribute("src", "/images/shooter/health_0.png");
    }
}

function resetGame() {
    ctx.clearRect(0, 0, 1280, 720);
    headingTargetsRemaining.innerHTML = "";
    headingTargetsRemaining.style.color = "black";
    pointsWon = 0;
    gunValue = 5;
    gun.setAttribute("src", "/images/shooter/gun_5.png");
    healthValue = 3;
    health.setAttribute("src", "/images/shooter/health_3.png");
    isTrue = true;
    isStageEnemyKilled = false;
}

async function count321Start() {
    new Audio("/sounds/shooter/sound_shooter_start.wav").play();
    ctx.font = "100px Arial";
    ctx.fillStyle = "black";
    ctx.fillText("3", 600, 360);
    await sleep(1000);
    ctx.clearRect(0, 0, 1280, 720);
    ctx.fillText("2", 600, 360);
    await sleep(1000);
    ctx.clearRect(0, 0, 1280, 720);
    ctx.fillText("1", 600, 360);
    await sleep(1000);
    ctx.clearRect(0, 0, 1280, 720);
    ctx.fillText("GO!", 540, 360);
    await sleep(1000);
    ctx.clearRect(0, 0, 1280, 720);
}

async function endGameWon() {
    new Audio("/sounds/shooter/sound_shooter_ctwin.wav").play();
    await sleep(1000);
    headingTargetsRemaining.style.color = "green";
    headingTargetsRemaining.innerHTML = "Game over!";
    await sleep(2000);
    ctx.font = "100px Arial";
    if (pointsWon >= 55) {
        ctx.fillStyle = "green";
    }
    ctx.fillText(`Your points: ${pointsWon}`, 320, 360);
    await hideNavBar();
}

async function endGameLost() {
    new Audio("/sounds/shooter/sound_shooter_twin.wav").play();
    await sleep(1000);
    headingTargetsRemaining.style.color = "red";
    headingTargetsRemaining.innerHTML = "Game over!";
    await sleep(2000);
    ctx.font = "100px Arial";
    ctx.fillStyle = "red";
    ctx.fillText("You lost!", 450, 360);
    await hideNavBar();
}

function showNavBar() {
    gun.style.display = "inline";
    health.style.display = "inline";
    headingTargetsRemaining.innerHTML = "Targets remaining: " + `${targetsTotal} 🐱‍👤` + " _____ " + "This target: " + `${1} 💯` + " _____ " + "Points won: " + `${pointsWon} 💯`;
}

function hideNavBar() {
    gun.style.display = "none";
    health.style.display = "none";
    headingTargetsRemaining.innerHTML = "";
}


buttonStart.addEventListener("click", () => {
    buttonStart.style.display = "none";
    play();
});

document.addEventListener("keypress", (event) => {
    if (event.key === 'Enter') {
        gunValue = 5;
        gun.setAttribute("src", "/images/shooter/gun_5.png");
        isTrue = true;
        new Audio("/sounds/shooter/sound_shooter_reload.wav").play();
    }
});

shooterCanvas.addEventListener("click", (event) => {
    if (gunValue === 0) {
        gun.setAttribute("src", "/images/shooter/gun_0.png");
        isTrue = false;
        new Audio("/sounds/shooter/sound_shooter_empty.wav").play();
    }
    else {
        new Audio("/sounds/shooter/sound_shooter_shoot.wav").play();
        switch (gunValue) {
            case 1:
                gun.setAttribute("src", "/images/shooter/gun_0.png");
                break;
            case 2:
                gun.setAttribute("src", "/images/shooter/gun_1.png");
                break;
            case 3:
                gun.setAttribute("src", "/images/shooter/gun_2.png");
                break;
            case 4:
                gun.setAttribute("src", "/images/shooter/gun_3.png");
                break;
            case 5:
                gun.setAttribute("src", "/images/shooter/gun_4.png");
                break;
            default:
                gun.setAttribute("src", "/images/shooter/gun_5.png");
                break;
        }
        gunValue--;
    }
});

shooterCanvas.addEventListener("mousedown", () => {
    shooterCanvas.style.cursor = "move";
});

shooterCanvas.addEventListener("mouseup", () => {
    shooterCanvas.style.cursor = "crosshair";
});

async function play() {
    await resetGame();
    await count321Start();
    await showNavBar();

    for (let i = 0; i < targetsTotal; i++) {
        isStageEnemyKilled = false;

        headingTargetsRemaining.innerHTML = "Targets remaining: " + `${targetsTotal - i} 🐱‍👤` + " _____ " + "This target: " + `${i + 1} 💯` + " _____ " + "Points won: " + `${pointsWon} 💯`;
        if (targetsTotal - i <= 3) {
            headingTargetsRemaining.style.color = "red";
        }

        await sleep((difficultyByTime * 2) + (targetsTotal * 100) - (i * 50));

        var xCoordinate = 1230 - (Math.floor(Math.random() * 1181));
        var yCoordinate = 670 - (Math.floor(Math.random() * 621));

        shooterCanvas.addEventListener("click", () => {
            if (((event.offsetX <= xCoordinate + (difficultyBySize / 2)) && (event.offsetX >= xCoordinate - (difficultyBySize / 2))) && ((event.offsetY <= yCoordinate + (difficultyBySize / 2)) && (event.offsetY >= yCoordinate - (difficultyBySize / 2))) && gunValue >= 0 && isTrue === true) {
                new Audio("/sounds/shooter/sound_shooter_success.wav").play();
                pointsWon += 1;
                headingTargetsRemaining.innerHTML = "Targets remaining: " + `${targetsTotal - i} 🐱‍👤` + " _____ " + "This target: " + `${i + 1} 💯` + " _____ " + "Points won: " + `${pointsWon} 💯`;
                isStageEnemyKilled = true;
            }
        });

        for (let j = 0; j <= difficultyBySize; j++) {
            ctx.drawImage(myImage, (xCoordinate - (j / 2)), (yCoordinate - (j / 2)), j, j);
            await sleep(targetsTotal - (i / 2));

            if (isStageEnemyKilled === true) {
                ctx.clearRect(0, 0, 1280, 720);
                break;
            }

            if (j === difficultyBySize) {
                new Audio("/sounds/shooter/sound_shooter_shoot.wav").play();
                ctx.drawImage(myImageBang, (xCoordinate - (j / 2)), (yCoordinate - (j / 2)), j, j);
                await sleep(250);
                await decreaseHealth();
                if (healthValue === 0) {
                    break;
                }
            }
        }

        if (healthValue === 0) {
            break;
        }
    }

    if (healthValue === 0) {
        await endGameLost();
    }
    else {
        await endGameWon();
    }

    buttonStart.innerHTML = "RESTART";
    buttonStart.style.display = "inline";
};