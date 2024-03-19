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
        redirectToHome();
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
        set.id = `set${currentSet}`;
        set.value = "Set: " + currentSet;
        set.min = 1;

        const rep = document.createElement('input');
        rep.type = "number";
        rep.id = `rep${currentSet}`;
        rep.placeholder = "How many reps?";
        rep.min = 1;

        const weight = document.createElement('input');
        weight.type = "text";
        weight.id = `weight${currentSet}`;
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
    reps.forEach((rep, index) => {
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
            if (response.ok) {
                alert("Workout submitted successfully");
                getWorkouts();
            }
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
            'Authorization': `${token}`
        }
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            displayWorkouts(data);
        })

}

function displayWorkouts(data) {
    const displayWorkouts = document.getElementById('workouts');
    displayWorkouts.innerHTML = "";
    data.forEach(workout => {
        const workoutCard = document.createElement('div');
        workoutCard.classList.add('workout-card');

        const actionElement = document.createElement('p');
        actionElement.textContent = `Action: ${workout.action}`;
        actionElement.classList.add('action');

        const dayElement = document.createElement('p');
        dayElement.textContent = `Day: ${new Date(workout.day).toLocaleDateString()}`;
        dayElement.classList.add('day');

        workoutCard.appendChild(actionElement);
        workoutCard.appendChild(dayElement);

        const setsList = document.createElement('ul');
        setsList.classList.add('sets-list');
        workout.sets.forEach((set, index) => {
            const setItem = document.createElement('li');
            setItem.textContent = `Set: ${index + 1}: ${set.reps} reps, ${set.weight}`;
            setsList.appendChild(setItem);
        });
        workoutCard.appendChild(setsList);

        const editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.classList.add('edit-button');
        editButton.addEventListener('click', () => {
            actionElement.innerHTML = `<input type="text" id="editAction" class="form-control" value="${workout.action}">`;

            const previousDate = new Date(workout.day).toISOString().split('T')[0];
            dayElement.innerHTML = `<input type="date" id="editDay" class="form-control" value="${previousDate}">`;

            setsList.innerHTML = "";

            workout.sets.forEach((set, index) => {
                const setItem = document.createElement('div');
                setItem.classList.add('set-item');
                setItem.innerHTML = `
            <span class="set-label">Set${index + 1}:</span>
            <input type="number" id="editReps${index}" class="form-control reps-input" value="${set.reps}">
            <input type="text" id="editWeight${index}" class="form-control weight-input" value="${set.weight}">
        `;
                setsList.appendChild(setItem);
            });

            const saveButton = document.createElement('button');
            saveButton.textContent = 'Save';
            saveButton.classList.add('save-button', 'btn', 'btn-primary');
            saveButton.addEventListener('click', async () => {
                const editedAction = document.getElementById('editAction').value;
                const editedDay = document.getElementById('editDay').value;
                const editedSets = [];
                workout.sets.forEach((set, index) => {
                    const editedReps = document.getElementById(`editReps${index}`).value;
                    const editedWeight = document.getElementById(`editWeight${index}`).value;
                    editedSets.push({ set: `Set: ${index + 1}`, reps: editedReps, weight: editedWeight });
                });
                const editedWorkout = {
                    exerciseName: editedAction,
                    date: editedDay,
                    sets: editedSets
                };

                actionElement.textContent = `Action: ${editedAction}`;
                dayElement.textContent = `Day: ${new Date(editedDay).toLocaleDateString()}`;

                setsList.innerHTML = "";
                editedWorkout.sets.forEach((set, index) => {
                    const setItem = document.createElement('li');
                    setItem.textContent = `${set.set}: ${set.reps} reps, ${set.weight}`;
                    setsList.appendChild(setItem);
                });
                console.log(workout._id)
                editWorkout(workout._id, editedWorkout)


                cancelButton.remove();
                saveButton.replaceWith(editButton);
            });

            const cancelButton = document.createElement('button');
            cancelButton.textContent = 'Cancel';
            cancelButton.classList.add('cancel-button', 'btn', 'btn-secondary', 'mx-2');
            cancelButton.addEventListener('click', () => {
                getWorkouts();
            });

            editButton.replaceWith(saveButton);
            saveButton.insertAdjacentElement('afterend', cancelButton);
        });

        workoutCard.appendChild(editButton);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('delete-button');
        deleteButton.addEventListener('click', () => {
            deleteWorkout(workout._id);
        });
        workoutCard.appendChild(deleteButton);

        displayWorkouts.appendChild(workoutCard);
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

async function editWorkout(id, workout) {
    const token = sessionStorage.getItem('gymappToken');

    await fetch(`http://localhost:5001/actions/${id}`, {
        method: 'PUT',
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
            if (response.ok) {
                alert("Workout submitted successfully");
                getWorkouts();
            }
        })
        .catch(error => {
            console.error(error);
            alert("An error occurred during workout submission");
        });
}