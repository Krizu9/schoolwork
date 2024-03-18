const actionsSchema = require('../models/actionsSchema');

const getActions = async (req, res) => {
    try {
        const actions = await actionsSchema.find();
        res.send(actions);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const createAction = async (req, res) => {
    try {
        const { action, repetition, day, user } = req.body;
        const newAction = { action, repetition, day, user };
        const createdAction = await actionsSchema.create(newAction);
        res.status(201).json(createdAction);
    } catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const updateAction = async (req, res) => {
    try {
        const { id } = req.params;
        const updated = await actionsSchema.findByIdAndUpdate(id, req.body, { new: true });
        res.status(200).json(updated);
    }
    catch (error) {
        res.status(500).json({ error: error.message });
    }
}

const deleteAction = async (req, res) => {
    try {
        const { id } = req.params;
        const deleted = await actionsSchema.findByIdAndDelete(id);
        res.status(200).json(deleted);
    }
    catch (error) {
        res.status(500).json({ error: error.message });
    }
}

module.exports = { getActions, createAction, updateAction, deleteAction }
