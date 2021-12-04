'use strict'

module.exports = class ModelMN {
    constructor(Model, model) {
        this.Model = Model;
        this.model = model;

        this.isSaving = false;
        this.isContinueSave = false;
    }

    Save() {
        if (this.isSaving) {
            this.isContinueSave = true;
        } else {
            this.isSaving = true;
            let currModel = this;
            this.Model.updateOne({ _id: this.model._id }, this.model, function (err, result) {
                if (err) {
                    console.log('error Save model MN', err)
                    return;
                }

                if (result.n == 0) {
                    currModel.model.save(function (err) {
                        if (!err) {
                            currModel.FinishSave();
                        }
                    })
                } else {
                    currModel.FinishSave();
                }

            })

        }
    }

    Update(data){
        if(this.isSaving){
            this.isContinueSave = true;
        } else {
            this.isSaving = true;
            let currModel = this;
            this.Model.updateOne({_id: this.model._id}, data, function(err, result){
                if(err){
                    console.log('err Update model MN', err);
                    return;
                }

                if(result.n == 0){
                    currModel.model.save(function (err) {
                        if (!err) {
                            currModel.FinishSave();
                        }
                    })
                } else {
                    currModel.FinishSave();
                }
            })
        }
    }

    FinishSave() {
        this.isSaving = false;
        if (this.isContinueSave)
            this.ContinueSave()
    }

    ContinueSave() {
        this.isContinueSave = false;
        this.Save();
    }
}