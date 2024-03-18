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

document.addEventListener('DOMContentLoaded', function () {
    const addBtn = document.querySelector('#addExercise .add');
    const input = document.querySelector('#addExercise .input-group');

    const today = new Date();

    const formattedDate = today.toISOString().substr(0, 10)
    document.getElementById('date').value = formattedDate;

    function addInput() {
        const currentSet = input.querySelectorAll('.flex').length + 1;

        const set = document.createElement('input');
        set.type = "text";
        set.id = `set${currentSet}`; // Unique ID for set input
        set.value = "Set: " + currentSet;
        set.min = 1;

        const rep = document.createElement('input');
        rep.type = "number";
        rep.id = `rep${currentSet}`; // Unique ID for rep input
        rep.placeholder = "How many reps?";
        rep.min = 1;

        const weight = document.createElement('input');
        weight.type = "text";
        weight.id = `weight${currentSet}`; // Unique ID for weight input
        weight.placeholder = "How much weight?";
        weight.min = 1;

        const btn = document.createElement('a')
        btn.className = "remove";
        btn.innerHTML = "&times";

        const flex = document.createElement('div');
        flex.className = "flex";

        flex.appendChild(set);
        flex.appendChild(rep);
        flex.appendChild(weight);
        flex.appendChild(btn);


        input.appendChild(flex);

        btn.addEventListener('click', function () {
            input.removeChild(flex);
        });
    }

    addBtn.addEventListener('click', addInput);
});

async function submitWorkout() {
    const exerciseName = document.getElementById('exerciseName').value;
    const date = document.getElementById('date').value;

    const sets = [];
    const reps = document.querySelectorAll(".flex");
    reps.forEach((rep, index) => { // Using index to differentiate between inputs
        const set = document.getElementById(`set${index + 1}`).value;
        const repsValue = document.getElementById(`rep${index + 1}`).value;
        const weightValue = document.getElementById(`weight${index + 1}`).value;
        sets.push({ set, reps: repsValue, weight: weightValue });
    });

    const workout = {
        exerciseName,
        date,
        sets
    }
    console.log(workout);
    const token = sessionStorage.getItem('gymappToken');

    await fetch("http://localhost:5001/actions", {
        method: 'POST',
        referrerPolicy: "strict-origin-when-cross-origin",
        headers: { 'Content-Type': 'application/json' },
        accessControlAllowOrigin: "*",
        origin: "http://localhost:5001",
        body: JSON.stringify({
            token: token,
            workout: workout
        })
    })
        .then(response => {
            //alert("Workout added successfully");
        })
        .catch(error => {
            console.error(error);
            alert("An error occurred during workout submission");
        });

}

async function getWorkouts() {
    const token = sessionStorage.getItem('gymappToken');

    await fetch("http://localhost:5001/actions", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `${token}` // Include the token in the Authorization header
        }
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            console.log(data);
            const displayWorkouts = document.getElementById('workouts');
            displayWorkouts.innerHTML = "";
            data.forEach(workout => {
                const workoutCard = document.createElement('div');
                workoutCard.classList.add('workout-card');

                workoutCard.innerHTML = `
            <div class="workout-details">
                <p>Action: ${workout.action}</p>
                <p>Day: ${new Date(workout.day).toLocaleDateString()}</p>
            </div>
        `;

                if (workout.sets.length > 0) {
                    const setsList = document.createElement('ul');
                    setsList.classList.add('workout-details');
                    workout.sets.forEach((set, index) => {
                        const setItem = document.createElement('li');

                        setItem.textContent = `Set ${index + 1}: ${set.reps} reps, ${set.weight}`;
                        setsList.appendChild(setItem);
                    });
                    workoutCard.appendChild(setsList);
                } else {
                    workoutCard.innerHTML += '<p class="no-sets">No sets recorded for this workout</p>';
                }

                // Create delete button
                const deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.classList.add('delete-button'); // Add the delete-button class
                deleteButton.addEventListener('click', () => {
                    deleteWorkout(workout._id);
                });
                const editButton = document.createElement('button');
                editButton.textContent = 'Edit';
                editButton.classList.add('edit-button'); // Add the edit-button class
                editButton.addEventListener('click', () => {
                    editWorkout(workout._id);
                });

                workoutCard.appendChild(editButton);
                workoutCard.appendChild(deleteButton);

                displayWorkouts.appendChild(workoutCard);
            });
        })
        .catch(error => {
            console.error('Error fetching workouts:', error);
        });
}

async function deleteWorkout(id) {
    const token = sessionStorage.getItem('gymappToken');
    console.log(id)

    await fetch(`http://localhost:5001/actions/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `${token}`
        }
    })
        .then(response => {
            if (response.ok) {
                alert("Workout deleted successfully");
                getWorkouts();
            }
        })
        .catch(error => {
            console.error('Error deleting workout:', error);
        });
}