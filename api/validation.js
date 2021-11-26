//VALIDATION
const Joi = require('@hapi/joi');


//Register Validation
const RegisterValidation = data => {
    const schema = Joi.object({
        name: Joi.string()
            .required()
            .min(6)
            .max(50),
        username: Joi.string()
            .required()
            .max(20),
        password: Joi.string()
            .required()
            .min(6)
            .max(50),
        GioiTinh: Joi.boolean()
            .default(true),
        email:  Joi.string()
            .required()
            .min(6)
            .max(50),
        SDT: Joi.string()
            .required()
            .max(50),
        DiaChi: Joi.string()
            .required()
            .max(50),
        Role: Joi.string()
            .required()
            .max(10),
        img: Joi.string()
    });
    return schema.validate(data);
}

//Login Validation
const LoginValidation = data => {
    const schema = Joi.object({
        email: Joi.string()
            .min(6)
            .email(),
        username: Joi.string()
            .min(1),
        password: Joi.string()
            .min(6)
            .required()
    });
    return schema.validate(data);
}

//Product Validation
const ProductValidation = data => {
    const schema = Joi.object({
        TenSP: Joi.string()
            .required()
            .max(100),
        Gia: Joi.number()
            .required(),
        Soluong: Joi.number()
            .required(),
        IdLoai: Joi.string()
            .required(),
        img: Joi.string()
    });
    return schema.validate(data);
}

//CTDDH Validation
const CTDDHValidation = data => {
    const schema = Joi.object({
        IdDDH: Joi.string()
            .required(),
        IdSP: Joi.string()
            .required(),
        Soluong: Joi.number()
            .required(),
        DonGia: Joi.number()
            .required()
    });
    return schema.validate(data);
}

//DDH Validation
const DDHValidation = data => {
    const schema = Joi.object({
        UserId: Joi.string()
            .required(),
        TT: Joi.string()
            .required()
    });
    return schema.validate(data);
}

//LoaiSP Validation
const LoaiSPValidation = data => {
    const schema = Joi.object({
        TenLoai: Joi.string()
        .required()
    });
    return schema.validate(data);
}

module.exports.RegisterValidation = RegisterValidation;
module.exports.LoginValidation = LoginValidation;
module.exports.ProductValidation = ProductValidation;
module.exports.CTDDHValidation = CTDDHValidation;
module.exports.DDHValidation = DDHValidation;
module.exports.LoaiSPValidation = LoaiSPValidation;