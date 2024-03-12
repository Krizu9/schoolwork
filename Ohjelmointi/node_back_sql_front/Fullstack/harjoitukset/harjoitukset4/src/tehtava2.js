async function getHouses() {
    let url = 'src/houses.json';
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
    const elements = document.getElementsByClassName("houseContainer");
    while (elements.length > 0) {
        elements[0].parentNode.removeChild(elements[0]);
    }
}


async function renderHouses() {
    clearBox();
    try {
        let Koko = document.getElementById("koko");
        let Hinta = document.getElementById("hinta");
        let houses = await getHouses();
        let housediv = document.getElementById("houses");

        houses.forEach(house => {
            if ((!Koko.checked || house.size < 200) && (!Hinta.checked || house.price <= 1000000)) {
                let housecontainer = document.createElement('div');
                housecontainer.className = 'houseContainer';

                let image = document.createElement('img');
                image.src = house.image;
                image.className = 'houseImage';

                let header = document.createElement('p');
                header.className = 'header';
                header.innerHTML = house.address;

                let text = document.createElement('p');
                text.className = 'text';
                text.innerHTML += house.size + 'm<sup>2</sup>';
                text.innerHTML += '<br>' + 'Price: €' + house.price;
                text.innerHTML += '<br>' + house.text;

                housecontainer.appendChild(image);
                housecontainer.appendChild(header);
                housecontainer.appendChild(text);

                housediv.appendChild(housecontainer);
            }
        });
    } catch (error) {
        console.error('Error:', error);
    }
}

window.onload = renderHouses;