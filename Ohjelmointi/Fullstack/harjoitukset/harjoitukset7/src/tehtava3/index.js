const express = require("express")
const app = express()
app.use(express.json())
const port = 3050
const fs = require('fs')

// use mongoose
const mongoose = require('mongoose')

// connection string - EDIT YOUR OWN HERE
const mongoDB = 'mongodb+srv://vahafullstack:f6ONQpXO0TVvORac@fullstackcluster0.ogr0r9x.mongodb.net/?retryWrites=true&w=majority'

// connect mongodb
mongoose.connect(mongoDB, { useNewUrlParser: true, useUnifiedTopology: true })
const db = mongoose.connection

// check connection - ok or error
db.on('error', console.error.bind(console, 'connection error:'))
db.once('open', function () {
    console.log("Database test connected")
})

const userSchema = new mongoose.Schema({
    name: String
})

// new model
const User = mongoose.model('User', userSchema, 'users')

const personSchema = new mongoose.Schema({
    name: { type: String, required: true },
    age: { type: Number, min: 0 },
    email: String
})

const logger = (request, response, next) => {
    const date = new Date()
    const lDate = `${date.toLocaleDateString()} ${date.toLocaleTimeString()}`
    const log = `${lDate}: ${request.method} ${request.url}\n`
    fs.appendFile("log.txt", log, (error) => {
        if (error) throw error
    })
    next()
}
app.use(logger)

app.listen(port, () => {
    console.log("Example app listening on port 3050")
})

// get all users
app.get('/users', async (request, response) => {
    const users = await User.find({})
    response.json(users)
})

// get one user
app.get('/users/:id', async (request, response) => {
    const user = await User.findById(request.params.id)
    if (user) response.json(user)
    else response.status(404).end()
})

// delete one user
app.delete('/users/:id', async (request, response) => {
    const deletedUser = await User.findByIdAndRemove(request.params.id)
    if (deletedUser) response.json(deletedUser)
    else response.status(404).end()
})

// update user data
app.put('/users/:id', (request, response) => {
    //const id = request.params.id
    const { id } = request.params
    // const name = request.query.name
    const { name } = request.query
    const user = users.find(user => user.id === id)
    if (user) {
        user.name = name
        response.status(200).end()
    } else {
        response.status(204).end()
    }
})

// create a new user
app.post('/users', async (request, response) => {
    // Get name from request
    const { name } = request.body

    // Create a new user
    const user = new User({
        name: name
    })

    // Save to db and send back to caller
    const savedUser = await user.save()
    response.json(savedUser)
})

