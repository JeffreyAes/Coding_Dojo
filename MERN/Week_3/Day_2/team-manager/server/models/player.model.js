const mongoose = require('mongoose');
const PlayerSchema = new mongoose.Schema({
    name: { type: String,
        required: [
            true,
            "Name is required"
        ],
        minlength: [
            2,
            "Name must be 2 characters or more."
        ]
    },
    position: { type: String }
}, { timestamps: true });
module.exports.Player = mongoose.model('Player', PlayerSchema);