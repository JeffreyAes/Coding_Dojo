const PlayerController = require('../controllers/player.controller');
module.exports = function (app) {
    app.get('/api', PlayerController.index);
    app.post('/api/players', PlayerController.createPlayer);
    app.get('/api/players', PlayerController.getAllPlayers);
    app.get('/api/players/:id', PlayerController.getPlayer);
    app.put('/api/players/:id', PlayerController.updatePlayer);
    app.delete('/api/delete/:id', PlayerController.deletePlayer);
    


}