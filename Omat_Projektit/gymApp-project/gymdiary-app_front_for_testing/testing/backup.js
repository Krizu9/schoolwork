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
                displayWorkouts(getWorkouts());
            }
        })
        .catch(error => {
            console.error(error);
            alert("An error occurred during workout submission");
        });

}

async function getWorkouts() {
    const token = sessionStorage.getItem('gymappToken');

    return await fetch("http://localhost:5001/actions", {
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
            return data;
        })

}

async function displayWorkouts() {
    const data = await getWorkouts();
    console.log(data);
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