function displayErrors(errors) {
    document.querySelectorAll('.field-error').forEach(el => el.textContent = '');
    document.querySelectorAll('.error-input').forEach(el => el.classList.remove('error-input'));
    
    for (const [field, message] of Object.entries(errors)) {
        const errorSpan = document.getElementById(`${field}Error`);
        if (errorSpan) {
            errorSpan.textContent = message;
        }
        
        const input = document.querySelector(`[name="${field}"]`);
        if (input) {
            input.classList.add('error-input');
        }
    }
}

function showError(message) {
    const container = document.getElementById('errorContainer');
    container.textContent = message;
    container.style.display = 'block';
    setTimeout(() => {
        container.style.display = 'none';
    }, 5000);
}

async function submitPlayer(event) {
    if (event) event.preventDefault();

    let formData = {
        id: parseInt(document.getElementById('playerId').value),
        name: document.getElementById('name').value,
        height: parseInt(document.getElementById('height').value),
        jersey_number: parseInt(document.getElementById('jersey_number').value),
        team_id: parseInt(document.getElementById('team_id').value),
        type: parseInt(document.getElementById('type').value),
        games_played: parseInt(document.getElementById('games_played').value)
    };

    if (formData.type == 1) {
        const centerData = {
            center: {
                id: parseInt(document.getElementById('playerId').value),
                blocks: parseInt(document.getElementById('blocks').value),
                rebounds: parseInt(document.getElementById('rebounds').value),
            }
        };
        formData = { ...formData, ...centerData };
    } else if (formData.type == 0) {
        const pointGuardData = {
            point_guard: {
                id: parseInt(document.getElementById('playerId').value),
                assists: parseInt(document.getElementById('assists').value),
                three_point_makes: parseInt(document.getElementById('three_point_makes').value),
            }
        };
        formData = { ...formData, ...pointGuardData };
    }

    console.log("Submitting player data:", formData);

    try {
        const response = await fetch('/api/players', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        });
        if (response.ok) {
            window.location.href = "/home"
        } else if (response.status == 400 || response.status == 409) {
            const errorResponse = await response.json();
            if (errorResponse.errors) {
                displayErrors(errorResponse.errors);
                showError('Пожалуйста, исправьте ошибки в форме');
            } else {
                displayErrors(errorResponse);
            }
        } else {
            try {
                const errorResponse = await response.json();
                showError("Ошибка " + response.status + ": " + errorResponse.message);
            } catch (e) {
                showError("Ошибка сервера: " + response.status);
            }
        }
    } catch (error) {
        showError('Ошибка сети: ' + error.message);
    }
}

function toggleFields() {
    const type = parseInt(document.getElementById('type').value);
    const centerBlock = document.getElementById('centerFields');
    const pgBlock = document.getElementById('pgFields');

    if (type == 1) {
        centerBlock.style.display = 'block';
        pgBlock.style.display = 'none';
    } else if (type == 0) {
        centerBlock.style.display = 'none';
        pgBlock.style.display = 'block';
    }
}

document.addEventListener('DOMContentLoaded', toggleFields);
document.getElementById("playerForm").addEventListener('submit', submitPlayer);