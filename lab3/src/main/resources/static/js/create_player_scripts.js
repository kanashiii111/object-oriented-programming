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
        name: document.getElementById('name').value,
        height: parseInt(document.getElementById('height').value),
        jersey_number: parseInt(document.getElementById('jerseyNumber').value),
        type: document.getElementById('type').value,
        team_id: parseInt(document.getElementById('teamId').value)
    };

    if (typeSelect.value === 'center') {
        const centerData = {
            center: {
                blocks: parseInt(document.getElementById('blocks').value),
                rebounds: parseInt(document.getElementById('rebounds').value),
                blocks_per_game: parseFloat(document.getElementById('blocksPerGame').value),
                rebounds_per_game: parseFloat(document.getElementById('reboundsPerGame').value),
            }
        };
        formData = { ...formData, ...centerData };
    } else if (typeSelect.value === 'point_guard') {
        const pointGuardData = {
            point_guard: {
                assists_per_game: parseFloat(document.getElementById('assistsPerGame').value),
                three_point_percentage: parseFloat(document.getElementById('threePointPercentage').value)
            }
        };
        formData = { ...formData, ...pointGuardData };
    }

    try {
        const response = await fetch('/api/players', {
            method: 'POST',
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

const typeSelect = document.getElementById('type');
const centerFields = document.querySelectorAll('.form-group-center');
const pgFields = document.querySelectorAll('.form-group-pg');

typeSelect.addEventListener('change', function() {
    const selectedValue = this.value;

    [...centerFields, ...pgFields].forEach(el => el.style.display = 'none');

    if (selectedValue === 'center') {
        centerFields.forEach(el => el.style.display = 'block');
    } else if (selectedValue === 'point_guard') {
        pgFields.forEach(el => el.style.display = 'block');
    }
});

document.getElementById("playerForm").addEventListener('submit', submitPlayer);