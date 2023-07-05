// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



async function SendSurvey(surveyId) {

   

    var checkboxCount = 0;
    var radioCount = 0;
    var ratingCount = 0;
    var textAreaCount = 0;
    var textBoxCount = 0;
    var textAreaFlag = true;
    var textBoxFlag = true;
    var checkboxFlag = true;
    var radioFlag = true;
    var ratingFlag = true;
    var filledCheckBoxes = [];
    var filledRadios = [];
    var filledRatings = [];
    var filledTextBoxes = [];
    var filledTextAreas = [];





    while (checkboxFlag) {
        var cb = 'checkbox ' + checkboxCount;
        var cboxes = document.getElementsByName(cb);



        if (cboxes.length == 0) {
            checkboxFlag = false;
        }

        else {
            var values = [];
            var len = cboxes.length;
            for (var i = 0; i < len; i++) {
                if (cboxes[i].checked) {
                    values.push(cboxes[i].value);
                }

            }
            filledCheckBoxes.push({ "selectedOptionId": values });
        }

        checkboxCount++;
        console.log(filledCheckBoxes[0]);

    }


    while (radioFlag) {
        var radio = 'radio ' + radioCount;
        var radios = document.getElementsByName(radio);



        if (radios.length == 0) {
            radioFlag = false;
        }

        else {
            var len = radios.length;
            for (var i = 0; i < len; i++) {
                if (radios[i].checked) {
                    filledRadios.push({ "selectedOptionId": radios[i].value });
                }

            }
        }

        radioCount++;
        console.log(filledRadios);

    }


    while (ratingFlag) {
        var rating = 'rating ' + ratingCount;
        var ratings = document.getElementsByName(rating);



        if (ratings.length == 0) {
            ratingFlag = false;
        }

        else {
            var len = ratings.length;
            for (var i = 0; i < len; i++) {
                if (ratings[i].checked) {
                    var value = ratings[i].value.split(',');
                    filledRatings.push({ "rating": value[0], "ratingQuestionId": value[1] });
                }

            }
        }

        ratingCount++;
        console.log(filledRatings);

    }

    while (textAreaFlag) {
        var textId = 'textArea ' + textAreaCount;
        var taId = 'area span ' + textAreaCount;

        var textArea = document.getElementById(textId);
        var id = document.getElementById(taId);



        if (textArea == null) {
            textAreaFlag = false;
        }

        else {
            filledTextAreas.push({ "answer": textArea.value, "textAreaId": id.innerHTML })
        }

        textAreaCount++;
        console.log(filledTextAreas);

    }


    while (textBoxFlag) {
        var textId = 'textBox ' + textBoxCount;
        var tbId = 'box span ' + textBoxCount;

        var textBox = document.getElementById(textId);
        var textBoxId = document.getElementById(tbId);



        if (textBox == null) {
            textBoxFlag = false;
        }

        else {
            filledTextBoxes.push({ "answer": textBox.value, "textBoxId": textBoxId.innerHTML })
        }

        textBoxCount++;
        console.log(filledTextBoxes);

    }



    var filledSurvey = {
        "surveyId": surveyId,
        "filledRatings": filledRatings,
        "filledCheckBoxes": filledCheckBoxes,
        "filledRadios": filledRadios,
        "filledTextAreas": filledTextAreas,
        "filledTextBoxes": filledTextBoxes
    }


    try {
        const response = await fetch("https://localhost:7240/api/Survey/FillSurvey", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(filledSurvey),
        });
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error sending:", error);
    }

    alert("Anketiniz başarıyla gönderildi");

}





    


    


