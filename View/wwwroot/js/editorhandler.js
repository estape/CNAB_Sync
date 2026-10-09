let currentClientIndex = -1;

// Theme switching logic (matches index.html)
function setTheme(theme) {
    document.getElementById('theme-style').href = theme === 'dark'
        ? 'css/dark/styles.css'
        : 'css/light/styles.css';
}

// Request initial data when window loads
setTimeout(() => {
    window.external.sendMessage("get_initial_theme");
    window.external.sendMessage("get_editor_data");
}, 100);

// Receive data from C#
window.external.receiveMessage(message => {
    if (message.startsWith("SWITCH_THEME_DARK")) {
        setTheme('dark');
    } else if (message.startsWith("SWITCH_THEME_LIGHT")) {
        setTheme('light');
    } else if (message.startsWith("LOAD_CLIENT_DATA:")) {
        const data = JSON.parse(message.substring(17));
        currentClientIndex = data.index;
        populateForm(data.client);
    }
});