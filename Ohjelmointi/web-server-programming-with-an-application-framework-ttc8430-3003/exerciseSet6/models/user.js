const mongoose = require('mongoose')
const { Schema } = mongoose

const userSchema = new Schema({
    name: { type: String, required: [true, 'Name is required'] },
    email: { type: String, required: [true, 'Email is required'] },
    password: { type: String, required: [true, 'Password is required'] },
    passwordConfirmation: { type: String, required: [true, 'Password confirmation is required'] }
})
module.exports = mongoose.model('User', userSchema)