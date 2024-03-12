document.addEventListener('keydown', keyPressed);
let i = -1;




async function getNames() {
    let url = 'src/names.json';
    try {
        let res = await fetch(url);
        if (!res.ok) {
            throw new Error('Network response was not ok');
        }
        return await res.json();
    } catch (error) {
        console.error('Error:', error);
    }
}

function clearBox() {
    const elements = document.getElementsByClassName("name");
    while (elements.length > 0) {
        elements[0].parentNode.removeChild(elements[0]);
    }

}



async function renderNames() {
    clearBox();
    try {
        if (haku.value == "") {
            clearBox();
        } else {
            let names = await getNames();
            const inputString = document.getElementById("haku").value.toLowerCase();
            const matchingNames = names.filter(name => name.toLowerCase().startsWith(inputString));

            if (matchingNames.length > 0) {
                let namediv = document.getElementById("tulokset");
                matchingNames.forEach(name => {
                    let nameElement = document.createElement('p');
                    nameElement.className = 'name';
                    nameElement.innerHTML = name;
                    namediv.appendChild(nameElement);
                });
            }
        }

    } catch (error) {
        console.error('Error:', error);
    }

}



function keyPressed(e) {

    if (e.key == "ArrowDown") {
        haku.blur();
        i++;
        updateSelection();

    }
    if (e.code == "ArrowUp") {
        haku.blur();
        i--;
        updateSelection();
    }
    if (e.code == "Enter") {
        const collection = document.getElementsByClassName("name");
        const selectedName = collection[i].innerHTML;
        document.getElementById("haku").value = selectedName;
        clearBox();
    }
    if (e.code == "Escape") {
        clearBox();
        i = -1;
        document.getElementById("haku").value = "";
    }
}

function updateSelection() {
    const collection = document.getElementsByClassName("name");
    for (let j = 0; j < collection.length; j++) {
        collection[j].style.backgroundColor = "";
    }
    if (i >= collection.length) {
        i = collection.length - 1;
    }
    if (i < -1) {
        i = -1;
    }
    collection[i].style.backgroundColor = "yellow";
}
