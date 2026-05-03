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