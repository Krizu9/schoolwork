const { Schema } = require('mongoose');

require('dotenv').config()

const collectionName = 'actions'

const actionsSchema = new Schema({
    action: { type: String, required: [true, 'Action is required.'] },
    repetition: { type: Number, required: [true, 'Repetition amount is required.'] },
    day: { type: Date, required: [true, 'Date is required.'] },
    user: { type: String, required: [true, 'User information is required.'] }
}, collectionName)


module.exports = actionsSchema;