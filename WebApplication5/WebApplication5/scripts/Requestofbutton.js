function userrequest() {
	$('.requestbtn').click(function () {
		
		$(this).addClass('btn-success');
		$(this).addClass('disabled');
		$(this).text('Request send');
			
		

	})
}