require('dotenv').config();
const mongoose = require('mongoose');

const url = process.env.MONGODB_URI;
const databaseName = "removedsensitiveinfo"
const collectionName = "removedsensitiveinfo"


mongoose.connect(url, { dbName: databaseName, });

const personSchema = new mongoose.Schema({
    firstname: String,
    lastname: String
}, { collection: collectionName });


const Person = mongoose.model('Person', personSchema, collectionName);

async function addName(firstname, lastname) {
    try {
        const person = new Person({
            firstname,
            lastname
        });

        result = await person.save();
        console.log(`Inserted ${result.firstname} ${result.lastname} into the collection`);
    } catch (error) {
        console.log(error);
    } finally {
        mongoose.disconnect();
    }
}

async function getNames() {
    try {
        const names = await Person.find();

        console.log("List of names:");
        names.forEach((name) => {
            console.log(`${name.firstname} ${name.lastname}`);
        });
    } catch (error) {
        console.log(error);
    } finally {
        mongoose.disconnect();
    }
}
const [, , ...args] = process.argv;

if (args.length === 2) {
    const [firstName, lastName] = args;
    addName(firstName, lastName);
} else if (args.length === 0) {
    getNames();
} else {
    console.error("Try again with -node mongodb_names.js firstname lastname-");
}