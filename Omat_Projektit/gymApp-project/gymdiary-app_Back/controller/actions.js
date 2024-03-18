const { Workouts } = require('../models/actionsSchema');

require('dotenv').config();

const getActions = async (req, res) => {
    let token = req.headers.authorization;

    try {
        if (!token) {
            return res.status(401).json({ error: 'No token delivered' });
        }

        if (token.startsWith('Bearer ')) {
            // Remove 'Bearer ' from token string
            token = token.slice(7);
        }

        const [tokenPart, userId] = token.split(',');

        const workouts = await Workouts.find({ user: userId });
        res.send(workouts);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const createAction = async (req, res) => {
    try {
        const { token, workout } = req.body;
        console.log(workout)
        const [tokenPart, userId] = token.split(',');
        const action = workout.exerciseName;
        const sets = workout.sets;
        const day = workout.date;
        const workoutToDB = new Workouts({ action: action, sets: sets, day: day, user: userId });
        console.log("asd")
        await workoutToDB.save();
        console.log("pääsee tänne")
        res.status(200).json({ success: true });
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const updateAction = async (req, res) => {
    try {
        const { id } = req.params;
        const updated = await Workouts.findByIdAndUpdate(id, req.body, { new: true });
        res.status(200).json(updated);
    }
    catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const deleteAction = async (req, res) => {
    try {
        console.log("pääsee tänne")
        const { id } = req.params;
        console.log(id)
        console.log(req.params)
        const deleted = await Workouts.findByIdAndDelete(id);
        res.status(200).json(deleted);
    }
    catch (error) {
        res.status(500).json({ error: error.message });
    }
}

module.exports = { getActions, createAction, updateAction, deleteAction }
