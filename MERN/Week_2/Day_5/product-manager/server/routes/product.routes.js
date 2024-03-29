const ProductController = require('../controllers/product.controller')

module.exports = function(app) {
    app.get('/api', ProductController.index);
    app.get('/api/products', ProductController.getAllProducts)
    app.post('/api/products/new', ProductController.createProduct)
    app.get('/api/products/:id', ProductController.getProduct);
    app.put('/api/products/:id', ProductController.updateProduct)
    app.delete('/api/delete/:id', ProductController.deleteProduct);
}