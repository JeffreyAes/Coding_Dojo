const express = require("express");
const app = express();
const port = 8000;
const { faker } = require('@faker-js/faker');
const createProduct = () => {
    const newFake = {
        name: faker.commerce.productName(),
        price: "$" + faker.commerce.price(),
        department: faker.commerce.department()
    };
    return newFake;
};
const newFakeProduct = createProduct();
console.log(newFakeProduct);

const CreateUser = () => {
    const newUser = {
        password: faker.internet.password(),
        email: faker.internet.email(),
        phoneNumber: faker.phone.number(),
        firstName: faker.name.firstName(),
        lastName: faker.name.lastName(),
        _id: faker.datatype.uuid()
    };
    return newUser;
};
const newFakeUser = CreateUser();

const CreateCompany = () => {
    const street = faker.address.street()
    const city = faker.address.city()
    const state = faker.address.state()
    const zipCode = faker.address.zipCode()
    const country = faker.address.country()
    const newCompany = {
        _id: faker.datatype.uuid(),
        name: faker.company.companyName(),
        address: faker.helpers.arrayElement([{street, city, state, zipCode, country}])
    };
    return newCompany
}
const newFakeCompany = CreateCompany();


// req is short for request
// res is short for response
app.get("/api/createProduct", (req, res) => {
    res.json({ newFakeProduct });
});

app.get("/api/users/new", (req, res) => {
    res.json({ newFakeUser });
});
app.get("/api/companies/new", (req, res) => {
    res.json({ newFakeCompany });
});
app.get("/api/user/company", (req, res) => {
    res.json({ newFakeUser, newFakeCompany });
});

// this needs to be below the other code blocks
app.listen(port, () => console.log(`Listening on port: ${port}`));
