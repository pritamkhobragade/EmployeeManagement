$(document).ready(function () {
    loadDashboard();

    $("#refreshDashboard").click(function () {
        loadDashboard();
    });

});


function loadDashboard() {
    $("#loadingMessage").text("Loading dashboard...");

    $.ajax({
        url: "/Dashboard/GetDashboardData",
        type: "GET",
        dataType: "json",

        success: function (response) {
            console.log("Dashboard Response:");
            console.log(response);


            // Total Employees
            $("#totalEmployee").text(response.TotalEmployee);

            // Departments
            $("#totalDepartments").text(response.TotalDepartments);

            // Active Employees
            $("#activeEmployees").text(response.activeEmployees);

            // Inactive Employees
            $("#inactiveEmployees").text(response.inactiveEmployees);


            // Total Salary
            var salary = Number(response.totalSalary);

            if (isNaN(salary)) {
                salary = 0;
            }

            $("#totalSalary").text("₹ " +salary.toLocaleString("en-IN"));


            // Active Percentage
            var active = Number(response.activePercentage);
            if (isNaN(active)) {
                active = 0;
            }

            $("#activePercentage").text(active.toFixed(1) + "%");

            $("#activeProgress").css("width", active + "%" )
                .text(active.toFixed(1) + "%" );


            // Inactive Percentage
            var inactive = Number(response.inactivePercentage);

            if (isNaN(inactive)) {
                inactive = 0;
            }


            $("#inactivePercentage").text(inactive.toFixed(1) + "%");

            $("#inactiveProgress").css("width", inactive + "%")
                .text(inactive.toFixed(1) + "%");

            // $("#loadingMessage").text("Dashboard updated successfully.");

        },


        error: function (xhr) {console.log("Dashboard Error:");
            console.log(xhr.responseText);
            $("#loadingMessage").text("Error loading dashboard data.");
        }
    });

}