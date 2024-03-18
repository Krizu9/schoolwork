const jwt = require('jsonwebtoken');
require('dotenv').config();

const authentication = async (req, res, next) => {
    let token = req.body.token || req.headers.authorization;
    console.log(token);
    try {
        if (!token) {
            return res.status(401).json({ error: 'No token delivered' });
        }

        const [tokenPart, userId] = token.split(',');
        const decodedToken = jwt.verify(tokenPart, process.env.ACCESS_TOKEN_SECRET);
        console.log("seuraavaksi decocedToken:");
        console.log(decodedToken)

        if (decodedToken.id === userId) {
            next();
        } else {
            return res.status(401).json({ error: 'Invalid token, please login' });
        }
    } catch (error) {
        console.error(error); // Log the error
        return res.status(500).json({ error: error.message });
    }
};

module.exports = authentication;
