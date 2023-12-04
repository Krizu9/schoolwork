const user = require('./src/user')

const userName = user.getName()
const userLocation = user.getLocation()
const userBirthdate = user.birthdate

console.log(`${userName} lives in ${userLocation} and was born on ${userBirthdate}.`)