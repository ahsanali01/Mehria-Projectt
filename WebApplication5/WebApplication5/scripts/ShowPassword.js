$(document).ready(function () { 
	$("#btnShowpasswrd").mousedown(function () {

		$("#Password").attr("type", "text");
	});
	$("#btnShowpasswrd").on("mouseleave", function () {
		$("#Password").attr("type", "password");
	});
});