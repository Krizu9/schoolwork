import { initializeApp } from 'firebase/app';
import { getAuth } from "firebase/auth";

const firebaseConfig = {
    apiKey: "shouldhaveapikeyhere",
    authDomain: "authdomainkey",
    projectId: "myprojectid",
    storageBucket: "storagebucketkey",
    messagingSenderId: "messagingsenderidkey",
    appId: "appidkey",
    measurementId: "measurementid"
};

const app = initializeApp(firebaseConfig);

export const auth = getAuth(app);