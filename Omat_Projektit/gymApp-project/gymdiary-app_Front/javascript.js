function showLoginForm() {
    document.getElementById('loginForm').style.display = 'block';
    document.getElementById('registerForm').style.display = 'none';
    document.getElementById('loginSubmitButton').style.display = 'block';
    document.getElementById('registerSubmitButton').style.display = 'none';
}

function showRegisterForm() {
    document.getElementById('registerForm').style.display = 'block';
    document.getElementById('loginForm').style.display = 'none';
    document.getElementById('registerSubmitButton').style.display = 'block';
    document.getElementById('loginSubmitButton').style.display = 'none';
}

function showError() {
    document.getElementById('loginForm').style.display = 'none';
}

async function getToken() {
    const name = document.getElementById('name').value;
    const password = document.getElementById('password').value;

    await fetch("http://localhost:5001/login", {
        method: 'POST',
        referrerPolicy: "strict-origin-when-cross-origin",
        headers: { 'Content-Type': 'application/json' },
        accessControlAllowOrigin: "*",
        origin: "http://localhost:5001",
        body: JSON.stringify({
            name: name,
            password: password
        })
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            userData = data.token + "," + data.user
            sessionStorage.setItem('gymappToken', userData);
            toFrontPage();
        });

}


async function toFrontPage() {
    const token = sessionStorage.getItem('gymappToken');
    if (token) {
        console.log(token);
        login(token);
    } else {
        alert("You are not logged in, please log in");
    }
}

async function login(tokenVariable) {
    const token = tokenVariable;

    await fetch("http://localhost:5001/checkToken", {
        method: 'POST',
        referrerPolicy: "strict-origin-when-cross-origin",
        headers: { 'Content-Type': 'application/json' },
        accessControlAllowOrigin: "*",
        origin: "http://localhost:5001",
        body: JSON.stringify({
            token: token
        })
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            redirectToHome(data);
        });
}

redirectToHome = async function (user) {
    if (user && user.access && user.access.name) {
        window.location.href = `dashboard.html?name=${encodeURIComponent(user.access.name)}`;

    } else {
        alert("You are not logged in, please log in");
    }
}



/*loaduserdata = function () {
    const token = sessionStorage.getItem('gymappToken');

    fetch("http://localhost:5001/userdata", {
        method: 'GET',
        referrerPolicy: "strict-origin-when-cross-origin",
        headers: { 'Content-Type': 'application/json' },
        accessControlAllowOrigin: "*",
        origin: "http://localhost:5001"
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            console.log(data);
            document.getElementById('username').innerHTML = data.name;
            document.getElementById('email').innerHTML = data.email;
        });
}
*/



async function register() {
    const username = document.getElementById('regname').value;
    const password = document.getElementById('regpassword').value;
    const email = document.getElementById('regemail').value;
    const confirmPassword = document.getElementById('regconfirmpassword').value;
    const answer = document.getElementById('question').value;

    if (answer !== "valkoinen") {
        alert("Wrong answer, are you a bot?");
        return;
    }

    if (password !== confirmPassword) {
        alert("Passwords do not match");
        return;
    }
    if (username === "" || password === "" || email === "" || confirmPassword === "") {
        alert("Please fill in all fields");
        return;
    }
    if (!email.includes("@")) {
        alert("Invalid email address");
        return;
    }



    await fetch("http://localhost:5001/register", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: username,
            email: email,
            password: password,
            passwordConfirmation: confirmPassword
        })
    })
        .then(response => {
            if (response.ok) {
                alert("Registration successful");
            }
        })
        .catch(error => {
            console.error(error);
            alert("An error occurred during registration");
        });

}

function logout() {
    sessionStorage.removeItem('gymappToken');
    window.location.href = "index.html";
}



