const mongooes = require('mongoose');

const boghohwaSchema = new mongooes.Schema({
   Id: {
        type: String
   },
   Boghohwa: {
        type: String
   }
});

module.exports = mongooes.model('boghohwa', boghohwaSchema);