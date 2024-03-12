const jwt = require('jsonwebtoken')
const bcrypt = require('bcryptjs')
const User = require('../models/user')
require('dotenv').config()

const login = async (req, res) => {
    const { name, password } = req.body
    const user = await User.findOne({ name })

    const passwordCorrect = user === null ? false : await bcrypt.compare(password, user.passwordConfirmation)

    if (!(user && passwordCorrect)) {
        return res.status(401).json({ error: 'invalid username or password' })
    }

    const userForToken = {
        name: name,
        id: user._id,
    }

    const token = jwt.sign(userForToken, process.env.ACCESS_TOKEN_SECRET, { expiresIn: process.env.JWT_EXPIRES_IN })

    res.status(200).send({ token, name: user.name, id: user._id })

}


module.exports = login
