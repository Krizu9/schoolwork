const jwt = require('jsonwebtoken')
require('dotenv').config()


const authentication = async (req, res, next) => {
    const authHeader = req.headers.authorization
    if (!authHeader || !authHeader.startsWith('Bearer')) {
        throw new Error('No token provided')
    }
    const token = authHeader.split(' ')[1]
    try {
        const decoded = jwt.verify(token, process.env.ACCESS_TOKEN_SECRET)
        const name = decoded
        req.user = name
        next()
    }
    catch (error) {
        return res.status(401).json({ error: 'token missing or invalid' })
    }
}
module.exports = authentication