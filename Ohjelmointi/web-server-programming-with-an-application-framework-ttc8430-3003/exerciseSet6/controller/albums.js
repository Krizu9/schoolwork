require('dotenv').config()
const mongoose = require('mongoose')
const url = process.env.MONGODB_URL
const databaseName = 'removedsensitiveinfo'
const collectionName = 'removedsensitiveinfo'

//haku toimii näin esim: http://localhost:5001/albums/?id=1&user=admin

mongoose.connect(url, { dbName: databaseName })

const albumSchema = new mongoose.Schema({
    id: {
        type: Number,
        required: true,
    },
    artist: {
        type: String,
        required: true,
    },
    title: {
        type: String,
        required: true,
    },
    year: {
        type: Number,
        required: true,
        validate: {
            validator: (value) => {

                const currentYear = new Date().getFullYear()
                return value >= 1900 && value <= currentYear

            },
            message: 'Year should between 1900 and the current year.'
        }
    },
    genre: String,
    tracks: {
        type: Number,
        validate: {
            validator: (value) => value > 0,
            message: 'Album should have more than 0 tracks.'
        }
    },
}, { collection: collectionName })


const generateNewId = async () => {
    const count = await Albums.countDocuments({})
    return String(count + 1)
}

const Albums = mongoose.model('Albums', albumSchema, collectionName)

// post - eli lisää uusi
const createAlbum = async (req, res) => {
    const { artist, title, year, genre, tracks } = req.body
    const newId = await generateNewId()
    const newAlbum = new Albums({ id: newId, artist, title, year, genre, tracks })
    await newAlbum.save()
    res.send(newAlbum)
}

// get kaikki albumit databasesta
// sort toimii esimerkiksi näin: http://localhost:5001/albums?sortBy=artist&user=admin
// filteröinti vuosilla toimii esimerkiksi näin: http://localhost:5001/albums?releaseYear=2020&user=admin
// valitsemat kentät tulostuu esimerkiksi: http://localhost:5001/albums?fields=artist,title&user=admin
// haku toimii esimerkiksi näin: http://localhost:5001/albums?search=ave&user=admin
const getAlbums = async (req, res) => {

    const { sortBy, releaseYear, fields, search } = req.query
    let result = Albums.find()

    if (releaseYear) {
        result = result.where('year').equals(releaseYear)
    }

    if (fields) {
        const selectFields = fields.split(',').join(' ')
        result = result.select('-_id ' + selectFields)
    }

    if (search) {
        result = result.where('artist').regex(new RegExp(search, 'i'))
    }

    if (sortBy) {
        const sortList = sortBy.split(',').join(' ')
        result = result.sort(sortList)
    } else {
        result = result.sort('artist')
    }

    const albums = await result
    res.send(albums)
}

// get idn perusteella
const getAlbum = (req, res) => {
    const id = req.params.id
    Albums.findOne({ id: id })
        .then(result => {
            if (result) {
                res.send(result)
            }
            else {
                res.status(404).send(`Album with id ${id} not found.`)
            }
        })
}

// put - eli päivitä
const updateAlbum = (req, res) => {
    const id = req.params.id
    const { artist, title, year, genre, tracks } = req.body
    Albums.updateOne({ id: id }, { artist, title, year, genre, tracks }).then(result => {
        res.send(result)
    })
}
// delete - eli poista idllä
const deleteAlbum = (req, res) => {
    const id = req.params.id
    Albums.deleteOne({ id: id }).then(result => {
        res.send(result)
    })
}

module.exports = {
    getAlbums,
    getAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum
}
