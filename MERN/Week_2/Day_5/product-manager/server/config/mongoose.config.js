const mongoose = require('mongoose');

mongoose.connect('mongodb://0.0.0.0:27017/productdb', {
    useNewUrlParser: true,
    useUnifiedTopology: true
})
    .then(() =>console.log("Database connection established epic style!"))
    .catch(err=>console.log("There was an error", err))