async function executeMethod(playerId, methodName) {
    const terminal = document.getElementById('terminal');
    
    const cmdEntry = document.createElement('div');
    cmdEntry.className = 'command-line';
    cmdEntry.textContent = `>Executing player.${methodName}()...`;
    terminal.appendChild(cmdEntry);

    try {
        const response = await fetch(`/api/players/${playerId}/methods/${methodName}`);
        const text = await response.text();

        const resEntry = document.createElement('div');
        resEntry.className = 'response-line';
        resEntry.textContent = text;
        terminal.appendChild(resEntry);
    } catch (error) {
        const errEntry = document.createElement('div');
        errEntry.style.color = 'red';
        errEntry.textContent = "Ошибка связи с сервером.";
        terminal.appendChild(errEntry);
    }

    terminal.scrollTop = terminal.scrollHeight;
}

function clearTerminal() {
    document.getElementById('terminal').innerHTML = '<div class="response-line">Терминал очищен.</div>';
}