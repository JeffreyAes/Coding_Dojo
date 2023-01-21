const { json } = require('express');
const Joke = require('../models/jokes.model');

module.exports.findAllJokes = (req, res) => {
    Joke.find()
        .then((allDaJokes) => {
            res.json({ jokes: allDaJokes })
        })
        .catch((err) => {
            res, json({ message: "Something went wrong!", error: err })
        });
}

module.exports.findOneSingleJoke = (req, res) => {
    Joke.findOne({ _id: req.params.id })
        .then(oneSingleJoke => {
            res.json({ user: oneSingleJoke })
        })
        .catch((err) => {
            res.json({ message: "Joke was so unfunny it wouldn't render", error: err })
        });
}

module.exports.randomJoke = (req, res) => {
    Joke.aggregate().sample(1)
        .then(oneJoke => {
            res.json({ joke: oneJoke })
        })
        .catch((err) => {
            res.json({ message: 'Something went wrong', error: err })
        })
}

module.exports.createNewJoke = (req, res) => {
    Joke.create(req.body)
        .then(newlyCreatedJoke => {
            res.json({ user: newlyCreatedJoke })
        })
        .catch((err) => {
            res.json({ message: "Get better material...", error: err })
        });
}

module.exports.updateExistingJoke = (req, res) => {
    Joke.findOneAndUpdate(
        { _id: req.params.id },
        req.body,
        { new: true, runValidators: true }
    )
        .then(updatedJoke => {
            res.json({ joke: updatedJoke })
        })
        .catch((err) => {
            res.json({ message: "I liked it better the old way :/", error: err })
        });
}

module.exports.deleteAnExistingJoke = (req, res) => {
    Joke.deleteOne({ _id: req.params.id })
        .then(result => {
            res.json({ result: result })
        })
        .catch((err) => {
            res.json({ message: "Something went wrong", error: err })
        });
}