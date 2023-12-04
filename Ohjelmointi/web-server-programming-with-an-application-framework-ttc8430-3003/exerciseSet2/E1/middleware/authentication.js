const authentication = (req, res, next) => {
    const user = req.query.user
    if (user !== 'admin') {

        return res.status(401).json({ message: 'Unauthorized' })
    }
    next()
}
//eli toimii kun urlin perään laitetaan ?user=admin
module.exports = authentication