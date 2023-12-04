import { initializeApp } from 'firebase/app';
import { getAuth } from "firebase/auth";

const firebaseConfig = {
    apiKey: "AIzaSyDQfgE5GTpC9OyVT80qLYLQMGVogZzeuUk",
    authDomain: "todo-afd4c.firebaseapp.com",
    projectId: "todo-afd4c",
    storageBucket: "todo-afd4c.appspot.com",
    messagingSenderId: "887200749366",
    appId: "1:887200749366:web:7abbe804641be4aee50597",
    measurementId: "G-03JYYD7C1J"
};

const app = initializeApp(firebaseConfig);

export const auth = getAuth(app);