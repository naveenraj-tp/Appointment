$(document).ready(function () {
    InitializeCalendar();
});


  

function InitializeCalendar() {
    try {



        var calendarEl = document.getElementById('calendar');

            calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                }
            });
            calendar.render();

        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {


            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                }
            });
            calendar.render();

        }


    }

        

    
    catch (e) {
        alert(e);
    }

}

function InitializeCalendar() {
    try {
        $('#calendar').fullCalendar({

            timezone: false,
            header: {
                left: 'prev,next,today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            selectable: true,
            editable: false,
            select: function (event) {
                onShowModal(event, null);
            }
        })




    }
    catch (e) {
        alert(e);
    }

}

function onShowModal(obj, isEventDetail) {

    $("#appointmentInput").modal("show");
}

function onCloseModel() {
    $("#appointmentInput").modal("hide");
}


////function onSubmitForm() {
////    //var requestdata = {
////    //    Id: parent($("#id").val()),
////    //    Title: ($("#title").val()),
////    //    Description: ($("#description").val()),
////    //    StartDate: ($("#appointmentdate").val()),
        
////    //    Duration: ($("#duration").val()),
////    //    DoctorId: ($("#doctorId").val()),
////    //    PattientId: ($("#patientId").val())
////    //}
////}



//$(document).ready(function () {
//    InitializeCalendar();
//});




//function InitializeCalendar() {
//    try {
//        $('#calendar').fullCalendar({

//            timezone: false,
//            header: {
//                left: 'prev,next,today',
//                center: 'title',
//                right: 'month,agendaWeek,agendaDay'
//            },
//            selectable: true,
//            editable: false,
//            select: function (event) {
//                onShowModal(event, null);
//            }
//        })




//    }
//    catch (e) {
//        alert(e);
//    }

//}

//function onShowModal(obj, isEventDetail) {

//    $("#appointmentInput").modal("show");
//}

//function onCloseModel() {
//    $("#appointmentInput").modal("hide");
//}