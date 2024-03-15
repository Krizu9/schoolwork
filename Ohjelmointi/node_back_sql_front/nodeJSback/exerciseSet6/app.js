
const express = require('express')
const app = express()
app.use(express.json())

// päästää indx.html sivulle

const albumRouter = require('./routes/albums')
const userRouter = require('./routes/users')
const loginRouter = require('./routes/login')
app.use('/register', userRouter)
app.use('/login', loginRouter)
app.use('/albums', albumRouter)


const logger = require('./middleware/logger')

app.use(express.static('./public'))


app.use(logger)




const PORT = 5001
app.listen(PORT, () => {
    console.log(`server is listening on port ${PORT}...`)
})
