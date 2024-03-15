const logger = (req, res, next) => {
    console.log(req.method + req.path + req.body)
    const { search } = req.query
    if (!search) {
        return res.status(401).json({ message: 'Not found' })
    }
    next()

}

module.exports = logger