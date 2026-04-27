async function deleteSelectedPlayer(id) {
    if (confirm("Вы уверены, что хотите удалить игрока с ID " + id + "?")) {
        const response = await fetch(`/api/players/${id}`, {
            method: 'DELETE'
        });
        
        if (response.ok) {
            location.reload();
        } else {
            const error = await response.json();
            alert(error.message || "Ошибка при удалении игрока");
        }
    }
}

async function deleteSelectedTeam(id) {
    if (confirm("Вы уверены, что хотите удалить команду с ID " + id + "?")) {
        const response = await fetch(`/api/teams/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            location.reload();
        } else {
            const error = await response.json();
            alert(error.message || "Ошибка при удалении игрока");
        }
    }
}

function redirectToCreatePlayerForm() {
    window.location.href = "/create/player";
}

function redirectToUpdatePlayerForm(id) {
    window.location.href = `/edit/player/${id}`;
}

function redirectToPlayerMethods(id) {
    window.location.href = `/methods/player/${id}`
}

function redirectToCreateTeamForm() {
    window.location.href = "/create/team";
}

function redirectToUpdateTeamForm(id) {
    window.location.href = `/edit/team/${id}`;
}