// async function showTeamPlayers(teamId, teamName) {
//     // Устанавливаем название команды в заголовок модального окна
//     document.getElementById('teamName').textContent = teamName;
    
//     // Показываем модальное окно
//     const modal = document.getElementById('teamPlayersModal');
//     modal.style.display = 'block';
    
//     // Загружаем игроков команды
//     const playersListDiv = document.getElementById('teamPlayersList');
//     playersListDiv.innerHTML = '<p>Загрузка...</p>';
    
//     try {
//         const response = await fetch(`/api/teams/${teamId}/players`);
        
//         if (response.ok) {
//             const players = await response.json();
//             displayTeamPlayers(players);
//         } else {
//             playersListDiv.innerHTML = '<p style="color: red;">Ошибка при загрузке игроков</p>';
//         }
//     } catch (error) {
//         playersListDiv.innerHTML = '<p style="color: red;">Ошибка соединения</p>';
//     }
// }

// // Функция отображения игроков команды
// function displayTeamPlayers(players) {
//     const playersListDiv = document.getElementById('teamPlayersList');
    
//     if (!players || players.length === 0) {
//         playersListDiv.innerHTML = '<p>В этой команде нет игроков</p>';
//         return;
//     }
    
//     let html = '<table class="team-players-table">';
//     html += '<thead>';
//     html += '<tr>';
//     html += '<th>ID</th>';
//     html += '<th>Имя</th>';
//     html += '<th>Рост (см)</th>';
//     html += '<th>Номер</th>';
//     html += '<th>Тип</th>';
//     html += '<th>Действия</th>';
//     html += '</tr>';
//     html += '</thead>';
//     html += '<tbody>';
    
//     players.forEach(player => {
//         html += '<tr>';
//         html += `<td>${player.id}</td>`;
//         html += `<td>${player.name}</td>`;
//         html += `<td>${player.height}</td>`;
//         html += `<td>${player.jerseyNumber}</td>`;
//         html += `<td>${player.type}</td>`;
//         html += `<td>
//                     <button class="modal-action-btn" onclick="closeModalAndRedirectToPlayerMethods(${player.id})">Методы</button>
//                     <button class="modal-action-btn" onclick="closeModalAndRedirectToUpdatePlayer(${player.id})">Редактировать</button>
//                 </td>`;
//         html += '</tr>';
//     });
    
//     html += '</tbody>';
//     html += '</table>';
    
//     playersListDiv.innerHTML = html;
// }

// async function deleteSelectedPlayer(id) {
//     if (confirm("Вы уверены, что хотите удалить игрока с ID " + id + "?")) {
//         const response = await fetch(`/api/players/${id}`, {
//             method: 'DELETE'
//         });
        
//         if (response.ok) {
//             location.reload();
//         } else {
//             const error = await response.json();
//             alert(error.message || "Ошибка при удалении игрока");
//         }
//     }
// }

// async function deleteSelectedTeam(id) {
//     if (confirm("Вы уверены, что хотите удалить команду с ID " + id + "?")) {
//         const response = await fetch(`/api/teams/${id}`, {
//             method: 'DELETE'
//         });

//         if (response.ok) {
//             location.reload();
//         } else {
//             const error = await response.json();
//             alert(error.message || "Ошибка при удалении игрока");
//         }
//     }
// }

// function redirectToCreatePlayerForm() {
//     window.location.href = "/create/player";
// }

// function redirectToUpdatePlayerForm(id) {
//     window.location.href = `/edit/player/${id}`;
// }

// function redirectToPlayerMethods(id) {
//     window.location.href = `/methods/player/${id}`
// }

// function redirectToCreateTeamForm() {
//     window.location.href = "/create/team";
// }

// function redirectToUpdateTeamForm(id) {
//     window.location.href = `/edit/team/${id}`;
// }


// Ждем загрузки DOM перед привязкой обработчиков
document.addEventListener('DOMContentLoaded', function() {
    
    // Обработчики для кнопок команд
    document.querySelectorAll('.show-players-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const teamId = btn.getAttribute('data-id');
            const teamName = btn.getAttribute('data-name');
            showTeamPlayers(teamId, teamName);
        });
    });
    
    document.querySelectorAll('.edit-team-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const teamId = btn.getAttribute('data-id');
            redirectToUpdateTeamForm(teamId);
        });
    });
    
    document.querySelectorAll('.delete-team-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const teamId = btn.getAttribute('data-id');
            deleteSelectedTeam(teamId);
        });
    });
    
    // Обработчики для кнопок игроков
    document.querySelectorAll('.player-methods-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const playerId = btn.getAttribute('data-id');
            redirectToPlayerMethods(playerId);
        });
    });
    
    document.querySelectorAll('.edit-player-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const playerId = btn.getAttribute('data-id');
            redirectToUpdatePlayerForm(playerId);
        });
    });
    
    document.querySelectorAll('.delete-player-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const playerId = btn.getAttribute('data-id');
            deleteSelectedPlayer(playerId);
        });
    });
});

// Остальные функции (без изменений или с небольшими правками)

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
            alert(error.message || "Ошибка при удалении команды");
        }
    }
}

async function showTeamPlayers(teamId, teamName) {
    document.getElementById('teamName').textContent = teamName;
    
    const modal = document.getElementById('teamPlayersModal');
    modal.style.display = 'block';
    
    const playersListDiv = document.getElementById('teamPlayersList');
    playersListDiv.innerHTML = '<p>Загрузка...</p>';
    
    try {
        const response = await fetch(`/api/teams/${teamId}/players`);
        
        if (response.ok) {
            const players = await response.json();
            displayTeamPlayers(players);
        } else {
            playersListDiv.innerHTML = '<p style="color: red;">Ошибка при загрузке игроков</p>';
        }
    } catch (error) {
        playersListDiv.innerHTML = '<p style="color: red;">Ошибка соединения</p>';
    }
}

function displayTeamPlayers(players) {
    const playersListDiv = document.getElementById('teamPlayersList');
    
    if (!players || players.length === 0) {
        playersListDiv.innerHTML = '<p>В этой команде нет игроков</p>';
        return;
    }
    
    let html = '<table class="team-players-table">';
    html += '<thead>';
    html += '<tr>';
    html += '<th>ID</th>';
    html += '<th>Имя</th>';
    html += '<th>Рост (см)</th>';
    html += '<th>Номер</th>';
    html += '<th>Тип</th>';
    html += '<th>Действия</th>';
    html += '</tr>';
    html += '</thead>';
    html += '<tbody>';
    
    players.forEach(player => {
        html += '<tr>';
        html += `<td>${player.id}</td>`;
        html += `<td>${player.name}</td>`;
        html += `<td>${player.height}</td>`;
        html += `<td>${player.jersey_number}</td>`;
        html += `<td>${player.type}</td>`;
        html += `<td>
                    <button class="modal-action-btn" onclick="closeModalAndRedirectToPlayerMethods(${player.id})">Методы</button>
                    <button class="modal-action-btn" onclick="closeModalAndRedirectToUpdatePlayer(${player.id})">Редактировать</button>
                    <button class="modal-action-btn" onclick="deleteSelectedPlayer(${player.id})">Удалить</button>
                </td>`;
        html += '</tr>';
    });
    
    html += '</tbody>';
    html += '</table>';
    
    playersListDiv.innerHTML = html;
}

function closeModal() {
    const modal = document.getElementById('teamPlayersModal');
    modal.style.display = 'none';
}

function closeModalAndRedirectToPlayerMethods(playerId) {
    closeModal();
    window.location.href = `/methods/player/${playerId}`;
}

function closeModalAndRedirectToUpdatePlayer(playerId) {
    closeModal();
    window.location.href = `/edit/player/${playerId}`;
}

window.onclick = function(event) {
    const modal = document.getElementById('teamPlayersModal');
    if (event.target === modal) {
        closeModal();
    }
}

function redirectToCreatePlayerForm() {
    window.location.href = "/create/player";
}

function redirectToUpdatePlayerForm(id) {
    window.location.href = `/edit/player/${id}`;
}

function redirectToPlayerMethods(id) {
    window.location.href = `/methods/player/${id}`;
}

function redirectToCreateTeamForm() {
    window.location.href = "/create/team";
}

function redirectToUpdateTeamForm(id) {
    window.location.href = `/edit/team/${id}`;
}