const albumRouter = require('express').Router()
const APIError = require('../errors/apierror')

const {
    getAlbum,
    getAlbums,
    createAlbum,
    updateAlbum,
    deleteAlbum,
} = require('../controller/albums')

const authentication = require('../middleware/authentication')

albumRouter.get('/', async (req, res, next) => {
    try {
        await getAlbums(req, res)
    } catch (error) {
        next(new APIError(error.message, 500))
    }
})

albumRouter.get('/:id', async (req, res, next) => {
    try {
        await getAlbum(req, res)
    } catch (error) {
        next(new APIError(error.message, 500))
    }
})

albumRouter.post('/', authentication, async (req, res, next) => {
    try {
        await createAlbum(req, res)
    } catch (error) {
        next(new APIError(error.message, 500))
    }
})

albumRouter.put('/:id', authentication, async (req, res, next) => {
    try {
        await updateAlbum(req, res)
    } catch (error) {
        next(new APIError(error.message, 500))
    }
})

albumRouter.delete('/:id', authentication, async (req, res, next) => {
    try {
        await deleteAlbum(req, res)
    } catch (error) {
        next(new APIError(error.message, 500))
    }
})

module.exports = albumRouter
