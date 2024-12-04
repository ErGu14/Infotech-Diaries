const txtTaskDescription = document.getElementById("txt-task-description");
const btnAddTask = document.getElementById("btn-add-task");
const filters = document.querySelectorAll("#filters span");
const btnClearAll= document.getElementById("btn-clear-all");
const taskList = document.getElementById("task-list");

let isEditMode = false; //eğer bu değişken true ise edit mode aktiftir. Değilse new mode aktiftir.
let editedTaskId; // o anda güncelleme işlemi yapılmakta olan Task'in Id sini tutacak.
let filterMode = "all"; // O sırada hangi görevlerin listeleneceği bilgileri tutacak.

let taskListArray =[];

// btnAddTask.addEventListener("click", function(){
//     //btnAddTask butonuna tıklandığı zaman çalışacak kodlar
// });

btnAddTask.addEventListener("click", addTask);
btnClearAll.addEventListener("click",clearAll)

function displayTasks(mode){
    taskList.innerHTML="";
    if(taskListArray.length ==0){
        taskList.innerHTML=`
            <div class="alert alert-warning m-2" role="alert">
                 Henüz Bir Görev Yoktur!
            </div>
        `;
    }else{
        for (const task of taskListArray) {
            if(mode=="all"|| mode==task.status){
                let completed = task.status == "completed" ? "checked" :"";
                // Görevi/Görevleri göster.
                let taskItemLi= `
                        <li class="list-group-item task-item " itemid="${task.id}">
    <div class="d-flex align-items-center gap-2">
        <input onclick="updateStatus(this);" class="form-check-input mt-0 " type="checkbox"  itemid="${task.id}" ${completed}>
        <div class="input-group">
            <input type="text" class="form-control bg-white ${completed}" itemid="${task.id}" value="${task.taskDescription}" disabled>
            <button onclick="editTask(this);" itemid="${task.id}" class="btn btn-warning btn-sm">Düzenle</button>
            <button onclick="deleteTask(this);" itemid="${task.id}" class="btn btn-danger btn-sm">Sil</button>
            
        </div>
        
    </div>
                `;
                taskList.insertAdjacentHTML("afterbegin",taskItemLi);

            }
        }
    }


}

function addTask(e){
    e.preventDefault(); //formun default olan özelliğini(sunucuya gidip gelip, yeniden render etme) kapanır
    let value = txtTaskDescription.value.trim();
    if(value != ""){
        let id = parseInt(Math.random()*1000000);
        taskListArray.push({
            "id":id,
            "taskDescription":value,
            "status": "pending"

        });
        setTask();
        displayTasks(filterMode);
    }else{
        alert("Açıklama Boş Bırakılamaz!");
    }
    txtTaskDescription.value = "";
    txtTaskDescription.focus();
}

function editTask(clickedButton){
    editedTaskId = clickedButton.getAttribute("itemid");
    let editedTask = clickedButton.previousElementSibling;

    if(!isEditMode){
        editedTask.removeAttribute("disabled");
        clickedButton.innerText = "Kaydet";
        clickedButton.classList.remove("btn-warning");
        clickedButton.classList.add("btn-success");
        editedTask.focus();
        isEditMode = true;

    }else{
        let editedTaskDesc = editedTask.value.trim();
        if(editedTaskDesc == ""){
            alert("Açıklamayı Boş Bırakmayınız")
        }else{

        for(const task of taskListArray){
            if(editedTaskId == task.id){
                task.taskDescription = editedTaskDesc;
                break;
            }
        }
    }



        editedTask.setAttribute("disabled","disabled");
        clickedButton.innerText = "Düzenle";
        clickedButton.classList.add("btn-warning");
        clickedButton.classList.remove("btn-success");
        isEditMode = false;
        setTask();
        displayTasks(filterMode);
        
    }
    

}

function updateStatus(clickedCheckBox){
    const updatedTaskId= clickedCheckBox.getAttribute("itemid");
    const newStatus = clickedCheckBox.checked ? "completed" : "pending";
    for(const task of taskListArray){
        if(task.id == updatedTaskId){
            task.status = newStatus;
            break;
        }
    }
    setTask();
    displayTasks(filterMode);
}

function deleteTask(clickedButton){
    const deletedTaskId = clickedButton.getAttribute("itemid");
    let deletedTaskIndex;
    for(let i = 0;i<taskListArray.length;i++){
        if(deletedTaskId == taskListArray[i].id){
            deletedTaskIndex = i;
            break;
        }
    }
    const answer = confirm(`${taskListArray[deletedTaskIndex].txtTaskDescription} Görevi Silinecektir`);
    if(answer){
        taskListArray.splice(deletedTaskIndex,1);
        setTask();
        displayTasks(filterMode);
    }
    taskListArray.splice(deletedTaskIndex,1);
    displayTasks(filterMode);
}
function clearAll(){
    const answer = confirm("Tüm Görevler Silinecektir!");
    if(answer){
        taskListArray = [];
        setTask();
        displayTasks(filterMode);
    }

}

function assignEventsToSpans(){
    for(const span of filters){
        span.addEventListener("click",function(){
            const activeSpan = document.querySelector("#filters span.active");
            activeSpan.classList.remove("active");
            span.classList.add("active");
            filterMode=span.id;
            displayTasks(filterMode);
        });
    }
}

function setTask(){
    localStorage.setItem("Tasks",JSON.stringify(taskListArray));

}

function getTask(){
    taskListArray = JSON.parse(localStorage.getItem("Tasks"));
    if(taskListArray == null){
        taskListArray = [];
    }
}

getTask();
assignEventsToSpans();
displayTasks(filterMode);
