const authentication = require('./middleware/authentication')
const express = require('express')
const app = express()

app.use(express.json())

app.use(express.static('./public'))
// päästää indx.html sivulle

const albumRouter = require('./routes/albums')
const logger = require('./middleware/logger')


app.use('/albums', authentication, albumRouter)


app.use(logger)




const PORT = 5001
app.listen(PORT, () => {
    console.log(`server is listening on port ${PORT}...`)
})
