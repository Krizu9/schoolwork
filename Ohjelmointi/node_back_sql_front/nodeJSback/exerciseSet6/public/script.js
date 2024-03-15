const baseUrl = 'http://127.0.0.1:5001/albums/?user=admin'
console.log(baseUrl)

async function loadAlbums() {
    try {
        let res = await fetch(`${baseUrl}`)
        let albums = await res.json()
        let albumList = document.getElementById('albums')
        albums.forEach(album => {
            let liNode = document.createElement('li')
            let txtNode = document.createTextNode(`id: ${album.id}, Artist: ${album.artist}, album: ${album.title}, year: ${album.year}, tracks: ${album.tracks}`)
            liNode.appendChild(txtNode)
            albumList.appendChild(liNode)
        })
    } catch (error) {
        console.log(error)
    }
}

loadAlbums()