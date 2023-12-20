const User = require('../models/user')
const bcrypt = require('bcryptjs')


const createUser = async (req, res) => {
    const { name, email, password, passwordConfirmation } = req.body
    const userExists = await User.findOne({ email })
    if (userExists) {
        return res.status(409).send({ success: false, msg: 'User already exists with email: ' + email })
    }

    if (password !== passwordConfirmation) {
        return res.status(400).send({ success: false, msg: 'Password and password confirmation do not match' })
    }

    const saltRounds = 10
    const passwordHash = await bcrypt.hash(password, saltRounds)
    const user = new User({
        name,
        email,
        password: passwordHash,
        passwordConfirmation: passwordHash
    })
    await user.save()
    res.status(200).json({ user })

}

module.exports = {
    createUser,
}