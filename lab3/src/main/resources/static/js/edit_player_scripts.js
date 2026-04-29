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

    const formData = {
        id: parseInt(document.getElementById('playerId').value),
        type: document.getElementById('playerType').value,
        name: document.getElementById('name').value,
        height: parseInt(document.getElementById('height').value),
        jersey_number: parseInt(document.getElementById('jerseyNumber').value),
        team_id: parseInt(document.getElementById('teamId').value)
    }

    try {
        const response = await fetch(`/api/players`, {
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
            showError("Ошибка: " + response.status + " " + response.message);
        }
    } catch (error) {
        showError('Ошибка сети: ' + error.message);
    }
}

document.getElementById("playerForm").addEventListener('submit', submitPlayer);