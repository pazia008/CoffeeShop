const url = "https://localhost:5001/api/beanvariety/";
const url2 = "https://localhost:5001/api/coffee/";


const beanTarget = document.querySelector(".bean__container")
const saveMaBeanButton = document.getElementById('saveMaBeans')
const beanTargetForm = document.querySelector(".bean__form")

const beanButton = document.querySelector("#run-button");
beanButton.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
            beanVarieties.forEach(b => beanTarget.innerHTML += `
                <div class ="bean__name">${b.name}</div>
                <div class ="bean__region">${b.region}</div>
                <div class ="bean__notes">${b.notes}</div>
                `)
        })


});

const getAllBeanVarieties = () => fetch(url).then(resp => resp.json());



const saveMaBeans = bean => {
    return fetch(url,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(bean)
        })
};

saveMaBeanButton.addEventListener("click", e => {
    let name = document.getElementById("bean--name").value;
    let region = document.getElementById("bean--region").value;
    let notes = document.getElementById("bean--notes").value;
    if (notes === "") {
        notes = null;
    }

    if (name.length > 3 && name.length < 55 && region.length > 3 && region.length && region.length < 255) {
        const newBeanz = {
            name,
            region,
            notes
        };

        saveMaBeans(newBeanz);
        beanTargetForm.clear();
        e.preventDefault();
    }

    else {
        alert("Please fill out region and name with more than three characters. Notes are up to you!");
    }

})