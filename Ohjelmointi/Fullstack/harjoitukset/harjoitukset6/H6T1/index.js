const express = require("express")
const app = express()
app.use(express.json())
const port = 3050

let users =
    [
        { 'id': '1', 'name': 'Kirsi Kernel' },
        { 'id': '2', 'name': 'Matti Mainio' }
    ]

app.listen(port, () => {
    console.log("Example app listening on port 3050")
})

// get all users
app.get('/users', (request, response) => {
    response.json(users)
})

// get one user
app.get('/users/:id', (request, response) => {
    //const id = request.params.id // note how you can do this in different ways!
    const { id } = request.params
    const user = users.find(user => user.id === id)
    if (user) response.json(user)
    else response.status(404).end()
})

// delete one user
app.delete('/users/:id', (request, response) => {
    //const id = request.params.id
    const { id } = request.params
    users = users.filter(user => user.id !== id)
    // Just send "204 no content" status code back
    response.status(204).end()
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
app.post('/users/', (request, response) => {
    const maxId = Math.max(...users.map(user => user.id), 0)
    const user = request.body
    user.id = (maxId + 1).toString()
    users = users.concat(user)
    response.json(user)
})


