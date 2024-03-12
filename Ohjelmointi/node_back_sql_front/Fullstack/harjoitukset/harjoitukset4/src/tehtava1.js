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

async function renderHouses() {
    try {
        let houses = await getHouses();
        console.log(houses);

        let housediv = document.getElementById("houses");

        houses.forEach(house => {
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
            text.innerHTML += '<br>' + '<br>' + house.text;

            housecontainer.appendChild(image);
            housecontainer.appendChild(header);
            housecontainer.appendChild(text);

            housediv.appendChild(housecontainer);
        });
    } catch (error) {
        console.error('Error:', error);
    }
}

window.onload = renderHouses;
