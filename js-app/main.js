const url = "https://localhost:5001/api/beanvariety/";
const url2 = "https://localhost:5001/api/coffee/";


const beanTarget = document.querySelector(".bean__container")

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





// const listBeans = (beanVarieties) => {
//     var beanPods = "";
//     beanVarieties.forEach(bv => {
//         beanPods += `
//         <div class="beans">
//         <div class ="bean__name">${bv.Name}</div>
//         <div class ="bean__region">${bv.Region}</div>
//         <div class ="bean__notes">${bv.Notes}</div>
//         </div>
//         `
//     });
//     return beanPods
// }

