import {
    getFirestore,
    collection,
    getDocs,
    addDoc,
    deleteDoc,
    doc
} from 'firebase/firestore/lite';
import { initializeApp } from "firebase/app";
import "../App.css"
import { useNavigate } from "react-router-dom";
import React, { useState, useEffect } from 'react';
import { getAuth, signOut } from "firebase/auth";



export default function ToDo() {

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
    const db = getFirestore(app);
    const auth = getAuth();
    const navigate = useNavigate();

    if (auth.currentUser === null) {
        return <h1>Not authorized</h1>
    }

    function Banner() {
        return (
            <h1>Todo Example with React</h1>
        );
    }

    function ToDoFormAndList() {

        const [itemText, setItemText] = useState('');
        const [items, setItems] = useState([]);

        const [loading, setLoading] = useState(true);

        // load todo list items
        useEffect(() => {
            const fetchData = async () => {
                const todosCol = collection(db, 'todos');
                const todoSnapshot = await getDocs(todosCol);

                const todos = todoSnapshot.docs.map(doc => {
                    return {
                        text: doc.data().text,
                        id: doc.id
                    };
                });
                console.log(todos);
                setItems(todos);
                setLoading(false);
            }
            console.log("fetch data...")
            fetchData();
        }, []);

        const handleSubmit = async (event) => {
            event.preventDefault();
            let newItem = { text: itemText };
            const docRef = await addDoc(collection(db, "todos"), newItem);
            newItem.id = docRef.id;
            setItems([...items, newItem]);
            setItemText("")
            console.log(auth.currentUser)
        }

        const handleLogout = async () => {
            try {
                await signOut(auth);
                navigate("/")


            } catch (error) {
                console.log("Logout error: ", error.message);
            }
        }


        const removeItem = (item) => {
            deleteDoc(doc(db, "todos", item.id));
            let filteredArray = items.filter(collectionItem => collectionItem.id !== item.id);
            setItems(filteredArray);
        }

        return (
            <div>
                <Banner />
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        value={itemText}
                        onChange={(event) => setItemText(event.target.value)}
                        placeholder="Write a new todo here"
                    />
                    <input type="submit" value="Add" />
                </form>
                <button onClick={handleLogout}>Logout</button>
                <ul>
                    {loading && <p>Loading...</p>}
                    {items.map((item) => (
                        <li key={item.id}>
                            {item.text + " "} <span onClick={() => removeItem(item)}> x </span>
                        </li>
                    ))}
                </ul>
            </div>
        );
    }
    return (
        <div>
            <ToDoFormAndList />
        </div>
    )
}

