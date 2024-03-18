const jwt = require('jsonwebtoken')
require('dotenv').config()


const authentication = async (req, res, next) => {
    const { token } = req.body;
    if (!token) {
        return res.status(401).json({ error: 'No token delivered' });
    }
    const [tokenPart, userId] = token.split(',');
    const decodedToken = jwt.verify(tokenPart, process.env.ACCESS_TOKEN_SECRET);
    if (decodedToken) {
        next()
    } else {
        return res.status(401).json({ error: 'Invalid token, please login' });
    }
}
module.exports = authentication