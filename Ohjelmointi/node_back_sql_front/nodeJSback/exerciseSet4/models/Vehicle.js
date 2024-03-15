const mongoose = require('mongoose')

const vehicleSchema = new mongoose.Schema({
  make: {
    type: String,
    required: true,
    maxLength: 10,
  },
  model: String,
  type: {
    type: String,
    required: true
  },
  license_plate: {
    type: String,
    required: [true, 'Lisence plate is required, and should be constructed like this: ABC-123'],
    validate: {
      validator: validatePlate,
      message: 'Lisence plate should be constructed like this: ABC-123',
    }
  }
})

vehicleSchema.pre('save', async function (next) {
  try {
    const existingVehicle = await this.constructor.findOne({ license_plate: this.license_plate })
    if (existingVehicle) {
      const error = new Error('License plate already exists in the database.')
      throw error
    }
    next()
  } catch (error) {
    next(error)
  }
})

function validatePlate(plate) {
  const regex = /^[A-Z]{3}-[0-9]{3}$/
  return regex.test(plate)
}

module.exports = mongoose.model('Vehicle', vehicleSchema)
