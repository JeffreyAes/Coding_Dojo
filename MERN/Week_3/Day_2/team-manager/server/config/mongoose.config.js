const mongoose = require('mongoose');
mongoose.connect("mongodb://0.0.0.0:27017/playermanagerdb", {
    useNewUrlParser: true,
    useUnifiedTopology: true,
})
    .then(() => console.log("Established a connection to the database"))
    .catch(err => console.log("Something went wrong when connecting to the database", err));