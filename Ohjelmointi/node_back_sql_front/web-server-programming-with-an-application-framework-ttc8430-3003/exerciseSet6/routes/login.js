const express = require('express')
const loginRouter = express.Router()

const login = require('../controller/login')

loginRouter.post('/', async (req, res) => {
    try {
        await login(req, res)
    } catch (error) {
        console.error('Error:', error.message)
        return res.status(500).json('epäonnistui' + error.message)
    }
})

module.exports = loginRouter
