function testing() {
	$(document).ready(function () {

		if ($("input[type='checkbox'][name='mehndiopen']").is(':checked')) {
			$('#1').show();
			
			
		
			
		}
		else  {
			$('#1').hide();

		
			

		}

	});
	}
	
function Barat()
{
	$(document).ready(function () {

		if ($("input[type='checkbox'][name='baratopen']").is(':checked')) {
			$('#2').show();
			
		}
		else {
			$('#2').hide();
		
		}
	});
}

function Walima() {
	$(document).ready(function () {

		if ($("input[type='checkbox'][name='walimaopen']").is(':checked')) {
			$('#3').show();
			
		}
		else {
			$('#3').hide();
		
		}
	});
}

function Nikah() {
	$(document).ready(function () {

		if ($("input[type='checkbox'][name='nikaahopen']").is(':checked')) {
			$('#4').show();

		}
		else {
			$('#4').hide();

		}
	});
}

function Party() {
	$(document).ready(function () {

		if ($("input[type='checkbox'][name='partyopen']").is(':checked')) {
			$('#5').show();

		}
		else {
			$('#5').hide();

		}
	});
}

function staticfunc() {
	$(document).ready(function () {

		if ($("input[name=static]").is(':checked')) {
			$('#11').show();




		}
		else {
			$('#11').hide();




		}

	});
}

