const mongoose = require('mongoose')
// my localhost is being used up by something else, so use [0.0.0.0:27017]
mongoose.connect('mongodb://0.0.0.0:27017', {
    useNewUrlParser: true,
    useUnifiedTopology: true
})
    .then(() => console.log("Database connection established."))
    .catch(err=> console.log("There was an error", err))